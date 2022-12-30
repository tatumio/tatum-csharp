using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tatum.CSharp.Utils
{
    public class DebugModeHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var traceId = Guid.NewGuid().ToString();

            await LogRequest(request, traceId);

            var response = await base.SendAsync(request, cancellationToken);

            await LogResponse(response, traceId);

            return response;
        }

        private static async Task LogRequest(HttpRequestMessage request, string traceId)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"############################################# Tatum Debug REQUEST - TraceId: {traceId}");
            sb.AppendLine($"curl --location --request {request.Method.Method} '{request.RequestUri}'");

            ReplaceDebugUserAgent(request);

            foreach (var header in request.Headers)
            {
                sb.AppendLine($"--header '{header.Key}: {string.Join(",", header.Value)}' ");
            }

            if (request.Content != null)
            {
                var content = await request.Content.ReadAsStringAsync();
                sb.AppendLine($"--header 'Content-Type: application/json' ");
                sb.AppendLine($"--data-raw '{content}'");
            }

            sb.AppendLine($"############################################# Tatum Debug REQUEST - TraceId: {traceId}");

            Debug.WriteLine(sb.ToString());
        }

        private static void ReplaceDebugUserAgent(HttpRequestMessage request)
        {
            if (request.Headers.TryGetValues("User-Agent", out var userAgent))
            {
                foreach (var headerValue in userAgent)
                {
                    if (!headerValue.StartsWith("Tatum_SDK_CSharp")) continue;

                    var debugUserAgent = headerValue.Replace("%2F", "_DebugMode%2F");

                    request.Headers.Remove("User-Agent");
                    request.Headers.Add("User-Agent", debugUserAgent);
                    return;
                }
            }
        }

        private static async Task LogResponse(HttpResponseMessage response, string traceId)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"############################################# Tatum Debug RESPONSE - TraceId: {traceId}");

            sb.AppendLine($"Status code: {response.StatusCode}");

            var content = await response.Content.ReadAsStringAsync();

            var prettyJson = FormatJson(content);

            sb.AppendLine($"Body: {prettyJson}");

            sb.AppendLine($"############################################# Tatum Debug RESPONSE - TraceId: {traceId}");

            Debug.WriteLine(sb.ToString());
        }

        private static string FormatJson(string uglyJson)
        {
            var json = JToken.Parse(uglyJson);
            return json.ToString(Formatting.Indented);
        }
    }
}