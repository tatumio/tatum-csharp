using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.CSharp.Core;
using Tatum.CSharp.Notifications.Models;
using Tatum.CSharp.Notifications.Models.Responses;

namespace Tatum.CSharp.Notifications
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