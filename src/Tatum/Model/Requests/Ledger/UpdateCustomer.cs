using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class UpdateCustomer
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        [JsonPropertyName("externalId")]
        public string ExternalId { get; set; }

        [StringLength(3, MinimumLength = 3)]
        [JsonPropertyName("accountingCurrency")]
        public string AccountingCurrency { get; set; }
        
        [StringLength(2, MinimumLength = 2)]
        [JsonPropertyName("customerCountry")]
        public string CustomerCountry { get; set; }

        [StringLength(2, MinimumLength = 2)]
        [JsonPropertyName("providerCountry")]
        public string ProviderCountry { get; set; }
    }
}
