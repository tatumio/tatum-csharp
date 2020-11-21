using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class XlmTx
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("paging_token")]
        public string PagingToken { get; set; }

        [JsonPropertyName("successful")]
        public bool Successful { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("ledger")]
        public int Ledger { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("source_account")]
        public string SourceAccount { get; set; }

        [JsonPropertyName("source_account_sequence")]
        public string SourceAccountSequence { get; set; }

        [JsonPropertyName("fee_paid")]
        public int FeePaid { get; set; }

        [JsonPropertyName("fee_charged")]
        public int FeeCharged { get; set; }

        [JsonPropertyName("max_fee")]
        public int MaxFee { get; set; }

        [JsonPropertyName("operation_count")]
        public int OperationCount { get; set; }

        [JsonPropertyName("envelope_xdr")]
        public string EnvelopeXdr { get; set; }

        [JsonPropertyName("result_xdr")]
        public string ResultXdr { get; set; }

        [JsonPropertyName("result_meta_xdr")]
        public string ResultMetaXdr { get; set; }

        [JsonPropertyName("fee_meta_xdr")]
        public string FeeMetaXdr { get; set; }

        [JsonPropertyName("memo")]
        public string Memo { get; set; }

        [JsonPropertyName("memo_type")]
        public string MemoType { get; set; }

        [JsonPropertyName("signatures")]
        public List<string> Signatures { get; set; }
    }
}
