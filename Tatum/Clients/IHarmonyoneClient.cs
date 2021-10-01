using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IHarmonyoneClient
/// </summary>
/// 
namespace Tatum
{
    public interface IHarmonyoneClient
    {
        Task<HarmonyOne> GenerateOneWallet(string mnemonic);
        Task<HarmonyOne> GenerateOneAccountAddressFromPublicKey(string xpub, int index);
        Task<HarmonyOne> TransferHexaddressBech32(int address);
        Task<HarmonyOne> GenerateOnePrivateKey( int index, string mnemonic);
        Task<HarmonyOne> Web3HttpDriver(string xapikey);
        Task<HarmonyOne> GetCurrentBlockNumber();
        Task<HarmonyOne> GetOneBlockByHash(string hash);
        Task<HarmonyOne> GetOneAccountBalance(string address);
        Task<HarmonyOne> GetOneTransaction(string hash);
        Task<HarmonyOne> GetCountOutgoingOneTransaction(string address);



        Task<HarmonyOne> SendTransferOneBlockchain(string data, string to, string gaslimit, string gasprice, string amount, string fromprivatekey);
        Task<HarmonyOne> SendTransferOneBlockchainKMS(string data, string to, string gaslimit, string gasprice, string amount, int index, string signatureid);





        Task<HarmonyOne> CallOneReadSmartContractMethod(string contractaddress, string methodname, string methodabi, string[] contractparams);
        Task<HarmonyOne> CallOneSmartContractMethod(string contractaddress,string amount, string methodname, string methodabi, string[] contractparams,string fromprivatekey, string gaslimit, string gasprice, string feecurrency);
        Task<HarmonyOne> CallOneSmartContractMethodKMS(string contractaddress, string methodname, string methodabi, string[] contractparams, int index, string signatureid, string gaslimit, string gasprice, string feecurrency);



        Task<HarmonyOne> BroadcastSignedOneTransaction(string txData, string signatureId);


    }
}