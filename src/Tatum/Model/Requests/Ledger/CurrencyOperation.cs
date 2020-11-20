using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class CurrencyOperation
    {
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("paymentId")]
        public string PaymentId { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("transactionCode")]
        public string TransactionCode { get; set; }

        [JsonPropertyName("recipientNote")]
        public string RecipientNote { get; set; }

        [JsonPropertyName("counterAccount")]
        public string CounterAccount { get; set; }

        [JsonPropertyName("senderNote")]
        public string SenderNote { get; set; }
    }
}
