using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class BroadcastRequest
    {
        [JsonPropertyName("txData")]
        public string TxData { get; set; }

        [JsonPropertyName("signatureId")]
        public string SignatureId { get; set; }
    }
}
