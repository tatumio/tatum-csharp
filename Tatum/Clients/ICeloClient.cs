using System;
using System.Collections.Generic;
using System.Linq;
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
/// Summary description for ICeloClient
/// </summary>
/// 
namespace Tatum
{
    public interface ICeloClient
    {


        Wallets CreateWallet(string mnemonic, bool testnet);
        String GeneratePrivateKey(string mnemonic, int index, bool testnet);
        String GenerateAddress(string xPub, int index, bool testnet);
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