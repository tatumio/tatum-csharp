using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class Blockage
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}

