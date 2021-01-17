using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class TransferBtcBasedOffchain : CreateWithdrawal, IValidatableObject
    {
        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string Mnemonic { get; set; }

        [Required]
        public List<KeyPair> KeyPairs { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (KeyPairs != null && !string.IsNullOrWhiteSpace(Mnemonic))
            {
                yield return new ValidationResult("Either KeyPair, or Mnemonic must be present. Not both at the same time.");
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(Mnemonic))
                {
                    var mnemonicContext = new ValidationContext(Mnemonic);
                    Validator.ValidateObject(Mnemonic, mnemonicContext);
                }

                if (KeyPairs != null)
                {
                    foreach (KeyPair keyPair in KeyPairs)
                    {
                        var keyPairContext = new ValidationContext(keyPair);
                        Validator.ValidateObject(keyPair, keyPairContext, validateAllProperties: true);
                    }
                }
            }
        }
    }
}
