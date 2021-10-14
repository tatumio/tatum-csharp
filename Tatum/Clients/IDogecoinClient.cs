using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

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
        Task<List<Dogecoin>> GetDogecoinUTXOTransaction(string hash,int index);


        Task<Dogecoin> SendDogeTransactionUTXO(string fee, string changeAddress, string txHash, string sentvalue, string fromAddress,int index,string privateKey,string toAddress,string value);
        Task<Dogecoin> SendDogeTransactionUTXOKMS(string txHash, string sentvalue, string fromAddress, int index, string signatureId, string toAddress, string value, string fee, string changeAddress);
     

        Task<Dogecoin> BroadcastSignedDogecoinTransaction(string txData, string signatureId);

    }
}