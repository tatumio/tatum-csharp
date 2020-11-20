using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class CreateVirtualCurrency
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("supply")]
        public string Supply { get; set; }

        [JsonPropertyName("basePair")]
        public string BasePair { get; set; }

        [JsonPropertyName("baseRate")]
        public int BaseRate { get; set; }

        [JsonPropertyName("customer")]
        public CreateCustomer Customer { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("accountCode")]
        public string AccountCode { get; set; }

        [JsonPropertyName("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("accountingCurrency")]
        public string AccountingCurrency { get; set; }
    }
}
