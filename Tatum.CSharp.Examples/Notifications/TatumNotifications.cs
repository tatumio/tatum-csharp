using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
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
        
        var tatum = new Tatum(new HttpClient(httpClient), apiKey);

        var notification = new Notification
        {
            Type = NotificationType.ADDRESS_TRANSACTION,
            Attributes = new Dictionary<string, string>()
            {
                { "address", "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380" },
                { "chain", "ETH" },
                { "url", "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380" }
            }
        };

        var createdNotification = await tatum.Notifications.Create(notification);
        
        createdNotification.Id.Should().NotBeNullOrEmpty();
        
        var notifications = await tatum.Notifications.ListAll();
        
        notifications.Should().NotBeNullOrEmpty();
        notifications.Should().Contain(x => x.Id == createdNotification.Id);
        
        await tatum.Notifications.Delete(createdNotification.Id);
        
        notifications = await tatum.Notifications.ListAll();
        
        notifications.Should().NotContain(x => x.Id == createdNotification.Id);
    }
}