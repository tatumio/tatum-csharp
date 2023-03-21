namespace Tatum.Notifications.Models
{
    public enum NotificationType
    {
        ADDRESS_EVENT = 1,
        INCOMING_NATIVE_TX,
        OUTGOING_NATIVE_TX,
        OUTGOING_FAILED_TX,
        PAID_FEE,
        INCOMING_INTERNAL_TX,
        OUTGOING_INTERNAL_TX,
        INCOMING_FUNGIBLE_TX,
        OUTGOING_FUNGIBLE_TX,
        INCOMING_NFT_TX,
        OUTGOING_NFT_TX,
        INCOMING_MULTITOKEN_TX,
        OUTGOING_MULTITOKEN_TX,
        FAILED_TXS_PER_BLOCK
    }
}