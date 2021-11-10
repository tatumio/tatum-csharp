using System.Linq;
using System.Web;
using Tatum.Model;
using Tatum.Model.Requests;
using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class FlowDeployNft : FlowMnemonicOrPrivateKeyOrSignatureId
    {
        [Required]
        public Currency chain { get; set; }
    }
}