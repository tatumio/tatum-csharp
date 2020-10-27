using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Tatum
{
    public class TatumHttpClientHandler : HttpClientHandler
    {
        private readonly string xApiKey;

        public TatumHttpClientHandler(string xApiKey)
        {
            this.xApiKey = xApiKey;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add(Headers.XApiKey, xApiKey);

            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                string errorMessage = $"Invalid Tatum API request. Response Status Code: {response.StatusCode}. {responseContent}";

                throw new Exception(errorMessage);
            }

            return response;
        }
    }
}
