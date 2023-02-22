namespace Tatum.Notifications.Models.Notifications
{
    public class CustomerTradeMatchNotification : Notification
    {
        public string AccountId { get; set; }
        
        public string Url { get; set; }
    }
}