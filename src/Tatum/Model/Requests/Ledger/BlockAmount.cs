using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class BlockAmount
    {
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
