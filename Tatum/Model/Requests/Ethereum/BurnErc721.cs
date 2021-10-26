using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tatum.Model;
using Tatum.Model.Requests;
using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class BurnErc721 : PrivateKeyOrSignatureId
    {
       

        [Required]
        public string tokenId { get; set; }

        [Required]

        public Currency chain { get; set; }



        [StringLength(38)]
        public string contractaddress { get; set; }

       

        [Range(0, uint.MaxValue)]
        public uint Nonce { get; set; }

        

    }
}