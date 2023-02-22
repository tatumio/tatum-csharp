namespace Tatum.Notifications.Models.Notifications
{
    public class ContractLogEventNotification : Notification
    {
        public ContractLogEventChain Chain { get; set; }

        public string Event { get; set; }
        
        public string Url { get; set; }
    }
    
    public enum ContractLogEventChain
    {
        Ethereum = 1,
        Polygon,
        Celo,
        Klaytn,
        BinanceSmartChain
    }
}