using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class VeChainAccountEnergy
    {
        [JsonPropertyName("energy")]
        public string Energy { get; set; }
    }
}
