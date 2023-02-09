using System.Text.Json.Serialization;

namespace Tatum.CSharp.Fees.Models.Responses
{
    public class EstimatedFeeResponse
    {
        [JsonPropertyName("result")]
        public EstimatedFeeResult[] Results { get; set; }

    }

    public class EstimatedFeeResult
    {
        [JsonPropertyName("data")]
        public EstimatedFeeResultData Data { get; set; }
    }

    public class EstimatedFeeResultData
    {
        [JsonPropertyName("gasLimit")]
        public string GasLimit { get; set; }

        [JsonPropertyName("estimations")]
        public EstimatedFeeResultDataEstimation Estimations { get; set; }
    }

    public class EstimatedFeeResultDataEstimation
    {
        [JsonPropertyName("safe")]
        public string Safe { get; set; }
        [JsonPropertyName("standard")]
        public string Standard { get; set; }
        [JsonPropertyName("fast")]
        public string Fast { get; set; }
        [JsonPropertyName("baseFee")]
        public string BaseFee { get; set; }
    }
}