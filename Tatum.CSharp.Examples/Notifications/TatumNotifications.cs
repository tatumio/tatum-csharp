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
    [Fact]
    public async Task Create_Get_Delete()
    {
        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();

        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        
        var tatum = new TatumSdk(new HttpClient(httpClient), apiKey);

        var notification = new AddressTransactionNotification
        {
            Chain = Chain.Ethereum,
            Address = "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380",
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        var createdNotification = await tatum.Notifications.Subscribe.AddressTransaction(notification);
        
        createdNotification.Id.Should().NotBeNullOrEmpty();
        
        var notifications = await tatum.Notifications.GetAll();
        
        notifications.Should().NotBeNull();
        notifications.AddressTransactions.Should().NotBeEmpty();
        notifications.AddressTransactions.Should().Contain(x => x.Id == createdNotification.Id);
        
        await tatum.Notifications.Unsubscribe(createdNotification.Id);
        
        notifications = await tatum.Notifications.GetAll();
        
        notifications.AddressTransactions.Should().NotContain(x => x.Id == createdNotification.Id);
    }
}