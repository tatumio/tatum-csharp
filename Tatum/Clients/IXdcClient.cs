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

        /// <summary>
        ///  Send Bsc store data transaction to the blockchain. This method broadcasts signed transaction to the blockchain.
        ///  This operation is irreversible.
        /// </summary>
        /// <param name="body">Content of the transaction to broadcast.</param>
        /// <param name="testnet">mainnet or testnet version</param>
        /// <param name="provider">Url of the Ethereum Server to connect to. If not set, default public server will be used.</param>
        /// <returns>Transaction id of the transaction in the blockchain.</returns>
        Task<TransactionHash> SendXDCStoreDataTransaction(CreateRecord body, bool testnet, string provider = null);

        /// <summary>
        /// Send XDC or supported ERC20 transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXdcOrErc20Transaction(TransferErc20 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send XDC custom Erc20 transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCCustomErc20Transaction(TransferErc20 body, bool testnet, string provider = null);

        /// <summary>
        /// Send XDC deploy Erc20 transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCDeployErc20Transaction(DeployErc20 body, bool testnet, string provider = null);

        /// <summary>
        /// Send XDC invoke smart contract transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCSmartContractMethodInvocationTransaction(SmartContractMethodInvocation body, bool testnet, string provider = null);

        /// <summary>
        /// Send XDC Erc721 mint transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCMintErc721Transaction(EthMintErc721 body, bool testnet, string provider = null);

        /// <summary>
        /// Send XDC ERC721 mint transaction to the blockchain with cashback details. Nothing is broadcast to the blockchain.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCMintCashbackErc721Transaction(EthMintErc721 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send XDC ERC721 mint provenance transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCMintErc721ProvenanceTransaction(EthMintErc721 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send XDC Erc721 mint multiple transaction with cashback to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCMintMultipleCashbackErc721Transaction(EthMintMultipleErc721 body, bool testnet, string provider = null);

        /// <summary>
        /// Send XDC Erc721 mint multiple provenance transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCMintMultipleErc721ProvenanceTransaction(EthMintMultipleErc721 body, bool testnet, string provider = null);



        /// <summary>
        ///  Send XDC Erc721 mint multiple transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCMintMultipleErc721Transaction(EthMintMultipleErc721 body, bool testnet, string provider = null);




        /// <summary>
        ///  Send XDC Erc721 burn transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCBurnErc721Transaction(EthBurnErc721 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send XDC ERC721 update cashback for author transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCUpdateCashbackForAuthorErc721Transaction(UpdateCashbackErc721 body, bool testnet, string provider = null);


        /// <summary>
        ///   Send XDC Erc721 transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCErc721Transaction(EthTransferErc721 body, bool testnet, string provider = null);



        /// <summary>
        /// *  Send XDC Erc721 deploy to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCDeployErc721Transaction(EthDeployErc721 body, bool testnet, string provider = null);


        /// <summary>
        /// * Send XDC MultiToken transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCMultiTokenTransaction(TransferMultiToken body, bool testnet, string provider = null);


        /// <summary>
        /// * Send XDC MultiToken transaction to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCMultiTokenBatchTransaction(TransferMultiTokenBatch body, bool testnet, string provider = null);


        /// <summary>
        /// Send XDC MultiToken deploy to the blockchain. This method broadcasts signed transaction to the blockchain. This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCDeployMultiTokenTransaction(EthDeployMultiToken body, bool testnet, string provider = null);


        /// <summary>
        /// Send XDC MultiToken mint transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCMintMultiTokenTransaction(MintMultiToken body, bool testnet, string provider = null);


        /// <summary>
        /// Send XDC MultiToken mint batch transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCMintMultiTokenBatchTransaction(MintMultiTokenBatch body, bool testnet, string provider = null);


        /// <summary>
        ///  Send XDC MultiToken burn transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCBurnMultiTokenTransaction(EthBurnMultiToken body, bool testnet, string provider = null);


        /// <summary>
        ///  Send XDC MultiToken burn batch transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCBurnBatchMultiTokenTransaction(EthBurnMultiTokenBatch body, bool testnet, string provider = null);


        /// <summary>
        ///  Send XDC generate custodial wallet transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCGenerateCustodialWalletSignedTransaction(GenerateCustodialAddress body, bool testnet, string provider = null);


        /// <summary>
        ///  Send XDC generate custodial wallet transaction to the blockchain. This method broadcasts signed transaction to the blockchain.This operation is irreversible
        /// </summary>
        /// <param name="body"></param>
        /// <param name="testnet"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<TransactionHash> sendXDCDeployMarketplaceListingSignedTransaction(DeployMarketplaceListing body, bool testnet, string provider = null);










    }
}