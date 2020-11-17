using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class TxHash
    {
        /// <summary>
        /// TX hash of successful transaction.
        /// </summary>
        [JsonPropertyName("txId")]
        public string TxId { get; set; }

        /// <summary>
        /// Whether withdrawal was completed in Tatum's internal ledger. If not, it must be done manually.
        /// </summary>
        [JsonPropertyName("completed")]
        public bool Completed { get; set; }
    }
}
