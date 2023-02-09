using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.CSharp.Notifications.Models.Responses
{
    public class NotificationResponse
    {
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Id { get; set; }
        
        [JsonPropertyName("type")]
        public NotificationType Type { get; set; }
        
        [JsonPropertyName("attr")]
        public Dictionary<string, string> Attributes { get; set; }
    }
}