using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Tatum.CSharp.Core.ErrorHandling;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Core.Serialization;

namespace Tatum.CSharp.Core.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<Result<TValue>> ToResultAsync<TValue>(this HttpResponseMessage httpResponseMessage, JsonSerializerOptions options = null)
        {
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadFromJsonAsync<TValue>(TatumSerializerOptions.Default);
                return content;
            }

            var error = await httpResponseMessage.Content.ReadFromJsonAsync<TatumError>(TatumSerializerOptions.Default);

            if (error?.ErrorCode == null)
            {
                var rawMessage = await httpResponseMessage.Content.ReadAsStringAsync();
                return new Result<TValue>(rawMessage);
            }
            
            var errorMessage = ErrorMessageStore.ErrorMessages.TryGetValue(error.ErrorCode, out var message) ? message : error.Message;

            if(error.Data != null && error.Data.Any())
            {
                errorMessage += $": {string.Join(", ", error.Data)}";
            }
            
            return new Result<TValue>(errorMessage);
        }

    }
}