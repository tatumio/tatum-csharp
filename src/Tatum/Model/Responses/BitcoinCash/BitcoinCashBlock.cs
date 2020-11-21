using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class BitcoinCashBlock
    {
        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("merkleroot")]
        public string Merkleroot { get; set; }

        [JsonPropertyName("tx")]
        public List<BitcoinCashTx> Tx { get; set; }

        [JsonPropertyName("time")]
        public long Time { get; set; }

        [JsonPropertyName("nonce")]
        public long Nonce { get; set; }

        [JsonPropertyName("difficulty")]
        public double Difficulty { get; set; }

        [JsonPropertyName("confirmations")]
        public int Confirmations { get; set; }

        [JsonPropertyName("previousblockhash")]
        public string Previousblockhash { get; set; }

        [JsonPropertyName("nextblockhash")]
        public string Nextblockhash { get; set; }
    }
}
