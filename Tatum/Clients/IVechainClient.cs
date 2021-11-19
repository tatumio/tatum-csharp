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
/// Summary description for IVechainClient
/// </summary>
/// 

namespace Tatum
{
    public interface IVechainClient
    {
        Wallets CreateWallet(string mnemonic, bool testnet);
        String GeneratePrivateKey(string mnemonic, int index, bool testnet);
        String GenerateAddress(string xPub, int index, bool testnet);
        Task<Vechain> GetVechainCurrentBlock();
        Task<Vechain> GetVechainBlockByHash(string hash);
        Task<Vechain> GetVechainAccountBalance(string address);
        Task<Vechain> GetVechainAccountEnergy(string address);
        Task<Vechain> GetVechainTransaction(string hash);
        Task<Vechain> GetVechainTransactionReceipt(string hash);
        Task<Vechain> EstimateVechainGasForTransaction(string from, string to, string value,  string data, string nonce);

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