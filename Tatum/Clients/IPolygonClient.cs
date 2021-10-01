using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IPolygonClient
/// </summary>
/// 
namespace Tatum
{
    public interface IPolygonClient
    {
        Task<Polygon> GeneratePolygonWallet(string mnemonic);
        Task<Polygon> GeneratePolygonAccountAddressFromPublicKey(string xpub, int index);
        Task<Polygon> GeneratePolygonPrivateKey(int index, string mnemonic);
        Task<Polygon> Web3HttpDriver(string xapikey);
        Task<Polygon> GetCurrentBlockNumber();
        Task<Polygon> GetPolygonBlockByHash(string hash);
        Task<Polygon> GetPolygonAccountBalance(string address);
        Task<Polygon> GetPolygonTransaction(string hash);
        Task<Polygon> GetCountOutgoingPolygonTransaction(string address);


        Task<Polygon> SendTransferPolygonBlockchain(string data, string to, string currency, string gaslimit, string gasprice, string amount, string fromprivatekey);
        Task<Polygon> SendTransferPolygonBlockchainKMS(string data, string to, string currency, string gaslimit, string gasprice, string amount, int index, string signatureid);


        Task<Polygon> EstimatePolygonTransactionFees(string from, string to, string amount, string data);


        Task<Polygon> CallPolygonSmartContractReadMethod(string contractaddress,string amount, string methodname, string methodabi, string[] contractparams);
        Task<Polygon> CallPolygonSmartContractMethod(string contractaddress, string methodname, string methodabi, string[] contractparams,string fromprivatekey, string gaslimit, string gasprice);
        Task<Polygon> CallPolygonSmartContractMethodKMS(string contractaddress, string methodname, string methodabi, string[] contractparams, int index, string signatureid, string gaslimit, string gasprice);



        Task<Polygon> BroadcastSignedPolygonTransaction(string txData, string signatureId);







    }
}