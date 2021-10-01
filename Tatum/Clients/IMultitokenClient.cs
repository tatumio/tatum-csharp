using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IMultitokenClient
/// </summary>
/// 
namespace Tatum
{
    public interface IMultitokenClient
    {
        Task<MultiToken> DeployMultiToken(string chain, string uri, string fromprivatekey, string gaslimit,string gasprice);
        Task<MultiToken> DeployMultiTokenKMS(string chain, string uri, string signatureid, string gaslimit, string gasprice);
        Task<MultiToken> DeployMultiTokenCelo(string chain, string uri, string fromprivatekey, string feecurrency);
        Task<MultiToken> DeployMultiTokenCeloKMS(string chain, string uri, string signatureid, string feecurrency);


        Task<MultiToken> MintMultiToken(string chain, string tokenid, string to, string contractaddress, string amount,string data,int index,string signatureid,string gaslimit,string gasprice);
        Task<MultiToken> MintMultiTokenKMS(string chain, string tokenid, string to, string contractaddress, string amount, string data, int index, string signatureid, string gaslimit, string gasprice);
        Task<MultiToken> MintMultiTokenCelo(string chain, string tokenid, string to, string contractaddress, string amount, string data,string fromprivatekey, string feecurrency);
        Task<MultiToken> MintMultiTokenKMSCelo(string chain, string tokenid, string to, string contractaddress, string amount, string data, int index, string signatureid, string feecurrency);


        Task<MultiToken> MintMultiTokenBatch(string chain, string tokenid, string to, string contractaddress, string amounts,  string fromprivatekey, string gaslimit, string gasprice);
        Task<MultiToken> MintMultiTokenBatchKMS(string chain, string tokenid, string to, string contractaddress, string amounts, string data, int index, string signatureid, string gaslimit, string gasprice);
        Task<MultiToken> MintMultiTokenBatchCelo(string chain, string tokenid, string to, string contractaddress, string amounts, string fromprivatekey, string feecurrency);
        Task<MultiToken> MintMultiTokenBatchKMSCelo(string chain, string tokenid, string to, string contractaddress, string amounts, string data, int index, string signatureid, string feecurrency);



        Task<MultiToken> BurnMultiToken(string chain,string account, string tokenid,  string contractaddress, string fromprivatekey,string data, string amount, string gaslimit, string gasprice);
        Task<MultiToken> BurnMultiTokenKMS(string chain, string account, string tokenid, string amount,string data, string contractaddress, int index, string signatureid,  string gaslimit, string gasprice);
        Task<MultiToken> BurnMultiTokenCelo(string chain, string account, string tokenid, string amount, string contractaddress, string fromprivatekey, string feecurrency);
        Task<MultiToken> BurnMultiTokenKMSCelo(string chain, string account, string tokenid, string amount, string data, string contractaddress, int index, string signatureid, string gaslimit, string gasprice);


        Task<MultiToken> BurnMultiTokenBatch(string chain, string account, string tokenid,string amounts,string data, string contractaddress, string fromprivatekey, string gaslimit, string gasprice);
        Task<MultiToken> BurnMultiTokenBatchKMS(string chain, string account, string tokenid, string amounts, string data, string contractaddress,int index, string signatureid, string gaslimit, string gasprice);
        Task<MultiToken> BurnMultiTokenBatchCelo(string chain, string account, string tokenid, string amounts, string contractaddress, string fromprivatekey, string feecurrency);
        Task<MultiToken> BurnMultiTokenBatchKMSCelo(string chain, string account, string tokenid, string amounts, string contractaddress,int index, string signatureid, string feecurrency);



        Task<MultiToken> TransferMultiToken(string chain, string to, string tokenid, string amount, string data, string contractaddress, string fromprivatekey, string gaslimit, string gasprice);
        Task<MultiToken> TransferMultiTokenCelo(string chain, string to, string tokenid, string amount, string data, string contractaddress, string fromprivatekey, string feecurrency);
        Task<MultiToken> TransferMultiTokenKMS(string chain, string to, string tokenid, string amount, string data, string contractaddress,int index, string signatureid, string gaslimit, string gasprice);
        Task<MultiToken> TransferMultiTokenKMSCelo(string chain, string to, string tokenid, string amount, string data, string contractaddress, int index, string signatureid, string feecurrency);



        Task<MultiToken> TransferMultiTokenBatch(string chain, string to, string tokenid, string[] amounts, string data, string contractaddress, string fromprivatekey, string gaslimit, string gasprice);
        Task<MultiToken> TransferMultiTokenBatchKMS(string chain, string to, string tokenid, string[] amounts, string data, string contractaddress, int index, string signatureid, string gaslimit, string gasprice);
        Task<MultiToken> TransferMultiTokenBatchCelo(string chain, string to, string tokenid, string[] amounts, string data, string contractaddress, string fromprivatekey, string feecurrency);
        Task<MultiToken> TransferMultiTokenBatchKMSCelo(string chain, string to, string tokenid, string[] amounts, string data, string contractaddress, int index, string signatureid, string feecurrency);



        Task<MultiToken> GetContractAddress(string chain, string hash);
        Task<MultiToken> GetTransaction(string chain, string hash);
        Task<MultiToken> GetMultiTokenAccountBalance(string chain, string address,string contractaddress,string tokenid);
        Task<MultiToken> GetMultiTokenAccountBatchBalance(string chain, string contractaddress,string tokenid,string address);
        Task<MultiToken> GetMultiTokenMetadata(string chain,string token, string contractaddress);















    }
}