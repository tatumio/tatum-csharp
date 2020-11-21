using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class LitecoinTx
    {
        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("witnessHash")]
        public string WitnessHash { get; set; }

        [JsonPropertyName("fee")]
        public string Fee { get; set; }

        [JsonPropertyName("rate")]
        public string Rate { get; set; }

        [JsonPropertyName("ps")]
        public long Ps { get; set; }

        [JsonPropertyName("height")]
        public long Height { get; set; }

        [JsonPropertyName("block")]
        public string Block { get; set; }

        [JsonPropertyName("ts")]
        public long Time { get; set; }

        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("version")]
        public long Version { get; set; }

        [JsonPropertyName("flag")]
        public int Flag { get; set; }

        [JsonPropertyName("inputs")]
        public List<LitecoinTxInput> Inputs { get; set; }

        [JsonPropertyName("outputs")]
        public List<LitecoinTxOutput> Outputs { get; set; }

        [JsonPropertyName("locktime")]
        public long Locktime { get; set; }
    }

    public class LitecoinTxInput
    {
        [JsonPropertyName("prevout")]
        public LitecoinTxPrevout Prevout { get; set; }

        [JsonPropertyName("script")]
        public string Script { get; set; }

        [JsonPropertyName("witness")]
        public string Witness { get; set; }

        [JsonPropertyName("sequence")]
        public long Sequence { get; set; }

        [JsonPropertyName("coin")]
        public LitecoinTxCoin Coin { get; set; }
    }

    public class LitecoinTxOutput
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("script")]
        public string Script { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }
    }

    public class LitecoinTxCoin
    {
        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("height")]
        public long Height { get; set; }

        [JsonPropertyName("value")]
        public long Value { get; set; }

        [JsonPropertyName("script")]
        public string Script { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("coinbase")]
        public bool Coinbase { get; set; }
    }

    public class LitecoinTxPrevout
    {
        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("index")]
        public long Index { get; set; }
    }
}
