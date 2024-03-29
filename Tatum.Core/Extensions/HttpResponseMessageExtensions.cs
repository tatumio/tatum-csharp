using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Tatum.Core.ErrorHandling;
using Tatum.Core.Models;
using Tatum.Core.Serialization;

namespace Tatum.Core.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<Result<TValue>> ToResultAsync<TValue>(this HttpResponseMessage httpResponseMessage, JsonSerializerOptions options = null)
        {
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadFromJsonAsync<TValue>(TatumSerializerOptions.Default).ConfigureAwait(false);
                return content;
            }

            var error = await httpResponseMessage.Content.ReadFromJsonAsync<TatumError>(TatumSerializerOptions.Default).ConfigureAwait(false);

            if (error?.ErrorCode == null)
            {
                var rawMessage = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                return new Result<TValue>(rawMessage);
            }
            
            var errorMessage = ErrorMessageStore.ErrorMessages.TryGetValue(error.ErrorCode, out var message) ? message : error.Message;

            if(error.Data != null && error.Data.Any())
            {
                errorMessage += $": {string.Join(", ", error.Data)}";
            }
            
            return new Result<TValue>(errorMessage);
        }
        
        public static async Task<EmptyResult> ToEmptyResultAsync(this HttpResponseMessage httpResponseMessage, JsonSerializerOptions options = null)
        {
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return new EmptyResult();
            }

            var error = await httpResponseMessage.Content.ReadFromJsonAsync<TatumError>(TatumSerializerOptions.Default).ConfigureAwait(false);

            if (error?.ErrorCode == null)
            {
                var rawMessage = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                return new EmptyResult(rawMessage);
            }
            
            var errorMessage = ErrorMessageStore.ErrorMessages.TryGetValue(error.ErrorCode, out var message) ? message : error.Message;

            if(error.Data != null && error.Data.Any())
            {
                errorMessage += $": {string.Join(", ", error.Data)}";
            }
            
            return new EmptyResult(errorMessage);
        }

    }
}