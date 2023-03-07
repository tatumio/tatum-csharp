using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Core;
using Tatum.Notifications.Models;
using Tatum.Notifications.Models.Responses;

namespace Tatum.Notifications
{
    public interface ITatumNotifications
    {
        Task<Result<List<INotification>>> GetAll(GetAllNotificationsQuery getAllNotificationsQuery);
        Task<Result<List<INotification>>> GetAll();
        Task<Result<List<WebhookExecutionResponse>>> GetAllExecutedWebhooks(GetAllExecutedWebhooksQuery getAllExecutedWebhooksQuery);
        Task<Result<List<WebhookExecutionResponse>>> GetAllExecutedWebhooks();
        Task<EmptyResult> Unsubscribe(string notificationId);
        ITatumNotificationSubscriptions Subscribe { get; }
    }
}