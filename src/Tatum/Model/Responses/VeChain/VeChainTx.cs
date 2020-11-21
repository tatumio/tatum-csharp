using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class VeChainTx
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("chainTag")]
        public string ChainTag { get; set; }

        [JsonPropertyName("blockRef")]
        public string BlockRef { get; set; }

        [JsonPropertyName("expiration")]
        public int Expiration { get; set; }

        [JsonPropertyName("clauses")]
        public List<VeChainTxClause> Clauses { get; set; }

        [JsonPropertyName("gasPriceCoef")]
        public int GasPriceCoef { get; set; }

        [JsonPropertyName("gas")]
        public int Gas { get; set; }

        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        [JsonPropertyName("nonce")]
        public string Nonce { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("meta")]
        public VeChainTxMeta Meta { get; set; }

        [JsonPropertyName("blockNumber")]
        public int BlockNumber { get; set; }
    }

    public class VeChainTxClause
    {
        [JsonPropertyName("to")]
        public string To { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("data")]
        public string Data { get; set; }
    }

    public class VeChainTxMeta
    {
        [JsonPropertyName("blockID")]
        public string BlockId { get; set; }

        [JsonPropertyName("blockNumber")]
        public int BlockNumber { get; set; }

        [JsonPropertyName("blockTimestamp")]
        public int BlockTimestamp { get; set; }
    }
}
