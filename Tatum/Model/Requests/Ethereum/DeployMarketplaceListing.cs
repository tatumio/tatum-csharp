using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tatum.Model;
using Tatum.Model.Requests;
using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class DeployMarketplaceListing : PrivateKeyOrSignatureId
    {

        [Required]
        public uint marketplaceFee { get; set; }


        [Required]
        public string feeRecipient { get; set; }


        [Required]
        public Currency feeCurrency { get; set; }


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