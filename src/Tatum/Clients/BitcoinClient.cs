using System.Threading.Tasks;
using Tatum.Blockchain;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public class BitcoinClient : IBitcoinClient
    {
        private readonly IBitcoinApi bitcoinApi;

        public BitcoinClient(string apiBaseUrl, string xApiKey)
        {
            bitcoinApi = RestClientFactory.Create<IBitcoinApi>(apiBaseUrl, xApiKey);
        }

        Task<BitcoinInfo> IBitcoinClient.GetBlockchainInfo()
        {
            return bitcoinApi.GetBlockchainInfo();
        }
    }
}
