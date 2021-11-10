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
        Wallets CreateWallet(string keyinput, bool testnet);
        Task<neo> GenerateCurrentNeoBlock();
        Task<neo> GenerateNeoBlock(string hash);
        Task<neo> GenerateNeoAccountBalance(string address);
        Task<neo> GenerateNeoAssetDetails(string asset);
        Task<neo> GenerateNeoUnspentTransactionOutput(string txId,int index);
        Task<List<neo>> GenerateNeoTransactions(string address);
        Task<neo> GetNeoContractDetails(string scriptHash);
        Task<neo> GetNeoTransactionByHash(string hash);


        Task<neo> SendNeoAsset(string to,int Neo,int gas,string fromprivatekey);
        Task<neo> ClaimGas(string privatekey);
        Task<neo> SendNeoSmartContractTokens(string numOfdecimals, int additionalInvocationGas, int amount, string scriptHash,string to,string fromPrivateKey);
        Task<neo> BroadcastSignedNeoTransaction(string txdata);
    }
}