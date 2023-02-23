using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Tatum.Core;
using Tatum.Core.Configuration;
using Tatum.Core.Extensions;
using Tatum.Core.Serialization;
using Tatum.Notifications.Mappers;
using Tatum.Notifications.Models;
using Tatum.Notifications.Models.Notifications;
using Tatum.Notifications.Models.Responses;

namespace Tatum.Notifications
{
    public class TatumNotifications : TatumClientBase, ITatumNotifications, ITatumNotificationSubscriptions
    {
        private const string NotificationsUrl = "/v1/subscription";

        public TatumNotifications(HttpClient httpClient, TatumSdkConfiguration configuration) : base(httpClient, configuration)
        {
        }
        
        public TatumNotifications(IHttpClientFactory httpClientFactory, TatumSdkConfiguration configuration) : base(httpClientFactory, configuration)
        {
        }

        public async Task<Result<List<INotification>>> GetAll(GetAllNotificationsQuery getAllNotificationsQuery)
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

            var response = await GetClient().GetAsync(sb.ToString()).ConfigureAwait(false);

            var result = await response.ToResultAsync<List<NotificationResponse>>().ConfigureAwait(false);

            if (result.Success)
            {
                return NotificationMapper.Map(result.Value);
            }

            return new Result<List<INotification>>(result.ErrorMessage);
        }

        public async Task<Result<List<INotification>>> GetAll()
        {
            return await GetAll(new GetAllNotificationsQuery()).ConfigureAwait(false);
        }

        public async Task<Result<List<WebhookExecutionResponse>>> GetAllExecutedWebhooks(GetAllExecutedWebhooksQuery getAllExecutedWebhooksQuery)
        {
            var sb = new StringBuilder();
            
            sb.Append(NotificationsUrl);
            sb.Append("/webhook");
            
            sb.Append($"?pageSize={getAllExecutedWebhooksQuery.PageSize}");
            
            if (getAllExecutedWebhooksQuery.Offset > 0)
            {
                sb.Append($"&offset={getAllExecutedWebhooksQuery.Offset}");
            }
            
            if (getAllExecutedWebhooksQuery.SortingDirection != SortingDirection.Default)
            {
                sb.Append($"&direction={getAllExecutedWebhooksQuery.SortingDirection.ToString().ToLower()}");
            }
            
            if (getAllExecutedWebhooksQuery.FilterFailed != null)
            {
                sb.Append($"&failed={(getAllExecutedWebhooksQuery.FilterFailed.Value ? "true" : "false")}");
            }

            var response = await GetClient().GetAsync(sb.ToString()).ConfigureAwait(false);

            var result = await response.ToResultAsync<List<WebhookExecutionResponse>>().ConfigureAwait(false);

            if (result.Success)
            {
                return result;
            }

            return new Result<List<WebhookExecutionResponse>>(result.ErrorMessage);
        }

        public Task<Result<List<WebhookExecutionResponse>>> GetAllExecutedWebhooks()
        {
            return GetAllExecutedWebhooks(new GetAllExecutedWebhooksQuery());
        }

        public async Task<EmptyResult> Unsubscribe(string notificationId)
        {
            var url = $"{NotificationsUrl}/{notificationId}";
            
            var responseMessage = await GetClient().DeleteAsync(url).ConfigureAwait(false);
            
            return await responseMessage.ToEmptyResultAsync().ConfigureAwait(false);
        }

        public ITatumNotificationSubscriptions Subscribe => this;

        public async Task<Result<AddressEventNotification>> AddressEvent(AddressEventNotification addressEventNotification)
        {
            return await CreateNotification(addressEventNotification).ConfigureAwait(false);
        }
        
        private async Task<Result<T>> CreateNotification<T>(T notification) where T : Notification
        {
            var notificationRequest = NotificationMapper.Map(notification);
            
            var responseMessage = await GetClient().PostAsJsonAsync(NotificationsUrl, notificationRequest, TatumSerializerOptions.Default).ConfigureAwait(false);

            var result = await responseMessage.ToResultAsync<T>().ConfigureAwait(false);

            if (result.Success)
            {
                notification.Id = result.Value.Id;
                return notification;
            }

            return result;
        }
    }
}