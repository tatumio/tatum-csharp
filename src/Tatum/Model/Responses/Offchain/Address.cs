using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class Address
    {
        [JsonPropertyName("address")]
        public string BlockchainAddress { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("derivationKey")]
        public uint DerivationKey { get; set; }

        [JsonPropertyName("xpub")]
        public string XPub { get; set; }

        [JsonPropertyName("destinationTag")]
        public uint? DestinationTag { get; set; }

        [JsonPropertyName("memo")]
        public string Memo { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
