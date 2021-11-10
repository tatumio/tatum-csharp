using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

/// <summary>
/// Summary description for IXlmClient
/// </summary>
/// 

namespace Tatum
{
    public interface IXlmClient
    {

        Wallets CreateWallet(string secret = null);
        Task<Xlm> GenerateXlmBlockchain();
        Task<Xlm> GetXlmBlockchainLedger(string sequence);
        Task<Xlm> GetXlmBlockchainTransactions(string sequence);
        Task<Xlm> GetActualXlmFee();
        Task<Xlm> GetXlmAccountTransaction(string account,string pagination);
        Task<Xlm> GetXlmTransactionByHash(string hash);
        Task<Xlm> GetXlmAccountInfo(string account);

        //Task<Xlm> SendTransferXlmBlockchain(string fromaccount,string to,string amount,string fromsecret,bool initialize,string message);
        //Task<Xlm> SendTransferXlmBlockchainAsset(string fromaccount, string to, string amount, string fromsecret, bool initialize, string token,string issuerAccount,string message);
        //Task<Xlm> SendTransferXlmBlockchainKMS(string fromaccount, string to, string amount, string signatureid, bool initialize, string message);
        //Task<Xlm> SendTransferXlmBlockchainKMSAsset(string fromaccount, string to, string amount, string signatureid, bool initialize, string token, string issuerAccount, string message);



        //Task<Xlm> CreateTrustLineXlmBlockchain(string fromaccount, string issuerAccount, string token, string fromsecret,string limit);

        //Task<Xlm> CreateTrustLineXlmBlockchainKMS(string fromaccount, string issuerAccount, string token, string signatureid, string limit);


        // Task<Xlm> BroadcastSignedXlmTransaction(string txData, string signatureid);

     

        /// <summary>
        /// Sign XLM transaction with private keys locally. Nothing is broadcasted to the blockchain.
        /// </summary>        
        /// <param name="body">content of the transaction to broadcast</param>
        /// <param name="testnet">testnet or mainnet version</param>
        /// <returns>Transaction data to be broadcast to blockchain.</returns>
        Task<string> PrepareSignedTransaction(bool testnet);

        /// <summary>
        /// Send XLM transaction to the blockchain. This method broadcasts signed transaction to the blockchain.
        /// This operation is irreversible.
        /// </summary>
        /// <param name="body">content of the transaction to broadcast</param>
        /// <param name="testnet">testnet or mainnet version</param>
        /// <returns>transaction id of the transaction in the blockchain</returns>
        Task<TransactionHash> SendTransaction( bool testnet);


        Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request);


    }
}