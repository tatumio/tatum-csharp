using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class KeyPair
    {
        [Required]
        [StringLength(50, MinimumLength = 30)]
        public string Address { get; set; }

        [Required]
        [StringLength(52, MinimumLength = 52)]
        public string PrivateKey { get; set; }
    }
}
