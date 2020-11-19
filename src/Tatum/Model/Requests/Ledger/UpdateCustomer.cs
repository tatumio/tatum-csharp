using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class UpdateCustomer
    {
        [JsonPropertyName("externalId")]
        public string ExternalId { get; set; }

        [JsonPropertyName("accountingCurrency")]
        public string AccountingCurrency { get; set; }

        [JsonPropertyName("customerCountry")]
        public string CustomerCountry { get; set; }

        [JsonPropertyName("providerCountry")]
        public string ProviderCountry { get; set; }
    }
}
