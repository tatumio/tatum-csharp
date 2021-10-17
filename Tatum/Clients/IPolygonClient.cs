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
/// Summary description for IPolygonClient
/// </summary>
/// 
namespace Tatum
{
    public interface IPolygonClient
    {
        Wallets CreateWallet(string mnemonic, bool testnet);
        String GeneratePrivateKey(string mnemonic, int index, bool testnet);
        String GenerateAddress(string xPub, int index, bool testnet);
        Task<Polygon> Web3HttpDriver(string xapikey);
        Task<Polygon> GetCurrentBlockNumber();
        Task<Polygon> GetPolygonBlockByHash(string hash);
        Task<Polygon> GetPolygonAccountBalance(string address);
        Task<Polygon> GetPolygonTransaction(string hash);
        Task<Polygon> GetCountOutgoingPolygonTransaction(string address);


        Task<Polygon> SendTransferPolygonBlockchain(string data, string to, string currency, string gaslimit, string gasprice, string amount, string fromprivatekey);
        Task<Polygon> SendTransferPolygonBlockchainKMS(string data, string to, string currency, string gaslimit, string gasprice, string amount, int index, string signatureid);


        Task<Polygon> EstimatePolygonTransactionFees(string from, string to, string amount, string data);


      //  Task<Polygon> CallPolygonSmartContractReadMethod(string contractaddress,string amount, string methodname, string methodabi, string[] contractparams);
       // Task<Polygon> CallPolygonSmartContractMethod(string contractaddress, string methodname, string methodabi, string[] contractparams,string fromprivatekey, string gaslimit, string gasprice);
        Task<Polygon> CallPolygonSmartContractMethodKMS(string contractaddress, string methodname, string methodabi, string[] contractparams, int index, string signatureid, string gaslimit, string gasprice);



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