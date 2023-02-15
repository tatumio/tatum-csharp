using System.Collections.Generic;
using Tatum.CSharp.Notifications.Models.Notifications;

namespace Tatum.CSharp.Notifications.Models
{
    public class NotificationsList
    {
        public List<AddressTransactionNotification> AddressTransactions { get; } = new List<AddressTransactionNotification>();
        public List<ContractLogEventNotification> ContractLogEvents { get; } = new List<ContractLogEventNotification>();
        public List<ContractNftTxsPerBlockNotification> ContractNftTxsPerBlock { get; } = new List<ContractNftTxsPerBlockNotification>();
        public List<ContractMultitokenTxsPerBlockNotification> ContractMultitokenTxsPerBlock { get; } = new List<ContractMultitokenTxsPerBlockNotification>();
        public List<AccountIncomingBlockchainTransactionNotification> AccountIncomingBlockchainTransactions { get; } = new List<AccountIncomingBlockchainTransactionNotification>();
        public List<AccountPendingBlockchainTransactionNotification> AccountPendingBlockchainTransactions { get; } = new List<AccountPendingBlockchainTransactionNotification>();
        public List<CustomerTradeMatchNotification> CustomerTradeMatches { get; } = new List<CustomerTradeMatchNotification>();
        public List<CustomerPartialTradeMatchNotification> CustomerPartialTradeMatches { get; } = new List<CustomerPartialTradeMatchNotification>();
        public List<TransactionInTheBlockNotification> TransactionInTheBlocks { get; } = new List<TransactionInTheBlockNotification>();
        public List<KmsFailedTxNotification> KmsFailedTxs { get; } = new List<KmsFailedTxNotification>();
        public List<KmsCompletedTxNotification> KmsCompletedTxs { get; } = new List<KmsCompletedTxNotification>();
        public List<AccountBalanceLimitNotification> AccountBalanceLimits { get; } = new List<AccountBalanceLimitNotification>();
        public List<TransactionHistoryReportNotification> TransactionHistoryReports { get; } = new List<TransactionHistoryReportNotification>();
    }
}