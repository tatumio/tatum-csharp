using System;
using System.Collections.Generic;
using System.Web;
using System.Threading.Tasks;
using Nethereum.Web3;
using System.Numerics;
using Tatum.Model.Requests;
using Tatum.Model.Responses;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3.Accounts;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Summary description for IHarmonyoneClient
/// </summary>
/// 
namespace Tatum
{
    public interface IHarmonyoneClient
    {

        Wallets CreateWallet(string mnemonic, bool testnet);
        String GeneratePrivateKey(string mnemonic, int index, bool testnet);
        String GenerateAddress(string xPub, int index, bool testnet);

        Task<HarmonyOne> TransferHexaddressBech32(int address);
      
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




        Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request);
        Task<int> GetTransactionsCount(string address);

        /// <summary>
        /// Estimate Gas price for the transaction.
        /// </summary>
        /// <returns>Gas price in Wei.</returns>
        Task<BigInteger> GetGasPriceInWei();

        Task<string> PrepareStoreDataTransaction(CreateRecord body, bool testnet, string provider = null);

        Task<TransactionHash> SendStoreDataTransaction(CreateRecord body, bool testnet, string provider = null);


    }
}