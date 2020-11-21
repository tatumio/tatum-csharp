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
    }
}
