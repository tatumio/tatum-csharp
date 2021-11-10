using Newtonsoft.Json;

namespace Tatum.Model.Responses
{
    public class DogecoinUtxo
    {

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("script")]
        public string Script { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("coinbase")]
        public bool Coinbase { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

    }
}