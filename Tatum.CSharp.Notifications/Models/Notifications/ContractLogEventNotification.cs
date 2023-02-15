using Tatum.CSharp.Core.Models;

namespace Tatum.CSharp.Notifications.Models.Notifications
{
    public class ContractLogEventNotification : Notification
    {
        public Chain Chain { get; set; }

        public string Event { get; set; }
        
        public string Url { get; set; }
    }
}