using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Tatum.Blockchain;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    ///<inheritdoc/>
    public partial class BitcoinCashClient : IBitcoinCashClient
    {
        private readonly IBitcoinCashApi bitcoinCashApi;

        public BitcoinCashClient(string apiBaseUrl, string xApiKey)
        {
            bitcoinCashApi = RestClientFactory.Create<IBitcoinCashApi>(apiBaseUrl, xApiKey);
        }

        Task<TransactionHash> IBitcoinCashClient.BroadcastSignedTransaction(BroadcastRequest request)
        {
            var validationContext = new ValidationContext(request);
            Validator.ValidateObject(request, validationContext, validateAllProperties: true);

            return bitcoinCashApi.BroadcastSignedTransaction(request);
        }

        Task<BitcoinCashBlock> IBitcoinCashClient.GetBlock(string hash)
        {
            return bitcoinCashApi.GetBlock(hash);
        }

        Task<BitcoinCashInfo> IBitcoinCashClient.GetBlockchainInfo()
        {
            return bitcoinCashApi.GetBlockchainInfo();
        }

        Task<BlockHash> IBitcoinCashClient.GetBlockHash(long blockHeight)
        {
            return bitcoinCashApi.GetBlockHash(blockHeight);
        }

        Task<BitcoinCashTx> IBitcoinCashClient.GetTransaction(string hash)
        {
            return bitcoinCashApi.GetTransaction(hash);
        }

        Task<List<BitcoinCashTx>> IBitcoinCashClient.GetTxForAccount(string address, int skip)
        {
            return bitcoinCashApi.GetTxForAccount(address, skip);
        }
    }
}
