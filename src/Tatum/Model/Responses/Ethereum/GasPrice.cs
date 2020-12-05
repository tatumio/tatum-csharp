using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class GasPrice
    {
        [JsonPropertyName("fast")]
        public double Fast { get; set; }

        [JsonPropertyName("fastest")]
        public double Fastest { get; set; }

        [JsonPropertyName("safeLow")]
        public double SafeLow { get; set; }

        [JsonPropertyName("average")]
        public double Average { get; set; }

        [JsonPropertyName("block_time")]
        public double BlockTime { get; set; }

        [JsonPropertyName("blockNum")]
        public int BlockNum { get; set; }

        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("safeLowWait")]
        public double SafeLowWait { get; set; }

        [JsonPropertyName("avgWait")]
        public double AvgWait { get; set; }

        [JsonPropertyName("fastWait")]
        public double FastWait { get; set; }

        [JsonPropertyName("fastestWait")]
        public double FastestWait { get; set; }

        [JsonPropertyName("gasPriceRange")]
        public Dictionary<string, double> GasPriceRange { get; set; }
    }
}
