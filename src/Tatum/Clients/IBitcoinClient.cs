using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public interface IBitcoinClient
    {
        Task<TransactionHash> Broadcast(BroadcastRequest request);
        Task<BitcoinInfo> GetBlockchainInfo();
        Task<BitcoinBlock> GetBlock(string hash);
        Task<BlockHash> GetBlockHash(int blockHeight);
        Task<BitcoinUtxo> GetUtxo(string txHash, int txOutputIndex);
        Task<List<BitcoinTx>> GetTxForAccount(string address, int pageSize = 50, int offset = 0);
        Task<BitcoinTx> GetTransaction(string hash);
        
        Wallet CreateWallet(string mnemonic, bool testnet);
        string GenerateAddress(string xPub, int index, bool testnet);
        string GeneratePrivateKey(string mnemonic, int index, bool testnet);

        Task<string> SignKmsTransaction(TransactionKms tx, List<string> privateKeys, bool testnet);
        Task<string> PrepareSignedTransaction(TransferBtcBasedBlockchain body, bool testnet);
        Task<TransactionHash> SendTransaction(TransferBtcBasedBlockchain body, bool testnet);
    }
}
