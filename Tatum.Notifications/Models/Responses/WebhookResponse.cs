using System.Text.Json.Serialization;

namespace Tatum.Notifications.Models.Responses
{
    public class WebhookResponse
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        
        [JsonPropertyName("data")]
        public string Data { get; set; }
        
        [JsonPropertyName("networkError")]
        public bool NetworkError { get; set; }
    }
}