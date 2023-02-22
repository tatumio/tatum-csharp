namespace Tatum.Notifications.Models.Notifications
{
    public class AddressTransactionNotification : Notification
    {
        public AddressTransactionChain Chain { get; set; }

        public string Address { get; set; }
        
        public string Url { get; set; }
    }

    public enum AddressTransactionChain
    {
        Ethereum = 1,
        Solana,
        Polygon,
        Celo,
        Klaytn,
        Bitcoin,
        Litecoin,
        BitcoinCash,
        Dogecoin,
        Tron,
        BinanceSmartChain
    }
}