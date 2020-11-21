using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public interface IEthereumClient
    {
        Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request);
        Task<int> GetTransactionsCount(string address);
        Task<long> GetCurrentBlock();
        Task<EthereumBlock> GetBlock(string hash);
        Task<EthereumAccountBalance> GetAccountBalance(string address);
        Task<EthereumAccountBalance> GetErc20AccountBalance(string address, string currency, string contractAddress);
        Task<EthereumTransaction> GetTransaction(string hash);
        Task<List<EthereumTransaction>> GetAccountTransactions(string address, int pageSize = 50, int offset = 0);
    }
}
