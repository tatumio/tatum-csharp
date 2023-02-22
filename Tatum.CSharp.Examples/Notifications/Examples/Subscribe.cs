using System;
using System.Text.Json;
using System.Threading.Tasks;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Notifications.Models.Notifications;
using Xunit;

namespace Tatum.CSharp.Examples.Notifications.Examples;

[Collection("Notification")]
public class Subscribe : IDisposable, IAsyncDisposable
{
    [Fact]
    public async Task Subscribe_Example()
    {
        // Your API key should go here.
        string apiKey = Environment.GetEnvironmentVariable("NOTIFICATION_TEST_APIKEY");

        var tatumSdk = await TatumSdk.InitAsync(Network.Testnet, apiKey);
        
        AddressTransactionNotification notification = new AddressTransactionNotification
        {
            Chain = AddressTransactionChain.Ethereum,
            Address = "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380",
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        var result = await tatumSdk.Notifications.Subscribe.AddressTransaction(notification);

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
        string apiKey = Environment.GetEnvironmentVariable("NOTIFICATION_TEST_APIKEY");
        var tatumSdk = await TatumSdk.InitAsync(Network.Testnet, apiKey);

        var notifications = await tatumSdk.Notifications.GetAll();

        if (!notifications.Success)
        {
            throw new Exception("Failed to get notifications.");
        }
        
        foreach (var notification in notifications.Value)
        {
            var unsubscribe = await tatumSdk.Notifications.Unsubscribe(notification.Id);

            if (!unsubscribe.Success)
            {
                throw new Exception("Failed to unsubscribe.");
            }
        }
    }

    public void Dispose()
    {
        DisposeAsync().GetAwaiter().GetResult();
    }
}