using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.CSharp.Fees.Models.Requests
{
    public class EstimationsRequest
    {
        [JsonPropertyName("estimations")]
        public List<FeeEstimationDetails> Estimations { get; set; }
    }
    
    public class FeeEstimationDetails
    {

        [JsonPropertyName("from")]
        public string From { get; set; }

        [JsonPropertyName("to")]
        public string To { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }
    }
}