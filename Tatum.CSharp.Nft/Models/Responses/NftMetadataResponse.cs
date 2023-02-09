using System.Text.Json.Serialization;

namespace Tatum.CSharp.Nft.Models.Responses
{
    public class NftMetadataResponse
    {
        [JsonPropertyName("data")]
        public string Data { get; set; }
    }
}