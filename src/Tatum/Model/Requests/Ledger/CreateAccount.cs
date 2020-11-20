using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class CreateAccount
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("xpub")]
        public string Xpub { get; set; }

        [JsonPropertyName("customer")]
        public CreateCustomer Customer { get; set; }

        [JsonPropertyName("compliant")]
        public bool Compliant { get; set; }

        [JsonPropertyName("accountCode")]
        public string AccountCode { get; set; }

        [JsonPropertyName("accountingCurrency")]
        public string AccountingCurrency { get; set; }
    }
}
