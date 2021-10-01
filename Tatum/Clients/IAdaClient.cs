using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IAdaClient
/// </summary>
/// 
namespace Tatum
{
    public interface IAdaClient
    {
        Task<Ada> GetBlockchainInfo();
        Task<Ada> GenerateAdaWallet(string mnemonic);
        Task<Ada> GenerateAdaFromExtendedPublicKey(string xpub,int index);
        Task<Ada> GenerateAdaPrivateKey(int index,string mnemonic);
        Task<Ada> GetBlockByHeight(string hash);
        Task<Ada> GetTransactionByHash(string hash);
        Task<Ada> GetTransactionsByAddress(string address,int pagesize=50,int offset=0);


        Task<Ada> SendAdaTransactionFromAddress(string fromAddress, string privateKey, string toAddress, double value);
        Task<Ada> SendAdaTransactionFromAddressKMS(string signatureId, string privateKey, string toAddress, double value);
        Task<Ada> SendAdaTransactionFromUTXO(string txHash, int index, string privateKey, string toAddress, string value);
        Task<Ada> SendAdaTransactionFromUTXOKMS(string txHash, int index, string signatureId, string toAddress, string value);

        Task<Ada> BroadcastSignedAdaTransaction(string txData, string signatureId);

        Task<Ada> GetAdaAccountByAddress(string address);
    }
}