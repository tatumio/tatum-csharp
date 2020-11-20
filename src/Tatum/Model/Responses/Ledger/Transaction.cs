using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class Transaction
    {
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("counterAccountId")]
        public string CounterAccountId { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("anonymous")]
        public bool Anonymous { get; set; }

        [JsonPropertyName("created")]
        public long Created { get; set; }

        [JsonPropertyName("marketValue")]
        public MarketValue MarketValue { get; set; }

        [JsonPropertyName("operationType")]
        public string OperationType { get; set; }

        [JsonPropertyName("transactionType")]
        public string TransactionType { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("transactionCode")]
        public string TransactionCode { get; set; }

        [JsonPropertyName("senderNote")]
        public string SenderNote { get; set; }

        [JsonPropertyName("recipientNote")]
        public string RecipientNote { get; set; }

        [JsonPropertyName("paymentId")]
        public string PaymentId { get; set; }

        [JsonPropertyName("attr")]
        public string Attr { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("txId")]
        public string TxId { get; set; }
    }
}
