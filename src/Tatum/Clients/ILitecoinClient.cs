using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public interface ILitecoinClient
    {
        Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request);
        Task<LitecoinInfo> GetBlockchainInfo();
        Task<LitecoinBlock> GetBlock(string hash);
        Task<BlockHash> GetBlockHash(long blockHeight);
        Task<LitecoinUtxo> GetUtxo(string txHash, int txOutputIndex);
        Task<List<LitecoinTx>> GetTxForAccount(string address, int pageSize = 50, int offset = 0);
        Task<LitecoinTx> GetTransaction(string hash);


        /// <summary>
        /// Generate Litecoin wallet
        /// </summary>
        /// <param name="mnemonic"></param>
        /// <param name="testnet">testnet or mainnet version of address</param>
        /// <returns></returns>
        Wallet CreateWallet(string mnemonic, bool testnet);

        /// <summary>
        /// Generate Litecoin private key from mnemonic seed
        /// </summary>
        /// <param name="mnemonic">mnemonic to generate private key from</param>
        /// <param name="index">derivation index of private key to generate</param>
        /// <param name="testnet">testnet or mainnet version of address</param>
        /// <returns>blockchain private key</returns>
        string GeneratePrivateKey(string mnemonic, int index, bool testnet);

        /// <summary>
        /// Generate Litecoin address
        /// </summary>
        /// <param name="xPubString">extended public key to generate address from</param>
        /// <param name="index">derivation index of address to generate. Up to 2^31 addresses can be generated</param>
        /// <param name="testnet">testnet or mainnet version of address</param>
        /// <returns>blockchain address</returns>
        string GenerateAddress(string xPubString, int index, bool testnet);


        Task<string> SignKmsTransaction(TransactionKms tx, List<string> privateKeys, bool testnet);

        /// <summary>
        /// Sign Litecoin transaction with private keys locally. Nothing is broadcasted to the blockchain.
        /// </summary>        
        /// <param name="body">content of the transaction to broadcast</param>
        /// <param name="testnet">testnet or mainnet version</param>
        /// <returns>Transaction data to be broadcast to blockchain.</returns>
        Task<string> PrepareSignedTransaction(TransferBtcBasedBlockchain body, bool testnet);

        /// <summary>
        /// Send Litecoin transaction to the blockchain. This method broadcasts signed transaction to the blockchain.
        /// This operation is irreversible.
        /// </summary>
        /// <param name="body">content of the transaction to broadcast</param>
        /// <param name="testnet">testnet or mainnet version</param>
        /// <returns>transaction id of the transaction in the blockchain</returns>
        Task<TransactionHash> SendTransaction(TransferBtcBasedBlockchain body, bool testnet);
    }
}
