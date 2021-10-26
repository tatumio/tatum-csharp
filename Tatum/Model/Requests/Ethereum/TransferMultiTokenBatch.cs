using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tatum.Model;
using Tatum.Model.Requests;
using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class TransferMultiTokenBatch : PrivateKeyOrSignatureId
    {

        [Required]
        [StringLength(43, MinimumLength = 42)]
        public string to { get; set; }



        [Required]
        public string tokenId { get; set; }

        [Required]

        public Currency chain { get; set; }



        [StringLength(38)]
        public string contractaddress { get; set; }

        [Required]
        public string[] amounts { get; set; }

        [Required]
        public string data { get; set; }

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