using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class XlmAccountInfo
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }

        [JsonPropertyName("subentry_count")]
        public int SubentryCount { get; set; }

        [JsonPropertyName("last_modified_ledger")]
        public int LastModifiedLedger { get; set; }

        [JsonPropertyName("thresholds")]
        public Thresholds Thresholds { get; set; }

        [JsonPropertyName("flags")]
        public Flags Flags { get; set; }

        [JsonPropertyName("balances")]
        public List<XlmAccountBalance> Balances { get; set; }

        [JsonPropertyName("signers")]
        public List<XlmSigner> Signers { get; set; }

        [JsonPropertyName("data")]
        public object Data { get; set; }
    }
    public class Thresholds
    {
        [JsonPropertyName("low_threshold")]
        public int LowThreshold { get; set; }

        [JsonPropertyName("med_threshold")]
        public int MedThreshold { get; set; }

        [JsonPropertyName("high_threshold")]
        public int HighThreshold { get; set; }
    }

    public class Flags
    {
        [JsonPropertyName("auth_required")]
        public bool AuthRequired { get; set; }

        [JsonPropertyName("auth_revocable")]
        public bool AuthRevocable { get; set; }

        [JsonPropertyName("auth_immutable")]
        public bool AuthImmutable { get; set; }
    }

    public class XlmSigner
    {
        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

}
