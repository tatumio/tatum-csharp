using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.CSharp.Nft.Models;

namespace Tatum.CSharp.Nft
{
    public interface ITatumNft
    {
        Task<NftBalance> Balance(IEnumerable<NftBalanceDetails> nftBalancesDetails);
        Task<NftBalance> Balance(NftBalanceDetails nftBalanceDetails);
        Task<NftTransactions> GetAllNftTransactions(GetAllNftTransactionsQuery getAllNftTransactionsQuery);
        Task<NftMetadata> GetNftMetadata(IEnumerable<GetNftMetadataDetails> getNftMetadataDetails);
        Task<NftMetadata> GetNftMetadata(GetNftMetadataDetails getNftMetadataDetails);
        
        ITatumNftCollections Collection { get; }
    }
}