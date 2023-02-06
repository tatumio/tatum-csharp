using System.Text.Json.Serialization;

namespace Tatum.CSharp.Nft.Models
{
    public class NftMetadataDetails
    {
        [JsonPropertyName("tokenId")]
        public string TokenId { get; set; }
        
        [JsonPropertyName("url")]
        public string Url { get; set; }
        
        [JsonPropertyName("metadata")]
        public object Metadata { get; set; }
    }
}