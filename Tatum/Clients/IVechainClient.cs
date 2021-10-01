using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IVechainClient
/// </summary>
/// 

namespace Tatum
{
    public interface IVechainClient
    {
        Task<Vechain> GenerateVechainWallet(string mnemonic);
        Task<Vechain> GenerateVechainFromExtendedPublicKey(string xpub,string index);
        Task<Vechain> GenerateVechainPrivateKey(string index, string mnemonic);
        Task<Vechain> GetVechainCurrentBlock();
        Task<Vechain> GetVechainBlockByHash(string hash);
        Task<Vechain> GetVechainAccountBalance(string address);
        Task<Vechain> GetVechainAccountEnergy(string address);
        Task<Vechain> GetVechainTransaction(string hash);
        Task<Vechain> GetVechainTransactionReceipt(string hash);
        Task<Vechain> SendVechainFromAccountToAccount(string to, string amount, string fromprivateKey, string signatureid,string data,string gasLimit);
        Task<Vechain> EstimateVechainGasForTransaction(string from, string to, string value,  string data, string nonce);
        Task<Record> BroadcastSignedVechainTransaction(string txdata,string signatureid);
    }
}