using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Requests.Ethereum;
using static Nethereum.Util.UnitConversion;

namespace Tatum.Clients
{
    public partial class EthereumClient : IEthereumClient
    {
        async Task<BigInteger> IEthereumClient.GetGasPriceInWei()
        {
            var gasPrice = await ethereumGasApi.GasPrice().ConfigureAwait(false);

            return Web3.Convert.ToWei(gasPrice.Fast, EthUnit.Gwei);
        }

        async Task<string> IEthereumClient.PrepareStoreDataTransaction(CreateRecord body, bool testnet, string provider)
        {
            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Account(body.FromPrivateKey);
            var web3 = new Web3(account, url: tatumWeb3DriverUrl);

            var addressTo = body.To ?? account.Address;
            var addressNonce = body.Nonce > 0 ? body.Nonce : (uint)(await (this as IEthereumClient).GetTransactionsCount(addressTo).ConfigureAwait(false));
            var customFee = body.Fee ??
                new Fee
                {
                    GasLimit = body.Data.Length * 68 + 21000,
                    GasPrice = await (this as IEthereumClient).GetGasPriceInWei().ConfigureAwait(false)
                };

            var transactionInput = new TransactionInput
            (
                data: body.Data,
                addressTo: addressTo,
                addressFrom: account.Address,
                gas: new HexBigInteger(new BigInteger(customFee.GasLimit)),
                gasPrice: new HexBigInteger(customFee.GasPrice),
                value: new HexBigInteger(0)
            );
            transactionInput.Nonce = new HexBigInteger(addressNonce);

            var transactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
                .ConfigureAwait(false);

            return $"0x{transactionHash}";
        }

        async Task<Model.Responses.TransactionHash> IEthereumClient.SendStoreDataTransaction(CreateRecord body, bool testnet, string provider)
        {
            var transaction = await (this as IEthereumClient).PrepareStoreDataTransaction(body, true).ConfigureAwait(false);
            var broadcastRequest = new BroadcastRequest
            {
                TxData = transaction
            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }

        async Task<string> IEthereumClient.PrepareEthereumOrErc20SignedTransaction(TransferEthereumErc20 body, bool testnet, string provider)
        {
            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Account(body.FromPrivateKey);
            var web3 = new Web3(account, url: tatumWeb3DriverUrl);

            BigInteger gasPrice = await DetermineGasPrice(body.Fee).ConfigureAwait(false);
            TransactionInput transactionInput = await BuildEthereumOrErc20TransactionInput(web3, body, gasPrice, account.Address).ConfigureAwait(false);

            var transactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
                .ConfigureAwait(false);

            return $"0x{transactionHash}";
        }

        async Task<Model.Responses.TransactionHash> IEthereumClient.SendEthereumOrErc20SignedTransaction(TransferEthereumErc20 body, bool testnet, string provider)
        {
            var transaction = await (this as IEthereumClient).PrepareEthereumOrErc20SignedTransaction(body, true).ConfigureAwait(false);
            var broadcastRequest = new BroadcastRequest
            {
                TxData = transaction
            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }

        async Task<string> IEthereumClient.PrepareCustomErc20SignedTransaction(TransferCustomErc20 body, bool testnet, string provider)
        {
            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Account(body.FromPrivateKey);
            var web3 = new Web3(account, url: tatumWeb3DriverUrl);

            BigInteger gasPrice = await DetermineGasPrice(body.Fee).ConfigureAwait(false);

            var transferHandler = web3.Eth.GetContractTransactionHandler<TransferFunction>();
            var transferFunction = new TransferFunction
            {
                FromAddress = account.Address,
                GasPrice = gasPrice,
                Nonce = body.Nonce,
                To = body.To,
                TokenAmount = new BigInteger(decimal.Parse(body.Amount))
            };

            TransactionInput transactionInput = await transferHandler.CreateTransactionInputEstimatingGasAsync(body.ContractAddress, transferFunction);

            if (body.Fee == null)
            {
                transactionInput.Gas = await web3.TransactionManager.EstimateGasAsync(transactionInput).ConfigureAwait(false);
            }
            else
            {
                transactionInput.Gas = new HexBigInteger(new BigInteger(body.Fee.GasLimit));
            }

            var transactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
               .ConfigureAwait(false);

            return $"0x{transactionHash}";
        }

        async Task<Model.Responses.TransactionHash> IEthereumClient.SendCustomErc20SignedTransaction(TransferCustomErc20 body, bool testnet, string provider)
        {
            var transaction = await (this as IEthereumClient).PrepareCustomErc20SignedTransaction(body, true).ConfigureAwait(false);
            var broadcastRequest = new BroadcastRequest
            {
                TxData = transaction
            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }

        async Task<string> IEthereumClient.PrepareDeployErc20SignedTransaction(DeployEthereumErc20 body, bool testnet, string provider)
        {
            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Account(body.FromPrivateKey);
            var web3 = new Web3(account, url: tatumWeb3DriverUrl);

            var deploymentHandler = web3.Eth.GetContractDeploymentHandler<StandardTokenDeployment>();

            var request = web3.Eth.Transactions.GetTransactionCount;

            var count = await request.SendRequestAsync(account.Address).ConfigureAwait(false);

            var deploymentMessage = new StandardTokenDeployment
            {
                Nonce = count.Value,
                TotalSupply = BigInteger.Parse(body.Supply)
            };



            deploymentMessage.GasPrice = await DetermineGasPrice(body.Fee);

            if (body.Fee == null)
            {
                deploymentMessage.Gas = await web3.Eth.DeployContract.EstimateGasAsync(
                    abi: StandardTokenDeployment.ABI,
                    contractByteCode: deploymentMessage.ByteCode,
                    from: account.Address)
                    .ConfigureAwait(false);
            }
            else
            {
                deploymentMessage.Gas = new HexBigInteger(new BigInteger(body.Fee.GasLimit));
            }

            var transactionHash = await deploymentHandler.SignTransactionAsync(deploymentMessage).ConfigureAwait(false);

            return $"0x{transactionHash}";
        }

        async Task<Model.Responses.TransactionHash> IEthereumClient.SendDeployErc20SignedTransaction(DeployEthereumErc20 body, bool testnet, string provider)
        {
            var transaction = await (this as IEthereumClient).PrepareDeployErc20SignedTransaction(body, true).ConfigureAwait(false);
            var broadcastRequest = new BroadcastRequest
            {
                TxData = transaction
            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }

        private async Task<TransactionInput> BuildEthereumOrErc20TransactionInput(Web3 web3, TransferEthereumErc20 body, BigInteger gasPrice, string addressFrom)
        {
            TransactionInput transactionInput = new TransactionInput();
            transactionInput.From = addressFrom;
            transactionInput.GasPrice = new HexBigInteger(gasPrice);
            transactionInput.Nonce = new HexBigInteger(body.Nonce);

            if (body.Currency == Model.Currency.ETH)
            {
                transactionInput.Data = body.Data;
                transactionInput.To = body.To;
                transactionInput.Value = new HexBigInteger(Web3.Convert.ToWei(body.Amount, EthUnit.Ether));
            }
            else
            {
                var transferHandler = web3.Eth.GetContractTransactionHandler<TransferFunction>();
                var transferFunction = new TransferFunction
                {
                    FromAddress = addressFrom,
                    GasPrice = gasPrice,
                    Nonce = body.Nonce,
                    To = body.To,
                    TokenAmount = new BigInteger(decimal.Parse(body.Amount))
                };

                transactionInput = await transferHandler.CreateTransactionInputEstimatingGasAsync(Constants.ContractAddresses[body.Currency], transferFunction);
            }

            if (body.Fee == null)
            {
                transactionInput.Gas = await web3.TransactionManager.EstimateGasAsync(transactionInput).ConfigureAwait(false);
            }
            else
            {
                transactionInput.Gas = new HexBigInteger(new BigInteger(body.Fee.GasLimit));
            }

            return transactionInput;
        }

        private async Task<BigInteger> DetermineGasPrice(Fee fee)
        {
            if (fee == null)
            {
                return await (this as IEthereumClient).GetGasPriceInWei().ConfigureAwait(false);
            }
            else
            {
                return fee.GasPrice;
            }
        }
    }
}
