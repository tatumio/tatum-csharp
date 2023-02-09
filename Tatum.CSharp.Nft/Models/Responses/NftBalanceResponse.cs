using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tatum.CSharp.Core.Converters;

namespace Tatum.CSharp.Nft.Models.Responses
{
    public class NftBalanceResponse
    {
        [JsonPropertyName("contractAddress")]
        public string ContractAddress { get; set; }
        
        [JsonPropertyName("balances")]
        public string[] Balances { get; set; }
        
        [JsonPropertyName("blockNumber")]
        public decimal[] BlockNumbers { get; set; }
        
        [JsonPropertyName("metadata")]
        public List<NftTokenMetadataDetails> TokenMetadataDetails { get; set; }
    }

    public class NftTokenMetadataDetails
    {
        [JsonPropertyName("tokenId")]
        public string TokenId { get; set; }
        
        [JsonPropertyName("url")]
        public string Url { get; set; }
        
        [JsonPropertyName("metadata")]
        [JsonConverter(typeof(MetadataToStringConverter))]
        public string Metadata { get; set; }
    }
}