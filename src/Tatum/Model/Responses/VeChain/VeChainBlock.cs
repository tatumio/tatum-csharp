using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class VeChainBlock
    {
        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("parentID")]
        public string ParentID { get; set; }

        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }

        [JsonPropertyName("gasLimit")]
        public int GasLimit { get; set; }

        [JsonPropertyName("beneficiary")]
        public string Beneficiary { get; set; }

        [JsonPropertyName("gasUsed")]
        public int GasUsed { get; set; }

        [JsonPropertyName("totalScore")]
        public int TotalScore { get; set; }

        [JsonPropertyName("txsRoot")]
        public string TxsRoot { get; set; }

        [JsonPropertyName("txsFeatures")]
        public int TxsFeatures { get; set; }

        [JsonPropertyName("stateRoot")]
        public string StateRoot { get; set; }

        [JsonPropertyName("receiptsRoot")]
        public string ReceiptsRoot { get; set; }

        [JsonPropertyName("signer")]
        public string Signer { get; set; }

        [JsonPropertyName("transactions")]
        public List<string> Transactions { get; set; }
    }
}
