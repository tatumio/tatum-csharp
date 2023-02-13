using Tatum.CSharp.Fees;
using Tatum.CSharp.Nft;
using Tatum.CSharp.Notifications;

namespace Tatum.CSharp
{
    public interface ITatumSdk
    {
        ITatumNotifications Notifications { get; }
        ITatumFees Fees { get; }
        ITatumNft Nft { get; }
    }
}