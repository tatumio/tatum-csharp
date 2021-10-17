using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

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
        
        Task<QTUM> GetUTXO(string address);
        Task<QTUM> GetQtumAccountBalance(string address);
        Task<QTUM> GetQtumTransaction(string id);
        Task<QTUM> GetQtumTransactionsByAddress(string address, int pageSize = 50, int offset = 0);
        Task<QTUM> GetQtumEstimatedGasFees(string nblocks);
        Task<QTUM> GetQtumEstimatedGasFeesByte(string nblocks);

       


        Task<TransactionHash> Broadcast(BroadcastRequest request);
        Task<BitcoinUtxo> GetUtxo(string txHash, int txOutputIndex);
        Task<List<BitcoinTx>> GetTxForAccount(string address, int pageSize = 50, int offset = 0);
        Task<string> SignKmsTransaction(TransactionKms tx, List<string> privateKeys, bool testnet);

        /// <summary>
        /// Sign Bitcoin transaction with private keys locally. Nothing is broadcasted to the blockchain.
        /// </summary>        
        /// <param name="body">content of the transaction to broadcast</param>
        /// <param name="testnet">testnet or mainnet version</param>
        /// <returns>Transaction data to be broadcast to blockchain.</returns>
        Task<string> PrepareSignedTransaction(TransferBtcBasedBlockchain body, bool testnet);

        /// <summary>
        /// Send Bitcoin transaction to the blockchain. This method broadcasts signed transaction to the blockchain.
        /// This operation is irreversible.
        /// </summary>
        /// <param name="body">content of the transaction to broadcast</param>
        /// <param name="testnet">testnet or mainnet version</param>
        /// <returns>transaction id of the transaction in the blockchain</returns>
        Task<TransactionHash> SendTransaction(TransferBtcBasedBlockchain body, bool testnet);

    }
}