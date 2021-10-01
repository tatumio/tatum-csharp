using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IBitcoinClient
/// </summary>
namespace Tatum
{
    public interface IBitcoinClient
    {
        Task<Bitcoin> GenerateBitcoinWallet(string mnemonic);

        Task<Bitcoin> GenerateBitcoinDepositAddressFromPublicKey(string xpub,int index);
        Task<Bitcoin> GenerateBitcoinPrivateKey(string index, int mnemonic);
        Task<Bitcoin> GetBlockchainInfo();
        Task<Bitcoin> GetBlockHash(int i);
        Task<Bitcoin> GetBlockByHash(string hash);
        Task<Bitcoin> GetTransactionByHash(string hash);

        Task<Bitcoin> GetMempoolTransaction();
        Task<List<Bitcoin>> GetCustomerAccounts(string address, int pageSize = 50, int offset = 0);
        Task<Bitcoin> GetBalanceOfAddress(string address);
        Task<Bitcoin> GetUTXOtransaction(string hash, int index);

        Task<Bitcoin> SendBtcTransactionFromAddress(string fromAddress, string privateKey,string toAddress,double value);
        Task<Bitcoin> SendBtcTransactionFromAddressKMS(string signatureId, string privateKey, string toAddress, double value);
        Task<Bitcoin> SendBtcTransactionFromUTXO(string txHash, int index, string privateKey, string toAddress,string value);
        Task<Bitcoin> SendBtcTransactionFromUTXOKMS(string txHash, int index, string signatureId, string toAddress, string value);

        Task<Bitcoin> BroadcastSignedBitcoinTransaction(string txData, string signatureId);

    }
}