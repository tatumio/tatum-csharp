using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Nft.Models;

namespace Tatum.CSharp.Nft
{
    public interface ITatumNft
    {
        Task<List<NftBalance>> BalanceOfWallet(Chain chain, string address);
        Task<List<NftTransaction>> ListTransactionsByNft(Chain chain, string tokenId, string tokenAddress, int pageSize = 10, int offset = 0, int from = 0, int to = 0);
        Task<NftMetadata> GetNftMetadata(Chain chain, string contractAddress, string tokenId);
        Task<List<NftInCollection>> ListOfNftsFromCollection(Chain chain, string address, int pageSize = 10, int offset = 0);
    }
}