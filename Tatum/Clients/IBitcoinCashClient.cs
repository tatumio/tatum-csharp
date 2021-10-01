using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IBitcoinCashClient
/// </summary>
namespace Tatum
{
    public interface IBitcoinCashClient
    {
        Task<BitcoinCash> GenerateBitcoinCashWallet(string mnemonic);

        Task<BitcoinCash> GenerateBitcoinCashDepositAddressFromPublicKey(string xpub, int index);
        Task<BitcoinCash> GenerateBitcoinCashPrivateKey(string index, int mnemonic);
        Task<BitcoinCash> GetBitcoinCashBlockchainInfo();
        Task<BitcoinCash> GetBitcoinCashBlockHash(int i);
        Task<BitcoinCash> GetBitcoinCashBlockByHash(string hash);
        Task<BitcoinCash> GetBitcoinCashTransactionByHash(string hash);
        Task<List<BitcoinCash>> GetBitcoinCashTransactionByAddress(string address);

        
        Task<BitcoinCash> SendBitcoinCashTransactionFromUTXO(string txHash, int index, string privateKey, string toAddress, string value);
        Task<BitcoinCash> SendBitcoinCashTransactionFromUTXOKMS(string txHash, int index, string signatureId, string toAddress, string value);

        Task<BitcoinCash> BroadcastSignedBitcoinCashTransaction(string txData, string signatureId);

    }
}