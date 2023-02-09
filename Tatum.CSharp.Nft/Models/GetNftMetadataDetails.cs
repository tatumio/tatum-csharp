using Tatum.CSharp.Core.Models;

namespace Tatum.CSharp.Nft.Models
{
    public class GetNftMetadataDetails
    {
        public Chain Chain { get; set; }
        public string ContractAddress { get; set; }
        public string TokenId { get; set; }
    }
}