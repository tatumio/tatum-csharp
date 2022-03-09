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
using stellar_dotnet_sdk;
using stellar_dotnet_sdk.responses;


/// <summary>
/// Summary description for XLMClient
/// </summary>
/// 

namespace Tatum
{
    public class XLMClient:IXlmClient
    {

        private readonly string _privateKey;
        private readonly string _serverUrl;
        public XLMClient(string privateKey, string serverUrl)
        {
            _privateKey = privateKey;
            _serverUrl = serverUrl;
        }



        Wallets IXlmClient.CreateWallet(string secret)
        {
            KeyPair keypair;
            if (string.IsNullOrWhiteSpace(secret))
            {
              keypair = KeyPair.Random();
            }
            else
            {
               keypair = KeyPair.FromSecretSeed(secret);
            }

            return new Wallets
            {
               PrivateKey = keypair.SecretSeed,
                Address = keypair.Address
            };
        }

        public async Task<Xlm> GenerateXlmBlockchain()
        {


            var stringResult = await GetSecureRequest($"info");

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }

        public async Task<Xlm> GetXlmBlockchainLedger(string sequence)
        {


            var stringResult = await GetSecureRequest($"ledger/{sequence}");

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }

        public async Task<Xlm> GetXlmBlockchainTransactions(string sequence)
        {


            var stringResult = await GetSecureRequest($"ledger/{sequence}/transaction");

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }

        public async Task<Xlm> GetActualXlmFee()
        {


            var stringResult = await GetSecureRequest($"fee");

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }


        public async Task<Xlm> GetXlmAccountTransaction(string account, string pagination)
        {


            var stringResult = await GetSecureRequest($"account/tx/{account}");

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }


        public async Task<Xlm> GetXlmTransactionByHash(string hash)
        {


            var stringResult = await GetSecureRequest($"transaction/{hash}");

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }



        public async Task<Xlm> GetXlmAccountInfo(string account)
        {


            var stringResult = await GetSecureRequest($"account/{account}");

            var result = JsonConvert.DeserializeObject<Xlm>(stringResult);

            return result;
        }



        


        public async Task<Tatum.Model.Responses.TransactionHash> BroadcastSignedTransaction(Tatum.Model.Requests.BroadcastRequest request)
        {
            string parameters = "{\"txData\":" + "\"" + request.TxData + "" + "\",\"signatureId\":" + "\"" + request.SignatureId + "" + "\"}";

            var stringResult = await PostSecureRequest($"broadcast", parameters);

            var result = JsonConvert.DeserializeObject<Tatum.Model.Responses.TransactionHash>(stringResult);

            return result;
        }






        async Task<Tatum.Model.Responses.TransactionHash> IXlmClient.SendTransaction( bool testnet)
        {
            string txData = await (this as IXlmClient).PrepareSignedTransaction( testnet).ConfigureAwait(false);
            var broadcastRequest = new Tatum.Model.Requests.BroadcastRequest
            {
                TxData = txData
            };

            return await (this as IXlmClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
        }

        [Obsolete]
        public async Task<string> PrepareSignedTransaction(bool testnet)
        {

            //Set network and server
            Network network = new Network("Test SDF Network ; September 2015");
            Server server = new Server("https://horizon-testnet.stellar.org");

            //Source keypair from the secret seed
            KeyPair sourceKeypair = KeyPair.FromSecretSeed("SOURCE_SECRET_SEED");

            //Destination keypair from the account id
            KeyPair destinationKeyPair = KeyPair.FromAccountId("DESTINATION_ACCOUNT_ID");

            //Load source account data
            AccountResponse sourceAccountResponse = await server.Accounts.Account(sourceKeypair.AccountId);

            //Create source account object
         stellar_dotnet_sdk.Account sourceAccount = new stellar_dotnet_sdk.Account(sourceKeypair.AccountId, sourceAccountResponse.SequenceNumber);

         

            //Create asset object with specific amount
            //You can use native or non native ones.
            stellar_dotnet_sdk.Asset asset = new AssetTypeNative();
           
            string amount = "1";

            //Create payment operation
            PaymentOperation operation = new PaymentOperation.Builder(destinationKeyPair, asset, amount).SetSourceAccount(sourceAccount.KeyPair).Build();

            //Create transaction and add the payment operation we created
            stellar_dotnet_sdk.Transaction  transaction = new stellar_dotnet_sdk.Transaction(null,0,0,null,null,null);

            //Sign Transaction
            transaction.Sign(sourceKeypair);
            
            //Try to send the transaction
            try
            {
                await server.SubmitTransaction(transaction);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Send Transaction Failed");
                Console.WriteLine("Exception: " + exception.Message);
            }


            return transaction.ToString();
        }


















        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = _serverUrl + "/v3/xlm";

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

            var baseUrl = _serverUrl + "/v3/xlm";

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

            var baseUrl = _serverUrl + "/v3/xlm";

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
            var baseUrl = _serverUrl + "/v3/xlm";

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