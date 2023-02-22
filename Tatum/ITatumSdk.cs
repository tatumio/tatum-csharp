using Tatum.Notifications;

namespace Tatum
{
    public interface ITatumSdk
    {
        ITatumNotifications Notifications { get; }
    }
}