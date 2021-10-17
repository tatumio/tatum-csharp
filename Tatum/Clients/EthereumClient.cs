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
//using Microsoft.Extensions.Http;
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
using Tatum.Blockchain;


namespace Tatum
{
    public partial class EthereumClient:IEthereumClient
     {


        private readonly string _privateKey;
        public EthereumClient(string privateKey)
        {
            _privateKey = privateKey;
        }



        Wallets IEthereumClient.CreateWallet(string mnemonic, bool testnet)
        {
            var wallet = new Nethereum.HdWallet.Wallet(mnemonic, "", testnet ? Constants.TestKeyDerivationPath : Constants.EthKeyDerivationPath);
            var xpub = wallet.GetMasterExtPubKey();

            return new Wallets
            {
                XPub = xpub.ToString(Network.Main),
                Mnemonic = mnemonic
            };
        }

        string IEthereumClient.GeneratePrivateKey(string mnemonic, int index, bool testnet)
        {
            var wallet = new Nethereum.HdWallet.Wallet(mnemonic, "", testnet ? Constants.TestKeyDerivationPath : Constants.EthKeyDerivationPath);
            
            return wallet.GetAccount(index).PrivateKey;
        }

        string IEthereumClient.GenerateAddress(string xPub, int index, bool testnet)
        {
            var extPubKey = ExtPubKey.Parse(xPub, Network.Main);

            var publicWallet = new Nethereum.HdWallet.PublicWallet(extPubKey);
            return publicWallet.GetAddress(index).ToLower();
        }



        public async Task<Ethereum> Web3Http3Driver(string testnetType,string xApiKey, string jsonrpc, string method, object[] web3params, string id)
        {
            string xtestnettype = "";
            string parameters = "{\"jsonrpc\":" + "\"" + jsonrpc + "" + "\",\"method\":" + "\"" + method + "" + "\",\"params\":" + "\"" + web3params + "" + "\",\"id\":" + "\"" + id + "" + "\"}";
            

            var stringResult = await PostSecureRequest($"web3/{xApiKey}?testnetType="+ testnetType,xtestnettype, parameters);

            var result = JsonConvert.DeserializeObject<Ethereum>(stringResult);

            return result;
        }


        public async Task<Ethereum> GetCurrentBlockNumber(string xtestnettype)
        {


            var stringResult = await GetSecureRequest($"block/current", xtestnettype);

            var result = JsonConvert.DeserializeObject<Ethereum>(stringResult);

            return result;
        }

        public async Task<Ethereum> GetBlockHash(string xtestnettype, string hash)
        {


            var stringResult = await GetSecureRequest($"block/{hash}", xtestnettype);

            var result = JsonConvert.DeserializeObject<Ethereum>(stringResult);

            return result;
        }


        public async Task<Ethereum> GetEthereumAccountBalance(string xtestnettype, string address)
        {


            var stringResult = await GetSecureRequest($"balance/{address}", xtestnettype);

            var result = JsonConvert.DeserializeObject<Ethereum>(stringResult);

            return result;
        }



        public async Task<Ethereum> GetEthereumTransaction(string xtestnettype, string hash)
        {


            var stringResult = await GetSecureRequest($"transaction/{hash}", xtestnettype);

            var result = JsonConvert.DeserializeObject<Ethereum>(stringResult);

            return result;
        }

       

        public  async Task<int> GetTransactionsCount(string address)
        {
            var stringResult = await GetSecureRequest($"transaction/count/{address}", "");

               var result = JsonConvert.DeserializeObject<int>(stringResult);

               return result;
        }

        public async Task<Ethereum> GetEthereumTransactionsAddress(string xtestnettype, string address, int from, int to, string sort, int pageSize = 50, int offset = 0)
        {


            var stringResult = await GetSecureRequest($"account/transaction/{address}?pageSize=10&offset=0&from="+from +"&to="+to + "&sort="+ sort, xtestnettype);

            var result = JsonConvert.DeserializeObject<Ethereum>(stringResult);

            return result;
        }


      

        public async Task<Ethereum> TransferEthBlockchainKms(string xtestnettype, string data, string to, string currency, string gaslimit, string gasprice, string amount, string signatureid, string index)
        {

            string parameters = "{\"data\":" + "\"" + data + "" + "\",\"to\":" + "\"" + to + "" + "\",\"currency\":" + "\"" + currency + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"},\"amount\":" + "\"" + amount + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"index\":" + "\"" + index + "" + "\"}";


            var stringResult = await PostSecureRequest($"transaction", xtestnettype, parameters);

            var result = JsonConvert.DeserializeObject<Ethereum>(stringResult);

            return result;
        }


        public async Task<Ethereum> EstimateEthTransactionFee(string xtestnettype, string from, string to, string amount, string data)
        {

            string parameters = "{\"from\":" + "\"" + data + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + to + "" + "\",\"data\":" + "\"" + to + "" + "\"}";


            var stringResult = await PostSecureRequest($"gas", xtestnettype, parameters);

            var result = JsonConvert.DeserializeObject<Ethereum>(stringResult);

            return result;
        }


        public async Task<Ethereum> CallSmartContractMethod(string xtestnettype, string contractAddress, string methodName, object methodAbi, object[] contractparams, string fromPrivateKey, string gasLimit, string gasPrice)
        {

            string parameters = "{\"contractAddress\":" + "\"" + contractAddress + "" + "\",\"methodName\":" + "\"" + methodName + "" + "\",\"methodABI\":{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"stake\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},\"params\":[" + "\"" + contractparams + "" + "\"],\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}";


            var stringResult = await PostSecureRequest($"smartcontract", xtestnettype, parameters);

            var result = JsonConvert.DeserializeObject<Ethereum>(stringResult);

            return result;
        }


        public async Task<Ethereum> CallReadSmartContractMethod(string xtestnettype, string contractAddress, string methodName, object methodAbi, object[] contractparams)
        {

            string parameters = "{\"contractAddress\":" + "\"" + contractAddress + "" + "\",\"methodName\":" + "\"" + methodName + "" + "\",\"methodABI\":{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"stake\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},\"params\":[" + "\"" + contractparams + "" + "\"]";


            var stringResult = await PostSecureRequest($"smartcontract", xtestnettype, parameters);

            var result = JsonConvert.DeserializeObject<Ethereum>(stringResult);

            return result;
        }


        public async Task<Ethereum> CallSmartContractMethodKMS(string xtestnettype, string contractAddress, string methodName, object methodAbi, object[] contractparams, string signatureId, int index, string gasLimit, string gasPrice)
        {

            string parameters = "{\"contractAddress\":" + "\"" + contractAddress + "" + "\",\"methodName\":" + "\"" + methodName + "" + "\",\"methodABI\":{\"inputs\":[{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"stake\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},\"params\":[" + "\"" + contractparams + "" + "\"],\"signatureId\":" + "\"" + signatureId + "" + "\",\"index\":" + "\"" + index + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gasLimit + "" + "\",\"gasPrice\":" + "\"" + gasPrice + "" + "\"}";


            var stringResult = await PostSecureRequest($"smartcontract", xtestnettype, parameters);

            var result = JsonConvert.DeserializeObject<Ethereum>(stringResult);

            return result;
        }



        public async Task<Ethereum> GetErc20InternalTransaction(string xtestnettype, string address, int pageSize = 50, int offset = 0)
        {


            var stringResult = await GetSecureRequest($"account/transaction/erc20/internal/{address}?pageSize=10&offset=0", xtestnettype);

            var result = JsonConvert.DeserializeObject<Ethereum>(stringResult);

            return result;
        }




        public async Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request)
        {
            string parameters = "{\"txData\":" + "\"" + request.TxData + "" + "\",\"signatureId\":" + "\"" + request.SignatureId + "" + "\"}";


            var stringResult = await PostSecureRequest($"broadcast", "", parameters);

            var result = JsonConvert.DeserializeObject<TransactionHash>(stringResult);

            return result;
        }


        Task<BigInteger> IEthereumClient.GetGasPriceInWei()
        {
            throw new NotImplementedException();

        }

        async Task<string> IEthereumClient.PrepareStoreDataTransaction(CreateRecord body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> IEthereumClient.SendStoreDataTransaction(CreateRecord body, bool testnet, string provider)
        {
            var transaction = await (this as IEthereumClient).PrepareStoreDataTransaction(body, true).ConfigureAwait(false);
            var broadcastRequest = new BroadcastRequest
            {
                TxData = transaction
            };

            return await (this as IEthereumClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }


























        private async Task<string> GetSecureRequest(string path,string headerparameter, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api-eu1.tatum.io/v3/ethereum";

            baseUrl = $"{baseUrl}/{path}";


            HttpWebRequest reqc = (HttpWebRequest)WebRequest.Create(baseUrl);

            reqc.Method = "GET";
            reqc.Headers.Add("x-api-key", _privateKey);
            reqc.Headers.Add("x-testnet-type", headerparameter);
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


        private async Task<string> PostSecureRequest(string path, string headerparameter, string parameters)
        {

            var baseUrl = "https://api-eu1.tatum.io/v3/ethereum";

            baseUrl = $"{baseUrl}/{path}";


            HttpWebRequest reqc = (HttpWebRequest)WebRequest.Create(baseUrl);

            reqc.Method = "POST";
            reqc.Headers.Add("x-api-key", _privateKey);
            reqc.Headers.Add("x-testnet-type", headerparameter);
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


        private async Task<string> PUTSecureRequest(string path, string parameters)
        {

            var baseUrl = "https://api-eu1.tatum.io/v3/ethereum";

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
            var baseUrl = "https://api-eu1.tatum.io/v3/ethereum";

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