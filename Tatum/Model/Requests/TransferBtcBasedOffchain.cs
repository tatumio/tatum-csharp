using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tatum.Model.Requests
{
    public class TransferBtcBasedOffchain : CreateWithdrawal
    {

        
            public string mnemonic { get; set; }
            public string xpub { get; set; }
            public KeyPair[] keyPair { get; set; }
            public bool signatureid { get; set; }


    }
}