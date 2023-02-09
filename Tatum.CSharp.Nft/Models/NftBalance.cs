using System.Collections.Generic;
using Tatum.CSharp.Core.Models;

namespace Tatum.CSharp.Nft.Models
{
    public class NftBalance
    {
        public Dictionary<Chain, ChainNftBalance> ChainNftBalances { get; set; } =
            new Dictionary<Chain, ChainNftBalance>();
    }
}