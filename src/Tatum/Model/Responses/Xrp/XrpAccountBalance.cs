using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class XrpAccountBalance
    {
        [JsonPropertyName("assets")]
        public List<Asset> Assets { get; set; }

        [JsonPropertyName("balance")]
        public string Balance { get; set; }
    }

    public class Asset
    {
        [JsonPropertyName("balance")]
        public string Balance { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }
}
