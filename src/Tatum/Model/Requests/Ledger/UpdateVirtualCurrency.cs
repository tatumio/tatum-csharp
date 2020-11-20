using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class UpdateVirtualCurrency
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("baseRate")]
        public int BaseRate { get; set; }

        [JsonPropertyName("basePair")]
        public string BasePair { get; set; }
    }
}
