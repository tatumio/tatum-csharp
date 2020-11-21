using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class EstimateGasRequest
    {
        [JsonPropertyName("from")]
        public string From { get; set; }

        [JsonPropertyName("to")]
        public string To { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("data")]
        public string Data { get; set; }

        [JsonPropertyName("nonce")]
        public int Nonce { get; set; }
    }
}
