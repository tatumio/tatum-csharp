using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tatum.Model;
using Tatum.Model.Requests;
using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class TransferErc721 : PrivateKeyOrSignatureId
    {
        [Required]
        [StringLength(43, MinimumLength = 42)]
        public string to { get; set; }

    

        [Required]
        public string tokenId { get; set; }

        [Required]

        public Currency chain { get; set; }

        [Required]
        public string value { get; set; }

        [StringLength(38)]
        public string contractaddress { get; set; }

        [Required]
        public bool provenance { get; set; }

        [Required]
        public string provenanceData { get; set; }

        [Range(0, uint.MaxValue)]
        public uint Nonce { get; set; }

        [Required]
        public string tokenPrice { get; set; }

    }
}