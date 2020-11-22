using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class XrpLedger
    {
        [JsonPropertyName("accepted")]
        public bool Accepted { get; set; }

        [JsonPropertyName("account_hash")]
        public string AccountHash { get; set; }

        [JsonPropertyName("close_flags")]
        public int CloseFlags { get; set; }

        [JsonPropertyName("close_time")]
        public int CloseTime { get; set; }

        [JsonPropertyName("close_time_human")]
        public string CloseTimeHuman { get; set; }

        [JsonPropertyName("close_time_resolution")]
        public int CloseTimeResolution { get; set; }

        [JsonPropertyName("closed")]
        public bool Closed { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("ledger_hash")]
        public string LedgerHash { get; set; }

        [JsonPropertyName("ledger_index")]
        public string LedgerIndex { get; set; }

        [JsonPropertyName("parent_close_time")]
        public int ParentCloseTime { get; set; }

        [JsonPropertyName("parent_hash")]
        public string ParentHash { get; set; }

        [JsonPropertyName("seqNum")]
        public string SeqNum { get; set; }

        [JsonPropertyName("totalCoins")]
        public string TotalCoins { get; set; }

        [JsonPropertyName("total_coins")]
        public string Total_Coins { get; set; }

        [JsonPropertyName("transaction_hash")]
        public string TransactionHash { get; set; }

        [JsonPropertyName("transactions")]
        public List<Transaction> Transactions { get; set; }
    }
}
