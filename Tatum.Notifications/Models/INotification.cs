namespace Tatum.Notifications.Models
{
    public interface INotification
    {
        string Id { get; set; }
        
        public NotificationType Type { get; set; }
    }
}