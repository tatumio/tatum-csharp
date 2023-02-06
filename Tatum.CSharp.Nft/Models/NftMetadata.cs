using System.Text.Json.Serialization;

namespace Tatum.CSharp.Nft.Models
{
    public class NftMetadata
    {
        [JsonPropertyName("data")]
        public string Data { get; set; }
    }
}