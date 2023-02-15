using Tatum.CSharp.Core.Models;

namespace Tatum.CSharp.Notifications.Models.Notifications
{
    public class ContractNftTxsPerBlockNotification : Notification
    {
        public Chain Chain { get; set; }

        public string Url { get; set; }
    }
}