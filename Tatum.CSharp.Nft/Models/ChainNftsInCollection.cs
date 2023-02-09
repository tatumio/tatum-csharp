using System.Collections.Generic;

namespace Tatum.CSharp.Nft.Models
{
    public class ChainNftsInCollection
    {
        public Dictionary<string, List<ContractAddressNftsInCollection>> ContractAddressNftsInCollection { get; set; } =
            new Dictionary<string, List<ContractAddressNftsInCollection>>();
    }
}