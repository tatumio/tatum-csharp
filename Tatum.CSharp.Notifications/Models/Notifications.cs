using System.Collections.Generic;
using Tatum.CSharp.Notifications.Models.Responses;

namespace Tatum.CSharp.Notifications.Models
{
    public class Notifications
    {
        public List<AddressTransactionNotification> AddressTransactions { get; } = new List<AddressTransactionNotification>();
        public List<NotificationResponse> ContractLogEvents { get; } = new List<NotificationResponse>();
        public List<NotificationResponse> AccountIncomingBlockchainTransactions { get; } = new List<NotificationResponse>();
        public List<NotificationResponse> AccountPendingBlockchainTransactions { get; } = new List<NotificationResponse>();
        public List<NotificationResponse> CustomerTradeMatches { get; } = new List<NotificationResponse>();
        public List<NotificationResponse> CustomerPartialTradeMatches { get; } = new List<NotificationResponse>();
        public List<NotificationResponse> TransactionInTheBlocks { get; } = new List<NotificationResponse>();
        public List<NotificationResponse> KmsFailedTxs { get; } = new List<NotificationResponse>();
        public List<NotificationResponse> KmsCompletedTxs { get; } = new List<NotificationResponse>();
        public List<NotificationResponse> AccountBalanceLimits { get; } = new List<NotificationResponse>();
        public List<NotificationResponse> TransactionHistoryReports { get; } = new List<NotificationResponse>();
    }
}