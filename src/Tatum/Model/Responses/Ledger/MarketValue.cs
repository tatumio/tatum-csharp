using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class MarketValue
    {
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("sourceDate")]
        public long SourceDate { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }
    }
}
