using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Tatum.CSharp.Core;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Nft.Mappers;
using Tatum.CSharp.Nft.Models;
using Tatum.CSharp.Nft.Models.Responses;

namespace Tatum.CSharp.Nft
{
    public class TatumNft : ITatumNft, ITatumNftCollections
    {
        private const string NftUrl = "/v3/nft";
        
        private readonly HttpClient _httpClient;

        public TatumNft(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<NftBalance> Balance(IEnumerable<NftBalanceDetails> nftBalancesDetails)
        {
            var nftBalance = new NftBalance();
            
            foreach (var nftBalancesDetail in nftBalancesDetails)
            {
                foreach (var address in nftBalancesDetail.Addresses)
                {
                    var response = await _httpClient.GetFromJsonAsync<List<NftBalanceResponse>>($"{NftUrl}/address/balance/{ChainMapper.GetChainAbbreviation(nftBalancesDetail.Chain)}/{address}", TatumSerializerOptions.Default);
                    
                    if (!response?.Any() ?? false)
                    {
                        continue;
                    }
                    
                    if (!nftBalance.ChainNftBalances.ContainsKey(nftBalancesDetail.Chain))
                    {
                        nftBalance.ChainNftBalances.Add(nftBalancesDetail.Chain, new ChainNftBalance());
                    }

                    if (!nftBalance.ChainNftBalances[nftBalancesDetail.Chain].AddressNftBalances.ContainsKey(address))
                    {
                        nftBalance.ChainNftBalances[nftBalancesDetail.Chain].AddressNftBalances.Add(address, new List<AddressNftBalance>());
                    }
                    
                    nftBalance.ChainNftBalances[nftBalancesDetail.Chain].AddressNftBalances[address].AddRange(response.SelectMany(NftMapper.Map));

                }
            }

            return nftBalance;
        }

        public Task<NftBalance> Balance(NftBalanceDetails nftBalanceDetails)
        {
            return Balance(new[] { nftBalanceDetails });
        }

        public async Task<NftTransactions> GetAllNftTransactions(GetAllNftTransactionsQuery getAllNftTransactionsQuery)
        {
            var ntfTransactions = new NftTransactions();
            
            foreach (var getAllNftTransactionsDetail in getAllNftTransactionsQuery.GetAllNftTransactionsDetails)
            {
                var sb = new StringBuilder();
            
                sb.Append($"{NftUrl}/transaction/tokenId/{ChainMapper.GetChainAbbreviation(getAllNftTransactionsDetail.Chain)}/{getAllNftTransactionsDetail.ContractAddress}/{getAllNftTransactionsDetail.TokenId}");
            
                sb.Append($"?pageSize={getAllNftTransactionsQuery.PageSize}");
            
                if (getAllNftTransactionsQuery.Offset > 0)
                {
                    sb.Append($"&offset={getAllNftTransactionsQuery.Offset}");
                }
            
                if (getAllNftTransactionsDetail.FromBlock > 0)
                {
                    sb.Append($"&from={getAllNftTransactionsDetail.FromBlock}");
                }
            
                if (getAllNftTransactionsDetail.ToBlock > 0)
                {
                    sb.Append($"&to={getAllNftTransactionsDetail.ToBlock}");
                }

                var response = await _httpClient.GetFromJsonAsync<List<NftTransactionResponse>>(sb.ToString(), TatumSerializerOptions.Default);
                
                if (!response?.Any() ?? false)
                {
                    continue;
                }
                    
                if (!ntfTransactions.ChainNftTransactions.ContainsKey(getAllNftTransactionsDetail.Chain))
                {
                    ntfTransactions.ChainNftTransactions.Add(getAllNftTransactionsDetail.Chain, new List<ChainNftTransaction>());
                }

                ntfTransactions.ChainNftTransactions[getAllNftTransactionsDetail.Chain].AddRange(response.Select(NftMapper.Map));
            }

            return ntfTransactions;
        }

        public async Task<NftMetadata> GetNftMetadata(IEnumerable<GetNftMetadataDetails> getNftMetadataDetails)
        {
            var nftMetadata = new NftMetadata();
            
            foreach (var getNftMetadataDetail in getNftMetadataDetails)
            {
                var response = await _httpClient.GetFromJsonAsync<NftMetadataResponse>($"{NftUrl}/metadata/{ChainMapper.GetChainAbbreviation(getNftMetadataDetail.Chain)}/{getNftMetadataDetail.ContractAddress}/{getNftMetadataDetail.TokenId}", TatumSerializerOptions.Default);
                
                if (response == null)
                {
                    continue;
                }
                    
                if (!nftMetadata.ChainNftMetadata.ContainsKey(getNftMetadataDetail.Chain))
                {
                    nftMetadata.ChainNftMetadata.Add(getNftMetadataDetail.Chain, new List<ChainNftMetadata>());
                }

                nftMetadata.ChainNftMetadata[getNftMetadataDetail.Chain].Add(NftMapper.Map(getNftMetadataDetail.ContractAddress, getNftMetadataDetail.TokenId, response));
            }

            return nftMetadata;
        }

        public async Task<NftMetadata> GetNftMetadata(GetNftMetadataDetails getNftMetadataDetails)
        {
            return await GetNftMetadata(new[] { getNftMetadataDetails });
        }

        public ITatumNftCollections Collection => this;

        public async Task<NftsInCollection> GetAllNfts(GetAllNftsQuery getAllNftsQuery)
        {
            var nftsInCollection = new NftsInCollection();
            
            foreach (var nftDetail in getAllNftsQuery.NftDetails)
            {
                var sb = new StringBuilder();
            
                sb.Append($"{NftUrl}/collection/{ChainMapper.GetChainAbbreviation(nftDetail.Chain)}/{nftDetail.ContractAddress}");
            
                sb.Append($"?pageSize={getAllNftsQuery.PageSize}");
            
                if (getAllNftsQuery.Offset > 0)
                {
                    sb.Append($"&offset={getAllNftsQuery.Offset}");
                }

                var response = await _httpClient.GetFromJsonAsync<List<NftInCollectionResponse>>(sb.ToString(), TatumSerializerOptions.Default);
                
                if (!response?.Any() ?? false)
                {
                    continue;
                }
                    
                if (!nftsInCollection.ChainNftsInCollection.ContainsKey(nftDetail.Chain))
                {
                    nftsInCollection.ChainNftsInCollection.Add(nftDetail.Chain, new ChainNftsInCollection());
                }
                
                if (!nftsInCollection.ChainNftsInCollection[nftDetail.Chain].ContractAddressNftsInCollection.ContainsKey(nftDetail.ContractAddress))
                {
                    nftsInCollection.ChainNftsInCollection[nftDetail.Chain].ContractAddressNftsInCollection.Add(nftDetail.ContractAddress, new List<ContractAddressNftsInCollection>());
                }
                    
                nftsInCollection.ChainNftsInCollection[nftDetail.Chain].ContractAddressNftsInCollection[nftDetail.ContractAddress].AddRange(response.Select(NftMapper.Map));
            }

            return nftsInCollection;
        }
    }

    public interface ITatumNftCollections
    {
        Task<NftsInCollection> GetAllNfts(GetAllNftsQuery getAllNftsQuery);
    }
}