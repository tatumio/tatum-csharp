using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tatum.Model.Responses
{
    public class LitecoinTx
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("witnessHash")]
        public string WitnessHash { get; set; }

        [JsonProperty("fee")]
        public string Fee { get; set; }

        [JsonProperty("rate")]
        public string Rate { get; set; }

        [JsonProperty("ps")]
        public long Ps { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("block")]
        public string Block { get; set; }

        [JsonProperty("ts")]
        public long Time { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("flag")]
        public int Flag { get; set; }

        [JsonProperty("inputs")]
        public List<LitecoinTxInput> Inputs { get; set; }

        [JsonProperty("outputs")]
        public List<LitecoinTxOutput> Outputs { get; set; }

        [JsonProperty("locktime")]
        public long Locktime { get; set; }
    }

    public class LitecoinTxInput
    {
        [JsonProperty("prevout")]
        public LitecoinTxPrevout Prevout { get; set; }

        [JsonProperty("script")]
        public string Script { get; set; }

        [JsonProperty("witness")]
        public string Witness { get; set; }

        [JsonProperty("sequence")]
        public long Sequence { get; set; }

        [JsonProperty("coin")]
        public LitecoinTxCoin Coin { get; set; }
    }

    public class LitecoinTxOutput
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("script")]
        public string Script { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }

    public class LitecoinTxCoin
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

    public class LitecoinTxPrevout
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("index")]
        public long Index { get; set; }
    }
}
