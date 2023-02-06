using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.CSharp.Nft.Models
{
    public class NftBalance
    {
        [JsonPropertyName("contractAddress")]
        public string ContractAddress { get; set; }
        
        [JsonPropertyName("balances")]
        public string[] Balances { get; set; }
        
        [JsonPropertyName("blockNumber")]
        public decimal[] BlockNumbers { get; set; }
        
        [JsonPropertyName("metadata")]
        public List<NftMetadataDetails> MetadataDetails { get; set; }
    }
}