using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public interface IVeChainClient
    {
        Task<TransactionHash> Broadcast(BroadcastRequest request);
        Task<long> EstimateGas(EstimateGasRequest request);
        Task<long> GetCurrentBlock();
        Task<VeChainBlock> GetBlock(string hash);
        Task<VeChainAccountBalance> GetAccountBalance(string address);
        Task<VeChainAccountEnergy> GetAccountEnergy(string address);
        Task<VeChainTx> GetTransaction(string hash);
        Task<VeChainTxReceipt> GetTransactionReceipt(string hash);

        /// <summary>
        /// Generate VeChain wallet
        /// </summary>
        /// <param name="mnemonic">mnemonic seed to use</param>
        /// <param name="testnet">testnet or mainnet version of address</param>
        /// <returns>Wallet</returns>
        Wallet CreateWallet(string mnemonic, bool testnet);

        /// <summary>
        ///  Generate VeChain private key from mnemonic seed
        /// </summary>
        /// <param name="mnemonic">mnemonic to generate private key from</param>
        /// <param name="index">derivation index of private key to generate</param>
        /// <param name="testnet">testnet or mainnet version of address</param>
        /// <returns>blockchain private key to the address</returns>
        string GeneratePrivateKey(string mnemonic, int index, bool testnet);

        /// <summary>
        /// Generate VeChain address
        /// </summary>
        /// <param name="xPub">extended public key to generate address from</param>
        /// <param name="index">derivation index of address to generate. Up to 2^31 addresses can be generated</param>
        /// <param name="testnet">testnet or mainnet version of address</param>
        /// <returns>blockchain address</returns>
        string GenerateAddress(string xPub, int index, bool testnet);
    }
}
