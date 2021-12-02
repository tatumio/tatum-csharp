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

using System.Security;
using Tatum.Model;
using Tatum.Model.Responses;
using Tatum.Model.Requests;
using Tatum.Contracts;
using System.ComponentModel.DataAnnotations;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Hex.HexTypes;
using System.Numerics;

/// <summary>
/// Summary description for NftClient
/// </summary>
/// 
namespace Tatum
{
    public class NftClient
    {


        private readonly string _privateKey;
        public NftClient(string privateKey)
        {
            _privateKey = privateKey;
        }



        async Task<Model.Responses.TransactionHash> DeployEthNft(EthDeployErc721 body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> DeployCeloNft(CeloDeployErc721 body, bool testnet, string provider)
        {

            var FromPrivatekey = body.FromPrivatekey;
            var name = body.name;
            var symbol = body.symbol;

            var fee = body.feecurrency;
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
              gas: new HexBigInteger(new BigInteger(0)),
              gasPrice: new HexBigInteger(new BigInteger(0)),
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

        async Task<Model.Responses.TransactionHash> DeployBscNft(EthDeployErc721 body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> DeployOneNft(EthDeployErc721 body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> DeployMaticNft(EthDeployErc721 body, bool testnet, string provider)
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














        async Task<Model.Responses.TransactionHash> sendMintEthNft(EthMintErc721 body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> MintEthNftCashback(EthMintErc721 body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> MintEthNftProvenance(EthMintErc721 body, bool testnet, string provider)
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


        async Task<Model.Responses.TransactionHash> MintCeloNft(CeloMintErc721 body, bool testnet, string provider)
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
            var fee = body.feecurrency;
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

        async Task<Model.Responses.TransactionHash> MintCeloNftCashback(CeloMintErc721 body, bool testnet, string provider)
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
            var fee = body.feecurrency;
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

        async Task<Model.Responses.TransactionHash> MintCeloNftProvenance(CeloMintErc721 body, bool testnet, string provider)
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
            var fee = body.feecurrency;
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


        async Task<Model.Responses.TransactionHash> MintBscNft(EthMintErc721 body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> MintBscNftCashback(EthMintErc721 body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> MintBscNftProvenance(EthMintErc721 body, bool testnet, string provider)
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


        async Task<Model.Responses.TransactionHash> MintOneNft(EthMintErc721 body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> MintOneNftCashback(EthMintErc721 body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> MintOneNftProvenance(EthMintErc721 body, bool testnet, string provider)
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


        async Task<Model.Responses.TransactionHash> MintMaticNft(EthMintErc721 body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> MintMaticNftCashback(EthMintErc721 body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> MintMaticNftProvenance(EthMintErc721 body, bool testnet, string provider)
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






        async Task<Model.Responses.TransactionHash> MintEthNftMultiple(EthMintMultipleErc721 body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> MintEthNftMultipleCashback(EthMintMultipleErc721 body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> MintEthNftMultipleProvenance(EthMintMultipleErc721 body, bool testnet, string provider)
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



        async Task<Model.Responses.TransactionHash> MintCeloNftMultiple(CeloMintMultipleErc721 body, bool testnet, string provider)
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
              gas: new HexBigInteger(new BigInteger(0)),
              gasPrice: new HexBigInteger(new BigInteger(0)),
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
        async Task<Model.Responses.TransactionHash> MintCeloNftMultipleCashback(CeloMintMultipleErc721 body, bool testnet, string provider)
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
            var fee = body.feecurrency;
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

        async Task<Model.Responses.TransactionHash> MintCeloNftMultipleProvenance(CeloMintMultipleErc721 body, bool testnet, string provider)
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
            var fee = body.feecurrency;
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


        async Task<Model.Responses.TransactionHash> MintBscNftMultiple(EthMintMultipleErc721 body, bool testnet, string provider)
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
        async Task<Model.Responses.TransactionHash> MintBscNftMultipleCashback(EthMintMultipleErc721 body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> MintBscNftMultipleProvenance(EthMintMultipleErc721 body, bool testnet, string provider)
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


        async Task<Model.Responses.TransactionHash> MintOneNftMultiple(EthMintMultipleErc721 body, bool testnet, string provider)
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
        async Task<Model.Responses.TransactionHash> MintOneNftMultipleCashback(EthMintMultipleErc721 body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> MintOneNftMultipleProvenance(EthMintMultipleErc721 body, bool testnet, string provider)
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


        async Task<Model.Responses.TransactionHash> MintMaticNftMultiple(EthMintMultipleErc721 body, bool testnet, string provider)
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
        async Task<Model.Responses.TransactionHash> MintMaticNftMultipleCashback(EthMintMultipleErc721 body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> MintMaticNftMultipleProvenance(EthMintMultipleErc721 body, bool testnet, string provider)
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


        async Task<Model.Responses.TransactionHash> BurnEthNft(EthBurnErc721 body, bool testnet, string provider)
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
        async Task<Model.Responses.TransactionHash> BurnCeloNft(CeloBurnErc721 body, bool testnet, string provider)
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
              gas: new HexBigInteger(new BigInteger(0)),
              gasPrice: new HexBigInteger(new BigInteger(0)),
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
        async Task<Model.Responses.TransactionHash> BurnBscNft(EthBurnErc721 body, bool testnet, string provider)
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



        async Task<Model.Responses.TransactionHash> EthUpdateCashbackForAuthorNft(UpdateCashbackErc721 body, bool testnet, string provider)
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
        async Task<Model.Responses.TransactionHash> CeloUpdateCashbackForAuthorNft(CeloUpdateCashbackErc721 body, bool testnet, string provider)
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
        async Task<Model.Responses.TransactionHash> BscUpdateCashbackForAuthorNft(UpdateCashbackErc721 body, bool testnet, string provider)
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
        async Task<Model.Responses.TransactionHash> OneUpdateCashbackForAuthorNft(UpdateCashbackErc721 body, bool testnet, string provider)
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
        async Task<Model.Responses.TransactionHash> MaticUpdateCashbackForAuthorNft(UpdateCashbackErc721 body, bool testnet, string provider)
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




        async Task<Model.Responses.TransactionHash> TransferNft(EthTransferErc721 body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> TransferCeloNft(CeloTransferErc721 body, bool testnet, string provider)
        {

            var FromPrivatekey = body.FromPrivatekey;
            var to = body.to;
            var tokenId = body.tokenId;
            var contractaddress = body.contractaddress;

            var fee = body.feecurrency;
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
              gas: new HexBigInteger(new BigInteger(0)),
              gasPrice: new HexBigInteger(new BigInteger(0)),
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

        async Task<Model.Responses.TransactionHash> TransferBscNft(EthTransferErc721 body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> TransferOneNft(EthTransferErc721 body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> TransferMaticNft(EthTransferErc721 body, bool testnet, string provider)
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


       







        public async Task<Nft> GetContractAddressFromTransaction(string chain, string hash)
        {

            var stringResult = await GetSecureRequest($"address/{chain}/{hash}");

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> GetTransaction(string chain, string hash)
        {

            var stringResult = await GetSecureRequest($"transaction/{chain}/{hash}");

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> GetNftAccountBalance(string chain, string address, string contractAddress)
        {

            var stringResult = await GetSecureRequest($"balance/{chain}/{contractAddress}/{address}");

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }



        public async Task<Nft> GetNftTokenMetadata(string chain, string token, string contractAddress,string account)
        {

            var stringResult = await GetSecureRequest($"metadata/{chain}/{contractAddress}/{token}?account="+account);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }


        public async Task<Nft> GetNftTokenRoyaltyInfo(string chain, string token, string contractAddress)
        {

            var stringResult = await GetSecureRequest($"royalty/{chain}/{contractAddress}/{token}");

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }












































        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api-eu1.tatum.io/v3/nft";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/nft";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/nft";

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
            var baseUrl = "https://api-eu1.tatum.io/v3/nft";

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