using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class LitecoinUtxo
    {
        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("height")]
        public long Height { get; set; }

        [JsonPropertyName("value")]
        public long Value { get; set; }

        [JsonPropertyName("script")]
        public string Script { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("coinbase")]
        public bool Coinbase { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("index")]
        public int Index { get; set; }
    }

}
