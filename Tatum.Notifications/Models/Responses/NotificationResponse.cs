using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tatum.Core.Converters;

namespace Tatum.Notifications.Models.Responses
{
    internal class NotificationResponse
    {
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Id { get; set; }
        
        [JsonPropertyName("type")]
        public NotificationType Type { get; set; }
        
        [JsonPropertyName("attr")]
        [JsonConverter(typeof(NotificationAttributesConverter))]
        public Dictionary<string, string> Attributes { get; set; }
    }
}