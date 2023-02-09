using System.Text.Json.Serialization;

namespace Tatum.CSharp.Nft.Models.Responses
{
    public class NftTransactionResponse
    {
        [JsonPropertyName("blockNumber")]
        public int BlockNumber { get; set; }
        
        [JsonPropertyName("txId")]
        public string TransactionId { get; set; }
        
        [JsonPropertyName("contractAddress")]
        public string ContractAddress { get; set; }
        
        [JsonPropertyName("tokenId")]
        public string TokenId { get; set; }
        
        [JsonPropertyName("from")]
        public string FromAddress { get; set; }
        
        [JsonPropertyName("to")]
        public string ToAddress { get; set; }
    }
}