using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class EstimateGasRequest
    {
        [Required]
        [StringLength(50)]
        [JsonPropertyName("from")]
        public string From { get; set; }

        [Required]
        [StringLength(50)]
        [JsonPropertyName("to")]
        public string To { get; set; }

        [Required]
        [StringLength(50)]
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [StringLength(1000)]
        [JsonPropertyName("data")]
        public string Data { get; set; }

        [JsonPropertyName("nonce")]
        public int Nonce { get; set; }
    }
}
