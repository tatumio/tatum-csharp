using System.Text.Json.Serialization;

namespace Tatum.Rpc.Models
{
    public class JsonRpcCall
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("jsonrpc")]
        public string JsonRpc { get; set; }
        
        [JsonPropertyName("method")]
        public string Method { get; set; }
        
        [JsonPropertyName("params")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object[] Params { get; set; }
    }
}