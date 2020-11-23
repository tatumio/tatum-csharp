using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public interface IBitcoinCashClient
    {
        Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request);
        Task<BitcoinCashInfo> GetBlockchainInfo();
        Task<BitcoinCashBlock> GetBlock(string hash);
        Task<BlockHash> GetBlockHash(long blockHeight);
        Wallet CreateWallet(string mnemonic, bool testnet);
        Task<List<BitcoinCashTx>> GetTxForAccount(string address, int skip = 0);
        Task<BitcoinCashTx> GetTransaction(string hash);
        string GeneratePrivateKey(string mnemonic, int index, bool testnet);
        string GenerateAddress(string xPubString, int index, bool testnet);
    }
}
