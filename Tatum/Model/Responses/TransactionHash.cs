using Newtonsoft.Json;

namespace Tatum.Model.Responses
{
    public class TransactionHash
    {
        /// <summary>
        /// TX hash of successful transaction.
        /// </summary>
        [JsonProperty("txId")]
        public string TxId { get; set; }

        [JsonProperty("failed")]
        public bool Failed { get; set; }
    }
}
