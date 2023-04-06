using System.Text.Json.Serialization;

namespace Tatum.Rpc.Models
{
    internal class StatusResponse
    {
        [JsonPropertyName("result")] public int Result { get; set; }

        [JsonPropertyName("error")] public object Error { get; set; }

        [JsonPropertyName("id")] public string Id { get; set; }
    }
}