using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tatum.Model.Responses
{
    public class GasPrice
    {
        [JsonProperty("fast")]
        public double Fast { get; set; }

        [JsonProperty("fastest")]
        public double Fastest { get; set; }

        [JsonProperty("safeLow")]
        public double SafeLow { get; set; }

        [JsonProperty("average")]
        public double Average { get; set; }

        [JsonProperty("block_time")]
        public double BlockTime { get; set; }

        [JsonProperty("blockNum")]
        public int BlockNum { get; set; }

        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("safeLowWait")]
        public double SafeLowWait { get; set; }

        [JsonProperty("avgWait")]
        public double AvgWait { get; set; }

        [JsonProperty("fastWait")]
        public double FastWait { get; set; }

        [JsonProperty("fastestWait")]
        public double FastestWait { get; set; }

        [JsonProperty("gasPriceRange")]
        public Dictionary<string, double> GasPriceRange { get; set; }
    }
}
