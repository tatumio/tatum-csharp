using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public partial class TatumClient : ITatumClient
    {
        Task<List<OrderBook>> ITatumClient.GetHistoricalTrades(int pageSize, int offset)
        {
            return tatumApi.GetHistoricalTrades(pageSize, offset);
        }

        Task<List<OrderBook>> ITatumClient.GetActiveBuyTrades(string accountId, int pageSize, int offset)
        {
            return tatumApi.GetActiveBuyTrades(accountId, pageSize, offset);
        }

        Task<List<OrderBook>> ITatumClient.GetActiveSellTrades(string accountId, int pageSize, int offset)
        {
            return tatumApi.GetActiveSellTrades(accountId, pageSize, offset);
        }

        Task<string> ITatumClient.StoreTrade(OrderBookRequest data)
        {
            return tatumApi.StoreTrade(data);
        }

        Task<OrderBook> ITatumClient.GetTrade(string tradeId)
        {
            return tatumApi.GetTrade(tradeId);
        }

        Task ITatumClient.DeleteTrade(string tradeId)
        {
            return tatumApi.DeleteTrade(tradeId);
        }

        Task ITatumClient.DeleteAccountTrades(string accountId)
        {
            return tatumApi.DeleteAccountTrades(accountId);
        }
    }
}
