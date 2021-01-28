using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class DeployEthereumErc20 : IValidatableObject
    {
        [Required]
        [StringLength(66, MinimumLength = 66)]
        public string FromPrivateKey { get; set; }

        [Required]
        [StringLength(42, MinimumLength = 42)]
        public string Address { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z0-9_]+$")]
        public string Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string Symbol { get; set; }

        [Required]
        [RegularExpression(@"^[+]?((\d+(\.\d*)?)|(\.\d+))$")]
        public string Supply { get; set; }

        [Range(1, 30)]
        public byte Digits { get; set; }

        public Fee Fee { get; set; }

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
