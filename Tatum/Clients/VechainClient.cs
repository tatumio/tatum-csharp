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
/// Summary description for VechainClient
/// </summary>
/// 
namespace Tatum
{
    public class VechainClient : IVechainClient
    {


        private readonly string _privateKey;
        private readonly string _serverUrl;
        public VechainClient(string privateKey, string serverUrl)
        {
            _privateKey = privateKey;
            _serverUrl = serverUrl;
        }


        Wallets IVechainClient.CreateWallet(string mnemonic, bool testnet)
        {
            var wallet = new Nethereum.HdWallet.Wallet(mnemonic, "", testnet ? Constants.TestKeyDerivationPath : Constants.VetKeyDerivationPath);
            var xpub = wallet.GetMasterExtPubKey();

            return new Wallets
            {
                XPub = xpub.ToString(Network.Main),
                Mnemonic = mnemonic
            };
        }

        string IVechainClient.GeneratePrivateKey(string mnemonic, int index, bool testnet)
        {
            var wallet = new Nethereum.HdWallet.Wallet(mnemonic, "", testnet ? Constants.TestKeyDerivationPath : Constants.VetKeyDerivationPath);

            return wallet.GetAccount(index).PrivateKey;
        }

        string IVechainClient.GenerateAddress(string xPub, int index, bool testnet)
        {
            var extPubKey = ExtPubKey.Parse(xPub, Network.Main);

            var publicWallet = new Nethereum.HdWallet.PublicWallet(extPubKey);
            return publicWallet.GetAddress(index).ToLower();
        }


        public async Task<Vechain> GetVechainCurrentBlock()
        {

            var stringResult = await GetSecureRequest($"block/current");

            var result = JsonConvert.DeserializeObject<Vechain>(stringResult);

            return result;
        }

        public async Task<Vechain> GetVechainBlockByHash(string hash)
        {

            var stringResult = await GetSecureRequest($"block/{hash}");

            var result = JsonConvert.DeserializeObject<Vechain>(stringResult);

            return result;
        }

        public async Task<Vechain> GetVechainAccountBalance(string address)
        {

            var stringResult = await GetSecureRequest($"account/balance/{address}");

            var result = JsonConvert.DeserializeObject<Vechain>(stringResult);

            return result;
        }

        public async Task<Vechain> GetVechainAccountEnergy(string address)
        {

            var stringResult = await GetSecureRequest($"account/energy/{address}");

            var result = JsonConvert.DeserializeObject<Vechain>(stringResult);

            return result;
        }


        public async Task<Vechain> GetVechainTransaction(string hash)
        {

            var stringResult = await GetSecureRequest($"transaction/{hash}");

            var result = JsonConvert.DeserializeObject<Vechain>(stringResult);

            return result;
        }


        public async Task<Vechain> GetVechainTransactionReceipt(string hash)
        {

            var stringResult = await GetSecureRequest($"transaction/{hash}/receipt");

            var result = JsonConvert.DeserializeObject<Vechain>(stringResult);

            return result;
        }


   



        public async Task<Vechain> EstimateVechainGasForTransaction(string from, string to, string value, string data, string nonce)
        {

            string parameters = "{\"from\":" + "\"" + from + "" + "\",\"to\":" + "\"" + to + "" + "\",\"value\":" + "\"" + value + "" + "\",\"data\":" + "\"" + data + "" + "\",\"nonce\":" + "\"" + nonce + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Vechain>(stringResult);

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





        Task<BigInteger> IVechainClient.GetGasPriceInWei()
        {
            throw new NotImplementedException();

        }

        async Task<string> IVechainClient.PrepareStoreDataTransaction(CreateRecord body, bool testnet, string provider)
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

        async Task<Model.Responses.TransactionHash> IVechainClient.SendStoreDataTransaction(CreateRecord body, bool testnet, string provider)
        {
            var transaction = await (this as IVechainClient).PrepareStoreDataTransaction(body, true).ConfigureAwait(false);
            var broadcastRequest = new BroadcastRequest
            {
                TxData = transaction
            };

            return await (this as IVechainClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }




































        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = serverUrl + "/v3/vet";

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

            var baseUrl = serverUrl + "/v3/vet";

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

            var baseUrl = serverUrl + "/v3/vet";

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
            var baseUrl = serverUrl + "/v3/vet";

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