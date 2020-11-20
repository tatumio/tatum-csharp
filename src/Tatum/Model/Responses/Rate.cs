using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class Rate
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("basePair")]
        public string BasePair { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }
    }
}
