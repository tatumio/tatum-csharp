using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class XrpLedgerRoot
    {
        [JsonPropertyName("ledger")]
        public XrpLedger Ledger { get; set; }

        [JsonPropertyName("ledger_hash")]
        public string LedgerHash { get; set; }

        [JsonPropertyName("ledger_index")]
        public int LedgerIndex { get; set; }

        [JsonPropertyName("validated")]
        public bool Validated { get; set; }
    }
}
