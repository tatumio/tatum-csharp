using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class BitcoinCashInfo
    {
        [JsonPropertyName("chain")]
        public string Chain { get; set; }

        [JsonPropertyName("blocks")]
        public long Blocks { get; set; }

        [JsonPropertyName("bestblockhash")]
        public string BestBlockHash { get; set; }

        [JsonPropertyName("difficulty")]
        public double Difficulty { get; set; }
    }
}
