using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;


/// <summary>
/// Summary description for IBitcoinCashClient
/// </summary>
namespace Tatum
{
    public interface IBitcoinCashClient
    {

        Wallets CreateWallet( string mnemonic, bool testnet);
        String GeneratePrivateKey(string mnemonic, int index, bool testnet);
        String GenerateAddress(string xPubString, int index, bool testnet);

        Task<BitcoinCash> GetBlockchainInfo();
        Task<BitcoinCash> GetBitcoinCashBlockHash(int i);
        Task<BitcoinCash> GetBitcoinCashBlockByHash(string hash);
        Task<BitcoinCash> GetBitcoinCashTransactionByHash(string hash);
        Task<List<BitcoinCash>> GetBitcoinCashTransactionByAddress(string address);


        //Task<BitcoinCash> SendBitcoinCashTransactionFromUTXO(string txHash, int index, string privateKey, string toAddress, string value);
        //Task<BitcoinCash> SendBitcoinCashTransactionFromUTXOKMS(string txHash, int index, string signatureId, string toAddress, string value);

        //Task<BitcoinCash> BroadcastSignedBitcoinCashTransaction(string txData, string signatureId);

        Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request);
        Task<string> SignKmsTransaction(TransactionKms tx, List<string> privateKeys, bool testnet);

        /// <summary>
        /// Sign BitcoinCash transaction with private keys locally. Nothing is broadcasted to the blockchain.
        /// </summary>        
        /// <param name="body">content of the transaction to broadcast</param>
        /// <param name="testnet">testnet or mainnet version</param>
        /// <returns>Transaction data to be broadcast to blockchain.</returns>
        string PrepareSignedTransaction(TransferBchBlockchain body, bool testnet);

        /// <summary>
        /// Send BitcoinCash transaction to the blockchain. This method broadcasts signed transaction to the blockchain.
        /// This operation is irreversible.
        /// </summary>
        /// <param name="body">content of the transaction to broadcast</param>
        /// <param name="testnet">testnet or mainnet version</param>
        /// <returns>transaction id of the transaction in the blockchain</returns>
        Task<TransactionHash> SendTransaction(TransferBchBlockchain body, bool testnet);

    }
}