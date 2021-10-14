using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IXlmClient
/// </summary>
/// 

namespace Tatum
{
    public interface IXlmClient
    {

        Wallets CreateWallet(string secret = null);
        Task<Xlm> GenerateXlmBlockchain();
        Task<Xlm> GetXlmBlockchainLedger(string sequence);
        Task<Xlm> GetXlmBlockchainTransactions(string sequence);
        Task<Xlm> GetActualXlmFee();
        Task<Xlm> GetXlmAccountTransaction(string account,string pagination);
        Task<Xlm> GetXlmTransactionByHash(string hash);
        Task<Xlm> GetXlmAccountInfo(string account);

        Task<Xlm> SendTransferXlmBlockchain(string fromaccount,string to,string amount,string fromsecret,bool initialize,string message);
        Task<Xlm> SendTransferXlmBlockchainAsset(string fromaccount, string to, string amount, string fromsecret, bool initialize, string token,string issuerAccount,string message);
        Task<Xlm> SendTransferXlmBlockchainKMS(string fromaccount, string to, string amount, string signatureid, bool initialize, string message);
        Task<Xlm> SendTransferXlmBlockchainKMSAsset(string fromaccount, string to, string amount, string signatureid, bool initialize, string token, string issuerAccount, string message);



        Task<Xlm> CreateTrustLineXlmBlockchain(string fromaccount, string issuerAccount, string token, string fromsecret,string limit);

        Task<Xlm> CreateTrustLineXlmBlockchainKMS(string fromaccount, string issuerAccount, string token, string signatureid, string limit);


        Task<Xlm> BroadcastSignedXlmTransaction(string txData, string signatureid);



    }
}