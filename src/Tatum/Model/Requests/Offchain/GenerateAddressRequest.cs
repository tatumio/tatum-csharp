using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class GenerateAddressRequest : IValidatableObject
    {
        [Required]
        [StringLength(24, MinimumLength = 24)]
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [Range(0, int.MaxValue)]
        [JsonPropertyName("derivationKey")]
        public int DerivationKey { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            var context = new ValidationContext(this);
            Validator.TryValidateObject(this, context, results, validateAllProperties: true);

            return results;
        }
    }
}
