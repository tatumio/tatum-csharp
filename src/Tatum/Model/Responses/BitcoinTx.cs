using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class BitcoinTx
    {
        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("witnessHash")]
        public string WitnessHash { get; set; }

        [JsonPropertyName("fee")]
        public int Fee { get; set; }

        [JsonPropertyName("rate")]
        public int Rate { get; set; }

        [JsonPropertyName("mtime")]
        public int MTime { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("block")]
        public string Block { get; set; }

        [JsonPropertyName("time")]
        public int Time { get; set; }

        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; }

        // TODO remaining properties
    }
}
