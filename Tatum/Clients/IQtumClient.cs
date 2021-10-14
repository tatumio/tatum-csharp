using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IQtumClient
/// </summary>
/// 

namespace Tatum
{
    public interface IQtumClient
    {

        Wallets CreateWallet(string mnemonic, bool testnet);
        String GeneratePrivateKey(string mnemonic, int index, bool testnet);
        String GenerateAddress(string xPubString, int index, bool testnet);
       
        Task<QTUM> Web3HttpDriver(string xapikey);
        Task<QTUM> GetCurrentBlockNumber();
        Task<QTUM> GetQtumBlockByHash(string hash);
        Task<QTUM> GenerateQtumAddressFromPrivateKey(string key);
        Task<QTUM> GetUTXO(string address);
        Task<QTUM> GetQtumAccountBalance(string address);
        Task<QTUM> GetQtumTransaction(string id);
        Task<QTUM> GetQtumTransactionsByAddress(string address, int pageSize = 50, int offset = 0);
        Task<QTUM> GetQtumEstimatedGasFees(string nblocks);
        Task<QTUM> GetQtumEstimatedGasFeesByte(string nblocks);

        Task<QTUM> BroadcastSignedQtumTransaction(string txData, string signatureId);


    }
}