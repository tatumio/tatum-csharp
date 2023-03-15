namespace Tatum.Notifications.Models.Notifications
{
    public class BlockBasedNotification<T> : Notification
    {
        public T Chain { get; set; }

        public string Url { get; set; }
    }
}