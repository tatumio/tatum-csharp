using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class OrderBookRequest
    {
        [Required]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [Required]
        [StringLength(38, MinimumLength = 1)]
        [RegularExpression(@"^[+]?((\d+(\.\d*)?)|(\.\d+))$")]
        [JsonPropertyName("price")]
        public string Price { get; set; }

        [Required]
        [StringLength(38, MinimumLength = 1)]
        [RegularExpression(@"^[+]?((\d+(\.\d*)?)|(\.\d+))$")]
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"^[A-a-zZ0-9_\-]+\/[A-Za-z0-9_\-]+$")]
        [JsonPropertyName("pair")]
        public string Pair { get; set; }

        [Required]
        [StringLength(24, MinimumLength = 24)]
        [JsonPropertyName("currency1AccountId")]
        public string Currency1AccountId { get; set; }

        [Required]
        [StringLength(24, MinimumLength = 24)]
        [JsonPropertyName("currency2AccountId")]
        public string Currency2AccountId { get; set; }

        [StringLength(24, MinimumLength = 24)]
        [JsonPropertyName("feeAccountId")]
        public string FeeAccountId { get; set; }

        [StringLength(100)]
        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }
    }
}
