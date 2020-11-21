using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class EthereumAccountBalance
    {
        [JsonPropertyName("balance")]
        public string Balance { get; set; }
    }
}
