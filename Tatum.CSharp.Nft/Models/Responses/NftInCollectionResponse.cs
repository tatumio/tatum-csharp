using System.Text.Json.Serialization;
using Tatum.CSharp.Core.Converters;

namespace Tatum.CSharp.Nft.Models.Responses
{
    public class NftInCollectionResponse
    {
        [JsonPropertyName("tokenId")]
        public string TokenId { get; set; }
        
        [JsonPropertyName("metadata")]
        public TokenMetadataDetails TokenMetadataDetails { get; set; }
    }

    public class TokenMetadataDetails
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