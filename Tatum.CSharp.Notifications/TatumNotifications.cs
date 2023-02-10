using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Tatum.CSharp.Core;
using Tatum.CSharp.Core.Configuration;
using Tatum.CSharp.Core.Serialization;
using Tatum.CSharp.Notifications.Mappers;
using Tatum.CSharp.Notifications.Models;
using Tatum.CSharp.Notifications.Models.Responses;

namespace Tatum.CSharp.Notifications
{
    public class TatumNotifications : TatumClientBase, ITatumNotifications, ITatumNotificationSubscriptions
    {
        private const string NotificationsUrl = "/v3/subscription";

        public TatumNotifications(HttpClient httpClient, TatumSdkConfiguration configuration) : base(httpClient, configuration)
        {
        }
        
        public TatumNotifications(IHttpClientFactory httpClientFactory, TatumSdkConfiguration configuration) : base(httpClientFactory, configuration)
        {
        }

        public async Task<Models.Notifications> GetAll(GetAllNotificationsQuery getAllNotificationsQuery)
        {
            var sb = new StringBuilder();
            
            sb.Append(NotificationsUrl);
            
            sb.Append($"?pageSize={getAllNotificationsQuery.PageSize}");
            
            if (getAllNotificationsQuery.Offset > 0)
            {
                sb.Append($"&offset={getAllNotificationsQuery.Offset}");
            }
            
            if (!string.IsNullOrEmpty(getAllNotificationsQuery.Address))
            {
                sb.Append($"&address={getAllNotificationsQuery.Address}");
            }

            var result = await GetClient().GetFromJsonAsync<List<NotificationResponse>>(sb.ToString(), TatumSerializerOptions.Default);

            return NotificationMapper.Map(result);
        }

        public async Task<Models.Notifications> GetAll()
        {
            return await GetAll(new GetAllNotificationsQuery());
        }

        public async Task Unsubscribe(string notificationId)
        {
            var url = $"{NotificationsUrl}/{notificationId}";
            
            await GetClient().DeleteAsync(url);
        }

        public ITatumNotificationSubscriptions Subscribe => this;

        public async Task<AddressTransactionNotification> AddressTransaction(AddressTransactionNotification addressTransactionNotification)
        {
            var notification = NotificationMapper.Map(addressTransactionNotification);
            
            var result = await GetClient().PostAsJsonAsync(NotificationsUrl, notification, TatumSerializerOptions.Default);

            var notificationCreated = await result.Content.ReadFromJsonAsync<NotificationCreatedResponse>();
            
            addressTransactionNotification.Id = notificationCreated?.Id;

            return addressTransactionNotification;
        }
    }
}