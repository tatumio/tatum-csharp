using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Tatum.CSharp.Core;
using Tatum.CSharp.Notifications.Models;
using Tatum.CSharp.Notifications.Models.Responses;

namespace Tatum.CSharp.Notifications
{
    public class TatumNotifications : ITatumNotifications
    {
        private const string NotificationsUrl = "/v3/subscription";
        
        private readonly HttpClient _httpClient;

        public TatumNotifications(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Notification>> ListAll(int pageSize = 10, int offset = 0, string address = null)
        {
            var sb = new StringBuilder();
            
            sb.Append(NotificationsUrl);
            
            sb.Append($"?pageSize={pageSize}");
            
            if (offset > 0)
            {
                sb.Append($"&offset={offset}");
            }
            
            if (!string.IsNullOrEmpty(address))
            {
                sb.Append($"&address={address}");
            }

            return await _httpClient.GetFromJsonAsync<List<Notification>>(sb.ToString(), TatumSerializerOptions.Default);
        }

        public async Task Delete(string notificationId)
        {
            var url = $"{NotificationsUrl}/{notificationId}";
            
            await _httpClient.DeleteAsync(url);
        }

        public async Task<Notification> Create(Notification notification)
        {
            var result = await _httpClient.PostAsJsonAsync(NotificationsUrl, notification, TatumSerializerOptions.Default);

            var notificationCreated = await result.Content.ReadFromJsonAsync<NotificationCreatedResponse>();
            
            notification.Id = notificationCreated?.Id;

            return notification;
        }
    }
}