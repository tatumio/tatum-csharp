using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class XrpFee
    {
        [JsonPropertyName("current_ledger_size")]
        public string CurrentLedgerSize { get; set; }

        [JsonPropertyName("current_queue_size")]
        public string CurrentQueueSize { get; set; }

        [JsonPropertyName("drops")]
        public Drops Drops { get; set; }

        [JsonPropertyName("expected_ledger_size")]
        public string ExpectedLedgerSize { get; set; }

        [JsonPropertyName("ledger_current_index")]
        public int LedgerCurrentIndex { get; set; }

        [JsonPropertyName("levels")]
        public Levels Levels { get; set; }

        [JsonPropertyName("max_queue_size")]
        public string MaxQueueSize { get; set; }
    }

    public class Drops
    {
        [JsonPropertyName("base_fee")]
        public string BaseFee { get; set; }

        [JsonPropertyName("median_fee")]
        public string MedianFee { get; set; }

        [JsonPropertyName("minimum_fee")]
        public string MinimumFee { get; set; }

        [JsonPropertyName("open_ledger_fee")]
        public string OpenLedgerFee { get; set; }
    }

    public class Levels
    {
        [JsonPropertyName("median_level")]
        public string MedianLevel { get; set; }

        [JsonPropertyName("minimum_level")]
        public string MinimumLevel { get; set; }

        [JsonPropertyName("open_ledger_level")]
        public string OpenLedgerLevel { get; set; }

        [JsonPropertyName("reference_level")]
        public string ReferenceLevel { get; set; }
    }
}
