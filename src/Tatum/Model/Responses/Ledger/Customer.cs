using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class Customer
    {
        [JsonPropertyName("externalId")]
        public string ExternalId { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("accountingCurrency")]
        public string AccountingCurrency { get; set; }

        [JsonPropertyName("customerCountry")]
        public string CustomerCountry { get; set; }

        [JsonPropertyName("providerCountry")]
        public string ProviderCountry { get; set; }
    }
}
