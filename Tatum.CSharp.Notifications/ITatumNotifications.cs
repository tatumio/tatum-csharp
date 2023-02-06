using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.CSharp.Notifications.Models;

namespace Tatum.CSharp.Notifications
{
    public interface ITatumNotifications
    {
        Task<List<Notification>> ListAll(int pageSize = 10, int offset = 0, string address = null);
        Task Delete(string notificationId);
        Task<Notification> Create(Notification notification);
    }
}