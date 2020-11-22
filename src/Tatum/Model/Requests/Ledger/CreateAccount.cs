using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class CreateAccount : IValidatableObject
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [StringLength(192)]
        [JsonPropertyName("xpub")]
        public string Xpub { get; set; }

        [JsonPropertyName("customer")]
        public CreateCustomer Customer { get; set; }

        [JsonPropertyName("compliant")]
        public bool Compliant { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [JsonPropertyName("accountCode")]
        public string AccountCode { get; set; }

        [StringLength(3, MinimumLength = 3)]
        [JsonPropertyName("accountingCurrency")]
        public string AccountingCurrency { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            if (Customer != null)
            {
                var customerContext = new ValidationContext(Customer);
                Validator.TryValidateObject(Customer, customerContext, results, validateAllProperties: true);
            }

            if (results.Count == 0)
            {
                results.Add(ValidationResult.Success);
            }

            return results;
        }
    }
}
