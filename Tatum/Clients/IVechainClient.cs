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
        Wallets CreateWallet(string mnemonic, bool testnet);
        String GeneratePrivateKey(string mnemonic, int index, bool testnet);
        String GenerateAddress(string xPub, int index, bool testnet);
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