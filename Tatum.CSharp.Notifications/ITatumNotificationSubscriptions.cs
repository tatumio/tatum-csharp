using System.Threading.Tasks;
using Tatum.CSharp.Core;
using Tatum.CSharp.Notifications.Models.Notifications;

namespace Tatum.CSharp.Notifications
{
    public interface ITatumNotificationSubscriptions
    {
        Task<Result<AddressTransactionNotification>> AddressTransaction(AddressTransactionNotification addressTransactionNotification);

        Task<Result<ContractLogEventNotification>> ContractLogEvent(ContractLogEventNotification contractLogEventNotification);
        Task<Result<ContractNftTxsPerBlockNotification>> ContractNftTxsPerBlock(ContractNftTxsPerBlockNotification contractNftTxsPerBlockNotification);
        Task<Result<ContractMultitokenTxsPerBlockNotification>> ContractMultitokenTxsPerBlock(ContractMultitokenTxsPerBlockNotification contractMultitokenTxsPerBlockNotification);
        Task<Result<AccountIncomingBlockchainTransactionNotification>> AccountIncomingBlockchainTransaction(AccountIncomingBlockchainTransactionNotification accountIncomingBlockchainTransactionNotification);
        Task<Result<AccountPendingBlockchainTransactionNotification>> AccountPendingBlockchainTransaction(AccountPendingBlockchainTransactionNotification accountPendingBlockchainTransactionNotification);
        Task<Result<CustomerTradeMatchNotification>> CustomerTradeMatch(CustomerTradeMatchNotification customerTradeMatchNotification);
        Task<Result<CustomerPartialTradeMatchNotification>> CustomerPartialTradeMatch(CustomerPartialTradeMatchNotification customerPartialTradeMatchNotification);
        Task<Result<TransactionInTheBlockNotification>> TransactionInTheBlock(TransactionInTheBlockNotification transactionInTheBlockNotification);
        Task<Result<KmsFailedTxNotification>> KmsFailedTx(KmsFailedTxNotification kmsFailedTxNotification);
        Task<Result<KmsCompletedTxNotification>> KmsCompletedTx(KmsCompletedTxNotification kmsCompletedTxNotification);
        Task<Result<AccountBalanceLimitNotification>> AccountBalanceLimit(AccountBalanceLimitNotification accountBalanceLimitNotification);
        Task<Result<TransactionHistoryReportNotification>> TransactionHistoryReport(TransactionHistoryReportNotification transactionHistoryReportNotification);
        
    }
}