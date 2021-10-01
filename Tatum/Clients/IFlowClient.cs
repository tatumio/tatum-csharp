using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IFlowClient
/// </summary>
namespace Tatum
{
    public interface IflowClient
    {
        Task<Flow> GenerateFlowWallet(string mnemonic);

        Task<Flow> GenerateFlowAddressFromPublicKey(string xpub, int index);
        Task<Flow> GenerateFlowPublicKey(string xpub, int index);
        Task<Flow> GenerateFlowPrivateKey(string index, int mnemonic);
        Task<Flow> GetFlowCurrentBlockNumber();
        Task<Flow> GetFlowBlockByHash(string hash);
        Task<Flow> GetFlowEventsFromBlock(string type,string from,string to);
        Task<Flow> GetFlowTransactionByHash(string hash);
        Task<Flow> GetFlowAccount(string address);
      


        Task<Flow> SendFlowTransactionMnemonic(string account, string currency, string to, string amount, string mnemonic, int index);
        Task<Flow> SendFlowTransactionPK(string account, string currency, string to, string amount, string privatekey);
        Task<Flow> SendFlowTransactionKMS(string account, string currency, string to, string amount, string signatureid,int index);


        Task<Flow> CreateFlowCreateAddressFromPubKeyMnemonic(string account, string publickey, string mnemonic, int index);
        Task<Flow> CreateFlowCreateAddressFromPubKeySecret(string account, string publickey, string privatekey);
        Task<Flow> CreateFlowCreateAddressFromPubKeyKMS(string account, string publickey, string signatureid,int index);


        Task<Flow> AddFlowCreateAddressFromPubKeyMnemonic(string account, string publickey, string mnemonic, int index);
        Task<Flow> AddFlowCreateAddressFromPubKeySecret(string account, string publickey, string privatekey);
        Task<Flow> AddFlowCreateAddressFromPubKeyKMS(string account, string publickey, string signatureid, int index);


       

    }
}