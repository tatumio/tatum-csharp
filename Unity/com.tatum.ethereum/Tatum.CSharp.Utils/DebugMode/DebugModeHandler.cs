#define DEBUG

using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Tatum.CSharp.Utils.DebugMode
{
    /// <summary>
    /// Debug Mode handler outputting request and response raw data to a Debug Output console - NOT FOR PRODUCTION USE
    /// </summary>
    public class DebugModeHandler : DelegatingHandler
    {
        private readonly bool _hideSecrets;

        private readonly string _dumpFilePath;

        public DebugModeHandler() : this(new DebugModeOptions())
        {
            
        }

        public DebugModeHandler(Func<DebugModeOptions, DebugModeOptions> options) : this(options(new DebugModeOptions()))
        {
            
        }
        
        public DebugModeHandler(DebugModeOptions options)
        {
            _hideSecrets = options.HideSecrets;
            _dumpFilePath = options.DumpFilePath;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var requestLog = await DebugModeFormatter.PrepareRequestLog(request, _hideSecrets);

            HttpResponseMessage response;

            try
            {
                response = await base.SendAsync(request, cancellationToken);
            }
            catch (Exception e)
            {
                var exceptionLog = DebugModeFormatter.PrepareExceptionLog(e);

                requestLog.AppendLine(exceptionLog.ToString());

                Debug.WriteLine(requestLog.ToString());

                throw;
            }

            var responseLog = await DebugModeFormatter.PrepareResponseLog(response, _hideSecrets);

            requestLog.AppendLine(responseLog.ToString());

            Debug.WriteLine(requestLog.ToString());

            if (!string.IsNullOrWhiteSpace(_dumpFilePath)){
                File.AppendAllText(_dumpFilePath, requestLog.ToString());
            }

            return response;
        }
    }
}