using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class BlockHash
    {
        [JsonPropertyName("hash")]
        public string Hash { get; set; }
    }
}
