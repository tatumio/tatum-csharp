using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Tatum.Model.Requests
{
    public class BroadcastRequest
    {
        [Required]
        [StringLength(500000, MinimumLength = 1)]
        [JsonProperty("txData")]
        public string TxData { get; set; }

        [StringLength(36, MinimumLength = 36)]
        [JsonProperty("signatureId")]
        public string SignatureId { get; set; }

   
    }
}
