using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;


/// <summary>
/// Summary description for ITronClient
/// </summary>
/// 
namespace Tatum
{
    public interface ITronClient
    {
        
        Task<Tron> GenerateTronWallet(string mnemonic);
        Task<Tron> GenerateTronDepositAddressFromPublicKey(string xpub, int index);
        Task<Tron> GenerateTronPrivateKey(int index, string mnemonic);
        Task<Tron> GetTronCurrentBlock();
        Task<Tron> GetTronBlockByHash(string hash);
        Task<Tron> GetTronAccountTransactions(string address,string next);
        Task<Tron> GetTronTrc20Transactions(string address, string next);
        Task<Tron> GetTronAccountByAddress(string address);
        Task<Tron> GetTronTransactionByHash(string hash);




        Task<Tron> SendTransferTronBlockchain(string fromprivatekey, string to, string amount);
        Task<Tron> SendTransferTronBlockchain(string from, string signatureid, string to, string amount, int index);


        Task<Tron> FreezeTron(string fromprivatekey, string receiver, string duration,string resource,string amount);
        Task<Tron> FreezeTronKMS(string from, string signatureid, int index, string receiver, string duration,string resource,string amount );



        Task<Tron> SendTransferTronTrc10Blockchain(string fromprivatekey, string to, string tokenid, string amount);
        Task<Tron> SendTransferTronTrc10BlockchainKMS(string from, string signatureid, int index, string to, string tokenid, string amount);


        Task<Tron> CreateTronTrc10Blockchain(string fromprivatekey, string recipient, string name, string abbreviation, string description, string url, int totalsupply,int decimals);
        Task<Tron> CreateTronTrc10BlockchainKMS(string from, string signatureid, int index, string recipient, string name, string abbreviation, string description, string url, int totalsupply, int decimals);


        Task<Tron> GetTronTrc10TokenDetail(string id);


        Task<Tron> SendTransferTronTrc20Blockchain(string fromprivatekey, string to, string tokenaddress,string feelimit, string amount);
        Task<Tron> SendTransferTronTrc20BlockchainKMS(string from, string signatureid, int index, string to, string tokenaddress,string feelimit, string amount);


        Task<Tron> CreateTronTrc20Blockchain(string fromprivatekey, string recipient, string name, string symbol, int totalsupply, int decimals);
        Task<Tron> CreateTronTrc20BlockchainKMS(string from, string signatureid, int index, string recipient, string name, string symbol, int totalsupply, int decimals);


        Task<Tron> BroadcastTronTransaction(string txData);





    }
}