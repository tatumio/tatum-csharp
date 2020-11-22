using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class XrpAccountTransaction
    {
        [JsonPropertyName("meta")]
        public XrpMeta Meta { get; set; }

        [JsonPropertyName("tx")]
        public XrpTx Tx { get; set; }

        [JsonPropertyName("validated")]
        public bool Validated { get; set; }
    }
}
