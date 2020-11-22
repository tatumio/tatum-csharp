using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class XrpInfo
    {
        [JsonPropertyName("ledger_hash")]
        public string LedgerHash { get; set; }

        [JsonPropertyName("ledger_index")]
        public int LedgerIndex { get; set; }
    }
}
