using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Blockchain
{
    public interface ILitecoinApi
    {
        [Post("/v3/litecoin/broadcast")]
        Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request);

        [Get("/v3/litecoin/info")]
        Task<LitecoinInfo> GetBlockchainInfo();

        [Get("/v3/litecoin/block/{hash}")]
        Task<LitecoinBlock> GetBlock(string hash);

        [Get("/v3/litecoin/block/hash/{blockHeight}")]
        Task<BlockHash> GetBlockHash(long blockHeight);

        [Get("/v3/litecoin/utxo/{txHash}/{txOutputIndex}")]
        Task<LitecoinUtxo> GetUtxo(string txHash, int txOutputIndex);

        [Get("/v3/litecoin/transaction/address/{address}?pageSize={pageSize}&offset={offset}")]
        Task<List<LitecoinTx>> GetTxForAccount(string address, int pageSize = 50, int offset = 0);

        [Get("/v3/litecoin/transaction/{hash}")]
        Task<LitecoinTx> GetTransaction(string hash);
    }
}
