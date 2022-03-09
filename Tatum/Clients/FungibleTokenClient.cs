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
/// Summary description for FungibleTokenClient
/// </summary>
/// 
namespace Tatum
{
    public class FungibleTokenClient
    {


        private readonly string _privateKey;
        private readonly string _serverUrl;
        public FungibleTokenClient(string privateKey, string serverUrl)
        {
            _privateKey = privateKey;
            _serverUrl = serverUrl;
        }





        async Task<Model.Responses.TransactionHash> DeployErc20(DeployErc20 body, bool testnet, string provider)
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
        async Task<Model.Responses.TransactionHash> DeployBep20(DeployErc20 body, bool testnet, string provider)
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
        async Task<Model.Responses.TransactionHash> OneDeployErc20(DeployErc20 body, bool testnet, string provider)
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
        async Task<Model.Responses.TransactionHash> MaticDeployErc20(DeployErc20 body, bool testnet, string provider)
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








        public async Task<FungibleToken> GetErc20AccountBalance(string chain, string address, string contractaddress)
        {

            var stringResult = await GetSecureRequest($"balance/{chain}/{contractaddress}/{address}");

            var result = JsonConvert.DeserializeObject<FungibleToken>(stringResult);

            return result;
        }























        private async Task<string> GetSecureRequest(string path, Dictionary<string, string> paramaters = null)
        {
            var baseUrl = serverUrl + "/v3/blockchain/token";

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

            var baseUrl = serverUrl + "/v3/blockchain/token";

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

            var baseUrl = serverUrl + "/v3/blockchain/token";

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
            var baseUrl = serverUrl + "/v3/blockchain/token";

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