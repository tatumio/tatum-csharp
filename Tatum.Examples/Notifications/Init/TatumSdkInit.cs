using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.Core;
using Tatum.Core.Configuration;
using Tatum.Core.Exceptions;
using Tatum.Core.Handlers;
using Tatum.Core.Models;
using Tatum.Notifications.Models;
using Tatum.Notifications.Models.Notifications;
using Tatum.Utils.DebugMode;
using Xunit;

namespace Tatum.Examples.Notifications.Init;

[Collection("Init")]
public class TatumSdkInit
{
    private readonly Dictionary<string, string> _apiKeys = new Dictionary<string, string>();

    public TatumSdkInit()
    {
        _apiKeys.Add("Main", Environment.GetEnvironmentVariable("NOTIFICATION_TEST_APIKEY_MAIN"));
        _apiKeys.Add("Test", Environment.GetEnvironmentVariable("NOTIFICATION_TEST_APIKEY"));
        _apiKeys.Add("Empty", string.Empty);
    }
    
    [Theory(Skip = "Api key WIP")]
    [InlineData(Network.Mainnet, "Test")]
    [InlineData(Network.Testnet, "Main")]
    public void Initialize_Wrong_Network_Key_Combination(Network network, string key)
    {
        Action result = () => TatumSdk.Init(network, _apiKeys[key], new HttpClient());

        result.Should().Throw<ValidateSdkException>().WithMessage($"Tatum API key is not valid for {(network == Network.Mainnet ? "Main" : "Test")}net.");
    }
    
    [Theory(Skip = "Api key WIP")]
    [InlineData(Network.Mainnet, "Main")]
    [InlineData(Network.Testnet, "Test")]
    [InlineData(Network.Mainnet, "Empty")]
    [InlineData(Network.Testnet, "Empty")]
    public async Task Initialize_Proper_Network_Key_Combination(Network network, string key)
    {
        DebugModeHandler debugModeHandler = new DebugModeHandler();
        NoApiKeyNetworkHandler noApiKeyNetworkHandler = new NoApiKeyNetworkHandler(new DefaultTatumSdkConfiguration(){Network = Network.Testnet});
        debugModeHandler.InnerHandler = noApiKeyNetworkHandler;
        noApiKeyNetworkHandler.InnerHandler = new HttpClientHandler();

        var tatumSdk = TatumSdk.Init(network, _apiKeys[key], new HttpClient(debugModeHandler));
        
        AddressEventNotification notification = new AddressEventNotification
        {
            Chain = AddressTransactionChain.Ethereum,
            Address = "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380",
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        Result<AddressEventNotification> createdNotificationResult = await tatumSdk.Notifications.Subscribe.AddressEvent(notification);

        if (!createdNotificationResult.Success)
        {
            Assert.True(false, createdNotificationResult.ErrorMessage);
        }

        AddressEventNotification createdNotification = createdNotificationResult.Value;
        
        createdNotification.Id.Should().NotBeNullOrEmpty();

        Result<List<INotification>> notificationsResult = await tatumSdk.Notifications.GetAll();
        
        if (!notificationsResult.Success)
        {
            Assert.True(false, notificationsResult.ErrorMessage);
        }
        
        List<INotification> notifications = notificationsResult.Value;

        notifications.Should().NotBeNull();
        notifications.Should().NotBeEmpty();
        notifications.Should().Contain(x => x.Id == createdNotification.Id);
        
        var unsubscribeResult = await tatumSdk.Notifications.Unsubscribe(createdNotification.Id);

        unsubscribeResult.Success.Should().BeTrue();
        
        notificationsResult = await tatumSdk.Notifications.GetAll();
        
        if (!notificationsResult.Success)
        {
            Assert.True(false, notificationsResult.ErrorMessage);
        }
        
        notifications = notificationsResult.Value;
        
        notifications.Should().NotContain(x => x.Id == createdNotification.Id);
    }
}