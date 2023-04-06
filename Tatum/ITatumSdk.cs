using Tatum.Notifications;
using Tatum.Rpc;

namespace Tatum
{
    public interface ITatumSdk
    {
        ITatumNotifications Notifications { get; }
        
        ITatumRpc Rpc { get; }
    }
}