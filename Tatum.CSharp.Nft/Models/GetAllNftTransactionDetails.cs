using Tatum.CSharp.Core.Models;

namespace Tatum.CSharp.Nft.Models
{
    public class GetAllNftTransactionDetails
    {
        public Chain Chain { get; set; }
        public string TokenId { get; set; }
        public string ContractAddress { get; set; }
        public int FromBlock { get; set; }
        public int ToBlock { get; set; }
    }
}