using System.Collections.Generic;
using Tatum.CSharp.Core.Models;

namespace Tatum.CSharp.Nft.Models
{
    public class NftMetadata
    {
        public Dictionary<Chain, List<ChainNftMetadata>> ChainNftMetadata { get; set; } =
            new Dictionary<Chain, List<ChainNftMetadata>>();
    }
}