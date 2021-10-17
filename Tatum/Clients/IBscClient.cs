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
/// Summary description for IBscClient
/// </summary>
/// 
namespace Tatum
{
    public interface IBscClient
    {
        Wallets CreateWallet(string mnemonic, bool testnet);
        String GeneratePrivateKey(string mnemonic, int index, bool testnet);
        String GenerateAddress(string xPub, int index, bool testnet);
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