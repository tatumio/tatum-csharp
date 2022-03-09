using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Nethereum.StandardTokenEIP20;
using System.Security;
using NBitcoin;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using Tatum.Model.Responses;
using Tatum.Model.Requests;
using Tatum.Contracts;
using Tatum.Blockchain;
using NBitcoin.RPC;
using Rest;
using RestSharp;

/// <summary>
/// Summary description for BscClient
/// </summary>
/// 
namespace Tatum
{
    public class BscClient:IBscClient
    {

        private readonly string _privateKey;
        private readonly string _serverUrl;
        public BscClient(string privateKey, string serverUrl)
        {
            _privateKey = privateKey;
            _serverUrl = serverUrl;
        }



        Wallets IBscClient.CreateWallet(string mnemonic, bool testnet)
        {
            var wallet = new Nethereum.HdWallet.Wallet(mnemonic, "", testnet ? Constants.TestKeyDerivationPath : Constants.VetKeyDerivationPath);
            var xpub = wallet.GetMasterExtPubKey();

            return new Wallets
            {
                XPub = xpub.ToString(Network.Main),
                Mnemonic = mnemonic
            };
        }

        string IBscClient.GeneratePrivateKey(string mnemonic, int index, bool testnet)
        {
            var wallet = new Nethereum.HdWallet.Wallet(mnemonic, "", testnet ? Constants.TestKeyDerivationPath : Constants.VetKeyDerivationPath);

            return wallet.GetAccount(index).PrivateKey;
        }

        string IBscClient.GenerateAddress(string xPub, int index, bool testnet)
        {
            var extPubKey = ExtPubKey.Parse(xPub, Network.Main);

            var publicWallet = new Nethereum.HdWallet.PublicWallet(extPubKey);
            return publicWallet.GetAddress(index).ToLower();
        }


        public async Task<Bsc> Web3HttpDriver(string xapikey)
        {
            string parameters = "{\"jsonrpc\":\"2.0\",\"method\":\"web3_clientVersion\",\"params\":[],\"id\":2}";

            var stringResult = await PostSecureRequest($"web3/{xapikey}", parameters);

            var result = JsonConvert.DeserializeObject<Bsc>(stringResult);

            return result;
        }


        public async Task<Bsc> GetCurrentBlockNumber()
        {

            var stringResult = await GetSecureRequest($"block/current");

            var result = JsonConvert.DeserializeObject<Bsc>(stringResult);

            return result;
        }

        public async Task<Bsc> GetBscBlockByHash(string hash)
        {

            var stringResult = await GetSecureRequest($"block/{hash}");

            var result = JsonConvert.DeserializeObject<Bsc>(stringResult);

            return result;
        }

        public async Task<Bsc> GetBscAccountBalance(string address)
        {

            var stringResult = await GetSecureRequest($"balance/{address}");

            var result = JsonConvert.DeserializeObject<Bsc>(stringResult);

            return result;
        }

        public async Task<Bsc> GetBscTransaction(string hash)
        {

            var stringResult = await GetSecureRequest($"transaction/{hash}");

            var result = JsonConvert.DeserializeObject<Bsc>(stringResult);

            return result;
        }

        public async Task<Bsc> GetCountOutgoingBscTransaction(string address)
        {

            var stringResult = await GetSecureRequest($"transaction/count/{address}");

            var result = JsonConvert.DeserializeObject<Bsc>(stringResult);

            return result;
        }






        public async Task<Bsc> EstimateBscTransactionFees(string from, string to, string amount, string data)
        {
            string parameters = "{\"from\":" + "\"" + from + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"data\":" + "\"" + data + "" + "\"}";

            var stringResult = await PostSecureRequest($"gas", parameters);

            var result = JsonConvert.DeserializeObject<Bsc>(stringResult);

            return result;
        }


     



        public async Task<int> GetTransactionsCount(string address)
        {
            var stringResult = await GetSecureRequest($"transaction/count/{address}");

            var result = JsonConvert.DeserializeObject<int>(stringResult);

            return result;
        }


        public async Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request)
        {
            string parameters = "{\"txData\":" + "\"" + request.TxData + "" + "\",\"signatureId\":" + "\"" + request.SignatureId + "" + "\"}";


            var stringResult = await PostSecureRequest($"broadcast", parameters);

            var result = JsonConvert.DeserializeObject<TransactionHash>(stringResult);

            return result;
        }





        Task<BigInteger> IBscClient.GetGasPriceInWei()
        {
            throw new NotImplementedException();

        }

        async Task<string> IBscClient.PrepareStoreDataTransaction(CreateRecord body, bool testnet, string provider)
        {
            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);

            var addressTo = body.To ?? account.Address;
            var addressNonce = body.Nonce > 0 ? body.Nonce : (uint)(await (this as IEthereumClient).GetTransactionsCount(addressTo).ConfigureAwait(false));
            var customFee = body.EthFee ??
                new EthFee
                {
                    GasLimit = body.Data.Length * 68 + 21000,

                    GasPrice = 420000
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

        async Task<Model.Responses.TransactionHash> IBscClient.SendBscStoreDataTransaction(CreateRecord body, bool testnet, string provider)
        {
            var transaction = await (this as IBscClient).PrepareStoreDataTransaction(body, true).ConfigureAwait(false);
            var broadcastRequest = new BroadcastRequest
            {
                TxData = transaction
            };

            return await (this as IBscClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }




        async Task<Model.Responses.TransactionHash> IBscClient.sendBscOrBep20Transaction(TransferErc20 body, bool testnet, string provider)
        {



            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);

            var transactionInput = new TransactionInput();

            var fromprivateKey = body.FromPrivatekey;
            var addressTo = body.To ?? account.Address;
            var amount = body.amount;
            var currency = body.currency;
            var gaslimit = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasLimit, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var gasprice = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasPrice, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var data = body.Data;
            var nonce = body.Nonce;
            var signatureid = body.signatureId;





            var tx = new TransactionReceipt();



            if (currency == Model.Currency.ETH)
            {

                tx = await web3.Eth.GetEtherTransferService().TransferEtherAndWaitForReceiptAsync(addressTo, decimal.Parse(amount), gasprice, gaslimit, new BigInteger(1.11m));

            }
            else
            {


                var contract = web3.Eth.GetContract("[TRANSFER_METHOD_ABI]", "CONTRACT_ADDRESSES[currency as string]");
                var transferFunction = contract.GetFunction("transfer");
                var gas = await transferFunction.EstimateGasAsync(account, null, null, body.To, body.amount);
                tx = await transferFunction.SendTransactionAndWaitForReceiptAsync(transactionInput);



            }


            var transactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
                .ConfigureAwait(false);




            var broadcastRequest = new BroadcastRequest
            {
                TxData = transactionHash
            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }


        async Task<Model.Responses.TransactionHash> IBscClient.sendCustomBep20Transaction(TransferErc20 body, bool testnet, string provider)
        {



            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);

            var transactionInput = new TransactionInput();

            var fromprivateKey = body.FromPrivatekey;
            var addressTo = body.To ?? account.Address;
            var amount = body.amount;
            var fee = body.EthFee;
            var contractaddress = body.contractAddress;
            var nonce = body.Nonce;
            var signatureid = body.signatureId;





            var tx = new TransactionReceipt();





            var contract = web3.Eth.GetContract("[TRANSFER_METHOD_ABI]", contractaddress);
            var transferFunction = contract.GetFunction("transfer");
            var gas = await transferFunction.EstimateGasAsync(account, null, null, addressTo, amount);

            tx = await transferFunction.SendTransactionAndWaitForReceiptAsync(transactionInput);






            var transactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
                .ConfigureAwait(false);




            var broadcastRequest = new BroadcastRequest
            {
                TxData = transactionHash
            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }


        async Task<Model.Responses.TransactionHash> IBscClient.sendDeployBep20Transaction(DeployErc20 body, bool testnet, string provider)
        {



            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);



            var FromPrivatekey = body.FromPrivatekey;
            var address = body.address;
            var name = body.name;
            var symbol = body.symbol;
            var supply = body.supply;
            var digits = body.digits;
            var gaslimit = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasLimit, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var fee = body.EthFee;
            var nonce = body.Nonce;
            var totalCap = body.totalCap;
            var signatureid = body.signatureId;





            var tx = new TransactionReceipt();



            var abi = new token_abi();

            var bytecode = new token_bytecode();




            tx = await web3.Eth.DeployContract.SendRequestAndWaitForReceiptAsync(abi._tokenabi, bytecode._tokenbytecode,
                                                                                    address, gaslimit,
                                                                                    null, address, name, symbol, supply, digits, totalCap,
                                                                                    signatureid);






            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash
            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }


        async Task<Model.Responses.TransactionHash> IBscClient.sendBscSmartContractMethodInvocationTransaction(SmartContractMethodInvocation body, bool testnet, string provider)
        {



            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);



            var FromPrivatekey = body.FromPrivatekey;
            var paramss = body.paramss;
            var methodname = body.methodName;
            var methodabi = body.methodABI;
            var amount = body.amount;
            var contractaddress = body.contractaddress;
            var gaslimit = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasLimit, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var fee = body.EthFee;
            var nonce = body.Nonce;
            var signatureid = body.signatureId;


            var tx = new TransactionReceipt();

            var contract = web3.Eth.GetContract(methodabi, contractaddress);
            var contractFunction = contract.GetFunction(methodname);


            tx = await contractFunction.SendTransactionAndWaitForReceiptAsync(account.Address, null, body);


            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash
            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }


        async Task<Model.Responses.TransactionHash> IBscClient.sendMintBep721Transaction(EthMintErc721 body, bool testnet, string provider)
        {



            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);



            var FromPrivatekey = body.FromPrivatekey;
            var to = body.to;
            var tokenid = body.tokenId;
            var contractaddress = body.contractaddress;
            var url = body.url;
            var fee = body.EthFee;
            var nonce = body.Nonce;
            var signatureid = body.signatureId;



            var tx = new TransactionReceipt();

            var abi = new erc721_token_abi();

            var contract = web3.Eth.GetContract(abi._erc721tokenabi, contractaddress);
            var mintFunction = contract.GetFunction("mintWithTokenURI");


            tx = await mintFunction.SendTransactionAndWaitForReceiptAsync(account.Address, null, body);


            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash
            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }


        async Task<Model.Responses.TransactionHash> IBscClient.sendMintBepCashback721Transaction(EthMintErc721 body, bool testnet, string provider)
        {



            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);



            var FromPrivatekey = body.FromPrivatekey;
            var to = body.to;
            var tokenid = body.tokenId;
            var contractaddress = body.contractaddress;
            var authoraddresses = body.authorAddresses;
            var cashbackvalues = body.cashbackValues;
            var url = body.url;
            var fee = body.EthFee;
            var nonce = body.Nonce;
            var signatureid = body.signatureId;



            var tx = new TransactionReceipt();

            var abi = new erc721_token_abi();

            var contract = web3.Eth.GetContract(abi._erc721tokenabi, contractaddress);
            var mintFunction = contract.GetFunction("mintWithCashback");


            tx = await mintFunction.SendTransactionAndWaitForReceiptAsync(account.Address, null, body);


            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash
            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }


        async Task<Model.Responses.TransactionHash> IBscClient.sendMintBep721ProvenanceTransaction(EthMintErc721 body, bool testnet, string provider)
        {



            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);



            var FromPrivatekey = body.FromPrivatekey;
            var to = body.to;
            var tokenid = body.tokenId;
            var contractaddress = body.contractaddress;
            var authoraddresses = body.authorAddresses;
            var cashbackvalues = body.cashbackValues;
            var url = body.url;
            var fee = body.EthFee;
            var nonce = body.Nonce;
            var signatureid = body.signatureId;



            var tx = new TransactionReceipt();

            var abi = new erc721_token_abi();

            var contract = web3.Eth.GetContract(abi._erc721tokenabi, contractaddress);
            var mintFunction = contract.GetFunction("mintMultiple");


            tx = await mintFunction.SendTransactionAndWaitForReceiptAsync(account.Address, null, body);


            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash
            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }


        async Task<Model.Responses.TransactionHash> IBscClient.sendMintMultipleCashbackBep721Transaction(EthMintMultipleErc721 body, bool testnet, string provider)
        {



            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);



            var FromPrivatekey = body.FromPrivatekey;
            var to = body.to;
            var tokenid = body.tokenId;
            var contractaddress = body.contractaddress;
            var authoraddresses = body.authorAddresses;
            var cashbackvalues = body.cashbackValues;
            var url = body.url;
            var fee = body.EthFee;
            var nonce = body.Nonce;
            var signatureid = body.signatureId;



            var tx = new TransactionReceipt();

            var abi = new erc721_token_abi();

            var contract = web3.Eth.GetContract(abi._erc721tokenabi, contractaddress);
            var mintFunction = contract.GetFunction("mintMultipleCashback");


            tx = await mintFunction.SendTransactionAndWaitForReceiptAsync(account.Address, null, body);


            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash
            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }


        async Task<Model.Responses.TransactionHash> IBscClient.sendMintMultipleBep721ProvenanceTransaction(EthMintMultipleErc721 body, bool testnet, string provider)
        {



            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);



            var FromPrivatekey = body.FromPrivatekey;
            var to = body.to;
            var tokenid = body.tokenId;
            var contractaddress = body.contractaddress;
            var authoraddresses = body.authorAddresses;
            var cashbackvalues = body.cashbackValues;
            var url = body.url;
            var fee = body.EthFee;
            var nonce = body.Nonce;
            var signatureid = body.signatureId;



            var tx = new TransactionReceipt();

            var abi = new erc721_provenance_abi();

            var contract = web3.Eth.GetContract(abi._erc721provenanceabi, contractaddress);
            var mintFunction = contract.GetFunction("mintMultiple");


            tx = await mintFunction.SendTransactionAndWaitForReceiptAsync(account.Address, null, body);


            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash
            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }



        async Task<Model.Responses.TransactionHash> IBscClient.sendMintMultipleBep721Transaction(EthMintMultipleErc721 body, bool testnet, string provider)
        {



            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);




            var tx = new TransactionReceipt();

            var abi = new erc721_token_abi();

            var contract = web3.Eth.GetContract(abi._erc721tokenabi, body.contractaddress);
            var mintFunction = contract.GetFunction("mintMultiple");



            var transactionInput = new TransactionInput
          (
              data: await mintFunction.SendTransactionAsync(account.Address, body.to, body.tokenId, body.url),
              addressTo: body.contractaddress,
              addressFrom: "0",
              gas: new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasLimit, Nethereum.Util.UnitConversion.EthUnit.Gwei)),
              gasPrice: new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasPrice, Nethereum.Util.UnitConversion.EthUnit.Gwei)),
              value: new HexBigInteger(new BigInteger(0))
          );

            if (body.signatureId != null)
            {
                JsonConvert.SerializeObject(transactionInput);
            }

            tx.TransactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
                .ConfigureAwait(false);

            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash

            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }

        async Task<Model.Responses.TransactionHash> IBscClient.sendBurnBep721Transaction(EthBurnErc721 body, bool testnet, string provider)
        {



            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);

            var tx = new TransactionReceipt();

            var abi = new erc721_token_abi();

            var contract = web3.Eth.GetContract(abi._erc721tokenabi, body.contractaddress);
            var burnFunction = contract.GetFunction("burn");



            var transactionInput = new TransactionInput
          (
              data: await burnFunction.SendTransactionAsync(account.Address, body.tokenId),
              addressTo: body.contractaddress,
              addressFrom: "0",
              gas: new HexBigInteger(new BigInteger(value: body.EthFee.GasLimit)),
              gasPrice: new HexBigInteger(value: body.EthFee.GasPrice),
              value: new HexBigInteger(new BigInteger(0))
          );

            if (body.signatureId != null)
            {
                JsonConvert.SerializeObject(transactionInput);
            }



            tx.TransactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
                .ConfigureAwait(false);

            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash



            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);

        }


        async Task<Model.Responses.TransactionHash> IBscClient.sendUpdateCashbackForAuthorBep721Transaction(UpdateCashbackErc721 body, bool testnet, string provider)
        {

            var FromPrivatekey = body.FromPrivatekey;
            var cashbackvalue = body.cashbackValues;
            var tokenId = body.tokenId;
            var contractaddress = body.contractaddress;
            var gaslimit = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasLimit, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var gasprice = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasPrice, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var fee = body.EthFee;
            var nonce = body.Nonce;
            var signatureid = body.signatureId;

            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);

            var tx = new TransactionReceipt();

            var abi = new erc721_token_abi();

            var contract = web3.Eth.GetContract(abi._erc721tokenabi, contractaddress);
            var burnFunction = contract.GetFunction("updateCashbackForAuthor");



            var transactionInput = new TransactionInput
          (
              data: await burnFunction.SendTransactionAsync(account.Address, tokenId, Web3.Convert.ToWei(cashbackvalue, Nethereum.Util.UnitConversion.EthUnit.Wei)),
              addressTo: contractaddress,
              addressFrom: "0",
              gas: gaslimit,
              gasPrice: gasprice,
              value: new HexBigInteger(new BigInteger(0))
          );

            if (body.signatureId != null)
            {
                JsonConvert.SerializeObject(transactionInput);
            }



            tx.TransactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
                .ConfigureAwait(false);

            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash



            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);

        }


        async Task<Model.Responses.TransactionHash> IBscClient.sendBep721Transaction(EthTransferErc721 body, bool testnet, string provider)
        {

            var FromPrivatekey = body.FromPrivatekey;
            var to = body.to;
            var tokenId = body.tokenId;
            var contractaddress = body.contractaddress;
            var gaslimit = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasLimit, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var gasprice = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasPrice, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var fee = body.EthFee;
            var nonce = body.Nonce;
            var signatureId = body.signatureId;
            var value = body.value;
            var provenancedata = body.provenance;
            bool provenance = body.provenance;
            var tokenprice = body.tokenPrice;

            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);

            var tx = new TransactionReceipt();

            var abi = new erc721_token_abi();
            var provenanceabi = new erc721_token_abi();

            var contract = web3.Eth.GetContract(provenanceabi._erc721tokenabi ?? abi._erc721tokenabi, contractaddress);
            var tokendata = "";
            tokendata = await contract.GetFunction("safeTransfer").SendTransactionAsync(account.Address, to, tokenId);

            if (provenance == true)
            {
                tokendata = await contract.GetFunction("safeTransfer").SendTransactionAsync(account.Address, to, tokenId, provenancedata + "\'\'\'###\'\'\'" + Web3.Convert.ToWei(tokenprice, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            }


            var transactionInput = new TransactionInput
          (
              data: tokendata,
              addressTo: contractaddress,
              addressFrom: "0",
              gas: gaslimit,
              gasPrice: gasprice,
              value: new HexBigInteger(new BigInteger(0))
          );

            if (signatureId != null)
            {
                JsonConvert.SerializeObject(transactionInput);
            }



            tx.TransactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
                .ConfigureAwait(false);

            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash



            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);

        }


        async Task<Model.Responses.TransactionHash> IBscClient.sendDeployBep721Transaction(EthDeployErc721 body, bool testnet, string provider)
        {

            var FromPrivatekey = body.FromPrivatekey;
            var name = body.name;
            var symbol = body.symbol;
            var gaslimit = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasLimit, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var gasprice = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasPrice, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var fee = body.EthFee;
            var nonce = body.Nonce;
            var signatureId = body.signatureId;
            bool provenance = body.provenance;


            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);

            var tx = new TransactionReceipt();

            var abi = new erc721_token_abi();


            var contract = web3.Eth.GetContract(abi._erc721tokenabi, null);

            var data = "";


            if (provenance == true)
            {
                var provenancebytecode = new erc721_provenance_bytecode();
                data = provenancebytecode._erc721provenancebytecode;
            }
            else
            {
                var erc721bytecode = new erc721_token_bytecode();
                data = erc721bytecode._erc721bytecode;
            }


            var transactionInput = new TransactionInput
          (
              data: data,
              addressTo: null,
              addressFrom: "0",
              gas: gaslimit,
              gasPrice: gasprice,
              value: new HexBigInteger(new BigInteger(0))
          );

            if (signatureId != null)
            {
                JsonConvert.SerializeObject(transactionInput);
            }



            tx.TransactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
                .ConfigureAwait(false);

            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash



            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);

        }


        async Task<Model.Responses.TransactionHash> IBscClient.sendBscMultiTokenTransaction(TransferMultiToken body, bool testnet, string provider)
        {

            var FromPrivatekey = body.FromPrivatekey;
            var to = body.to;
            var tokenid = body.tokenId;
            var contractaddress = body.contractaddress;
            var gaslimit = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasLimit, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var gasprice = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasPrice, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var fee = body.EthFee;
            var nonce = body.Nonce;
            var signatureId = body.signatureId;
            var amount = body.amount;
            var data = body.data;


            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);

            var tx = new TransactionReceipt();

            var abi = new erc1155token_abi();


            var contract = web3.Eth.GetContract(abi._tokenabi, contractaddress);
            var transferFunction = contract.GetFunction("safeTransfer");



            var transactionInput = new TransactionInput
          (
              data: await transferFunction.SendTransactionAsync(to, tokenid, new HexBigInteger(amount), data ?? "0X0"),
              addressTo: contractaddress,
              addressFrom: "0",
              gas: gaslimit,
              gasPrice: gasprice,
              value: new HexBigInteger(new BigInteger(0))
          );

            if (signatureId != null)
            {
                JsonConvert.SerializeObject(transactionInput);
            }



            tx.TransactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
                .ConfigureAwait(false);

            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash



            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);

        }


        async Task<Model.Responses.TransactionHash> IBscClient.sendBscMultiTokenBatchTransaction(TransferMultiTokenBatch body, bool testnet, string provider)
        {

            var FromPrivatekey = body.FromPrivatekey;
            var to = body.to;
            var tokenid = body.tokenId;
            var contractaddress = body.contractaddress;
            var gaslimit = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasLimit, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var gasprice = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasPrice, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var fee = body.EthFee;
            var nonce = body.Nonce;
            var signatureId = body.signatureId;
            var amounts = body.amounts;
            var data = body.data;


            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);

            var tx = new TransactionReceipt();

            var abi = new erc1155token_abi();

            var amt = new HexBigInteger(amounts.ToString());

            var contract = web3.Eth.GetContract(abi._tokenabi, contractaddress);
            var transferFunction = contract.GetFunction("safeBatchTransfer");



            var transactionInput = new TransactionInput
          (
              data: await transferFunction.SendTransactionAsync(to, tokenid, amt, data ?? "0X0"),
              addressTo: contractaddress,
              addressFrom: "0",
              gas: gaslimit,
              gasPrice: gasprice,
              value: new HexBigInteger(new BigInteger(0))
          );

            if (signatureId != null)
            {
                JsonConvert.SerializeObject(transactionInput);
            }



            tx.TransactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
                .ConfigureAwait(false);

            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash



            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);

        }


        async Task<Model.Responses.TransactionHash> IBscClient.sendBscDeployMultiTokenTransaction(EthDeployMultiToken body, bool testnet, string provider)
        {

            var FromPrivatekey = body.FromPrivatekey;
            var uri = body.uri;

            var gaslimit = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasLimit, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var gasprice = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasPrice, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var fee = body.EthFee;
            var nonce = body.Nonce;
            var signatureId = body.signatureId;



            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);

            var tx = new TransactionReceipt();

            var abi = new erc1155token_abi();

            var data = new erc1155token_bytecode();

            var contract = web3.Eth.GetContract(abi._tokenabi, null);
            var deployFunction = contract.GetFunction("safeBatchTransfer");



            var transactionInput = new TransactionInput
          (
              data: data._tokenbytecode,
              addressTo: "0",
              addressFrom: "0",
              gas: gaslimit,
              gasPrice: gasprice,
              value: new HexBigInteger(new BigInteger(0))
          );

            if (signatureId != null)
            {
                JsonConvert.SerializeObject(transactionInput);
            }



            tx.TransactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
                .ConfigureAwait(false);

            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash



            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);

        }

        async Task<Model.Responses.TransactionHash> IBscClient.sendBscMintMultiTokenTransaction(MintMultiToken body, bool testnet, string provider)
        {

            var FromPrivatekey = body.FromPrivatekey;
            var to = body.to;
            var tokenid = body.tokenId;
            var contractaddress = body.contractaddress;
            var gaslimit = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasLimit, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var gasprice = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasPrice, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var fee = body.EthFee;
            var nonce = body.Nonce;
            var data = body.data;
            var amounts = body.amount;
            var signatureId = body.signatureId;



            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);

            var tx = new TransactionReceipt();

            var abi = new erc1155token_abi();

            var amt = new HexBigInteger(amounts);

            var contract = web3.Eth.GetContract(abi._tokenabi, null);
            var mintFunction = contract.GetFunction("mintBatch");



            var transactionInput = new TransactionInput
          (
              data: await mintFunction.SendTransactionAsync(account.Address, to, tokenid, amt, data ?? "0X0"),
              addressTo: contractaddress,
              addressFrom: "0",
              gas: gaslimit,
              gasPrice: gasprice,
              value: new HexBigInteger(new BigInteger(0))
          );

            if (signatureId != null)
            {
                JsonConvert.SerializeObject(transactionInput);
            }



            tx.TransactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
                .ConfigureAwait(false);

            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash



            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);

        }


        async Task<Model.Responses.TransactionHash> IBscClient.sendBscMintMultiTokenBatchTransaction(MintMultiTokenBatch body, bool testnet, string provider)
        {

            var FromPrivatekey = body.FromPrivatekey;
            var to = body.to;
            var tokenid = body.tokenId;
            var contractaddress = body.contractaddress;
            var gaslimit = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasLimit, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var gasprice = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasPrice, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var fee = body.EthFee;
            var nonce = body.Nonce;
            var data = body.data;
            string[][] amounts = body.amounts;
            var chain = body.chain;
            var signatureId = body.signatureId;



            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);

            var tx = new TransactionReceipt();

            var abi = new erc1155token_abi();

            var contract = web3.Eth.GetContract(abi._tokenabi, null);
            var mintFunction = contract.GetFunction("mint");



            var transactionInput = new TransactionInput
          (
              data: await mintFunction.SendTransactionAsync(account.Address, to, tokenid, new HexBigInteger(amounts.ToString()), data ?? "0X0"),
              addressTo: contractaddress,
              addressFrom: "0",
              gas: gaslimit,
              gasPrice: gasprice,
              value: new HexBigInteger(new BigInteger(0))
          );

            if (signatureId != null)
            {
                JsonConvert.SerializeObject(transactionInput);
            }



            tx.TransactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
                .ConfigureAwait(false);

            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash



            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);

        }


        async Task<Model.Responses.TransactionHash> IBscClient.sendBscBurnMultiTokenTransaction(EthBurnMultiToken body, bool testnet, string provider)
        {

            var FromPrivatekey = body.FromPrivatekey;
            var tokenid = body.tokenId;
            var amount = body.amount;
            var contractaddress = body.contractaddress;
            var gaslimit = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasLimit, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var gasprice = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasPrice, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var fee = body.EthFee;
            var nonce = body.Nonce;
            var chain = body.chain;
            var signatureId = body.signatureId;



            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);

            var tx = new TransactionReceipt();

            var abi = new erc1155token_abi();

            var contract = web3.Eth.GetContract(abi._tokenabi, null);
            var mintFunction = contract.GetFunction("mint");



            var transactionInput = new TransactionInput
          (
              data: await mintFunction.SendTransactionAsync(account.Address, tokenid, amount),
              addressTo: contractaddress,
              addressFrom: "0",
              gas: gaslimit,
              gasPrice: gasprice,
              value: new HexBigInteger(new BigInteger(0))
          );

            if (signatureId != null)
            {
                JsonConvert.SerializeObject(transactionInput);
            }



            tx.TransactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
                .ConfigureAwait(false);

            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash



            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);

        }


        async Task<Model.Responses.TransactionHash> IBscClient.sendBscBurnBatchMultiTokenTransaction(EthBurnMultiTokenBatch body, bool testnet, string provider)
        {

            var FromPrivatekey = body.FromPrivatekey;
            var tokenid = body.tokenId;
            var amounts = body.amounts;
            var contractaddress = body.contractaddress;
            var gaslimit = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasLimit, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var gasprice = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasPrice, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var fee = body.EthFee;
            var nonce = body.Nonce;
            var chain = body.chain;
            var signatureId = body.signatureId;



            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);

            var tx = new TransactionReceipt();

            var abi = new erc1155token_abi();

            var contract = web3.Eth.GetContract(abi._tokenabi, null);
            var mintFunction = contract.GetFunction("burnBatch");



            var transactionInput = new TransactionInput
          (
              data: await mintFunction.SendTransactionAsync(account.Address, tokenid, amounts),
              addressTo: contractaddress,
              addressFrom: "0",
              gas: gaslimit,
              gasPrice: gasprice,
              value: new HexBigInteger(new BigInteger(0))
          );

            if (signatureId != null)
            {
                JsonConvert.SerializeObject(transactionInput);
            }



            tx.TransactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
                .ConfigureAwait(false);

            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash



            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);

        }


        async Task<Model.Responses.TransactionHash> IBscClient.sendBscGenerateCustodialWalletSignedTransaction(GenerateCustodialAddress body, bool testnet, string provider)
        {

            var fromprivatekey = body.FromPrivatekey;
            var gaslimit = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasLimit, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var gasprice = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasPrice, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var fee = body.EthFee;
            var nonce = body.Nonce;

            var signatureId = body.signatureId;



            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);

            var tx = new TransactionReceipt();

            var abi = new erc1155token_abi();
            var bytecode = new erc1155token_bytecode();

            var contract = web3.Eth.DeployContract;

            var deployFunction = contract.SendRequestAsync(abi._tokenabi, bytecode._tokenbytecode, account.Address);



            var transactionInput = new TransactionInput
          (
              data: await deployFunction,
              addressTo: "0",
              addressFrom: "0",
              gas: gaslimit,
              gasPrice: gasprice,
              value: new HexBigInteger(new BigInteger(0))
          );

            if (signatureId != null)
            {
                JsonConvert.SerializeObject(transactionInput);
            }



            tx.TransactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
                .ConfigureAwait(false);

            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash



            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);

        }


        async Task<Model.Responses.TransactionHash> IBscClient.sendBscDeployMarketplaceListingSignedTransaction(DeployMarketplaceListing body, bool testnet, string provider)
        {

            var fromprivatekey = body.FromPrivatekey;
            var marketplacefee = body.marketplaceFee;
            var feerecipient = body.feeRecipient;

            var gaslimit = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasLimit, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var gasprice = new HexBigInteger(Web3.Convert.ToWei(body.EthFee.GasPrice, Nethereum.Util.UnitConversion.EthUnit.Gwei));
            var fee = body.EthFee;
            var nonce = body.Nonce;

            var signatureId = body.signatureId;



            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            var account = new Nethereum.Web3.Accounts.Account(body.FromPrivatekey);
            var web3 = new Web3(account);

            var tx = new TransactionReceipt();

            var abi = new erc1155token_abi();
            var bytecode = new erc1155token_bytecode();

            var contract = web3.Eth.DeployContract;

            var deployFunction = contract.SendRequestAsync(abi._tokenabi, bytecode._tokenbytecode, account.Address, marketplacefee, feerecipient);



            var transactionInput = new TransactionInput
          (
              data: await deployFunction,
              addressTo: "0",
              addressFrom: "0",
              gas: gaslimit,
              gasPrice: gasprice,
              value: new HexBigInteger(new BigInteger(0))
          );

            if (signatureId != null)
            {
                JsonConvert.SerializeObject(transactionInput);
            }



            tx.TransactionHash = await web3.TransactionManager.SignTransactionAsync(transactionInput)
                .ConfigureAwait(false);

            var broadcastRequest = new BroadcastRequest
            {
                TxData = tx.TransactionHash



            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);

        }























































































        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = _serverUrl + "/v3/bsc";

            baseUrl = $"{baseUrl}/{path}";


            HttpWebRequest reqc = (HttpWebRequest)WebRequest.Create(baseUrl);

            reqc.Method = "GET";
            reqc.Headers.Add("x-api-key", _privateKey);
            reqc.Credentials = CredentialCache.DefaultCredentials;
            reqc.ContentType = "application/json";




            try
            {
                HttpWebResponse httpResponse = (HttpWebResponse)(await reqc.GetResponseAsync());
                string json;
                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    json = new StreamReader(responseStream).ReadToEnd();
                }

                return json;
            }
            catch (Exception ex)
            {
                throw new SecurityException("Bad credentials", ex);
            }
        }


        private async Task<string> PostSecureRequest(string path, string parameters)
        {

            var baseUrl = _serverUrl + "/v3/bsc";

            baseUrl = $"{baseUrl}/{path}";


            HttpWebRequest reqc = (HttpWebRequest)WebRequest.Create(baseUrl);

            reqc.Method = "POST";
            reqc.Headers.Add("x-api-key", _privateKey);
            reqc.Credentials = CredentialCache.DefaultCredentials;
            reqc.ContentType = "multipart/form-data";

            using (var streamWriter = new StreamWriter(reqc.GetRequestStream()))
            {

                streamWriter.Write(parameters);
            }


            try
            {
                HttpWebResponse httpResponse = (HttpWebResponse)(await reqc.GetResponseAsync());
                string json;
                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    json = new StreamReader(responseStream).ReadToEnd();
                }

                return json;
            }
            catch (Exception ex)
            {
                throw new SecurityException("Bad credentials", ex);
            }

        }


        private async Task<string> PUTSecureRequest(string path, string parameters)
        {

            var baseUrl = _serverUrl + "/v3/bsc";

            baseUrl = $"{baseUrl}/{path}";


            HttpWebRequest reqc = (HttpWebRequest)WebRequest.Create(baseUrl);

            reqc.Method = "PUT";
            reqc.Headers.Add("x-api-key", _privateKey);
            reqc.Credentials = CredentialCache.DefaultCredentials;
            reqc.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(reqc.GetRequestStream()))
            {

                streamWriter.Write(parameters);
            }


            try
            {
                HttpWebResponse httpResponse = (HttpWebResponse)(await reqc.GetResponseAsync());
                string json;
                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    json = new StreamReader(responseStream).ReadToEnd();
                }

                return json;
            }
            catch (Exception ex)
            {
                throw new SecurityException("Bad credentials", ex);
            }

        }

        private async Task<string> DeleteSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = _serverUrl + "/v3/bsc";

            baseUrl = $"{baseUrl}/{path}";


            HttpWebRequest reqc = (HttpWebRequest)WebRequest.Create(baseUrl);

            reqc.Method = "DELETE";
            reqc.Headers.Add("x-api-key", _privateKey);
            reqc.Credentials = CredentialCache.DefaultCredentials;
            reqc.ContentType = "application/json";




            try
            {
                HttpWebResponse httpResponse = (HttpWebResponse)(await reqc.GetResponseAsync());
                string json;
                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    json = new StreamReader(responseStream).ReadToEnd();
                }

                return json;
            }
            catch (Exception ex)
            {
                throw new SecurityException("Bad credentials", ex);
            }
        }

    }



}