using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IBscClient
/// </summary>
/// 
namespace Tatum
{
    public interface IBscClient
    {
        Task<Bsc> GenerateBscWallet(string mnemonic);
        Task<Bsc> GenerateBscAccountAddressFromPublicKey(string xpub, int index);
        Task<Bsc> GenerateBscPrivateKey(int index, string mnemonic);
        Task<Bsc> Web3HttpDriver( string xapikey);
        Task<Bsc> GetCurrentBlockNumber();
        Task<Bsc> GetBscBlockByHash(string hash);
        Task<Bsc> GetBscAccountBalance(string address);
        Task<Bsc> GetBscTransaction(string hash);
        Task<Bsc> GetCountOutgoingBscTransaction(string address);



        Task<Bsc> SendTransferBscBlockchain(string data,string to,string currency,string gaslimit,string gasprice,string amount,string fromprivatekey);
        Task<Bsc> SendTransferBscBlockchainKMS(string data, string to, string currency, string gaslimit, string gasprice, string amount,int index, string signatureid);


        Task<Bsc> EstimateBscTransactionFees(string from,string to,string amount,string data);


        Task<Bsc> CallBscSmartContractReadMethod(string contractaddress, string methodname, string methodabi, string[] contractparams);
        Task<Bsc> CallBscSmartContractMethod(string contractaddress, string methodname, string methodabi, string[] contractparams,string amount,string fromprivatekey,string gaslimit,string gasprice);
        Task<Bsc> CallBscSmartContractMethodKMS(string contractaddress, string methodname, string methodabi, string[] contractparams, int index, string signatureid, string gaslimit, string gasprice);



        Task<Bsc> BroadcastSignedBitcoinTransaction(string txData, string signatureId);






    }
}