using Tatum.CSharp.Core.Models;

namespace Tatum.CSharp.Notifications.Models.Notifications
{
    public class AddressTransactionNotification : Notification
    {
        public Chain Chain { get; set; }

        public string Address { get; set; }
        
        public string Url { get; set; }
    }
}