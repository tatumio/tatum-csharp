namespace Tatum.Notifications.Models.Notifications
{
    public class AddressBasedNotification<T> : Notification
    {
        public T Chain { get; set; }

        public string Address { get; set; }
        
        public string Url { get; set; }
    }
}