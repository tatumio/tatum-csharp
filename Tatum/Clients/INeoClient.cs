using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for INeoClient
/// </summary>
/// 
namespace Tatum
{
    public interface INeoClient
    {
        Task<Neo> GenerateNeoAccount();
        Task<Neo> GenerateCurrentNeoBlock();
        Task<Neo> GenerateNeoBlock(string hash);
        Task<Neo> GenerateNeoAccountBalance(string address);
        Task<Neo> GenerateNeoAssetDetails(string asset);
        Task<Neo> GenerateNeoUnspentTransactionOutput(string txId,int index);
        Task<List<Neo>> GenerateNeoTransactions(string address);
        Task<Neo> GetNeoContractDetails(string scriptHash);
        Task<Neo> GetNeoTransactionByHash(string hash);


        Task<Neo> SendNeoAsset(string to,int Neo,int gas,string fromprivatekey);
        Task<Neo> ClaimGas(string privatekey);
        Task<Neo> SendNeoSmartContractTokens(string numOfdecimals, int additionalInvocationGas, int amount, string scriptHash,string to,string fromPrivateKey);
        Task<Neo> BroadcastSignedNeoTransaction(string txdata);
    }
}