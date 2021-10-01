using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for ICeloClient
/// </summary>
/// 
namespace Tatum
{
    public interface ICeloClient
    {


        Task<Celo> GenerateCeloWallet(string mnemonic);
        Task<Celo> GenerateCeloAccountAddressFromPublicKey(string xpub, int index);
        Task<Celo> GenerateCeloPrivateKey(int index, string mnemonic);
        Task<Celo> Web3HttpDriver(string xapikey);
        Task<Celo> GetCurrentBlockNumber();
        Task<Celo> GetCeloBlockByHash(string hash);
        Task<Celo> GetCeloAccountBalance(string address);
        Task<Celo> GetCeloTransaction(string hash);
        Task<Celo> GetCountOutgoingCeloTransaction(string address);



        Task<Celo> SendTransferCeloBlockchain(string data, string to, string currency, string feecurrency, string amount, string fromprivatekey);
        Task<Celo> SendTransferCeloBlockchainKMS(string data, string to, string currency, string feecurrency, string amount, int index, string signatureid);





        Task<Celo> CallCeloReadSmartContractMethod(string contractaddress, string methodname, string methodabi, string[] contractparams);
        Task<Celo> CallCeloSmartContractMethod(string contractaddress, string methodname, string methodabi, string[] contractparams, string amount, string fromprivatekey, string gaslimit, string gasprice,string feecurrency);
        Task<Celo> CallCeloSmartContractMethodKMS(string contractaddress, string methodname, string methodabi, string[] contractparams, int index, string signatureid, string gaslimit, string gasprice, string feecurrency);



        Task<Celo> BroadcastSignedCeloTransaction(string txData, string signatureId);






    }
}