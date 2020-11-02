using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class WithdrawalResponse
    {
        public string Reference { get; set; }
        public List<WithdrawalResponseData> Data { get; set; }
        public string Id { get; set; }
    }

    public class WithdrawalResponseData
    {
        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("vIn")]
        public string VIn { get; set; }

        [JsonPropertyName("vInIndex")]
        public long VInIndex { get; set; }

        [JsonPropertyName("scriptPubKey")]
        public string ScriptPubKey { get; set; }
    }
}
