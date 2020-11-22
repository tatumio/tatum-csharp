using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class BlockAmount
    {
        [Required]
        [StringLength(38)]
        [RegularExpression(@"^[+]?((\d+(\.\d*)?)|(\.\d+))$")]
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [StringLength(300, MinimumLength = 1)]
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
