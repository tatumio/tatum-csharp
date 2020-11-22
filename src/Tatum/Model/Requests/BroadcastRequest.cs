using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class BroadcastRequest
    {
        [Required]
        [StringLength(500000, MinimumLength = 1)]
        [JsonPropertyName("txData")]
        public string TxData { get; set; }

        [StringLength(36, MinimumLength = 36)]
        [JsonPropertyName("signatureId")]
        public string SignatureId { get; set; }
    }
}
