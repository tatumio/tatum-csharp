using System.Text.Json.Serialization;

namespace Tatum.Model.Requests
{
    public class CreateSubscription
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("attr")]
        public Attr Attr { get; set; }
    }

    public class Attr
    {
        [JsonPropertyName("limit")]
        public string Limit { get; set; }

        [JsonPropertyName("typeOfBalance")]
        public string TypeOfBalance { get; set; }
    }
}
