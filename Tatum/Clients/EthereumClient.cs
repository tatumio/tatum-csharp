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
using Microsoft.Extensions.Http;
using System.Security;



namespace Tatum
{
    public partial class EthereumClient:IEthereumClient
     {


        private readonly string _privateKey;
        public EthereumClient(string privateKey)
        {
            _privateKey = privateKey;
        }



        public async Task<Ethereum> GenerateEthereumWallet(string xtestnettype, string mnemonic)
        {


            var stringResult = await GetSecureRequest($"wallet?mnemonic="+ mnemonic, xtestnettype);

            var result = JsonConvert.DeserializeObject<Ethereum>(stringResult);

            return result;
        }


        public async Task<Ethereum> GenerateEthereumDepositAddressFromPublicKey(string xtestnettype, string xpub, int index)
        {


            var stringResult = await GetSecureRequest($"address/{xpub}/{index}", xtestnettype);

            var result = JsonConvert.DeserializeObject<Ethereum>(stringResult);

            return result;
        }


        public async Task<Ethereum> GenerateEthereumPrivateKey(string xtestnettype, string index, int mnemonic)
        {

            string parameters = "{\"index\":" + "\"" + index + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\"}";


            var stringResult = await PostSecureRequest($"wallet/priv", xtestnettype, parameters);

            var result = JsonConvert.DeserializeObject<Ethereum>(stringResult);

            return result;
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

        public async Task<Ethereum> GetCountOfOutgoingTransaction(string xtestnettype, string address)
        {


            var stringResult = await GetSecureRequest($"transaction/count/{address}", xtestnettype);

            var result = JsonConvert.DeserializeObject<Ethereum>(stringResult);

            return result;
        }

        public async Task<Ethereum> GetEthereumTransactionsAddress(string xtestnettype, string address, int from, int to, string sort, int pageSize = 50, int offset = 0)
        {


            var stringResult = await GetSecureRequest($"account/transaction/{address}?pageSize=10&offset=0&from="+from +"&to="+to + "&sort="+ sort, xtestnettype);

            var result = JsonConvert.DeserializeObject<Ethereum>(stringResult);

            return result;
        }


        public async Task<Ethereum> TransferEthBlockchain(string xtestnettype, string data, string to, string currency, string gaslimit, string gasprice, string amount, string fromprivatekey)
        {
            
            string parameters = "{\"data\":" + "\"" + data + "" + "\",\"to\":" + "\"" + to + "" + "\",\"currency\":" + "\"" + currency + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"},\"amount\":" + "\"" + amount + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\"}";


            var stringResult = await PostSecureRequest($"transaction", xtestnettype, parameters);

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


        public async Task<Ethereum> BroadcastSignedEthTransaction(string xtestnettype, string txData, string signatureId)
        {
            
            string parameters = "{\"txData\":" + "\"" + txData + "" + "\",\"signatureId\":" + "\"" + signatureId + "" + "\"}";


            var stringResult = await PostSecureRequest($"broadcast", xtestnettype, parameters);

            var result = JsonConvert.DeserializeObject<Ethereum>(stringResult);

            return result;
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