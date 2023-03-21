using System;
using System.Text.Json;
using System.Threading.Tasks;
using Tatum.Core.Models;
using Tatum.Notifications.Models.Notifications;
using Tatum.Notifications.Models.Notifications.SupportedChains;
using Xunit;

namespace Tatum.Examples.Notifications.Examples;

[Collection("Notification")]
public class Subscribe : IDisposable, IAsyncDisposable
{
    [Fact]
    public async Task Subscribe_Example()
    {
        var tatumSdk = await TatumSdk.InitAsync(Network.Testnet, config => config.EnableDebugMode = true);
        
        AddressBasedNotification<AddressEventChain> notification = new AddressBasedNotification<AddressEventChain>()
        {
            Chain = AddressEventChain.Ethereum,
            Address = "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380",
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        var result = await tatumSdk.Notifications.Subscribe.AddressEvent(notification);

        if (result.Success)
        {
            Console.WriteLine("Success - notification subscribed.");
            Console.WriteLine(JsonSerializer.Serialize(result.Value, new JsonSerializerOptions() { WriteIndented = true }));
        }
        else
        {
            Console.WriteLine("Failure - there was a problem creating the subscription.");
            Console.WriteLine(result.ErrorMessage);
        }
        
        Assert.True(result.Success);
    }

    public async ValueTask DisposeAsync()
    {
        var tatumSdk = await TatumSdk.InitAsync(Network.Testnet, config => config.EnableDebugMode = true);

        var notifications = await tatumSdk.Notifications.GetAll();

        if (!notifications.Success)
        {
            throw new Exception($"Failed to get notifications: {notifications.ErrorMessage}");
        }
        
        foreach (var notification in notifications.Value)
        {
            var unsubscribe = await tatumSdk.Notifications.Unsubscribe(notification.Id);

            if (!unsubscribe.Success)
            {
                throw new Exception($"Failed to unsubscribe: {unsubscribe.ErrorMessage}");
            }
        }
    }

    public void Dispose()
    {
        DisposeAsync().GetAwaiter().GetResult();
    }
}