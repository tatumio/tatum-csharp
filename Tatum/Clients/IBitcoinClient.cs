using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

/// <summary>
/// Summary description for IBitcoinClient
/// </summary>
namespace Tatum
{
    public interface IBitcoinClient
    {

        Wallets CreateWallet(string mnemonic, bool testnet);
        String GeneratePrivateKey(string mnemonic,int index, bool testnet);
        String GenerateAddress(string xPubString, int index, bool testnet);
       
       
        Task<Bitcoin> GetBlockchainInfo();
        Task<Bitcoin> GetBlockHash(int i);
        Task<Bitcoin> GetBlockByHash(string hash);
        Task<Bitcoin> GetTransactionByHash(string hash);

        Task<Bitcoin> GetMempoolTransaction();
        Task<List<Bitcoin>> GetCustomerAccounts(string address, int pageSize = 50, int offset = 0);
        Task<Bitcoin> GetBalanceOfAddress(string address);

        //Task<Bitcoin> GetUTXOtransaction(string hash, int index);

        //Task<Bitcoin> SendBtcTransactionFromAddress(string fromAddress, string privateKey,string toAddress,double value);
        //Task<Bitcoin> SendBtcTransactionFromAddressKMS(string signatureId, string privateKey, string toAddress, double value);
        //Task<Bitcoin> SendBtcTransactionFromUTXO(string txHash, int index, string privateKey, string toAddress,string value);
        //Task<Bitcoin> SendBtcTransactionFromUTXOKMS(string txHash, int index, string signatureId, string toAddress, string value);

        


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