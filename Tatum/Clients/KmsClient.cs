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

/// <summary>
/// Summary description for KmsClient
/// </summary>
/// 
namespace Tatum { 
public partial class KmsClient:IKmsClient
{
    private readonly string _privateKey;

    public KmsClient(string privateKey)
    {

        _privateKey = privateKey;
    }



        public async Task<List<SecurityTransactions>> GetPendingTransactions(string chain)
    {


        var stringResult = await GetSecureRequest($"pending/{chain}");

        var result = JsonConvert.DeserializeObject<List<SecurityTransactions>>(stringResult);

        return result;
    }

        public async Task<SecurityTransactions> CompletePendingTransactions(string id, string txId)
        {
            string parameters = "";

            var stringResult = await PUTSecureRequest($"{id}/{txId}",parameters);

            var result = JsonConvert.DeserializeObject<SecurityTransactions>(stringResult);

            return result;
        }
        public async Task<List<SecurityTransactions>> GetTransactionDetails(string id)
        {


            var stringResult = await GetSecureRequest($"{id}");

            var result = JsonConvert.DeserializeObject<List<SecurityTransactions>>(stringResult);

            return result;
        }
        public async Task<SecurityTransactions> DeleteTransaction(string id)
        {


            var stringResult = await DeleteSecureRequest($"{id}?revert=true");

            var result = JsonConvert.DeserializeObject<SecurityTransactions>(stringResult);

            return result;
        }

        public async Task<SecurityTransactions> CheckMaliciousAddress(string address)
        {


            var stringResult = await GetSecureSecurityRequest($"address/{address}");

            var result = JsonConvert.DeserializeObject<SecurityTransactions>(stringResult);

            return result;
        }











        private async Task<string> GetSecureSecurityRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = "https://api-eu1.tatum.io/v3/security";

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
        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
    {
        var baseUrl = "https://api-eu1.tatum.io/v3/kms";

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

        var baseUrl = "https://api-eu1.tatum.io/v3/kms";

        baseUrl = $"{baseUrl}/{path}";


        HttpWebRequest reqc = (HttpWebRequest)WebRequest.Create(baseUrl);

        reqc.Method = "POST";
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


    private async Task<string> PUTSecureRequest(string path, string parameters)
    {

        var baseUrl = "https://api-eu1.tatum.io/v3/kms";

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
        var baseUrl = "https://api-eu1.tatum.io/v3/kms";

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