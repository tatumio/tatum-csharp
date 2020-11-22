using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class XrpAccountTransactionsRoot
    {
        [JsonPropertyName("account")]
        public string Account { get; set; }

        [JsonPropertyName("ledger_index_max")]
        public int LedgerIndexMax { get; set; }

        [JsonPropertyName("ledger_index_min")]
        public int LedgerIndexMin { get; set; }

        [JsonPropertyName("marker")]
        public Marker Marker { get; set; }

        [JsonPropertyName("transactions")]
        public List<XrpAccountTransaction> Transactions { get; set; }
    }
    public class Marker
    {
        [JsonPropertyName("ledger")]
        public int Ledger { get; set; }

        [JsonPropertyName("seq")]
        public int Seq { get; set; }
    }

}
