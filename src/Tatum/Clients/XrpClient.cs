using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Blockchain;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public class XrpClient : IXrpClient
    {
        private readonly IXrpApi xrpApi;

        public XrpClient(string apiBaseUrl, string xApiKey)
        {
            xrpApi = RestClientFactory.Create<IXrpApi>(apiBaseUrl, xApiKey);
        }

        Task<TransactionHash> IXrpClient.Broadcast(BroadcastRequest request)
        {
            return xrpApi.Broadcast(request);
        }

        Task<XrpAccountBalance> IXrpClient.GetAccountBalance(string accountAddress)
        {
            return xrpApi.GetAccountBalance(accountAddress);
        }

        Task<XrpAccountInfo> IXrpClient.GetAccountInfo(string accountAddress)
        {
            return xrpApi.GetAccountInfo(accountAddress);
        }

        Task<XrpAccountTransactionsRoot> IXrpClient.GetAccountTransactions(string address, uint min, string marker)
        {
            return xrpApi.GetAccountTransactions(address, min, marker);
        }

        Task<XrpInfo> IXrpClient.GetBlockchainInfo()
        {
            return xrpApi.GetBlockchainInfo();
        }

        Task<XrpFee> IXrpClient.GetFee()
        {
            return xrpApi.GetFee();
        }

        Task<XrpLedgerRoot> IXrpClient.GetLedger(uint sequence)
        {
            return xrpApi.GetLedger(sequence);
        }

        Task<XrpTx> IXrpClient.GetTransaction(string hash)
        {
            return xrpApi.GetTransaction(hash);
        }
    }
}
