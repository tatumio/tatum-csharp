using System.Collections.Generic;

namespace Tatum.CSharp.Nft.Models
{
    public class ChainNftBalance
    {
        public Dictionary<string, List<AddressNftBalance>> AddressNftBalances { get; set; } =
            new Dictionary<string, List<AddressNftBalance>>();

    }
}