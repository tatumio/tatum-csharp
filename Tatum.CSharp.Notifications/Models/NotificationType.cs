namespace Tatum.CSharp.Notifications.Models
{
    public enum NotificationType
    {
        ADDRESS_TRANSACTION = 1,
        CONTRACT_LOG_EVENT,
        CONTRACT_NFT_TXS_PER_BLOCK,
        CONTRACT_MULTITOKEN_TXS_PER_BLOCK,
        ACCOUNT_INCOMING_BLOCKCHAIN_TRANSACTION,
        ACCOUNT_PENDING_BLOCKCHAIN_TRANSACTION,
        CUSTOMER_TRADE_MATCH,
        CUSTOMER_PARTIAL_TRADE_MATCH,
        TRANSACTION_IN_THE_BLOCK,
        KMS_FAILED_TX,
        KMS_COMPLETED_TX,
        ACCOUNT_BALANCE_LIMIT,
        TRANSACTION_HISTORY_REPORT
    }
}