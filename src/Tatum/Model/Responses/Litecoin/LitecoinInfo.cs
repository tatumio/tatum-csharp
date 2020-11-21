using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class LitecoinInfo
    {
        [JsonPropertyName("chain")]
        public string Chain { get; set; }

        [JsonPropertyName("blocks")]
        public long Blocks { get; set; }

        [JsonPropertyName("headers")]
        public long Headers { get; set; }

        [JsonPropertyName("bestblockhash")]
        public string BestBlockHash { get; set; }

        [JsonPropertyName("difficulty")]
        public double Difficulty { get; set; }
    }
}
