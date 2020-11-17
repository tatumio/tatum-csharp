using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class Account
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("frozen")]
        public bool Frozen { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("balance")]
        public AccountBalance Balance { get; set; }

        [JsonPropertyName("customerId")]
        public string CustomerId { get; set; }

        [JsonPropertyName("accountCode")]
        public string AccountCode { get; set; }

        [JsonPropertyName("xpub")]
        public string Xpub { get; set; }
    }
}
