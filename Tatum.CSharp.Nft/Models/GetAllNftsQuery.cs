using System.Collections.Generic;

namespace Tatum.CSharp.Nft.Models
{
    public class GetAllNftsQuery
    {
        public int PageSize { get; set; } = 10;
        public int Offset { get; set; } = 0;
        public List<NftDetails> NftDetails { get; set; }
    }
}