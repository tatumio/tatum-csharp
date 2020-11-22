using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class XrpAccountInfo
    {
        [JsonPropertyName("account_data")]
        public XrpAccountData AccountData { get; set; }

        [JsonPropertyName("ledger_current_index")]
        public int LedgerCurrentIndex { get; set; }

        [JsonPropertyName("validated")]
        public bool Validated { get; set; }
    }

    public class XrpAccountData
    {
        [JsonPropertyName("Account")]
        public string Account { get; set; }

        [JsonPropertyName("Balance")]
        public string Balance { get; set; }

        [JsonPropertyName("Flags")]
        public int Flags { get; set; }

        [JsonPropertyName("LedgerEntryType")]
        public string LedgerEntryType { get; set; }

        [JsonPropertyName("OwnerCount")]
        public int OwnerCount { get; set; }

        [JsonPropertyName("PreviousTxnID")]
        public string PreviousTxnID { get; set; }

        [JsonPropertyName("PreviousTxnLgrSeq")]
        public int PreviousTxnLgrSeq { get; set; }

        [JsonPropertyName("Sequence")]
        public int Sequence { get; set; }

        [JsonPropertyName("index")]
        public string Index { get; set; }
    }
}
