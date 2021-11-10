using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

/// <summary>
/// Summary description for IDogecoinClient
/// </summary>
namespace Tatum
{
    public interface IDogecoinClient
    {
        Wallets CreateWallet(string mnemonic, bool testnet);
        String GeneratePrivateKey(string mnemonic, int index, bool testnet);
        String GenerateAddress(string xPubString, int index, bool testnet);


        Task<Dogecoin> GetDogecoinBlockchainInfo();
        Task<Dogecoin> GetDogecoinBlockHash(int i);
        Task<Dogecoin> GetDogecoinBlockByHash(string hash);
        Task<Dogecoin> GetDogecoinTransactionByHash(string hash);
        Task<List<Dogecoin>> GetMempoolTransactions();

        Task<DogecoinUtxo> GetUtxo(string txHash, int txOutputIndex);
        Task<List<DogecoinTx>> GetTxForAccount(string address, int pageSize = 50, int offset = 0);
      

        Task<string> SignKmsTransaction(TransactionKms tx, List<string> privateKeys, bool testnet);

        /// <summary>
        /// Sign Dogecoin transaction with private keys locally. Nothing is broadcasted to the blockchain.
        /// </summary>        
        /// <param name="body">content of the transaction to broadcast</param>
        /// <param name="testnet">testnet or mainnet version</param>
        /// <returns>Transaction data to be broadcast to blockchain.</returns>
        Task<string> PrepareSignedTransaction(TransferBtcBasedBlockchain body, bool testnet);

        /// <summary>
        /// Send Dogecoin transaction to the blockchain. This method broadcasts signed transaction to the blockchain.
        /// This operation is irreversible.
        /// </summary>
        /// <param name="body">content of the transaction to broadcast</param>
        /// <param name="testnet">testnet or mainnet version</param>
        /// <returns>transaction id of the transaction in the blockchain</returns>
        Task<TransactionHash> SendTransaction(TransferBtcBasedBlockchain body, bool testnet);


        Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request);




    }
}