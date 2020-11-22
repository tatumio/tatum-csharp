using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class CreateVirtualCurrency : IValidatableObject
    {
        [Required]
        [StringLength(30, MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z0-9_]+$")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [StringLength(38, MinimumLength = 1)]
        [RegularExpression(@"^[+]?((\d+(\.\d*)?)|(\.\d+))$")]
        [JsonPropertyName("supply")]
        public string Supply { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 3)]
        [JsonPropertyName("basePair")]
        public string BasePair { get; set; }

        [Range(0, int.MaxValue)]
        [JsonPropertyName("baseRate")]
        public int BaseRate { get; set; }

        [JsonPropertyName("customer")]
        public CreateCustomer Customer { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [JsonPropertyName("accountCode")]
        public string AccountCode { get; set; }

        [JsonPropertyName("accountNumber")]
        public string AccountNumber { get; set; }

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
