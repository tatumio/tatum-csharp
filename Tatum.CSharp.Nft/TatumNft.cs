using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Tatum.CSharp.Core;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Nft.Models;

namespace Tatum.CSharp.Nft
{
    public class TatumNft : ITatumNft
    {
        private const string NftUrl = "/v3/nft";
        
        private readonly HttpClient _httpClient;

        public TatumNft(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<List<NftBalance>> BalanceOfWallet(Chain chain, string address)
        {
            return await _httpClient.GetFromJsonAsync<List<NftBalance>>($"{NftUrl}/address/balance/{chain}/{address}", TatumSerializerOptions.Default);
        }
        
        public async Task<List<NftTransaction>> ListTransactionsByNft(Chain chain, string tokenId, string tokenAddress, int pageSize = 10, int offset = 0, int from = 0, int to = 0)
        {
            var sb = new StringBuilder();
            
            sb.Append($"{NftUrl}/transaction/tokenId/{chain}/{tokenAddress}/{tokenId}");
            
            sb.Append($"?pageSize={pageSize}");
            
            if (offset > 0)
            {
                sb.Append($"&offset={offset}");
            }
            
            if (from > 0)
            {
                sb.Append($"&from={from}");
            }
            
            if (to > 0)
            {
                sb.Append($"&to={to}");
            }

            return await _httpClient.GetFromJsonAsync<List<NftTransaction>>(sb.ToString(), TatumSerializerOptions.Default);

        }

        public async Task<NftMetadata> GetNftMetadata(Chain chain, string contractAddress, string tokenId)
        {
            return await _httpClient.GetFromJsonAsync<NftMetadata>($"{NftUrl}/metadata/{chain}/{contractAddress}/{tokenId}", TatumSerializerOptions.Default);
        }
        
        public async Task<List<NftInCollection>> ListOfNftsFromCollection(Chain chain, string address, int pageSize = 10, int offset = 0)
        {
            var sb = new StringBuilder();
            
            sb.Append($"{NftUrl}/collection/{chain}/{address}");
            
            sb.Append($"?pageSize={pageSize}");
            
            if (offset > 0)
            {
                sb.Append($"&offset={offset}");
            }

            return await _httpClient.GetFromJsonAsync<List<NftInCollection>>(sb.ToString(), TatumSerializerOptions.Default);
        }
    }
}