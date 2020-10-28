using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public interface IBitcoinClient
    {
        Task<BitcoinInfo> GetBlockchainInfo();
        Task<BitcoinBlock> GetBlock(string hash);
        Task<BlockHash> GetBlockHash(int blockHeight);
        Task<BitcoinUtxo> GetUtxo(string txHash, int txOutputIndex);
        Task<List<BitcoinTx>> GetTxForAccount(string address, int pageSize = 50, int offset = 0);
        Task<BitcoinTx> GetTransaction(string hash);
    }
}
