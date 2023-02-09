using System.Threading.Tasks;
using Tatum.CSharp.Notifications.Models;

namespace Tatum.CSharp.Notifications
{
    public interface ITatumNotificationSubscriptions
    {
        Task<AddressTransactionNotification> AddressTransaction(
            AddressTransactionNotification addressTransactionNotification);
    }
}