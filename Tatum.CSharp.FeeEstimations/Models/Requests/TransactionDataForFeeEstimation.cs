using System.Text.Json.Serialization;
using Tatum.CSharp.Core.Models;

namespace Tatum.CSharp.FeeEstimations.Models.Requests
{
    public class TransactionDataForFeeEstimation
    {
        [JsonPropertyName("chain")]
        public Chain Chain { get; set; }
        
        [JsonPropertyName("type")]
        public TransactionTypeForFeeEstimation Type { get; set; }
        
        [JsonPropertyName("sender")]
        public string SenderAddress { get; set; }

        [JsonPropertyName("recipient")]
        public string RecipientAddress { get; set; }

        [JsonPropertyName("contractAddress")]
        public string ContractAddress { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

    }
}