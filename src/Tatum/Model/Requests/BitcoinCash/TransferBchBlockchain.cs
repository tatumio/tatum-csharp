using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class TransferBchBlockchain : IValidatableObject
    {
        public List<FromUtxoBcash> FromUtxos { get; set; }
        public List<To> Tos { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FromUtxos != null && FromUtxos.Count > 0)
            {
                foreach (FromUtxoBcash utxo in FromUtxos)
                {
                    if (!double.TryParse(utxo.Value, out _))
                    {
                        yield return new ValidationResult("Value must be a number.");
                    }

                    var utxoContext = new ValidationContext(utxo);
                    Validator.ValidateObject(utxo, utxoContext, validateAllProperties: true);
                }
            }
            else
            {
                yield return new ValidationResult("FromUtxos can not be empty.");
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

    public class FromUtxoBcash : FromUtxo
    {
        [Required]
        public string Value { get; set; }
    }
}
