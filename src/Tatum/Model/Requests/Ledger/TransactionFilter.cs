using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class TransactionFilter
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("counterAccount")]
        public string CounterAccount { get; set; }

        [JsonPropertyName("from")]
        public long From { get; set; }

        [JsonPropertyName("to")]
        public long To { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("transactionType")]
        public string TransactionType { get; set; }

        [JsonPropertyName("opType")]
        public string OpType { get; set; }

        [JsonPropertyName("transactionCode")]
        public string TransactionCode { get; set; }

        [JsonPropertyName("paymentId")]
        public string PaymentId { get; set; }

        [JsonPropertyName("recipientNote")]
        public string RecipientNote { get; set; }

        [JsonPropertyName("senderNote")]
        public string SenderNote { get; set; }
    }
}
