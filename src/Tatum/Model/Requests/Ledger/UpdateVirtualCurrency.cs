using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class UpdateVirtualCurrency
    {
        [Required]
        [StringLength(30, MinimumLength = 1)]
        [RegularExpression(@"^[a-zA-Z0-9_]+$")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("baseRate")]
        public uint BaseRate { get; set; }

        [StringLength(5, MinimumLength = 3)]
        [JsonPropertyName("basePair")]
        public string BasePair { get; set; }
    }
}
