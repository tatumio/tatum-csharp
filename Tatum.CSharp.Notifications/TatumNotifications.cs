using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tatum.CSharp.Notifications.Models;

namespace Tatum.CSharp.Notifications
{
    public class TatumNotifications : ITatumNotifications
    {
        private const string NotificationUrl = "/v3/subscription";
        
        private readonly HttpClient _httpClient;

        public TatumNotifications(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Notification>> ListAll(int pageSize = 10, int offset = 0, string address = null)
        {
            var sb = new StringBuilder();
            
            sb.Append(NotificationUrl);
            
            sb.Append($"?pageSize={pageSize}");
            
            if (offset > 0)
            {
                sb.Append($"&offset={offset}");
            }
            
            if (!string.IsNullOrEmpty(address))
            {
                sb.Append($"&address={address}");
            }

            return await _httpClient.GetFromJsonAsync<List<Notification>>(sb.ToString(), new JsonSerializerOptions(){ Converters = { new JsonStringEnumConverter() }});
        }

        public async Task Delete(string notificationId)
        {
            var url = $"{NotificationUrl}/{notificationId}";
            
            await _httpClient.DeleteAsync(url);
        }

        public async Task<Notification> Create(Notification notification)
        {
            var result = await _httpClient.PostAsJsonAsync(NotificationUrl, notification, new JsonSerializerOptions(){ Converters = { new JsonStringEnumConverter() }});

            var notificationCreated = await result.Content.ReadFromJsonAsync<NotificationCreated>();
            
            notification.Id = notificationCreated?.Id;

            return notification;
        }
    }
}