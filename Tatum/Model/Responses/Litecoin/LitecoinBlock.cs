using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tatum.Model.Responses
{
    public class LitecoinBlock
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("prevBlock")]
        public string PreviousBlockHash { get; set; }

        [JsonProperty("merkleRoot")]
        public string MerkleRoot { get; set; }

        [JsonProperty("ts")]
        public long Time { get; set; }

        [JsonProperty("bits")]
        public long Bits { get; set; }

        [JsonProperty("nonce")]
        public long Nonce { get; set; }

        [JsonProperty("txs")]
        public List<LitecoinTx> Txs { get; set; }
    }
}
