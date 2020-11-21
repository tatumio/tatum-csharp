using System;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class XlmInfo
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("paging_token")]
        public string PagingToken { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("sequence")]
        public int Sequence { get; set; }

        [JsonPropertyName("successful_transaction_count")]
        public int SuccessfulTransactionCount { get; set; }

        [JsonPropertyName("failed_transaction_count")]
        public int FailedTransactionCount { get; set; }

        [JsonPropertyName("operation_count")]
        public int OperationCount { get; set; }

        [JsonPropertyName("closed_at")]
        public DateTime ClosedAt { get; set; }

        [JsonPropertyName("total_coins")]
        public string TotalCoins { get; set; }

        [JsonPropertyName("fee_pool")]
        public string FeePool { get; set; }

        [JsonPropertyName("base_fee_in_stroops")]
        public int BaseFeeInStroops { get; set; }

        [JsonPropertyName("base_reserve_in_stroops")]
        public int BaseReserveInStroops { get; set; }

        [JsonPropertyName("max_tx_set_size")]
        public int MaxTxSetSize { get; set; }

        [JsonPropertyName("protocol_version")]
        public int ProtocolVersion { get; set; }

        [JsonPropertyName("header_xdr")]
        public string HeaderXdr { get; set; }
    }
}
