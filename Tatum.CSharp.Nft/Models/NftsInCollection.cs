using System.Collections.Generic;
using Tatum.CSharp.Core.Models;

namespace Tatum.CSharp.Nft.Models
{
    public class NftsInCollection
    {
        public Dictionary<Chain, ChainNftsInCollection> ChainNftsInCollection { get; set; } =
            new Dictionary<Chain, ChainNftsInCollection>();
    }
}