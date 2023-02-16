namespace Tatum.CSharp.Notifications.Models
{
    public class GetAllExecutedWebhooksQuery
    {
        public int PageSize { get; set; } = 10;
        public int Offset { get; set; }
        public SortingDirection SortingDirection { get; set; } = SortingDirection.Default;
        public bool? FilterFailed { get; set; }
    }
    
    public enum SortingDirection
    {
        Default,
        Asc,
        Desc
    }
}