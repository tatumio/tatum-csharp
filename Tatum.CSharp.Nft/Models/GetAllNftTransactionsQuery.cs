using System.Collections.Generic;

namespace Tatum.CSharp.Nft.Models
{
    public class GetAllNftTransactionsQuery
    {
        public int PageSize { get; set; } = 10;
        public int Offset { get; set; } = 0;
        public List<GetAllNftTransactionDetails> GetAllNftTransactionsDetails { get; set; }
    }
}