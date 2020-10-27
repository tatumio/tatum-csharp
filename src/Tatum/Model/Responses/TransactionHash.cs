using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class TransactionHash
    {
        [JsonPropertyName("txId")]
        public string TxId { get; set; }

        [JsonPropertyName("failed")]
        public bool Failed { get; set; }
    }
}
