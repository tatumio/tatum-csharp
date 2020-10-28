using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class BitcoinTx
    {
        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("witnessHash")]
        public string WitnessHash { get; set; }

        [JsonPropertyName("fee")]
        public long Fee { get; set; }

        [JsonPropertyName("rate")]
        public int Rate { get; set; }

        [JsonPropertyName("mtime")]
        public long MTime { get; set; }

        [JsonPropertyName("height")]
        public long Height { get; set; }

        [JsonPropertyName("block")]
        public string Block { get; set; }

        [JsonPropertyName("time")]
        public long Time { get; set; }

        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("version")]
        public long Version { get; set; }

        [JsonPropertyName("inputs")]
        public List<BitcoinTxInput> Inputs { get; set; }

        [JsonPropertyName("outputs")]
        public List<BitcoinTxOutput> Outputs { get; set; }

        [JsonPropertyName("locktime")]
        public int Locktime { get; set; }
    }

    public class BitcoinTxInput
    {
        [JsonPropertyName("prevout")]
        public BitcoinTxPrevout Prevout { get; set; }

        [JsonPropertyName("script")]
        public string Script { get; set; }

        [JsonPropertyName("witness")]
        public string Witness { get; set; }

        [JsonPropertyName("sequence")]
        public long Sequence { get; set; }

        [JsonPropertyName("coin")]
        public BitcoinTxCoin Coin { get; set; }
    }

    public class BitcoinTxOutput
    {
        [JsonPropertyName("value")]
        public long Value { get; set; }

        [JsonPropertyName("script")]
        public string Script { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }
    }

    public class BitcoinTxCoin
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

    public class BitcoinTxPrevout
    {
        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("index")]
        public long Index { get; set; }
    }
}
