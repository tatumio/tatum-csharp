using Tatum.Blockchain;

namespace Tatum.Clients
{
    public partial class TatumClient : ITatumClient
    {
        private readonly ITatumApi tatumApi;

        public TatumClient(string apiBaseUrl, string xApiKey)
        {
            tatumApi = RestClientFactory.Create<ITatumApi>(apiBaseUrl, xApiKey);
        }
    }
}
