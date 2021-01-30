using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public interface IEthereumClient
    {
        Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request);
        Task<int> GetTransactionsCount(string address);
        Task<long> GetCurrentBlock();
        Task<EthereumBlock> GetBlock(string hash);
        Task<EthereumAccountBalance> GetAccountBalance(string address);
        Task<EthereumAccountBalance> GetErc20AccountBalance(string address, string currency, string contractAddress);
        Task<EthereumTx> GetTransaction(string hash);
        Task<List<EthereumTx>> GetAccountTransactions(string address, int pageSize = 50, int offset = 0);


        /// <summary>
        /// Generate Ethereum or any other ERC20 wallet
        /// </summary>
        /// <param name="mnemonic">mnemonic seed to use</param>
        /// <param name="testnet">testnet or mainnet version of address</param>
        /// <returns>Wallet</returns>
        Wallet CreateWallet(string mnemonic, bool testnet);

        /// <summary>
        ///  Generate Ethereum or any other ERC20 private key from mnemonic seed
        /// </summary>
        /// <param name="mnemonic">mnemonic to generate private key from</param>
        /// <param name="index">derivation index of private key to generate</param>
        /// <param name="testnet">testnet or mainnet version of address</param>
        /// <returns>blockchain private key to the address</returns>
        string GeneratePrivateKey(string mnemonic, int index, bool testnet);

        /// <summary>
        /// Generate Ethereum or any other ERC20 address
        /// </summary>
        /// <param name="xPub">extended public key to generate address from</param>
        /// <param name="index">derivation index of address to generate. Up to 2^31 addresses can be generated</param>
        /// <param name="testnet">testnet or mainnet version of address</param>
        /// <returns>blockchain address</returns>
        string GenerateAddress(string xPub, int index, bool testnet);


        /// <summary>
        /// Estimate Gas price for the transaction.
        /// </summary>
        /// <returns>Gas price in Wei.</returns>
        Task<BigInteger> GetGasPriceInWei();

        /// <summary>
        /// Sign Ethereum Store data transaction with private keys locally. Nothing is broadcast to the blockchain.
        /// </summary>
        /// <param name="body">Content of the transaction to broadcast.</param>
        /// <param name="testnet">Mainnet or testnet version</param>
        /// <param name="provider">Url of the Ethereum Server to connect to. If not set, default public server will be used.</param>
        /// <returns>Transaction data to be broadcast to blockchain.</returns>
        Task<string> PrepareStoreDataTransaction(CreateRecord body, bool testnet, string provider = null);

        /// <summary>
        ///  Send Ethereum store data transaction to the blockchain. This method broadcasts signed transaction to the blockchain.
        ///  This operation is irreversible.
        /// </summary>
        /// <param name="body">Content of the transaction to broadcast.</param>
        /// <param name="testnet">mainnet or testnet version</param>
        /// <param name="provider">Url of the Ethereum Server to connect to. If not set, default public server will be used.</param>
        /// <returns>Transaction id of the transaction in the blockchain.</returns>
        Task<TransactionHash> SendStoreDataTransaction(CreateRecord body, bool testnet, string provider = null);

        /// <summary>
        /// Sign Ethereum or supported ERC20 transaction with private keys locally. Nothing is broadcast to the blockchain.
        /// </summary>
        /// <param name="body">Content of the transaction to broadcast.</param>
        /// <param name="testnet">Mainnet or testnet version</param>
        /// <param name="provider">Url of the Ethereum Server to connect to. If not set, default public server will be used.</param>
        /// <returns>Transaction data to be broadcast to blockchain.</returns>
        Task<string> PrepareEthereumOrErc20SignedTransaction(TransferEthereumErc20 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send Ethereum store data transaction to the blockchain. This method broadcasts signed transaction to the blockchain.
        ///  This operation is irreversible. 
        /// </summary>
        /// <param name="body">Content of the transaction to broadcast.</param>
        /// <param name="testnet">mainnet or testnet version</param>
        /// <param name="provider">Url of the Ethereum Server to connect to. If not set, default public server will be used.</param>
        /// <returns>Transaction id of the transaction in the blockchain.</returns>
        Task<TransactionHash> SendEthereumOrErc20SignedTransaction(TransferEthereumErc20 body, bool testnet, string provider = null);

        /// <summary>
        /// Sign Ethereum custom ERC20 transaction with private keys locally. Nothing is broadcast to the blockchain.
        /// </summary>
        /// <param name="body">Content of the transaction to broadcast.</param>
        /// <param name="testnet">Mainnet or testnet version</param>
        /// <param name="provider">Url of the Ethereum Server to connect to. If not set, default public server will be used.</param>
        /// <returns>Transaction data to be broadcast to blockchain.</returns>
        Task<string> PrepareCustomErc20SignedTransaction(TransferCustomErc20 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send Ethereum custom ERC20 transaction to the blockchain. This method broadcasts signed transaction to the blockchain.
        ///  This operation is irreversible. 
        /// </summary>
        /// <param name="body">Content of the transaction to broadcast.</param>
        /// <param name="testnet">mainnet or testnet version</param>
        /// <param name="provider">Url of the Ethereum Server to connect to. If not set, default public server will be used.</param>
        /// <returns>Transaction id of the transaction in the blockchain.</returns>
        Task<TransactionHash> SendCustomErc20SignedTransaction(TransferCustomErc20 body, bool testnet, string provider = null);

        /// <summary>
        /// Sign Ethereum deploy ERC20 transaction with private keys locally. Nothing is broadcast to the blockchain.
        /// </summary>
        /// <param name="body">Content of the transaction to broadcast.</param>
        /// <param name="testnet">Mainnet or testnet version</param>
        /// <param name="provider">Url of the Ethereum Server to connect to. If not set, default public server will be used.</param>
        /// <returns>Transaction data to be broadcast to blockchain.</returns>
        Task<string> PrepareDeployErc20SignedTransaction(DeployEthereumErc20 body, bool testnet, string provider = null);

        /// <summary>
        ///  Send Ethereum deploy ERC20 transaction to the blockchain. This method broadcasts signed transaction to the blockchain.
        ///  This operation is irreversible. 
        /// </summary>
        /// <param name="body">Content of the transaction to broadcast.</param>
        /// <param name="testnet">mainnet or testnet version</param>
        /// <param name="provider">Url of the Ethereum Server to connect to. If not set, default public server will be used.</param>
        /// <returns>Transaction id of the transaction in the blockchain.</returns>
        Task<TransactionHash> SendDeployErc20SignedTransaction(DeployEthereumErc20 body, bool testnet, string provider = null);
    }
}
