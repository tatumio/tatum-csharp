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



     

        Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request);
        Task<int> GetTransactionsCount(string address);

        /// <summary>
        /// Estimate Gas price for the transaction.
        /// </summary>
        /// <returns>Gas price in Wei.</returns>
        Task<BigInteger> GetGasPriceInWei();

        Task<string> PrepareStoreDataTransaction(CreateRecord body, bool testnet, string provider = null);

        /// <summary>
        ///  Send One store data transaction to the blockchain. This method broadcasts signed transaction to the blockchain.
        ///  This operation is irreversible.
        /// </summary>
        /// <param name="body">Content of the transaction to broadcast.</param>
        /// <param name="testnet">mainnet or testnet version</param>
        /// <param name="provider">Url of the Ethereum Server to connect to. If not set, default public server will be used.</param>
        /// <returns>Transaction id of the transaction in the blockchain.</returns>
        Task<TransactionHash> SendOneStoreDataTransaction(CreateRecord body, bool testnet, string provider = null);

        /// <summary>
        /// Send One custom Erc20 transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneErc20Transaction(TransferErc20 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send One custom Erc20 transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneCustomErc20Transaction(TransferErc20 body, bool testnet, string provider = null);

        /// <summary>
        /// Send One deploy Erc20 transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneDeployErc20Transaction(DeployErc20 body, bool testnet, string provider = null);

        /// <summary>
        /// Send One invoke smart contract transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneSmartContractMethodInvocationTransaction(SmartContractMethodInvocation body, bool testnet, string provider = null);

        /// <summary>
        /// Send One Erc721 mint transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneMintErc721Transaction(EthMintErc721 body, bool testnet, string provider = null);

        /// <summary>
        /// Send One Erc721 mint transaction to the blockchain with cashback details. Nothing is broadcast to the blockchain.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneMintCashbackErc721Transaction(EthMintErc721 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send One Erc721 mint provenance transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneMintErc721ProvenanceTransaction(EthMintErc721 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send One Erc721 mint multiple transaction with cashback to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneMintMultipleCashbackErc721Transaction(EthMintMultipleErc721 body, bool testnet, string provider = null);

        /// <summary>
        /// Send One Erc721 mint multiple provenance transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneMintMultipleErc721ProvenanceTransaction(EthMintMultipleErc721 body, bool testnet, string provider = null);



        /// <summary>
        ///  Send One Erc721 mint multiple transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneMintMultipleErc721Transaction(EthMintMultipleErc721 body, bool testnet, string provider = null);




        /// <summary>
        ///  Send One Erc721 burn transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneBurnErc721Transaction(EthBurnErc721 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send One ERC721 update cashback for author transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneUpdateCashbackForAuthorErc721Transaction(UpdateCashbackErc721 body, bool testnet, string provider = null);


        /// <summary>
        ///   Send One Erc721 transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneErc721Transaction(EthTransferErc721 body, bool testnet, string provider = null);



        /// <summary>
        /// *  Send One Erc721 deploy to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneDeployErc721Transaction(EthDeployErc721 body, bool testnet, string provider = null);


        /// <summary>
        /// * Send One MultiToken transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneMultiTokenTransaction(TransferMultiToken body, bool testnet, string provider = null);


        /// <summary>
        /// * Send One MultiToken transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneMultiTokenBatchTransaction(TransferMultiTokenBatch body, bool testnet, string provider = null);


        /// <summary>
        /// Send One MultiToken deploy to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneDeployMultiTokenTransaction(EthDeployMultiToken body, bool testnet, string provider = null);


        /// <summary>
        /// Send One MultiToken mint transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneMintMultiTokenTransaction(MintMultiToken body, bool testnet, string provider = null);


        /// <summary>
        /// Send One MultiToken mint batch transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneMintMultiTokenBatchTransaction(MintMultiTokenBatch body, bool testnet, string provider = null);


        /// <summary>
        ///  Send One MultiToken burn transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneBurnMultiTokenTransaction(EthBurnMultiToken body, bool testnet, string provider = null);


        /// <summary>
        ///  Send One MultiToken burn batch transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneBurnBatchMultiTokenTransaction(EthBurnMultiTokenBatch body, bool testnet, string provider = null);


        /// <summary>
        ///  Send One generate custodial wallet transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneGenerateCustodialWalletSignedTransaction(GenerateCustodialAddress body, bool testnet, string provider = null);


        /// <summary>
        ///  Send One generate custodial wallet transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendOneDeployMarketplaceListingSignedTransaction(DeployMarketplaceListing body, bool testnet, string provider = null);







    }
}