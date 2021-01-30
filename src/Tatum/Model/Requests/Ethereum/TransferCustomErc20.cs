using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class TransferCustomErc20 : IValidatableObject
    {
        [Required]
        [StringLength(66, MinimumLength = 66)]
        public string FromPrivateKey { get; set; }

        [Required]
        [StringLength(42, MinimumLength = 42)]
        public string To { get; set; }

        [Required]
        [RegularExpression(@"^[+]?((\d+(\.\d*)?)|(\.\d+))$")]
        public string Amount { get; set; }

        [Required]
        [StringLength(42, MinimumLength = 42)]
        public string ContractAddress { get; set; }

        public Fee Fee { get; set; }

        [Range(1, 30)]
        public int Digits { get; set; }

        [Range(0, uint.MaxValue)]
        public uint Nonce { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (Fee != null)
            {
                var feeContext = new ValidationContext(Fee);
                Validator.ValidateObject(Fee, feeContext, validateAllProperties: true);
            }

            if (results.Count == 0)
            {
                results.Add(ValidationResult.Success);
            }

            return results;
        }
    }
}
