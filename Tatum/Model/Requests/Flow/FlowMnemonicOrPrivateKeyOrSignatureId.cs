using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tatum.Model;
using Tatum.Model.Requests;
using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class FlowMnemonicOrPrivateKeyOrSignatureId
    {

        [Required]
        [StringLength(66, MinimumLength = 64)]
        public string Privatekey { get; set; }

        [StringLength(36, MinimumLength = 36)]
        public string signatureId { get; set; }

        [Range(0, uint.MaxValue)]
        public uint index { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string mnemonic { get; set; }

        [Required]
        [StringLength(18, MinimumLength = 18)]
        public string account { get; set; }
    }
}