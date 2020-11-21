using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class VeChainAccountBalance
    {
        [JsonPropertyName("balance")]
        public string Balance { get; set; }
    }
}
