using System.Linq;
using System.Web;
using Tatum.Model;
using Tatum.Model.Requests;
using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class FlowMintNft : FlowMnemonicOrPrivateKeyOrSignatureId
    {

        [Required]
        public string to { get; set; }

        [Required]
        public string url { get; set; }

        [Required]
        public Currency chain { get; set; }

        [Required]
        public uint contractAddress { get; set; }

    }
}