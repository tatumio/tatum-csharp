using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class TransactionHash
    {
        /// <summary>
        /// TX hash of successful transaction.
        /// </summary>
        [JsonPropertyName("txId")]
        public string TxId { get; set; }

        [JsonPropertyName("failed")]
        public bool Failed { get; set; }
    }
}
