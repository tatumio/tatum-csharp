namespace Tatum.CSharp.Notifications.Models
{
    public class GetAllNotificationsQuery
    {
        public int PageSize { get; set; } = 10;
        public int Offset { get; set; } = 0;
        public string Address { get; set; }
    }
}