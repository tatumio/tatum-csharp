using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.Core;
using Tatum.Core.Exceptions;
using Tatum.Core.Models;
using Tatum.Notifications.Models;
using Tatum.Notifications.Models.Notifications;
using Tatum.Notifications.Models.Notifications.SupportedChains;
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
        Action result = () => TatumSdk.Init(network, _apiKeys[key], config => config.EnableDebugMode = true);

        result.Should().Throw<ValidateSdkException>().WithMessage($"Tatum API key is not valid for {(network == Network.Mainnet ? "Main" : "Test")}net.");
    }
    
    [Theory(Skip = "Api key WIP")]
    [InlineData(Network.Mainnet, "Main")]
    [InlineData(Network.Testnet, "Test")]
    [InlineData(Network.Mainnet, "Empty")]
    [InlineData(Network.Testnet, "Empty")]
    public async Task Initialize_Proper_Network_Key_Combination(Network network, string key)
    {
        var tatumSdk = TatumSdk.Init(network, _apiKeys[key], config => config.EnableDebugMode = true);
        
        AddressBasedNotification<AddressEventChain> notification = new AddressBasedNotification<AddressEventChain>
        {
            Chain = AddressEventChain.Ethereum,
            Address = "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380",
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        Result<AddressBasedNotification<AddressEventChain>> createdNotificationResult = await tatumSdk.Notifications.Subscribe.AddressEvent(notification);

        if (!createdNotificationResult.Success)
        {
            Assert.True(false, createdNotificationResult.ErrorMessage);
        }

        AddressBasedNotification<AddressEventChain> createdNotification = createdNotificationResult.Value;
        
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