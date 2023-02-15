namespace Tatum.CSharp.Notifications.Models.Notifications
{
    public class AccountBalanceLimitNotification : Notification
    {
        public string Limit { get; set; }
        
        public BalanceType TypeOfBalance { get; set; }
    }
}