namespace Tatum.CSharp.Notifications.Models.Notifications
{
    public class AccountPendingBlockchainTransactionNotification : Notification
    {
        public string AccountId { get; set; }
        
        public string Url { get; set; }
    }
}