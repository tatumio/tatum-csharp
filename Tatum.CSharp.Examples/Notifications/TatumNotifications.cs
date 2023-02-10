using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Notifications.Models;
using Tatum.CSharp.Utils.DebugMode;
using Xunit;

namespace Tatum.CSharp.Examples.Notifications;

public class TatumNotifications
{
    private readonly TatumSdk _tatumSdk;
    
    public TatumNotifications()
    {
        var debugModeHandler = new DebugModeHandler();
        debugModeHandler.InnerHandler = new HttpClientHandler();
        
        var apiKey = Environment.GetEnvironmentVariable("NOTIFICATION_TEST_APIKEY");

        _tatumSdk = TatumSdk.Init(true, apiKey, new HttpClient(debugModeHandler));
    }
    
    [Fact]
    public async Task Create_Get_Delete()
    {
        var notification = new AddressTransactionNotification
        {
            Chain = Chain.Ethereum,
            Address = "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380",
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        var createdNotification = await _tatumSdk.Notifications.Subscribe.AddressTransaction(notification);
        
        createdNotification.Id.Should().NotBeNullOrEmpty();
        
        var notifications = await _tatumSdk.Notifications.GetAll();
        
        notifications.Should().NotBeNull();
        notifications.AddressTransactions.Should().NotBeEmpty();
        notifications.AddressTransactions.Should().Contain(x => x.Id == createdNotification.Id);
        
        await _tatumSdk.Notifications.Unsubscribe(createdNotification.Id);
        
        notifications = await _tatumSdk.Notifications.GetAll();
        
        notifications.AddressTransactions.Should().NotContain(x => x.Id == createdNotification.Id);
    }
}