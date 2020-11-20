using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class CreateTransaction
    {
        [JsonPropertyName("senderAccountId")]
        public string SenderAccountId { get; set; }

        [JsonPropertyName("recipientAccountId")]
        public string RecipientAccountId { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("anonymous")]
        public bool Anonymous { get; set; }

        [JsonPropertyName("compliant")]
        public bool Compliant { get; set; }

        [JsonPropertyName("transactionCode")]
        public string TransactionCode { get; set; }

        [JsonPropertyName("paymentId")]
        public string PaymentId { get; set; }

        [JsonPropertyName("recipientNote")]
        public string RecipientNote { get; set; }

        [JsonPropertyName("baseRate")]
        public int BaseRate { get; set; }

        [JsonPropertyName("senderNote")]
        public string SenderNote { get; set; }
    }

}
