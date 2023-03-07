using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Tatum.Core.Configuration;
using Tatum.Core.Models;

namespace Tatum.Core.Handlers
{
    public class NoApiKeyNetworkHandler : DelegatingHandler
    {
        private readonly ITatumSdkConfiguration _configuration;

        public NoApiKeyNetworkHandler(ITatumSdkConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_configuration.Network == Network.Testnet && string.IsNullOrWhiteSpace(_configuration.ApiKey))
            {
                if (string.IsNullOrWhiteSpace(request.RequestUri.Query))
                {
                    request.RequestUri = new Uri($"{request.RequestUri}?type=testnet");
                }
                else
                {
                    request.RequestUri = new Uri($"{request.RequestUri}&type=testnet");
                }
                
                return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }
            
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}