using System.Text.Json.Serialization;
using Tatum.Core.Converters;
using Tatum.Notifications.Converters;
using Tatum.Notifications.Models.NotificationExecutions;

namespace Tatum.Notifications.Models.Responses
{
    [JsonConverter(typeof(WebhookExecutionResponseConverter))]
    public class WebhookExecutionResponse
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public NotificationType Type { get; set; }
        
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("subscriptionId")]
        public string SubscriptionId { get; set; }
        
        [JsonPropertyName("url")]
        public string Url { get; set; }
        
        [JsonPropertyName("data")]
        [JsonConverter(typeof(MetadataToStringConverter))]
        public IWebhookExecution Data { get; set; }
        
        [JsonPropertyName("nextTime")]
        public long NextTime { get; set; }
        
        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }
        
        [JsonPropertyName("retryCount")]
        public int RetryCount { get; set; }
        
        [JsonPropertyName("failed")]
        public bool Failed { get; set; }
        
        [JsonPropertyName("response")]
        public WebhookResponse Response { get; set; }
    }
}