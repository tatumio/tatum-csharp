using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Blockchain
{
    public interface IEthereumApi
    {
        [Post("/v3/ethereum/broadcast")]
        Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request);

        [Get("/v3/ethereum/transaction/count/{address}")]
        Task<int> GetTransactionsCount(string address);

        [Get("/v3/ethereum/block/current")]
        Task<long> GetCurrentBlock();

        [Get("/v3/ethereum/block/{hash}")]
        Task<EthereumBlock> GetBlock(string hash);

        [Get("/v3/ethereum/account/balance/{address}")]
        Task<EthereumAccountBalance> GetAccountBalance(string address);

        [Get("/v3/ethereum/account/balance/erc20/{address}?currency={currency}&contractAddress={contractAddress}")]
        Task<EthereumAccountBalance> GetErc20AccountBalance(string address, string currency, string contractAddress);

        [Get("/v3/ethereum/transaction/{hash}")]
        Task<EthereumTransaction> GetTransaction(string hash);

        [Get("/v3/ethereum/account/transaction/{address}?pageSize={pageSize}&offset={offset}")]
        Task<List<EthereumTransaction>> GetAccountTransactions(string address, int pageSize = 50, int offset = 0);
    }
}
