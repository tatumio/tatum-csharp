using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public partial class VeChainClient : IVeChainClient
    {
        async Task<BigInteger> IVeChainClient.GetGasPriceInWei()
        {
            var gasPrice = await ethereumGasApi.GasPrice().ConfigureAwait(false);

            return Web3.Convert.ToWei(gasPrice.Fast, Nethereum.Util.UnitConversion.EthUnit.Gwei);
        }

        async Task<string> IVeChainClient.PrepareStoreDataTransaction(CreateRecord body, bool testnet, string provider)
        {
            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account, url: tatumWeb3DriverUrl);

            var addressTo = body.To ?? account.Address;
            var addressNonce = body.Nonce > 0 ? body.Nonce : (uint)(await (this as IEthereumClient).GetTransactionsCount(addressTo).ConfigureAwait(false));
            var customFee = body.EthFee ??
                new Fee
                {
                    GasLimit = body.Data.Length * 68 + 21000,
                    GasPrice = await (this as IVeChainClient).GetGasPriceInWei().ConfigureAwait(false)
                };

            var transactionInput = new TransactionInput
            (
                data: body.Data,
                addressTo: addressTo,
                addressFrom: account.Address,
                gas: new HexBigInteger(new BigInteger(customFee.GasLimit)),
                gasPrice: new HexBigInteger(customFee.GasPrice),
                value: new HexBigInteger(new BigInteger(0))
            );

            var transactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
                .ConfigureAwait(false);

            return $"0x{transactionHash}";
        }

        async Task<Model.Responses.TransactionHash> IVeChainClient.SendStoreDataTransaction(CreateRecord body, bool testnet, string provider)
        {
            var transaction = await (this as IVeChainClient).PrepareStoreDataTransaction(body, true).ConfigureAwait(false);
            var broadcastRequest = new BroadcastRequest
            {
                TxData = transaction
            };

            return await (this as IVeChainClient).Broadcast(broadcastRequest).ConfigureAwait(false);
        }
    }
}
