using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tatum.Model;
using Tatum.Model.Requests;
using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class DeployMultiToken : PrivateKeyOrSignatureId
    {

        [Required]
       
        public string uri { get; set; }


        [Required]
        public Currency chain { get; set; }


        [Range(0, uint.MaxValue)]
        public uint Nonce { get; set; }
    }
}