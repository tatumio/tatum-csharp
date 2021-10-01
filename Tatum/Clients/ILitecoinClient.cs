using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for ILitecoinClient
/// </summary>
namespace Tatum
{
    public interface ILitecoinClient
    {
        Task<Litecoin> GenerateLitecoinWallet(string mnemonic);

       
        Task<Litecoin> GetLitecoinBlockchainInfo();
        Task<Litecoin> GetLitecoinBlockHash(int i);
        Task<Litecoin> GetLitecoinBlockByHash(string hash);
        Task<Litecoin> GetLitecoinTransactionByHash(string hash);
        Task<List<Litecoin>> GetMempoolTransactions();
        Task<List<Litecoin>> GetLitecoinTransactionsByAddress(string address);
        Task<Litecoin> GetLitecoinBalanceOfAddress(string address);
        Task<Litecoin> GetLitecoinUTXOTransaction(string hash,int index);
        Task<Litecoin> GenerateLitecoinDepositAddressFromPublicKey(string xpub, int index);
        Task<Litecoin> GenerateLitecoinPrivateKey(string index, int mnemonic);


        Task<Litecoin> SendLitecoinTransactionAddress(string fromaddress, string privateKey, string toAddress, string value);
        Task<Litecoin> SendLitecoinTransactionAddressKMS(string fromaddress,string signatureId, string toAddress, string value);
        Task<Litecoin> SendLitecoinTransactionUTXO(string txHash,int index, string privateKey, string toAddress, string value);
        Task<Litecoin> SendLitecoinTransactionUTXOKMS(string txHash, int index, string signatureId, string toAddress, string value);

        Task<Litecoin> BroadcastSignedLitecoinTransaction(string txData, string signatureId);

    }
}