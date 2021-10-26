using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tatum.Model;
using Tatum.Model.Requests;

namespace Tatum.Model.Requests
{
    public class SmartContractMethodInvocation : PrivateKeyOrSignatureId
    {

        [Required]
        [StringLength(43, MinimumLength = 42)]
        public string contractaddress { get; set; }

        [Required]

        public object paramss { get; set; }

        [Required]
        public string methodABI { get; set; }

        [StringLength(500, MinimumLength = 1)]
        public string methodName { get; set; }

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