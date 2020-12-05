using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class BroadcastWithdrawal
    {
        [Required]
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [Required]
        [JsonPropertyName("txData")]
        public string TxData { get; set; }

        [StringLength(24, MinimumLength = 24)]
        [JsonPropertyName("withdrawalId")]
        public string WithdrawalId { get; set; }

        [JsonPropertyName("signatureId")]
        public Guid SignatureId { get; set; }
    }
}
