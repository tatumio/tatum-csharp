using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class BitcoinCashTx
    {
        [JsonPropertyName("txid")]
        public string Txid { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("locktime")]
        public int Locktime { get; set; }

        [JsonPropertyName("vin")]
        public List<BitcoinCashTxInput> Inputs { get; set; }

        [JsonPropertyName("vout")]
        public List<BitcoinCashTxOutput> Outputs { get; set; }
    }

    public class BitcoinCashTxInput
    {
        [JsonPropertyName("txid")]
        public string Txid { get; set; }

        [JsonPropertyName("vout")]
        public int Vout { get; set; }

        [JsonPropertyName("scriptSig")]
        public ScriptSig ScriptSig { get; set; }

        [JsonPropertyName("coinbase")]
        public string Coinbase { get; set; }

        [JsonPropertyName("sequence")]
        public long Sequence { get; set; }
    }

    public class BitcoinCashTxOutput
    {
        [JsonPropertyName("value")]
        public decimal Value { get; set; }

        [JsonPropertyName("n")]
        public int N { get; set; }

        [JsonPropertyName("scriptPubKey")]
        public ScriptPubKey ScriptPubKey { get; set; }
    }
   
    public class ScriptSig
    {
        [JsonPropertyName("hex")]
        public string Hex { get; set; }

        [JsonPropertyName("asm")]
        public string Asm { get; set; }
    }

    public class ScriptPubKey
    {
        [JsonPropertyName("hex")]
        public string Hex { get; set; }

        [JsonPropertyName("asm")]
        public string Asm { get; set; }

        [JsonPropertyName("addresses")]
        public List<string> Addresses { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
