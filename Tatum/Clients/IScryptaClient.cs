using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IScryptaClient
/// </summary>
/// 
namespace Tatum
{
    public interface IScryptaClient
    {

        Task<Scrypta> GenerateScryptaWallet();

        Task<Scrypta> GenerateScryptaPrivateKey(int index, string mnemonic);
        Task<Scrypta> GetBlockHash(string i);
        Task<Scrypta> GetBlockByHash(string hash);
        Task<Scrypta> SendLyratoBlockchainAddresses(string signatureidfrom, string address, string privatekeyfrom, string txhash, string index, string privatekeyto, string signatureidto, string addressto, string value);
        Task<Scrypta> GetScryptaTransactionByHash(string hash);
        Task<Scrypta> GetTransactionsByAddress(string address, int pageSize = 50, int offset = 0);
        Task<Scrypta> GetScryptaSpendableUTXO(string address, int pageSize = 50, int offset = 0);
        Task<Scrypta> GetUTXOOfTransactions(string hash, string index);
        Task<Scrypta> GenerateScryptaDepositAddressFromPublicKey(string xpub, int index);
        Task<Scrypta> GetBlockchainInfo(string address);


        Task<Scrypta> BroadcastSignedScryptaTransaction(string txData, string signatureId);



    }

}