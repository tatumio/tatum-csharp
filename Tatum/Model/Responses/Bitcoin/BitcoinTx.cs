using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tatum.Model.Responses
{
    public class BitcoinTx
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("witnessHash")]
        public string WitnessHash { get; set; }

        [JsonProperty("fee")]
        public long Fee { get; set; }

        [JsonProperty("rate")]
        public int Rate { get; set; }

        [JsonProperty("mtime")]
        public long MTime { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("block")]
        public string Block { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("inputs")]
        public List<BitcoinTxInput> Inputs { get; set; }

        [JsonProperty("outputs")]
        public List<BitcoinTxOutput> Outputs { get; set; }

        [JsonProperty("locktime")]
        public int Locktime { get; set; }
    }

    public class BitcoinTxInput
    {
        [JsonProperty("prevout")]
        public BitcoinTxPrevout Prevout { get; set; }

        [JsonProperty("script")]
        public string Script { get; set; }

        [JsonProperty("witness")]
        public string Witness { get; set; }

        [JsonProperty("sequence")]
        public long Sequence { get; set; }

        [JsonProperty("coin")]
        public BitcoinTxCoin Coin { get; set; }
    }

    public class BitcoinTxOutput
    {
        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("script")]
        public string Script { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }

    public class BitcoinTxCoin
    {
        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("script")]
        public string Script { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("coinbase")]
        public bool Coinbase { get; set; }
    }

    public class BitcoinTxPrevout
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("index")]
        public long Index { get; set; }
    }
}
