using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tatum.Model;
using Tatum.Model.Requests;

using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class DeployErc20 : PrivateKeyOrSignatureId
    {

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string symbol { get; set; }

        [StringLength(43, MinimumLength = 42)]
        public string address { get; set; }

        [Required]
        [StringLength(38)]
        public string supply { get; set; }



        [StringLength(38)]
        public string totalCap { get; set; }

        [Required]
        [StringLength(30)]
        public uint digits { get; set; }

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