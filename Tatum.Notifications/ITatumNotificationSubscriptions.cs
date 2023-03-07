using System.Threading.Tasks;
using Tatum.Core;
using Tatum.Notifications.Models.Notifications;

namespace Tatum.Notifications
{
    public interface ITatumNotificationSubscriptions
    {
        Task<Result<AddressEventNotification>> AddressEvent(AddressEventNotification addressEventNotification);
    }
}