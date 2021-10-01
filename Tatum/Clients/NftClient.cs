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



        public async Task<Nft> DeployNftCelo(string chain, string name, string symbol, string fromprivatekey, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"name\":" + "\"" + name + "" + "\",\"symbol\":" + "\"" + symbol + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"deploy", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> DeployNftCeloKMS(string chain, string name, string symbol, int index, string signatureid, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"name\":" + "\"" + name + "" + "\",\"symbol\":" + "\"" + symbol + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"deploy", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> DeployNftTron(string chain, string name, string symbol, string fromprivatekey, string feelimit)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"name\":" + "\"" + name + "" + "\",\"symbol\":" + "\"" + symbol + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeLimit\":" + "\"" + feelimit + "" + "\"}";
            var stringResult = await PostSecureRequest($"deploy", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }


        public async Task<Nft> DeployNftTronKMS(string chain, string account, string name, string symbol, int index, string signatureid, string feelimit)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"account\":" + "\"" + account + "" + "\",\"name\":" + "\"" + name + "" + "\",\"symbol\":" + "\"" + symbol + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeLimit\":" + "\"" + feelimit + "" + "\"}";
            var stringResult = await PostSecureRequest($"deploy", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> DeployNft(string chain, string name, string symbol, string fromprivatekey, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"name\":" + "\"" + name + "" + "\",\"symbol\":" + "\"" + symbol + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"deploy", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> DeployNftKMS(string chain, string name, string symbol, int index, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"name\":" + "\"" + name + "" + "\",\"symbol\":" + "\"" + symbol + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"deploy", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> DeployNftFlowPK(string chain, string account, string fromprivatekey)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"account\":" + "\"" + account + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\"}";
            var stringResult = await PostSecureRequest($"deploy", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> DeployNftFlowMnemonic(string chain, string account, string mnemonic, int index)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"account\":" + "\"" + account + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"index\":" + "\"" + index + "" + "\"}";
            var stringResult = await PostSecureRequest($"deploy", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> DeployNftFlowKMS(string chain, string account, string signatureid, int index)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"account\":" + "\"" + account + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"index\":" + "\"" + index + "" + "\"}";
            var stringResult = await PostSecureRequest($"deploy", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }













        public async Task<Nft> MintNftCelo(string chain, string tokenid, string to, string contractaddress, string url, string[] authoraddresses, string cashbackvalues, string fromprivatekey, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"url\":" + "\"" + url + "" + "\",\"authorAddresses\":[" + "\"" + authoraddresses + "" + "\"],\"cashbackValues\":[" + "\"" + cashbackvalues + "" + "\"],\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> MintNftKMSCelo(string chain, string tokenid, string to, string contractaddress, string url, string[] authoraddresses, string cashbackvalues, string index, string signatureid, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"url\":" + "\"" + url + "" + "\",\"authorAddresses\":[" + "\"" + authoraddresses + "" + "\"],\"cashbackValues\":[" + "\"" + cashbackvalues + "" + "\"],\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> MintNftTron(string chain, string tokenid, string to, string contractaddress, string url, string[] authoraddresses, string cashbackvalues, string fromprivatekey, string feelimit)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"url\":" + "\"" + url + "" + "\",\"authorAddresses\":[" + "\"" + authoraddresses + "" + "\"],\"cashbackValues\":[" + "\"" + cashbackvalues + "" + "\"],\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeLimit\":" + "\"" + feelimit + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> MintNftKMSTron(string chain, string tokenid, string to, string contractaddress, string url, string[] authoraddresses, string cashbackvalues, string index, string signatureid, string feelimit)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"url\":" + "\"" + url + "" + "\",\"authorAddresses\":[" + "\"" + authoraddresses + "" + "\"],\"cashbackValues\":[" + "\"" + cashbackvalues + "" + "\"],\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeLimit\":" + "\"" + feelimit + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }


        public async Task<Nft> MintNft(string chain, string tokenid, string to, string contractaddress, string url, string[] authoraddresses, string cashbackvalues, string index, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"url\":" + "\"" + url + "" + "\",\"authorAddresses\":[" + "\"" + authoraddresses + "" + "\"],\"cashbackValues\":[" + "\"" + cashbackvalues + "" + "\"],\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> MintNftKMS(string chain, string tokenid, string to, string contractaddress, string url, string[] authoraddresses, string cashbackvalues, string index, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"url\":" + "\"" + url + "" + "\",\"authorAddresses\":[" + "\"" + authoraddresses + "" + "\"],\"cashbackValues\":[" + "\"" + cashbackvalues + "" + "\"],\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }


        public async Task<Nft> MintNftFlowPK(string chain, string to, string url, string contractaddress, string account, string fromprivatekey)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"url\":" + "\"" + url + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"account\":" + "\"" + account + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }
        public async Task<Nft> MintNftFlowMnemonic(string chain, string to, string url, string contractaddress, string account, string mnemonic, int index)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"url\":" + "\"" + url + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"account\":" + "\"" + account + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"index\":" + "\"" + index + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }
        public async Task<Nft> MintNftFlowKMS(string chain, string to, string url, string contractaddress, string account, string signatureid, int index)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"url\":" + "\"" + url + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"account\":" + "\"" + account + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"index\":" + "\"" + index + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }











        public async Task<Nft> TransferNft(string value, string chain, string to, string tokenid, string contractaddress, string fromprivatekey, string gaslimit, string gasprice)
        {
            string parameters = "{\"value\":" + "\"" + value + "" + "\",\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> TransferNftCelo(string value, string chain, string to, string tokenid, string contractaddress, string fromprivatekey, string feecurrency)
        {
            string parameters = "{\"value\":" + "\"" + value + "" + "\",\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> TransferNftTron(string value, string chain, string to, string tokenid, string contractaddress, string fromprivatekey, string feelimit)
        {
            string parameters = "{\"value\":" + "\"" + value + "" + "\",\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeLimit\":" + "\"" + feelimit + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> TransferNftKMS(string value, string chain, string to, string tokenid, string contractaddress, int index, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"value\":" + "\"" + value + "" + "\",\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }


        public async Task<Nft> TransferNftKMSCelo(string value, string chain, string to, string tokenid, string contractaddress, int index, string signatureid, string feecurrency)
        {
            string parameters = "{\"value\":" + "\"" + value + "" + "\",\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> TransferNftKMSTron(string value, string chain, string account, string to, string tokenid, string contractaddress, int index, string signatureid, string feelimit)
        {
            string parameters = "{\"value\":" + "\"" + value + "" + "\",\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeLimit\":" + "\"" + feelimit + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }


        public async Task<Nft> TransferNftFlowPK(string chain, string to, string tokenid, string contractaddress, string account, string privatekey)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"account\":" + "\"" + account + "" + "\",\"PrivateKey\":" + "\"" + privatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }
        public async Task<Nft> TransferNftFlowMnemonic(string chain, string to, string tokenid, string contractaddress, string account, string mnemonic, int index)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"account\":" + "\"" + account + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }
        public async Task<Nft> TransferNftFlowKMS(string chain, string to, string tokenid, string contractaddress, string account, string signatureid, int index)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"account\":" + "\"" + account + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"transaction", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }









        public async Task<Nft> MintMultipleNftCelo(string chain, string tokenid, string to, string contractaddress, string url, string[] authoraddresses, string cashbackvalues, string fromprivatekey, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"url\":" + "\"" + url + "" + "\",\"authorAddresses\":[" + "\"" + authoraddresses + "" + "\"],\"cashbackValues\":[" + "\"" + cashbackvalues + "" + "\"],\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint/batch", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> MintMultipleNftKMSCelo(string chain, string tokenid, string to, string contractaddress, string url, string[] authoraddresses, string cashbackvalues, string index, string signatureid, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"url\":" + "\"" + url + "" + "\",\"authorAddresses\":[" + "\"" + authoraddresses + "" + "\"],\"cashbackValues\":[" + "\"" + cashbackvalues + "" + "\"],\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint/batch", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> MintMultipleNftTron(string chain, string tokenid, string to, string contractaddress, string url, string fromprivatekey, string feelimit)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"url\":" + "\"" + url + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeLimit\":" + "\"" + feelimit + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint/batch", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> MintMultipleNftKMSTron(string chain, string tokenid, string to, string contractaddress, string url, string index, string signatureid, string feelimit)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"url\":" + "\"" + url + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeLimit\":" + "\"" + feelimit + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint/batch", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }


        public async Task<Nft> MintMultipleNft(string chain, string tokenid, string to, string contractaddress, string url, string[] authoraddresses, string cashbackvalues, string fromPrivateKey, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"url\":" + "\"" + url + "" + "\",\"authorAddresses\":[" + "\"" + authoraddresses + "" + "\"],\"cashbackValues\":[" + "\"" + cashbackvalues + "" + "\"]\"fromPrivateKey\":" + "\"" + fromPrivateKey + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint/batch", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> MintMultipleNftKMS(string chain, string tokenid, string to, string contractaddress, string url, string[] authoraddresses, string cashbackvalues, string index, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"to\":" + "\"" + to + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"url\":" + "\"" + url + "" + "\",\"authorAddresses\":[" + "\"" + authoraddresses + "" + "\"],\"cashbackValues\":[" + "\"" + cashbackvalues + "" + "\"],\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint/batch", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }


        public async Task<Nft> MintMultipleNftFlowPK(string chain, string to, string url, string contractaddress, string account, string fromprivatekey)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"url\":" + "\"" + url + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"account\":" + "\"" + account + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint/batch", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }
        public async Task<Nft> MintMultipleNftFlowMnemonic(string chain, string to, string url, string contractaddress, string account, string mnemonic, int index)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"url\":" + "\"" + url + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"account\":" + "\"" + account + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"index\":" + "\"" + index + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint/batch", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }
        public async Task<Nft> MintMultipleNftFlowKMS(string chain, string to, string url, string contractaddress, string account, string signatureid, int index)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"to\":" + "\"" + to + "" + "\",\"url\":" + "\"" + url + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"account\":" + "\"" + account + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"index\":" + "\"" + index + "" + "\"}";
            var stringResult = await PostSecureRequest($"mint/batch", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }








        public async Task<Nft> BurnNftCelo(string chain, string tokenid, string contractaddress, string fromprivatekey, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";

            var stringResult = await PostSecureRequest($"burn", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> BurnNftKmsCelo(string chain, string tokenid, string contractaddress, int index, string signatureid, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";

            var stringResult = await PostSecureRequest($"burn", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> BurnNftTron(string chain, string tokenid, string contractaddress, string fromprivatekey, string feelimit)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeLimit\":" + "\"" + feelimit + "" + "\"}";

            var stringResult = await PostSecureRequest($"burn", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> BurnNftKmsTron(string chain, string account, string tokenid, string contractaddress, int index, string signatureid, string feelimit)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeLimit\":" + "\"" + feelimit + "" + "\"}";

            var stringResult = await PostSecureRequest($"burn", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }


        public async Task<Nft> BurnNft(string chain, string tokenid, string contractaddress, string fromprivatekey, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";

            var stringResult = await PostSecureRequest($"burn", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> BurnNftKms(string chain, string tokenid, string contractaddress, int index, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";

            var stringResult = await PostSecureRequest($"burn", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }


        public async Task<Nft> BurnNftFlowPk(string chain, string tokenid, string contractaddress, string account, string fromprivatekey)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"account\":" + "\"" + account + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\"}";

            var stringResult = await PostSecureRequest($"burn", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }
        public async Task<Nft> BurnNftFlowMnemonic(string chain, string tokenid, string contractaddress, string account, string mnemonic, int index)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"account\":" + "\"" + account + "" + "\",\"mnemonic\":" + "\"" + mnemonic + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"burn", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }
        public async Task<Nft> BurnNftFlowKms(string chain, string tokenid, string contractaddress, string account, string signatureid, int index)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"account\":" + "\"" + account + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"index\":" + "\"" + index + "" + "\"}";

            var stringResult = await PostSecureRequest($"burn", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }









        public async Task<Nft> UpdateCashbackValueForAuthorNftCelo(string chain, string tokenid, string cashbackvalue, string contractaddress, string fromprivatekey, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"cashbackValue\":" + "\"" + cashbackvalue + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";

            var stringResult = await PUTSecureRequest($"royalty", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> UpdateCashbackValueForAuthorNftKMSCelo(string chain, string tokenid, string cashbackvalue, string contractaddress, int index, string signatureid, string feecurrency)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"cashbackValue\":" + "\"" + cashbackvalue + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeCurrency\":" + "\"" + feecurrency + "" + "\"}";

            var stringResult = await PUTSecureRequest($"royalty", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> UpdateCashbackValueForAuthorNftTron(string chain, string tokenid, string cashbackvalue, string contractaddress, string fromprivatekey, string feelimit)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"cashbackValue\":" + "\"" + cashbackvalue + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"feeLimit\":" + "\"" + feelimit + "" + "\"}";

            var stringResult = await PUTSecureRequest($"royalty", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> UpdateCashbackValueForAuthorNftKMSTron(string chain, string account, string tokenid, string cashbackvalue, string contractaddress, int index, string signatureid, string feelimit)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"account\":" + "\"" + account + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"cashbackValue\":" + "\"" + cashbackvalue + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"feeLimit\":" + "\"" + feelimit + "" + "\"}";

            var stringResult = await PUTSecureRequest($"royalty", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }


        public async Task<Nft> UpdateCashbackValueForAuthorNft(string chain, string tokenid, string cashbackvalue, string contractaddress, string fromprivatekey, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"cashbackValue\":" + "\"" + cashbackvalue + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"fromPrivateKey\":" + "\"" + fromprivatekey + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";

            var stringResult = await PUTSecureRequest($"royalty", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
        }

        public async Task<Nft> UpdateCashbackValueForAuthorNftKMS(string chain, string tokenid, string cashbackvalue, string contractaddress, int index, string signatureid, string gaslimit, string gasprice)
        {
            string parameters = "{\"chain\":" + "\"" + chain + "" + "\",\"tokenId\":" + "\"" + tokenid + "" + "\",\"cashbackValue\":" + "\"" + cashbackvalue + "" + "\",\"contractAddress\":" + "\"" + contractaddress + "" + "\",\"index\":" + "\"" + index + "" + "\",\"signatureId\":" + "\"" + signatureid + "" + "\",\"gasLimit\":" + "\"" + gaslimit + "" + "\",\"gasPrice\":" + "\"" + gasprice + "" + "\"}";

            var stringResult = await PUTSecureRequest($"royalty", parameters);

            var result = JsonConvert.DeserializeObject<Nft>(stringResult);

            return result;
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