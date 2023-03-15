using System.Threading.Tasks;
using Tatum.Core;
using Tatum.Notifications.Models.Notifications;
using Tatum.Notifications.Models.Notifications.SupportedChains;

namespace Tatum.Notifications
{
    public interface ITatumNotificationSubscriptions
    {
        Task<Result<AddressBasedNotification<AddressEventChain>>> AddressEvent(AddressBasedNotification<AddressEventChain> addressBasedNotification);
        Task<Result<BlockBasedNotification<FailedTxPerBlockChain>>> FailedTxPerBlock(BlockBasedNotification<FailedTxPerBlockChain> addressBasedNotification);
        Task<Result<AddressBasedNotification<IncomingNativeTxChain>>> IncomingNativeTx(AddressBasedNotification<IncomingNativeTxChain> addressBasedNotification);
        Task<Result<AddressBasedNotification<OutgoingNativeTxChain>>> OutgoingNativeTx(AddressBasedNotification<OutgoingNativeTxChain> addressBasedNotification);
        Task<Result<AddressBasedNotification<OutgoingFailedTxChain>>> OutgoingFailedTx(AddressBasedNotification<OutgoingFailedTxChain> addressBasedNotification);
        Task<Result<AddressBasedNotification<PaidFeeChain>>> PaidFee(AddressBasedNotification<PaidFeeChain> addressBasedNotification);
        Task<Result<AddressBasedNotification<IncomingInternalTxChain>>> IncomingInternalTx(AddressBasedNotification<IncomingInternalTxChain> addressBasedNotification);
        Task<Result<AddressBasedNotification<OutgoingInternalTxChain>>> OutgoingInternalTx(AddressBasedNotification<OutgoingInternalTxChain> addressBasedNotification);
        Task<Result<AddressBasedNotification<IncomingFungibleTxChain>>> IncomingFungibleTx(AddressBasedNotification<IncomingFungibleTxChain> addressBasedNotification);
        Task<Result<AddressBasedNotification<OutgoingFungibleTxChain>>> OutgoingFungibleTx(AddressBasedNotification<OutgoingFungibleTxChain> addressBasedNotification);
        Task<Result<AddressBasedNotification<IncomingNftTxChain>>> IncomingNftTx(AddressBasedNotification<IncomingNftTxChain> addressBasedNotification);
        Task<Result<AddressBasedNotification<OutgoingNftTxChain>>> OutgoingNftTx(AddressBasedNotification<OutgoingNftTxChain> addressBasedNotification);
        Task<Result<AddressBasedNotification<IncomingMultitokenTxChain>>> IncomingMultitokenTx(AddressBasedNotification<IncomingMultitokenTxChain> addressBasedNotification);
        Task<Result<AddressBasedNotification<OutgoingMultitokenTxChain>>> OutgoingMultitokenTx(AddressBasedNotification<OutgoingMultitokenTxChain> addressBasedNotification);
    }
}