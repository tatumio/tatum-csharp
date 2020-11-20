using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class BroadcastWithdrawal : IValidatableObject
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            var context = new ValidationContext(this);
            Validator.TryValidateObject(this, context, results, validateAllProperties: true);

            return results;
        }
    }
}
