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
        Task<List<BitcoinCashTx>> GetTxForAccount(string address, int skip = 0);
        Task<BitcoinCashTx> GetTransaction(string hash);
    }
}
