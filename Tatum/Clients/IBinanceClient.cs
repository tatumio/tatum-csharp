using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IBinanceClient
/// </summary>
/// 

namespace Tatum
{
    public interface IBinanceClient
    {
        Task<Binance> GenerateBinanceWallet();
        Task<Binance> GetBinanceCurrentBlock();
        Task<Binance> GetBinanceTransactionsBlock(int height);
        Task<Binance> GetBinanceAccount(string address);
        Task<Binance> GetBinanceTransaction(string hash);

        Task<Binance> TransferBnbBlockchain(string to, string currency,string amount, string fromprivateKey, string message);
        Task<Binance> TransferBnbBlockchainKMS(string to, string currency, string amount, string signatureid,string fromaddress, string message);

        Task<Binance> BroadcastSignedBnbTransaction(string txdata);
    }
}