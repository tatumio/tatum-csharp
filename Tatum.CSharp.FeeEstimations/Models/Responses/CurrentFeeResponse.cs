using System.Text.Json.Serialization;

namespace Tatum.CSharp.FeeEstimations.Models.Responses
{
    internal class CurrentFeeResponse
    {
        [JsonPropertyName("fast")]
        public decimal Fast { get; set; }

        [JsonPropertyName("medium")]
        public decimal Medium { get; set; }

        [JsonPropertyName("slow")]
        public decimal Slow { get; set; }

        [JsonPropertyName("baseFee")]
        public decimal BaseFee { get; set; }

        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("block")]
        public int Block { get; set; }
    }  
}

