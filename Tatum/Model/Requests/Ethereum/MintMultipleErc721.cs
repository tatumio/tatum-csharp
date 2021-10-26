using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tatum.Model;
using Tatum.Model.Requests;
using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class MintMultipleErc721 : PrivateKeyOrSignatureId
    {

        [Required]
       
        public string[] to { get; set; }

        [Required]
       
        public string[] url { get; set; }

        [Required]
        public string[] tokenId { get; set; }

        [Required]

        public Currency chain { get; set; }



        [StringLength(38)]
        public string contractaddress { get; set; }

        [Required]
        public bool provenance { get; set; }

        [Range(0, uint.MaxValue)]
        public uint Nonce { get; set; }

        [Required]
        public string[][] authorAddresses { get; set; }

        [Required]
        public string[][] cashbackValues { get; set; }

        [Required]
        public string[][] fixedValues { get; set; }



    }
}