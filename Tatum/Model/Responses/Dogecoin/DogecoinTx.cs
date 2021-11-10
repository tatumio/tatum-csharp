using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tatum.Model.Responses
{
    public class DogecoinTx
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
        public List<DogecoinTxInput> Inputs { get; set; }

        [JsonProperty("outputs")]
        public List<DogecoinTxOutput> Outputs { get; set; }

        [JsonProperty("locktime")]
        public long Locktime { get; set; }
    }

    public class DogecoinTxInput
    {
        [JsonProperty("prevout")]
        public DogecoinTxPrevout Prevout { get; set; }

        [JsonProperty("script")]
        public string Script { get; set; }

        [JsonProperty("witness")]
        public string Witness { get; set; }

        [JsonProperty("sequence")]
        public long Sequence { get; set; }

        [JsonProperty("coin")]
        public DogecoinTxCoin Coin { get; set; }
    }

    public class DogecoinTxOutput
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("script")]
        public string Script { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }

    public class DogecoinTxCoin
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

    public class DogecoinTxPrevout
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("index")]
        public long Index { get; set; }
    }


}
