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
/// Summary description for MultiTokenClient
/// </summary>
/// 
namespace Tatum
{
    public class MultiTokenClient
    {


        private readonly string _privateKey;
        public MultiTokenClient(string privateKey)
        {
            _privateKey = privateKey;
        }




        async Task<Model.Responses.TransactionHash> DeployMultiToken(EthDeployMultiToken body, bool testnet, string provider)
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


        async Task<Model.Responses.TransactionHash> DeployCeloMultiToken(CeloDeployMultiToken body, bool testnet, string provider)
        {

            var FromPrivatekey = body.FromPrivatekey;
            var uri = body.uri;
            var fee = body.feecurrency;
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

        async Task<Model.Responses.TransactionHash> DeployBscMultiToken(EthDeployMultiToken body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> DeployOneMultiToken(EthDeployMultiToken body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> DeployMaticMultiToken(EthDeployMultiToken body, bool testnet, string provider)
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


        async Task<Model.Responses.TransactionHash> MintMultiToken(MintMultiToken body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> MintCeloMultiToken(CeloMintMultiToken body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> MintBscMultiToken(MintMultiToken body, bool testnet, string provider)
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
        async Task<Model.Responses.TransactionHash> MintOneMultiToken(MintMultiToken body, bool testnet, string provider)
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
        async Task<Model.Responses.TransactionHash> MintMaticMultiToken(MintMultiToken body, bool testnet, string provider)
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








        


        async Task<Model.Responses.TransactionHash> MintMultiTokenBatch(MintMultiTokenBatch body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> MintCeloMultiTokenBatch(CeloMintMultiTokenBatch body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> MintBscMultiTokenBatch(MintMultiTokenBatch body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> MintOneMultiTokenBatch(MintMultiTokenBatch body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> MintMaticMultiTokenBatch(MintMultiTokenBatch body, bool testnet, string provider)
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





        async Task<Model.Responses.TransactionHash> BurnMultiToken(EthBurnMultiToken body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> BurnCeloMultiToken(CeloBurnMultiToken body, bool testnet, string provider)
        {

            var FromPrivatekey = body.FromPrivatekey;
            var tokenid = body.tokenId;
            var amount = body.amount;
            var contractaddress = body.contractaddress;

            var fee = body.feecurrency;
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

        async Task<Model.Responses.TransactionHash> BurnBscMultiToken(EthBurnMultiToken body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> BurnOneMultiToken(EthBurnMultiToken body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> BurnMaticMultiToken(EthBurnMultiToken body, bool testnet, string provider)
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








        async Task<Model.Responses.TransactionHash> BurnMultiTokenBatch(EthBurnMultiTokenBatch body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> BurnCeloMultiTokenBatch(CeloBurnMultiTokenBatch body, bool testnet, string provider)
        {

            var FromPrivatekey = body.FromPrivatekey;
            var tokenid = body.tokenId;
            var amounts = body.amounts;
            var contractaddress = body.contractaddress;

            var fee = body.feecurrency;
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

        async Task<Model.Responses.TransactionHash> BurnBscBatchMultiTokenBatch(EthBurnMultiTokenBatch body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> BurnOneMultiTokenBatch(EthBurnMultiTokenBatch body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> BurnMaticMultiTokenBatch(EthBurnMultiTokenBatch body, bool testnet, string provider)
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





        async Task<Model.Responses.TransactionHash> TransferMultiToken(TransferMultiToken body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> TransferCeloMultiToken(CeloTransferMultiToken body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> TransferBscMultiToken(TransferMultiToken body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> TransferOneMultiToken(TransferMultiToken body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> TransferMaticMultiToken(TransferMultiToken body, bool testnet, string provider)
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




        async Task<Model.Responses.TransactionHash> TransferMultiTokenBatch(TransferMultiTokenBatch body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> TransferCeloMultiTokenBatch(CeloTransferMultiTokenBatch body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> TransferBscMultiTokenBatch(TransferMultiTokenBatch body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> TransferOneMultiTokenBatch(TransferMultiTokenBatch body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> TransferMaticMultiTokenBatch(TransferMultiTokenBatch body, bool testnet, string provider)
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









        public async Task<MultiToken> GetContractAddress(string chain, string hash)
        {

            var stringResult = await GetSecureRequest($"address/{chain}/{hash}");

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }



        public async Task<MultiToken> GetTransaction(string chain, string hash)
        {

            var stringResult = await GetSecureRequest($"transaction/{chain}/{hash}");

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }

        public async Task<MultiToken> GetMultiTokenAccountBalance(string chain, string address, string contractaddress, string tokenid)
        {

            var stringResult = await GetSecureRequest($"balance/{chain}/{contractaddress}/{address}/{tokenid}");

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }



        public async Task<MultiToken> GetMultiTokenAccountBatchBalance(string chain, string contractaddress,string tokenid,string address)
        {

            var stringResult = await GetSecureRequest($"balance/batch/{chain}/{contractaddress}?tokenId="+tokenid +" &address="+address);

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }



        public async Task<MultiToken> GetMultiTokenMetadata(string chain, string token, string contractaddress)
        {

            var stringResult = await GetSecureRequest($"metadata/{chain}/{contractaddress}/{token}");

            var result = JsonConvert.DeserializeObject<MultiToken>(stringResult);

            return result;
        }



























        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api-eu1.tatum.io/v3/multitoken";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/multitoken";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/multitoken";

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
            var baseUrl = "https://api-eu1.tatum.io/v3/multitoken";

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