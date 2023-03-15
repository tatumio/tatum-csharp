using System.Text.Json.Serialization;

namespace Tatum.Notifications.Models
{
    public abstract class Notification : INotification
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("type")]

        public NotificationType Type { get; set; }
    }
}