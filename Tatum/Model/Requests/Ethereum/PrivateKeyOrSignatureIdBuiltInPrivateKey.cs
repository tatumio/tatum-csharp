using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tatum.Model;
using Tatum.Model.Requests;

using System.ComponentModel.DataAnnotations;

namespace Tatum.Model.Requests
{
    public class PrivateKeyOrSignatureIdBuiltInPrivateKey
    {
        [Required]
        [StringLength(66, MinimumLength = 32)]
        public string FromPrivatekey { get; set; }

        [StringLength(36, MinimumLength = 36)]
        public string signatureId { get; set; }

        [Range(0, uint.MaxValue)]
        public uint index { get; set; }
    }
}