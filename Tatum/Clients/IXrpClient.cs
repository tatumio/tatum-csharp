using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IXrpClient
/// </summary>
namespace Tatum
{
    public interface IXrpClient
    {
        Task<Xrp> GenerateXrpAccount();

        Task<Xrp> GenerateXrpBlockchainInfo();
        Task<Xrp> GetXrpBlockchainFee();
        Task<Xrp> GetAccountTransactions(string account);
        Task<Xrp> GetLedger(int i);
        Task<Xrp> GetXrpTransactionByHash(string hash);
        Task<Xrp> GetAccountInfo(string account);
        Task<Xrp> GetAccountBalance(string account);
        



        Task<Xrp> SendXrpBlockchain(string fromaccount, string to, string amount, string fromsecret, string fee, string sourceTag,string destinationTag);
        Task<Xrp> SendXrpBlockchainAsset(string fromaccount, string to, string amount, string fromsecret, string fee, string sourceTag, string destinationTag,string issuerAccount,string token);
        Task<Xrp> SendXrpBlockchainKMS(string fromaccount, string to, string amount, string signatureid, string fee, string sourceTag, string destinationTag);
        Task<Xrp> SendXrpBlockchainAssetKMS(string fromaccount, string to, string amount, string signatureid, string fee, string sourceTag, string destinationTag, string issuerAccount, string token);


        Task<Xrp> CreateTrustLineXrpBlockchain(string fromaccount, string issueraccount, string limit, string token,string signatureId,string fee);
        Task<Xrp> CreateTrustLineXrpBlockchainKMS(string fromaccount, string issueraccount, string limit,string token, string fromsecret, string fee);
        


        Task<Xrp> AddFlowCreateAddressFromPubKeyMnemonic(string account, string publickey, string mnemonic, int index);
        Task<Xrp> AddFlowCreateAddressFromPubKeySecret(string account, string publickey, string privatekey);
        Task<Xrp> AddFlowCreateAddressFromPubKeyKMS(string account, string publickey, string signatureid, int index);



        Task<Xrp> ModifyAccountSettingsXrpBlockchain(string fromAccount, string fromSecret, string fee, bool rippling,string requireDestinationTag);
        Task<Xrp> ModifyAccountSettingsXrpBlockchainKMS(string fromAccount, string signatureid, string fee, bool rippling, string requireDestinationTag);


        Task<Xrp> BroadcastSignedXrpTransaction(string txData, string signatureid);


    }
}