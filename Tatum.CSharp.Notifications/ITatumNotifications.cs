using System.Threading.Tasks;
using Tatum.CSharp.Core;
using Tatum.CSharp.Notifications.Models;

namespace Tatum.CSharp.Notifications
{
    public interface ITatumNotifications
    {
        Task<Result<NotificationsList>> GetAll(GetAllNotificationsQuery getAllNotificationsQuery);
        Task<Result<NotificationsList>> GetAll();
        Task Unsubscribe(string notificationId);
        ITatumNotificationSubscriptions Subscribe { get; }
    }
}