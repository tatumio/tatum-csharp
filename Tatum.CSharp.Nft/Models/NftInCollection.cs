using System.Text.Json.Serialization;

namespace Tatum.CSharp.Nft.Models
{
    public class NftInCollection
    {
        [JsonPropertyName("tokenId")]
        public string TokenId { get; set; }
        
        [JsonPropertyName("metadata")]
        public NftMetadataDetails MetadataDetails { get; set; }
    }
}