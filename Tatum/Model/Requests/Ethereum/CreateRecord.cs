using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class CreateRecord : IValidatableObject
    {
        [Required]
        [StringLength(130000, MinimumLength = 1)]
        public string Data { get; set; }

        [Required]
        [StringLength(66, MinimumLength = 32)]
        public string FromPrivatekey { get; set; }

        [StringLength(42, MinimumLength = 42)]
        public string To { get; set; }

        [Range(0, uint.MaxValue)]
        public uint Nonce { get; set; }

        public EthFee EthFee { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (EthFee != null)
            {
                var feeContext = new ValidationContext(EthFee);
                Validator.ValidateObject(EthFee, feeContext, validateAllProperties: true);
            }

            if (results.Count == 0)
            {
                results.Add(ValidationResult.Success);
            }

            return results;
        }
    }
}
