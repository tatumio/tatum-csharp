using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class XlmAccountBalance
    {
        [JsonPropertyName("balance")]
        public string Balance { get; set; }

        [JsonPropertyName("limit")]
        public string Limit { get; set; }

        [JsonPropertyName("buying_liabilities")]
        public string BuyingLiabilities { get; set; }

        [JsonPropertyName("selling_liabilities")]
        public string SellingLiabilities { get; set; }

        [JsonPropertyName("asset_type")]
        public string AssetType { get; set; }

        [JsonPropertyName("asset_code")]
        public string AssetCode { get; set; }

        [JsonPropertyName("asset_issuer")]
        public string AssetIssuer { get; set; }
    }

}
