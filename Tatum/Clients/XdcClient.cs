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
using Tatum.Model.Requests;
using Tatum.Model.Responses;

/// <summary>
/// Summary description for XdcClient
/// </summary>
/// 
namespace Tatum
{
    public class XdcClient: IXdcClient
    {



        private readonly string _privateKey;
        public XdcClient(string privateKey)
        {
            _privateKey = privateKey;
        }



        Wallets IXdcClient.CreateWallet(string mnemonic, bool testnet)
        {
            var wallet = new Nethereum.HdWallet.Wallet(mnemonic, "", testnet ? Constants.TestKeyDerivationPath : Constants.VetKeyDerivationPath);
            var xpub = wallet.GetMasterExtPubKey();

            return new Wallets
            {
                XPub = xpub.ToString(Network.Main),
                Mnemonic = mnemonic
            };
        }

        string IXdcClient.GeneratePrivateKey(string mnemonic, int index, bool testnet)
        {
            var wallet = new Nethereum.HdWallet.Wallet(mnemonic, "", testnet ? Constants.TestKeyDerivationPath : Constants.VetKeyDerivationPath);

            return wallet.GetAccount(index).PrivateKey;
        }

        string IXdcClient.GenerateAddress(string xPub, int index, bool testnet)
        {
            var extPubKey = ExtPubKey.Parse(xPub, Network.Main);

            var publicWallet = new Nethereum.HdWallet.PublicWallet(extPubKey);
            return publicWallet.GetAddress(index).ToLower();
        }








        public async Task<XDCNetwork> Web3HttpDriver(string xapikey)
        {
            string parameters = "{\"jsonrpc\":\"2.0\",\"method\":\"web3_clientVersion\",\"params\":[],\"id\":2}";

            var stringResult = await PostSecureRequest($"web3/{xapikey}", parameters);

            var result = JsonConvert.DeserializeObject<XDCNetwork>(stringResult);

            return result;
        }


        public async Task<XDCNetwork> GetCurrentBlockNumber()
        {

            var stringResult = await GetSecureRequest($"block/current");

            var result = JsonConvert.DeserializeObject<XDCNetwork>(stringResult);

            return result;
        }

        public async Task<XDCNetwork> GetXDCBlockByHash(string hash)
        {

            var stringResult = await GetSecureRequest($"block/{hash}");

            var result = JsonConvert.DeserializeObject<XDCNetwork>(stringResult);

            return result;
        }

        public async Task<XDCNetwork> GetXDCAccountBalance(string address)
        {

            var stringResult = await GetSecureRequest($"balance/{address}");

            var result = JsonConvert.DeserializeObject<XDCNetwork>(stringResult);

            return result;
        }

        public async Task<XDCNetwork> GetXDCTransaction(string hash)
        {

            var stringResult = await GetSecureRequest($"transaction/{hash}");

            var result = JsonConvert.DeserializeObject<XDCNetwork>(stringResult);

            return result;
        }

        public async Task<XDCNetwork> GetCountOutgoingXDCTransaction(string address)
        {

            var stringResult = await GetSecureRequest($"transaction/count/{address}");

            var result = JsonConvert.DeserializeObject<XDCNetwork>(stringResult);

            return result;
        }




        public async Task<XDCNetwork> SendTransferXdcBlockchain(string data, string to, string gaslimit, string gasprice, string amount, string fromprivatekey)
        {
            string parameters = "{\"data\":" + "\"" + data + "" + "\",\"to\":" + "\"" + to + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"},\"amount\":" + "\"" + amount + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<XDCNetwork>(stringResult);

            return result;
        }

        public async Task<XDCNetwork> SendTransferXdcBlockchainKMS(string data, string to, string gaslimit, string gasprice, string amount, int index, string signatureid)
        {
            string parameters = "{\"data\":" + "\"" + data + "" + "\",\"to\":" + "\"" + to + "" + "\",\"fee\":{\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"},\"amount\":" + "\"" + amount + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<XDCNetwork>(stringResult);

            return result;
        }



        public async Task<XDCNetwork> EstimateXdcTransactionFees(string from, string to, string amount, string data)
        {
            string parameters = "{\"from\":" + "\"" + from + "" + "\",\"to\":" + "\"" + to + "" + "\",\"amount\":" + "\"" + amount + "" + "\",\"data\":" + "\"" + data + "" + "\"}";

            var stringResult = await PostSecureRequest($"gas", parameters);

            var result = JsonConvert.DeserializeObject<XDCNetwork>(stringResult);

            return result;
        }







        public async Task<XDCNetwork> CallXdcSmartContractReadMethod(string contractaddress, string methodname, string methodabi, string[] contractparams)
        {
            string parameters = "{\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"methodName\":" + "\"" + methodname + "" + "\",\"methodABI\":{" + "\"" + methodabi + "" + "\"},\"params\":[" + "\"" + contractparams + "" + "\"]}";
            var stringResult = await PostSecureRequest($"smartcontract", parameters);

            var result = JsonConvert.DeserializeObject<XDCNetwork>(stringResult);

            return result;
        }


        public async Task<XDCNetwork> CallXdcSmartContractMethod(string contractaddress, string methodname, string methodabi, string[] contractparams, string amount, string fromprivatekey, string gaslimit, string gasprice)
        {
            string parameters = "{\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"methodName\":" + "\"" + methodname + "" + "\",\"methodABI\":{" + "\"" + methodabi + "" + "\"},\"params\":[" + "\"" + contractparams + "" + "\"],\"amount\":" + "\"" + amount + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"smartcontract", parameters);

            var result = JsonConvert.DeserializeObject<XDCNetwork>(stringResult);

            return result;
        }

        public async Task<XDCNetwork> CallXdcSmartContractMethodKMS(string contractaddress, string methodname, string methodabi, string[] contractparams, int index, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"methodName\":" + "\"" + methodname + "" + "\",\"methodABI\":{" + "\"" + methodabi + "" + "\"},\"params\":[" + "\"" + contractparams + "" + "\"],\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"smartcontract", parameters);

            var result = JsonConvert.DeserializeObject<XDCNetwork>(stringResult);

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





        Task<BigInteger> IXdcClient.GetGasPriceInWei()
        {
            throw new NotImplementedException();

        }

        async Task<string> IXdcClient.PrepareStoreDataTransaction(CreateRecord body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> IXdcClient.SendStoreDataTransaction(CreateRecord body, bool testnet, string provider)
        {
            var transaction = await (this as IXdcClient).PrepareStoreDataTransaction(body, true).ConfigureAwait(false);
            var broadcastRequest = new BroadcastRequest
            {
                TxData = transaction
            };

            return await (this as IXdcClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }




























        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api-eu1.tatum.io/v3/xdc";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/xdc";

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

            var baseUrl = "https://api-eu1.tatum.io/v3/xdc";

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
            var baseUrl = "https://api-eu1.tatum.io/v3/xdc";

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