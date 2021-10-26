using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tatum.Model;
using Tatum.Model.Requests;

namespace Tatum.Model.Requests
{
    public class TransferErc20 : PrivateKeyOrSignatureId
    {

        [Required]
        
        public Currency currency { get; set; }

        [Required]
        [StringLength(43, MinimumLength = 42)]
        public string contractAddress { get; set; }

        [StringLength(42, MinimumLength = 42)]
        public string digits { get; set; }

        [Required]
        [StringLength(130000, MinimumLength = 1)]
        public string Data { get; set; }

   

        [StringLength(42, MinimumLength = 42)]
        public string To { get; set; }

        [Required]

        public string amount { get; set; }

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