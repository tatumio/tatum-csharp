using System.Collections.Generic;
using Tatum.CSharp.Core.Models;

namespace Tatum.CSharp.Nft.Models
{
    public class NftTransactions
    {
        public Dictionary<Chain, List<ChainNftTransaction>> ChainNftTransactions { get; set; } =
            new Dictionary<Chain, List<ChainNftTransaction>>();
    }
}