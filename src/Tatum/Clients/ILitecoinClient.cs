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
        Task<string> SignKmsTransaction(TransactionKms tx, List<string> privateKeys, bool testnet);
        Task<LitecoinBlock> GetBlock(string hash);
        Task<BlockHash> GetBlockHash(long blockHeight);
        Task<LitecoinUtxo> GetUtxo(string txHash, int txOutputIndex);
        Task<List<LitecoinTx>> GetTxForAccount(string address, int pageSize = 50, int offset = 0);
        Task<LitecoinTx> GetTransaction(string hash);

        Wallet CreateWallet(string mnemonic, bool testnet);
        string GeneratePrivateKey(string mnemonic, int index, bool testnet);
        string GenerateAddress(string xPubString, int index, bool testnet);
        Task<string> PrepareSignedTransaction(TransferBtcBasedBlockchain body, bool testnet);
        Task<TransactionHash> SendTransaction(TransferBtcBasedBlockchain body, bool testnet);
    }
}
