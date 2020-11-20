using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class Subscription
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("attr")]
        public Attr Attr { get; set; }
    }

    public class Attr
    {
    }
}
