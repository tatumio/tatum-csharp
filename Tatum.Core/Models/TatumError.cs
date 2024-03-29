using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.Core.Models
{
    public class TatumError
    {
        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }
        
        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; }
        
        [JsonPropertyName("message")]
        public string Message { get; set; }
        
        [JsonPropertyName("data")]
        public List<string> Data { get; set; }
    }
}