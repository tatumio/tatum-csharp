using Tatum.CSharp.Notifications;

namespace Tatum.CSharp
{
    public interface ITatumSdk
    {
        ITatumNotifications Notifications { get; }
    }
}