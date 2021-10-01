using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IXdcClient
/// </summary>
/// 
namespace Tatum
{
    public interface IXdcClient
    {


        Task<XDCNetwork> GenerateXDCWallet(string mnemonic);
        Task<XDCNetwork> GenerateXDCAccountAddressFromPublicKey(string xpub, int index);
        Task<XDCNetwork> GenerateXDCPrivateKey(int index, string mnemonic);
        Task<XDCNetwork> Web3HttpDriver(string xapikey);
        Task<XDCNetwork> GetCurrentBlockNumber();
        Task<XDCNetwork> GetXDCBlockByHash(string hash);
        Task<XDCNetwork> GetXDCAccountBalance(string address);
        Task<XDCNetwork> GetXDCTransaction(string hash);
        Task<XDCNetwork> GetCountOutgoingXDCTransaction(string address);



        Task<XDCNetwork> SendTransferXdcBlockchain(string data, string to,  string gaslimit, string gasprice, string amount, string fromprivatekey);
        Task<XDCNetwork> SendTransferXdcBlockchainKMS(string data, string to, string gaslimit, string gasprice, string amount, int index, string signatureid);


        Task<XDCNetwork> EstimateXdcTransactionFees(string from, string to, string amount, string data);


        Task<XDCNetwork> CallXdcSmartContractReadMethod(string contractaddress, string methodname, string methodabi, string[] contractparams);
        Task<XDCNetwork> CallXdcSmartContractMethod(string contractaddress, string methodname, string methodabi, string[] contractparams, string amount, string fromprivatekey, string gaslimit, string gasprice);
        Task<XDCNetwork> CallXdcSmartContractMethodKMS(string contractaddress, string methodname, string methodabi, string[] contractparams, int index, string signatureid, string gaslimit, string gasprice);



        Task<XDCNetwork> BroadcastSignedXdcTransaction(string txData, string signatureId);





    }
}