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


        /// <summary>
        ///  Send Bsc store data transaction to the blockchain. This method broadcasts signed transaction to the blockchain.
        ///  This operation is irreversible.
        /// </summary>
        /// <param name="body">Content of the transaction to broadcast.</param>
        /// <param name="testnet">mainnet or testnet version</param>
        /// <param name="provider">Url of the Ethereum Server to connect to. If not set, default public server will be used.</param>
        /// <returns>Transaction id of the transaction in the blockchain.</returns>
        Task<TransactionHash> SendBscStoreDataTransaction(CreateRecord body, bool testnet, string provider = null);

        /// <summary>
        /// Send Bsc custom BEP20 transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendBscOrBep20Transaction(TransferErc20 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send Bsc custom BEP20 transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendCustomBep20Transaction(TransferErc20 body, bool testnet, string provider = null);

        /// <summary>
        /// Send Bsc deploy BEP20 transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendDeployBep20Transaction(DeployErc20 body, bool testnet, string provider = null);

        /// <summary>
        /// Send Bsc invoke smart contract transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendBscSmartContractMethodInvocationTransaction(SmartContractMethodInvocation body, bool testnet, string provider = null);

        /// <summary>
        /// Send Bsc BEP721 mint transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendMintBep721Transaction(EthMintErc721 body, bool testnet, string provider = null);

        /// <summary>
        /// Send Bsc BEP721 mint transaction to the blockchain with cashback details. Nothing is broadcast to the blockchain.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendMintBepCashback721Transaction(EthMintErc721 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send Bsc BEP721 mint provenance transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendMintBep721ProvenanceTransaction(EthMintErc721 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send Bsc BEP721 mint multiple transaction with cashback to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendMintMultipleCashbackBep721Transaction(EthMintMultipleErc721 body, bool testnet, string provider = null);

        /// <summary>
        /// Send Bsc BEP721 mint multiple provenance transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendMintMultipleBep721ProvenanceTransaction(EthMintMultipleErc721 body, bool testnet, string provider = null);



        /// <summary>
        ///  Send Bsc BEP721 mint multiple transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendMintMultipleBep721Transaction(EthMintMultipleErc721 body, bool testnet, string provider = null);




        /// <summary>
        ///  Send Bsc BEP721 burn transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendBurnBep721Transaction(EthBurnErc721 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send Bsc ERC721 update cashback for author transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendUpdateCashbackForAuthorBep721Transaction(UpdateCashbackErc721 body, bool testnet, string provider = null);


        /// <summary>
        ///   Send Bsc BEP721 transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendBep721Transaction(EthTransferErc721 body, bool testnet, string provider = null);



        /// <summary>
        /// *  Send Bsc BEP721 deploy to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendDeployBep721Transaction(EthDeployErc721 body, bool testnet, string provider = null);


        /// <summary>
        /// * Send Bsc MultiToken transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendBscMultiTokenTransaction(TransferMultiToken body, bool testnet, string provider = null);


        /// <summary>
        /// * Send Ethereum MultiToken transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendBscMultiTokenBatchTransaction(TransferMultiTokenBatch body, bool testnet, string provider = null);


        /// <summary>
        /// Send Bsc MultiToken deploy to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendBscDeployMultiTokenTransaction(EthDeployMultiToken body, bool testnet, string provider = null);


        /// <summary>
        /// Send Bsc MultiToken mint transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendBscMintMultiTokenTransaction(MintMultiToken body, bool testnet, string provider = null);


        /// <summary>
        /// Send Bsc MultiToken mint batch transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendBscMintMultiTokenBatchTransaction(MintMultiTokenBatch body, bool testnet, string provider = null);


        /// <summary>
        ///  Send Bsc MultiToken burn transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendBscBurnMultiTokenTransaction(EthBurnMultiToken body, bool testnet, string provider = null);


        /// <summary>
        ///  Send Bsc MultiToken burn batch transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendBscBurnBatchMultiTokenTransaction(EthBurnMultiTokenBatch body, bool testnet, string provider = null);


        /// <summary>
        ///  Send Bsc generate custodial wallet transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendBscGenerateCustodialWalletSignedTransaction(GenerateCustodialAddress body, bool testnet, string provider = null);


        /// <summary>
        ///  Send Bsc generate custodial wallet transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendBscDeployMarketplaceListingSignedTransaction(DeployMarketplaceListing body, bool testnet, string provider = null);





































    }
}