namespace Tatum.CSharp.Notifications.Models.Notifications
{
    public class ContractNftTxsPerBlockNotification : Notification
    {
        public ContractNftTxsPerBlockChain Chain { get; set; }

        public string Url { get; set; }
    }

    public enum ContractNftTxsPerBlockChain
    {
        Ethereum = 1,
    }
}