using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class OrderBook
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("pair")]
        public string Pair { get; set; }

        [JsonPropertyName("fill")]
        public string Fill { get; set; }

        [JsonPropertyName("currency1AccountId")]
        public string Currency1AccountId { get; set; }

        [JsonPropertyName("currency2AccountId")]
        public string Currency2AccountId { get; set; }

        [JsonPropertyName("created")]
        public long Created { get; set; }
    }
}
