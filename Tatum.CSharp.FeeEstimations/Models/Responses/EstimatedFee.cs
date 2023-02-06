using System.Text.Json.Serialization;

namespace Tatum.CSharp.FeeEstimations.Models.Responses
{
    public class EstimatedFeeResponse
    {
        [JsonPropertyName("gasLimit")]
        public decimal GasLimit { get; set; }
        
        [JsonPropertyName("gasPrice")]
        public decimal GasPrice { get; set; }
    }
}