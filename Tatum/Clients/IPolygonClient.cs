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


      

        Task<Polygon> EstimatePolygonTransactionFees(string from, string to, string amount, string data);


     
       


        Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request);
        Task<int> GetTransactionsCount(string address);

        /// <summary>
        /// Estimate Gas price for the transaction.
        /// </summary>
        /// <returns>Gas price in Wei.</returns>
        Task<BigInteger> GetGasPriceInWei();

        Task<string> PrepareStoreDataTransaction(CreateRecord body, bool testnet, string provider = null);

        /// <summary>
        ///  Send Polygon store data transaction to the blockchain. This method broadcasts signed transaction to the blockchain.
        ///  This operation is irreversible.
        /// </summary>
        /// <param name="body">Content of the transaction to broadcast.</param>
        /// <param name="testnet">mainnet or testnet version</param>
        /// <param name="provider">Url of the Ethereum Server to connect to. If not set, default public server will be used.</param>
        /// <returns>Transaction id of the transaction in the blockchain.</returns>
        Task<TransactionHash> SendPolygonStoreDataTransaction(CreateRecord body, bool testnet, string provider = null);



        /// <summary>
        /// Send Polygon deploy Erc20 transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonDeployErc20Transaction(DeployErc20 body, bool testnet, string provider = null);

        /// <summary>
        /// Send Polygon invoke smart contract transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonContractMethodInvocationTransaction(SmartContractMethodInvocation body, bool testnet, string provider = null);

        /// <summary>
        /// Send Polygon Erc721 mint transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonMintErc721Transaction(EthMintErc721 body, bool testnet, string provider = null);

        /// <summary>
        /// Send Polygon ERC721 mint transaction to the blockchain with cashback details. Nothing is broadcast to the blockchain.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonMintCashbackErc721Transaction(EthMintErc721 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send Polygon Erc721 mint provenance transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonMintErc721ProvenanceTransaction(EthMintErc721 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send Polygon ERC721 mint multiple transaction with cashback to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonMintMultipleCashbackERC721Transaction(EthMintMultipleErc721 body, bool testnet, string provider = null);

        /// <summary>
        /// Send Polygon Erc721 mint multiple provenance transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonMintMultipleErc721ProvenanceTransaction(EthMintMultipleErc721 body, bool testnet, string provider = null);



        /// <summary>
        ///  Send Polygon Erc721 mint multiple transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonMintMultipleErc721Transaction(EthMintMultipleErc721 body, bool testnet, string provider = null);




        /// <summary>
        ///  Send Polygon ERC721 burn transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonBurnERC721Transaction(EthBurnErc721 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send Polygon ERC721 update cashback for author transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonUpdateCashbackForAuthorERC721Transaction(UpdateCashbackErc721 body, bool testnet, string provider = null);



        /// <summary>
        /// *  Send Polygon Erc721 deploy to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonDeployERC721Transaction(EthDeployErc721 body, bool testnet, string provider = null);


        /// <summary>
        /// * Send Polygon MultiToken transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonMultiTokenTransaction(TransferMultiToken body, bool testnet, string provider = null);


        /// <summary>
        /// * Send Polygon MultiToken transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonMultiTokenBatchTransaction(TransferMultiTokenBatch body, bool testnet, string provider = null);


        /// <summary>
        /// Send Polygon MultiToken deploy to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonDeployMultiTokenTransaction(EthDeployMultiToken body, bool testnet, string provider = null);


        /// <summary>
        /// Send Polygon MultiToken mint transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonMintMultiTokenTransaction(MintMultiToken body, bool testnet, string provider = null);


        /// <summary>
        /// Send Polygon MultiToken mint batch transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonMintMultiTokenBatchTransaction(MintMultiTokenBatch body, bool testnet, string provider = null);


        /// <summary>
        ///  Send Polygon MultiToken burn transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonBurnMultiTokenTransaction(EthBurnMultiToken body, bool testnet, string provider = null);


        /// <summary>
        ///  Send Polygon MultiToken burn batch transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonBurnBatchMultiTokenTransaction(EthBurnMultiTokenBatch body, bool testnet, string provider = null);


        /// <summary>
        ///  Send Polygon generate custodial wallet transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonGenerateCustodialWalletSignedTransaction(GenerateCustodialAddress body, bool testnet, string provider = null);


        /// <summary>
        ///  Send Polygon generate custodial wallet transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonDeployMarketplaceListingSignedTransaction(DeployMarketplaceListing body, bool testnet, string provider = null);



        /// <summary>
        ///  Send Polygon ERC721 update cashback for author transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonUpdateCashbackForAuthorErc721Transaction(UpdateCashbackErc721 body, bool testnet, string provider = null);


        /// <summary>
        ///  Send Polygon Erc721 mint multiple transaction with cashback to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonMintMultipleCashbackErc721Transaction(EthMintMultipleErc721 body, bool testnet, string provider = null);




        /// <summary>
        ///  Send Polygon Erc721 burn transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonBurnErc721Transaction(EthBurnErc721 body, bool testnet, string provider = null);


        /// <summary>
        ///   Send Polygon Erc721 transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonErc721Transaction(EthTransferErc721 body, bool testnet, string provider = null);


        /// <summary>
        /// *  Send Polygon Erc721 deploy to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendPolygonDeployErc721Transaction(EthDeployErc721 body, bool testnet, string provider = null);



    }
}