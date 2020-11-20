using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class VirtualCurrency
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("supply")]
        public string Supply { get; set; }

        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("baseRate")]
        public int BaseRate { get; set; }

        [JsonPropertyName("basePair")]
        public string BasePair { get; set; }

        [JsonPropertyName("customerId")]
        public string CustomerId { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("erc20Address")]
        public string Erc20Address { get; set; }

        [JsonPropertyName("issuerAccount")]
        public string IssuerAccount { get; set; }

        [JsonPropertyName("chain")]
        public string Chain { get; set; }

        [JsonPropertyName("initialAddress")]
        public string InitialAddress { get; set; }
    }

}
