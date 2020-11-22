using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class CreateWithdrawal
    {
        [Required]
        [StringLength(24, MinimumLength = 24)]
        [JsonPropertyName("senderAccountId")]
        public string SenderAccountId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [Required]
        [StringLength(38, MinimumLength = 1)]
        [RegularExpression(@"^[+]?((\d+(\.\d*)?)|(\.\d+))$")]
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [StringLength(64, MinimumLength = 1)]
        [JsonPropertyName("attr")]
        public string Attr { get; set; }

        [JsonPropertyName("compliant")]
        public bool Compliant { get; set; }

        [RegularExpression(@"^[+]?((\d+(\.\d*)?)|(\.\d+))$")]
        [JsonPropertyName("fee")]
        public string Fee { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [JsonPropertyName("paymentId")]
        public string PaymentId { get; set; }

        [StringLength(500, MinimumLength = 1)]
        [JsonPropertyName("senderNote")]
        public string SenderNote { get; set; }
    }
}
