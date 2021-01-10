using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Tatum.Model.Requests
{
    /// <summary>
    /// Unit is Gwei.
    /// </summary>
    public class Fee
    {
        [Required]
        public double GasLimit { get; set; }

        [Required]
        public BigInteger GasPrice { get; set; }
    }
}
