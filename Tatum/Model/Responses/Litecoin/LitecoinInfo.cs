using Newtonsoft.Json;

namespace Tatum.Model.Responses
{
    public class LitecoinInfo
    {
        [JsonProperty("chain")]
        public string Chain { get; set; }

        [JsonProperty("blocks")]
        public long Blocks { get; set; }

        [JsonProperty("headers")]
        public long Headers { get; set; }

        [JsonProperty("bestblockhash")]
        public string BestBlockHash { get; set; }

        [JsonProperty("difficulty")]
        public double Difficulty { get; set; }
    }
}
