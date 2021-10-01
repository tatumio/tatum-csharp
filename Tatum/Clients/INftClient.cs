using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for INftClient
/// </summary>
/// 

namespace Tatum
{
    public interface INftClient
    {
        Task<Nft> DeployNftCelo(string chain,string name,string symbol,string fromprivatekey,string feecurrency);
        Task<Nft> DeployNftCeloKMS(string chain, string name, string symbol,int index, string signatureid, string feecurrency);
        Task<Nft> DeployNftTron(string chain, string name, string symbol, string fromprivatekey, string feelimit);
        Task<Nft> DeployNftTronKMS(string chain,string account, string name, string symbol, int index, string signatureid, string feelimit);
        Task<Nft> DeployNft(string chain, string name, string symbol, string fromprivatekey, string gaslimit,string gasprice);
        Task<Nft> DeployNftKMS(string chain, string name, string symbol, int index, string signatureid, string gaslimit, string gasprice);
        Task<Nft> DeployNftFlowPK(string chain, string account,string fromprivatekey);
        Task<Nft> DeployNftFlowMnemonic(string chain, string account, string mnemonic,int index);
        Task<Nft> DeployNftFlowKMS(string chain, string account, string signatureid, int index);


        Task<Nft> MintNftCelo(string chain, string tokenid, string to, string contractaddress, string url,string[] authoraddresses,string cashbackvalues,string fromprivatekey,string feecurrency);
        Task<Nft> MintNftKMSCelo(string chain, string tokenid, string to, string contractaddress, string url, string[] authoraddresses, string cashbackvalues,string index, string signatureid, string feecurrency);
        Task<Nft> MintNftTron(string chain, string tokenid, string to, string contractaddress, string url, string[] authoraddresses, string cashbackvalues, string fromprivatekey, string feelimit);
        Task<Nft> MintNftKMSTron(string chain, string tokenid, string to, string contractaddress, string url, string[] authoraddresses, string cashbackvalues, string index, string signatureid, string feelimit);
        Task<Nft> MintNft(string chain, string tokenid, string to, string contractaddress, string url, string[] authoraddresses, string cashbackvalues, string index, string signatureid, string gaslimit,string gasprice);
        Task<Nft> MintNftKMS(string chain, string tokenid, string to, string contractaddress, string url, string[] authoraddresses, string cashbackvalues, string index, string signatureid, string gaslimit, string gasprice);
        Task<Nft> MintNftFlowPK(string chain,string to, string url, string contractaddress,string account, string fromprivatekey);
        Task<Nft> MintNftFlowMnemonic(string chain, string to, string url, string contractaddress, string account, string mnemonic,int index);
        Task<Nft> MintNftFlowKMS(string chain, string to, string url, string contractaddress, string account, string signatureid, int index);


        Task<Nft> TransferNft(string value, string chain, string to, string tokenid, string contractaddress,string fromprivatekey,string gaslimit,string gasprice);
        Task<Nft> TransferNftCelo(string value, string chain, string to, string tokenid, string contractaddress, string fromprivatekey, string feecurrency);
        Task<Nft> TransferNftTron(string value, string chain, string to, string tokenid, string contractaddress, string fromprivatekey, string feelimit);
        Task<Nft> TransferNftKMS(string value, string chain, string to, string tokenid, string contractaddress,int index, string signatureid, string gaslimit,string gasprice);
        Task<Nft> TransferNftKMSCelo(string value, string chain, string to, string tokenid, string contractaddress, int index, string signatureid, string feecurrency);
        Task<Nft> TransferNftKMSTron(string value, string chain,string account, string to, string tokenid, string contractaddress, int index, string signatureid, string feelimit);
        Task<Nft> TransferNftFlowPK( string chain, string to, string tokenid, string contractaddress,  string account, string privatekey);
        Task<Nft> TransferNftFlowMnemonic(string chain, string to, string tokenid, string contractaddress, string account, string mnemonic,int index);
        Task<Nft> TransferNftFlowKMS(string chain, string to, string tokenid, string contractaddress, string account, string signatureid, int index);






        Task<Nft> MintMultipleNftCelo(string chain, string tokenid, string to, string contractaddress, string url, string[] authoraddresses, string cashbackvalues, string fromprivatekey, string feecurrency);
        Task<Nft> MintMultipleNftKMSCelo(string chain, string tokenid, string to, string contractaddress, string url, string[] authoraddresses, string cashbackvalues, string index, string signatureid, string feecurrency);
        Task<Nft> MintMultipleNftTron(string chain, string tokenid, string to, string contractaddress, string url, string fromprivatekey, string feelimit);
        Task<Nft> MintMultipleNftKMSTron(string chain, string tokenid, string to, string contractaddress, string url, string index, string signatureid, string feelimit);
        Task<Nft> MintMultipleNft(string chain, string tokenid, string to, string contractaddress, string url, string[] authoraddresses, string cashbackvalues, string fromPrivateKey, string gaslimit, string gasprice);
        Task<Nft> MintMultipleNftKMS(string chain, string tokenid, string to, string contractaddress, string url, string[] authoraddresses, string cashbackvalues, string index, string signatureid, string gaslimit, string gasprice);
        Task<Nft> MintMultipleNftFlowPK(string chain, string to, string url, string contractaddress, string account, string fromprivatekey);
        Task<Nft> MintMultipleNftFlowMnemonic(string chain, string to, string url, string contractaddress, string account, string mnemonic, int index);
        Task<Nft> MintMultipleNftFlowKMS(string chain, string to, string url, string contractaddress, string account, string signatureid, int index);



        Task<Nft> BurnNftCelo(string chain, string tokenid,  string contractaddress, string fromprivatekey,  string feecurrency);
        Task<Nft> BurnNftKmsCelo(string chain, string tokenid, string contractaddress, int index, string signatureid, string feecurrency);
        Task<Nft> BurnNftTron(string chain, string tokenid, string contractaddress, string fromprivatekey, string feelimit);
        Task<Nft> BurnNftKmsTron(string chain,string account, string tokenid, string contractaddress,int index, string signatureid, string feelimit);
        Task<Nft> BurnNft(string chain, string tokenid, string contractaddress, string fromprivatekey, string gaslimit,string gasprice);
        Task<Nft> BurnNftKms(string chain, string tokenid, string contractaddress, int index, string signatureid, string gaslimit,string gasprice);
        Task<Nft> BurnNftFlowPk(string chain, string tokenid, string contractaddress,string account, string fromprivatekey);
        Task<Nft> BurnNftFlowMnemonic(string chain, string tokenid, string contractaddress, string account, string mnemonic,int index);
        Task<Nft> BurnNftFlowKms(string chain, string tokenid, string contractaddress, string account, string signatureid, int index);




        Task<Nft> UpdateCashbackValueForAuthorNftCelo(string chain, string tokenid, string cashbackvalue, string contractaddress, string fromprivatekey,string feecurrency);
        Task<Nft> UpdateCashbackValueForAuthorNftKMSCelo(string chain, string tokenid, string cashbackvalue, string contractaddress,int index, string signatureid, string feecurrency);
        Task<Nft> UpdateCashbackValueForAuthorNftTron(string chain, string tokenid, string cashbackvalue, string contractaddress, string fromprivatekey, string feelimit);
        Task<Nft> UpdateCashbackValueForAuthorNftKMSTron(string chain,string account, string tokenid, string cashbackvalue, string contractaddress, int index, string signatureid, string feelimit);
        Task<Nft> UpdateCashbackValueForAuthorNft(string chain, string tokenid, string cashbackvalue, string contractaddress, string fromprivatekey, string gaslimit,string gasprice);
        Task<Nft> UpdateCashbackValueForAuthorNftKMS(string chain, string tokenid, string cashbackvalue, string contractaddress,int index, string signatureid, string gaslimit,string gasprice);



        Task<Nft> GetContractAddressFromTransaction(string chain, string hash);
        Task<Nft> GetTransaction(string chain, string hash);
        Task<Nft> GetNftAccountBalance(string chain, string address,string contractAddress);
        Task<Nft> GetNftTokenMetadata(string chain, string token, string contractAddress,string account);
        Task<Nft> GetNftTokenRoyaltyInfo(string chain, string token, string contractAddress);








    }

}