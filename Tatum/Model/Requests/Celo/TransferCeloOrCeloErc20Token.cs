using System.Linq;
using System.Web;
using Tatum.Model;
using Tatum.Model.Requests;
using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class TransferCeloOrCeloErc20Token : PrivateKeyOrSignatureId
    {

        [Required]
        [StringLength(42, MinimumLength = 42)]
        public string to { get; set; }

        [Required]   
        public string amount { get; set; }

        [Required]
        [StringLength(130000)]
        public string data { get; set; }

        [Required]
        
        public Currency currency { get; set; }

        [Required]
        [StringLength(42, MinimumLength = 42)]
        public string contractAddress { get; set; }

        [Required]
        [StringLength(42, MinimumLength = 42)]
        public Currency feccCurrency { get; set; }


        [Required]
        public int number { get; set; }

        [Required]
        public EthFee fee { get; set; }


    }
}