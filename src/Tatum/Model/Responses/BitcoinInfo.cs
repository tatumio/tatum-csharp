using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class BitcoinInfo
    {
        [JsonPropertyName("chain")]
        public string Chain { get; set; }

        [JsonPropertyName("blocks")]
        public int Blocks { get; set; }

        [JsonPropertyName("headers")]
        public int Headers { get; set; }

        [JsonPropertyName("bestblockhash")]
        public string BestBlockHash { get; set; }

        [JsonPropertyName("difficulty")]
        public double Difficulty { get; set; }
    }
}
