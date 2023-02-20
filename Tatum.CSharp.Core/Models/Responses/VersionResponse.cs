using System.Text.Json.Serialization;
using Tatum.CSharp.Core.Converters;

namespace Tatum.CSharp.Core.Models.Responses
{
    public class VersionResponse
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("testnet")]
        public bool Testnet { get; set; }
        [JsonPropertyName("planName")]
        public string PlanName { get; set; }
        [JsonPropertyName("planCode")]
        public string PlanCode { get; set; }
        [JsonPropertyName("price")]
        [JsonConverter(typeof(StringToNumberConverter))]
        public int Price { get; set; }
        [JsonPropertyName("expiration")]
        public long Expiration { get; set; }
        [JsonPropertyName("creditLimit")]
        public int CreditLimit { get; set; }
        [JsonPropertyName("usage")]
        public int Usage { get; set; }
        [JsonPropertyName("rolloverDay")]
        public int RolloverDay { get; set; }
    }
}