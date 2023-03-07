using System.Text.Json.Serialization;

namespace Tatum.Notifications.Models.Responses
{
    internal class NotificationCreatedResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}