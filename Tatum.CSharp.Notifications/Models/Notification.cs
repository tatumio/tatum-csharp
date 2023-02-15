using System.Text.Json.Serialization;

namespace Tatum.CSharp.Notifications.Models
{
    public abstract class Notification
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}