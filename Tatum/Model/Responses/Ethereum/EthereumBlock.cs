using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tatum.Model.Responses
{
    public class EthereumBlock
    {
        [JsonProperty("difficulty")]
        public long Difficulty { get; set; }

        [JsonProperty("extraData")]
        public string ExtraData { get; set; }

        [JsonProperty("gasLimit")]
        public int GasLimit { get; set; }

        [JsonProperty("gasUsed")]
        public int GasUsed { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("logsBloom")]
        public string LogsBloom { get; set; }

        [JsonProperty("miner")]
        public string Miner { get; set; }

        [JsonProperty("mixHash")]
        public string MixHash { get; set; }

        [JsonProperty("nonce")]
        public string Nonce { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("parentHash")]
        public string ParentHash { get; set; }

        [JsonProperty("receiptsRoot")]
        public string ReceiptsRoot { get; set; }

        [JsonProperty("sha3Uncles")]
        public string Sha3Uncles { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("stateRoot")]
        public string StateRoot { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("totalDifficulty")]
        public string TotalDifficulty { get; set; }

        [JsonProperty("transactions")]
        public List<EthereumTx> Transactions { get; set; }

        [JsonProperty("transactionsRoot")]
        public string TransactionsRoot { get; set; }
    }
}
