using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class TransferBtcBasedBlockchain : IValidatableObject
    {
        public List<FromAddress> FromAddresses { get; set; }                
        public List<FromUtxo> FromUtxos { get; set; }        
        public List<To> Tos { get; set; }

        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FromAddresses != null && FromUtxos != null)
            {
                yield return new ValidationResult("Either FromAddresses, or FromUtxos must be present. Not both at the same time.");
            }
            else
            {
                if (FromAddresses != null)
                {
                    foreach (FromAddress address in FromAddresses)
                    {
                        var addressContext = new ValidationContext(address);
                        Validator.ValidateObject(address, addressContext, validateAllProperties: true);
                    }
                }

                if (FromUtxos != null)
                {
                    foreach (FromUtxo utxo in FromUtxos)
                    {
                        var utxoContext = new ValidationContext(utxo);
                        Validator.ValidateObject(utxo, utxoContext, validateAllProperties: true);
                    }
                }
            }

            if (Tos != null && Tos.Count > 0)
            {
                foreach (To to in Tos)
                {
                    var toContext = new ValidationContext(to);
                    Validator.ValidateObject(to, toContext, validateAllProperties: true);
                }
            }
            else
            {
                yield return new ValidationResult("Tos can not be empty.");
            }
        }
    }

    public class FromAddress
    {
        [Required]
        [StringLength(50, MinimumLength = 30)]
        public string Address { get; set; }

        [Required]
        [StringLength(52, MinimumLength = 52)]
        public string PrivateKey { get; set; }
    }

    public class FromUtxo
    {
        [Required]
        [StringLength(64, MinimumLength = 64)]
        public string TxHash { get; set; }

        [Required]
        [Range(0, uint.MaxValue)]
        public uint Index { get; set; }

        [Required]
        [StringLength(52, MinimumLength = 52)]
        public string PrivateKey { get; set; }
    }

    public class To
    {
        [Required]
        [StringLength(50, MinimumLength = 30)]
        public string Address { get; set; }

        [Required]
        [Range(0, double.PositiveInfinity)]
        public decimal Value { get; set; }
    }
}
