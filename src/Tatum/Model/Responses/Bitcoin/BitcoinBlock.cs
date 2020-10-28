using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class BitcoinBlock
    {
        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("height")]
        public long Height { get; set; }

        [JsonPropertyName("depth")]
        public long Depth { get; set; }

        [JsonPropertyName("version")]
        public long Version { get; set; }

        [JsonPropertyName("prevBlock")]
        public string PreviousBlockHash { get; set; }

        [JsonPropertyName("merkleRoot")]
        public string MerkleRoot { get; set; }

        [JsonPropertyName("time")]
        public long Time { get; set; }

        [JsonPropertyName("bits")]
        public long Bits { get; set; }

        [JsonPropertyName("nonce")]
        public long Nonce { get; set; }

        [JsonPropertyName("txs")]
        public List<BitcoinTx> Txs { get; set; }
    }
}
