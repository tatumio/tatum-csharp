using System.Text.Json.Serialization;

namespace Tatum.CSharp.Core.Models
{
    public class TatumError
    {
        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }
        
        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; }
        
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}