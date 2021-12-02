using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class TransferBtcBasedOffchainKMS
    {

        [Required]
        [StringLength(24, MinimumLength = 24)]
        public string xpub { get; set; }

        [Required]
        [StringLength(24, MinimumLength = 1000)]
        public string signatureId { get; set; }

    }
}