using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Tatum.Model.Requests
{
    public class EthFee
    {
        [Required]
        public double GasLimit { get; set; }

        [Required]
        public BigInteger GasPrice { get; set; }
    }
}
