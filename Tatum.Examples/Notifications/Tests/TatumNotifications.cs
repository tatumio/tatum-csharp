using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.Core;
using Tatum.Core.Configuration;
using Tatum.Core.Handlers;
using Tatum.Core.Models;
using Tatum.Notifications.Models;
using Tatum.Notifications.Models.Notifications;
using Tatum.Notifications.Models.Responses;
using Tatum.Utils.DebugMode;
using Xunit;

namespace Tatum.Examples.Notifications.Tests;

[Collection("Notification")]
public class TatumNotifications
{
    private readonly TatumSdk _tatumSdk;
    
    public TatumNotifications()
    {
        DebugModeHandler debugModeHandler = new DebugModeHandler();
        NoApiKeyNetworkHandler noApiKeyNetworkHandler = new NoApiKeyNetworkHandler(new DefaultTatumSdkConfiguration());
        debugModeHandler.InnerHandler = noApiKeyNetworkHandler;
        noApiKeyNetworkHandler.InnerHandler = new HttpClientHandler();
        
        string apiKey = Environment.GetEnvironmentVariable("NOTIFICATION_TEST_APIKEY");

        _tatumSdk = TatumSdk.Init(Network.Testnet, apiKey, new HttpClient(debugModeHandler));
    }

    [Fact]
    public async Task GetAllExecutedWebhooks()
    {
        DebugModeHandler debugModeHandler = new DebugModeHandler();
        NoApiKeyNetworkHandler noApiKeyNetworkHandler = new NoApiKeyNetworkHandler(new DefaultTatumSdkConfiguration());
        debugModeHandler.InnerHandler = noApiKeyNetworkHandler;
        noApiKeyNetworkHandler.InnerHandler = new HttpClientHandler();
        
        var tatumSdk = await TatumSdk.InitAsync(Network.Testnet, new HttpClient(debugModeHandler));

        
        GetAllExecutedWebhooksQuery getAllExecutedWebhooksQuery = new GetAllExecutedWebhooksQuery
        {
            PageSize = 15,
            Offset = 1,
            SortingDirection = SortingDirection.Asc
        };
        
        Result<List<WebhookExecutionResponse>> result = await tatumSdk.Notifications.GetAllExecutedWebhooks(getAllExecutedWebhooksQuery);
        
        result.Should().NotBeNull();
        
        if (!result.Success)
        {
            Assert.True(false, result.ErrorMessage);
        }
        
        result.Value.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task GetAll()
    {
        DebugModeHandler debugModeHandler = new DebugModeHandler();
        NoApiKeyNetworkHandler noApiKeyNetworkHandler = new NoApiKeyNetworkHandler(new DefaultTatumSdkConfiguration());
        debugModeHandler.InnerHandler = noApiKeyNetworkHandler;
        noApiKeyNetworkHandler.InnerHandler = new HttpClientHandler();
        
        var tatumSdk = await TatumSdk.InitAsync(Network.Testnet, new HttpClient(debugModeHandler));
        
        var result = await tatumSdk.Notifications.GetAll();
        
        result.Should().NotBeNull();
        
        if (!result.Success)
        {
            Assert.True(false, result.ErrorMessage);
        }
        
        result.Value.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task Unsubscribe_ShouldFailOnNonExisting()
    {
        var result = await _tatumSdk.Notifications.Unsubscribe("6398ded68bfa23a9709b1b17");

        result.Should().NotBeNull();
        result.Success.Should().BeFalse();
    }
    
    [Theory]
    [InlineData(AddressTransactionChain.Ethereum, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(AddressTransactionChain.Solana, "8Kvnpupqf2hPrMDJ4mK2kXnSSMihh1AjFg7RiF5Vn8wX")]
    [InlineData(AddressTransactionChain.Polygon, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(AddressTransactionChain.Celo, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(AddressTransactionChain.Klaytn, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(AddressTransactionChain.Bitcoin, "tb1qjzjyd3l3vh8an8w4mkr6dwur59lan60367kr04")]
    [InlineData(AddressTransactionChain.Litecoin, "mxz6DCurdU65oyzfUnE36enNUFG8soaRXi")]
    [InlineData(AddressTransactionChain.BitcoinCash, "bchtest:qrg27kw32qkeym2q8mdhw0lcqu2x7gw5fghy405gn7")]
    [InlineData(AddressTransactionChain.Dogecoin, "ndz9RPmJWwNiNt1aRvgxhG4G5xMgr61Wn8")]
    [InlineData(AddressTransactionChain.Tron, "TLZirVxP5m37d2ZEWDtmvk97KMJXiBsWGZ")]
    [InlineData(AddressTransactionChain.BinanceSmartChain, "0x58107193278ea4bb56c390185f4755e0a4239d68")]
    public async Task AddressTransaction_Create_Get_Delete(AddressTransactionChain chain, string address)
    {
        AddressEventNotification notification = new AddressEventNotification
        {
            Chain = chain,
            Address = address,
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.AddressEvent);
    }

    private async Task Create_Get_Delete<T>(T notification, Func<T, Task<Result<T>>> createFunc) where T : Notification
    {
        Result<T> createdNotificationResult = await createFunc(notification);

        if (!createdNotificationResult.Success)
        {
            Assert.True(false, createdNotificationResult.ErrorMessage);
        }

        T createdNotification = createdNotificationResult.Value;
        
        createdNotification.Id.Should().NotBeNullOrEmpty();

        Result<List<INotification>> notificationsResult = await _tatumSdk.Notifications.GetAll();
        
        if (!notificationsResult.Success)
        {
            Assert.True(false, notificationsResult.ErrorMessage);
        }
        
        List<INotification> notifications = notificationsResult.Value;

        notifications.Should().NotBeNull();
        notifications.Should().NotBeEmpty();
        notifications.Should().Contain(x => x.Id == createdNotification.Id);
        
        var unsubscribeResult = await _tatumSdk.Notifications.Unsubscribe(createdNotification.Id);

        unsubscribeResult.Success.Should().BeTrue();
        
        notificationsResult = await _tatumSdk.Notifications.GetAll();
        
        if (!notificationsResult.Success)
        {
            Assert.True(false, notificationsResult.ErrorMessage);
        }
        
        notifications = notificationsResult.Value;
        
        notifications.Should().NotContain(x => x.Id == createdNotification.Id);
    }
}