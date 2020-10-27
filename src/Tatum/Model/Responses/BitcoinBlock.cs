
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class BitcoinBlock
    {
        [JsonPropertyName("hash")]
        public string Hash { get; set; }
        
        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("depth")]
        public int Depth { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("prevBlock")]
        public string PreviousBlockHash { get; set; }

        [JsonPropertyName("merkleRoot")]
        public string MerkleRoot { get; set; }

        [JsonPropertyName("time")]
        public int Time { get; set; }

        [JsonPropertyName("bits")]
        public int Bits { get; set; }

        [JsonPropertyName("bits")]
        public int Nonce { get; set; }




    }
}
