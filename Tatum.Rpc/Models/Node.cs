using System.Text.Json.Serialization;

namespace Tatum.Rpc.Models
{
    public class Node
    {
        [JsonPropertyName("url")] public string Url { get; set; }

        public long ResponseTime { get; set; }

        public long BlockCount { get; set; }
    }
}