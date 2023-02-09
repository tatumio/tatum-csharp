using System.Threading.Tasks;
using Tatum.CSharp.Notifications.Models;

namespace Tatum.CSharp.Notifications
{
    public interface ITatumNotifications
    {
        Task<Models.Notifications> GetAll(GetAllNotificationsQuery getAllNotificationsQuery);
        Task<Models.Notifications> GetAll();
        Task Unsubscribe(string notificationId);
        ITatumNotificationSubscriptions Subscribe { get; }
    }
}