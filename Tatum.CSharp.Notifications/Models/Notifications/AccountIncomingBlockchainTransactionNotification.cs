namespace Tatum.CSharp.Notifications.Models.Notifications
{
    public class AccountIncomingBlockchainTransactionNotification : Notification
    {
        public string AccountId { get; set; }
        
        public string Url { get; set; }
    }
}