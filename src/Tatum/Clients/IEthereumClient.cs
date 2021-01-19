using System.Collections.Generic;
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
    }
}
