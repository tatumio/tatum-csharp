using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class OrderBookRequest
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("pair")]
        public string Pair { get; set; }

        [JsonPropertyName("currency1AccountId")]
        public string Currency1AccountId { get; set; }

        [JsonPropertyName("currency2AccountId")]
        public string Currency2AccountId { get; set; }

        [JsonPropertyName("feeAccountId")]
        public string FeeAccountId { get; set; }

        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }
    }
}
