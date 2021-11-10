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



        //Task<Celo> SendTransferCeloBlockchain(string data, string to, string currency, string feecurrency, string amount, string fromprivatekey);
        //Task<Celo> SendTransferCeloBlockchainKMS(string data, string to, string currency, string feecurrency, string amount, int index, string signatureid);





        //Task<Celo> CallCeloReadSmartContractMethod(string contractaddress, string methodname, string methodabi, string[] contractparams);
        //Task<Celo> CallCeloSmartContractMethod(string contractaddress, string methodname, string methodabi, string[] contractparams, string amount, string fromprivatekey, string gaslimit, string gasprice,string feecurrency);
        //Task<Celo> CallCeloSmartContractMethodKMS(string contractaddress, string methodname, string methodabi, string[] contractparams, int index, string signatureid, string gaslimit, string gasprice, string feecurrency);



        Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request);
        Task<int> GetTransactionsCount(string address);

        /// <summary>
        /// Estimate Gas price for the transaction.
        /// </summary>
        /// <returns>Gas price in Wei.</returns>
        Task<BigInteger> GetGasPriceInWei();

        Task<string> PrepareStoreDataTransaction(CreateRecord body, bool testnet, string provider = null);

        Task<TransactionHash> SendStoreDataTransaction(CreateRecord body, bool testnet, string provider = null);



        /// <summary>
        /// Send Celo or cUsd transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloOrcUsdTransaction(TransferCeloOrCeloErc20Token body, bool testnet, string provider = null);

        /// <summary>
        ///  Send Celo or cUsd transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloErc20Transaction(TransferCeloOrCeloErc20Token body, bool testnet, string provider = null);

        /// <summary>
        /// Send Celo mint erc721 transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloMintErc721Transaction(CeloMintErc721 body, bool testnet, string provider = null);

        /// <summary>
        /// Send Celo mint cashback erc721 transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloMintCashbackErc721Transaction(CeloMintErc721 body, bool testnet, string provider = null);

        /// <summary>
        /// Send Celo mint provenance cashback erc721 transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloMintErc721ProvenanceTransaction(CeloMintErc721 body, bool testnet, string provider = null);

        /// <summary>
        /// Send Celo mint multiple provenance erc721 transaction to the blockchain. Nothing is broadcast to the blockchain.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloMintMultipleErc721ProvenanceTransaction(CeloMintMultipleErc721 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send Celo mint multiple erc721 transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloMintMultipleErc721Transaction(CeloMintMultipleErc721 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send Celo mint multiple cashback erc721 transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloMintMultipleCashbackErc721Transaction(CeloMintMultipleErc721 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send Celo burn erc721 transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloBurnErc721Transaction(CeloBurnErc721 body, bool testnet, string provider = null);



        /// <summary>
        ///  Send Celo update cashback for author erc721 transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloUpdateCashbackForAuthorErc721Transaction(CeloUpdateCashbackErc721 body, bool testnet, string provider = null);




        /// <summary>
        ///  Send Celo transfer nft transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloTransferErc721Transaction(CeloTransferErc721 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send Celo deploy erc721 transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloDeployErc721Transaction(CeloDeployErc721 body, bool testnet, string provider = null);


        /// <summary>
        ///  Send Celo deploy multiple tokens transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloDeployMultiTokenTransaction(CeloDeployMultiToken body, bool testnet, string provider = null);



        /// <summary>
        /// * Send Celo mint multiple tokens transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloMintMultiTokenTransaction(CeloMintMultiToken body, bool testnet, string provider = null);


        /// <summary>
        /// * Send Celo mint multiple tokens batch transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloMintMultiTokenBatchTransaction(CeloMintMultiTokenBatch body, bool testnet, string provider = null);


        /// <summary>
        /// * Send Celo transfer multiple tokens transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloTransferMultiTokenTransaction(CeloTransferMultiToken body, bool testnet, string provider = null);


        /// <summary>
        /// Send Celo transfer multiple tokens batch transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloTransferMultiTokenBatchTransaction(CeloTransferMultiTokenBatch body, bool testnet, string provider = null);


        /// <summary>
        /// Send Celo burn multiple tokens transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloBurnMultiTokenTransaction(CeloBurnMultiToken body, bool testnet, string provider = null);


        /// <summary>
        /// Send Celo burn multiple tokens batch transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloBurnMultiTokenBatchTransaction(CeloBurnMultiTokenBatch body, bool testnet, string provider = null);


        /// <summary>
        ///  Send generate custodial wallet transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloGenerateCustodialWalletSignedTransaction(GenerateCustodialAddress body, bool testnet, string provider = null);


        /// <summary>
        ///  Deploy new smart contract for NFT marketplace logic. This method broadcasts signed transaction to the blockchain.This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCeloDeployMarketplaceListingSignedTransaction(DeployMarketplaceListing body, bool testnet, string provider = null);


        





    }
}