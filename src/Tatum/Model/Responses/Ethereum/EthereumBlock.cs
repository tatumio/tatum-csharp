using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class EthereumBlock
    {
        [JsonPropertyName("difficulty")]
        public long Difficulty { get; set; }

        [JsonPropertyName("extraData")]
        public string ExtraData { get; set; }

        [JsonPropertyName("gasLimit")]
        public int GasLimit { get; set; }

        [JsonPropertyName("gasUsed")]
        public int GasUsed { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("logsBloom")]
        public string LogsBloom { get; set; }

        [JsonPropertyName("miner")]
        public string Miner { get; set; }

        [JsonPropertyName("mixHash")]
        public string MixHash { get; set; }

        [JsonPropertyName("nonce")]
        public string Nonce { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("parentHash")]
        public string ParentHash { get; set; }

        [JsonPropertyName("receiptsRoot")]
        public string ReceiptsRoot { get; set; }

        [JsonPropertyName("sha3Uncles")]
        public string Sha3Uncles { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("stateRoot")]
        public string StateRoot { get; set; }

        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        [JsonPropertyName("totalDifficulty")]
        public string TotalDifficulty { get; set; }

        [JsonPropertyName("transactions")]
        public List<EthereumTransaction> Transactions { get; set; }

        [JsonPropertyName("transactionsRoot")]
        public string TransactionsRoot { get; set; }
    }
}
