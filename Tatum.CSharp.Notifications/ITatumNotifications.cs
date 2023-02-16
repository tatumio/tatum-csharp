using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.CSharp.Core;
using Tatum.CSharp.Notifications.Models;
using Tatum.CSharp.Notifications.Models.Responses;

namespace Tatum.CSharp.Notifications
{
    public interface ITatumNotifications
    {
        Task<Result<NotificationsList>> GetAll(GetAllNotificationsQuery getAllNotificationsQuery);
        Task<Result<NotificationsList>> GetAll();
        Task<Result<List<WebhookExecutionResponse>>> GetAllExecutedWebhooks(GetAllExecutedWebhooksQuery getAllExecutedWebhooksQuery);
        Task<Result<List<WebhookExecutionResponse>>> GetAllExecutedWebhooks();
        Task Unsubscribe(string notificationId);
        ITatumNotificationSubscriptions Subscribe { get; }
    }
}