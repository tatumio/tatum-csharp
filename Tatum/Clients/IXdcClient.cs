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
/// Summary description for IXdcClient
/// </summary>
/// 
namespace Tatum
{
    public interface IXdcClient
    {


        Wallets CreateWallet(string mnemonic, bool testnet);
        String GeneratePrivateKey(string mnemonic, int index, bool testnet);
        String GenerateAddress(string xPub, int index, bool testnet);
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