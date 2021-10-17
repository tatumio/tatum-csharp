using Newtonsoft.Json;

namespace Tatum.Model.Responses
{
    public class EthereumAccountBalance
    {
        [JsonProperty("balance")]
        public string Balance { get; set; }
    }
}
