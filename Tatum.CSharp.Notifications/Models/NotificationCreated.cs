using System.Text.Json.Serialization;

namespace Tatum.CSharp.Notifications.Models
{
    internal class NotificationCreated
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}