using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

/// <summary>
/// Summary description for ILitecoinClient
/// </summary>
namespace Tatum
{
    public interface ILitecoinClient
    {
        Wallets CreateWallet(string mnemonic, bool testnet);
        String GeneratePrivateKey(string mnemonic, int index, bool testnet);
        String GenerateAddress(string xPubString, int index, bool testnet);


        Task<Litecoin> GetLitecoinBlockchainInfo();
        Task<Litecoin> GetLitecoinBlockHash(int i);
        Task<Litecoin> GetLitecoinBlockByHash(string hash);
        Task<Litecoin> GetLitecoinTransactionByHash(string hash);
        Task<List<Litecoin>> GetMempoolTransactions();
     
        Task<Litecoin> GetLitecoinBalanceOfAddress(string address);





        Task<LitecoinUtxo> GetUtxo(string txHash, int txOutputIndex);
        Task<List<LitecoinTx>> GetTxForAccount(string address, int pageSize = 50, int offset = 0);

        Task<string> SignKmsTransaction(TransactionKms tx, List<string> privateKeys, bool testnet);

        /// <summary>
        /// Sign Litecoin transaction with private keys locally. Nothing is broadcasted to the blockchain.
        /// </summary>        
        /// <param name="body">content of the transaction to broadcast</param>
        /// <param name="testnet">testnet or mainnet version</param>
        /// <returns>Transaction data to be broadcast to blockchain.</returns>
        Task<string> PrepareSignedTransaction(TransferBtcBasedBlockchain body, bool testnet);

        /// <summary>
        /// Send Litecoin transaction to the blockchain. This method broadcasts signed transaction to the blockchain.
        /// This operation is irreversible.
        /// </summary>
        /// <param name="body">content of the transaction to broadcast</param>
        /// <param name="testnet">testnet or mainnet version</param>
        /// <returns>transaction id of the transaction in the blockchain</returns>
        Task<TransactionHash> SendTransaction(TransferBtcBasedBlockchain body, bool testnet);

      
        Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request);

    }
}