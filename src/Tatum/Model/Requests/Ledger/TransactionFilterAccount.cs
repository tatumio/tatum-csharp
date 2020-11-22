using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class TransactionFilterAccount
    {
        [Required]
        [StringLength(24, MinimumLength = 24)]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [StringLength(24, MinimumLength = 24)]
        [JsonPropertyName("counterAccount")]
        public string CounterAccount { get; set; }

        [JsonPropertyName("from")]
        public ulong From { get; set; }

        [JsonPropertyName("to")]
        public ulong To { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("transactionType")]
        public string TransactionType { get; set; }

        [JsonPropertyName("opType")]
        public string OpType { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [JsonPropertyName("transactionCode")]
        public string TransactionCode { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [JsonPropertyName("paymentId")]
        public string PaymentId { get; set; }

        [StringLength(500, MinimumLength = 1)]
        [JsonPropertyName("recipientNote")]
        public string RecipientNote { get; set; }

        [StringLength(500, MinimumLength = 1)]
        [JsonPropertyName("senderNote")]
        public string SenderNote { get; set; }
    }
}
