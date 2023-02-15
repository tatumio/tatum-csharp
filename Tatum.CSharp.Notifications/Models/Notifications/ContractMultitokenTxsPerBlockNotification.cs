namespace Tatum.CSharp.Notifications.Models.Notifications
{
    public class ContractMultitokenTxsPerBlockNotification : Notification
    {
        public ContractMultitokenTxsPerBlockChain Chain { get; set; }

        public string Url { get; set; }
    }

    public enum ContractMultitokenTxsPerBlockChain
    {
        Ethereum = 1
    }
}