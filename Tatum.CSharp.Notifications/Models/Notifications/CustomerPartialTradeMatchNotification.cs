namespace Tatum.CSharp.Notifications.Models.Notifications
{
    public class CustomerPartialTradeMatchNotification : Notification
    {
        public string AccountId { get; set; }
        
        public string Url { get; set; }
    }
}