using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class CurrencyOperation
    {
        [Required]
        [StringLength(24, MinimumLength = 24)]
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [Required]
        [StringLength(38, MinimumLength = 1)]
        [RegularExpression(@"^[+]?((\d+(\.\d*)?)|(\.\d+))$")]
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [JsonPropertyName("paymentId")]
        public string PaymentId { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [JsonPropertyName("transactionCode")]
        public string TransactionCode { get; set; }

        [StringLength(500, MinimumLength = 1)]
        [JsonPropertyName("recipientNote")]
        public string RecipientNote { get; set; }

        [StringLength(24, MinimumLength = 24)]
        [JsonPropertyName("counterAccount")]
        public string CounterAccount { get; set; }

        [StringLength(500, MinimumLength = 1)]
        [JsonPropertyName("senderNote")]
        public string SenderNote { get; set; }
    }
}
