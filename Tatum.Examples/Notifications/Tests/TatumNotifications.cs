using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;
using Tatum.Core;
using Tatum.Core.Configuration;
using Tatum.Core.Models;
using Tatum.Notifications.Mappers;
using Tatum.Notifications.Models;
using Tatum.Notifications.Models.Notifications;
using Tatum.Notifications.Models.Notifications.SupportedChains;
using Tatum.Notifications.Models.Responses;
using Xunit;

namespace Tatum.Examples.Notifications.Tests;

[Collection("Notification")]
public class TatumNotifications
{
    private readonly TatumSdk _tatumSdk;
    
    public TatumNotifications()
    {
        var config = new TatumSdkConfiguration()
        {
            EnableDebugMode = true,
            // Because of the speed of tests we need to increase retry count to avoid throttling on the API side.
            RetryPolicy = Policy<HttpResponseMessage>
                .Handle<HttpRequestException>()
                .OrTransientHttpStatusCode()
                .WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(2), 10))
        };
        
        _tatumSdk = TatumSdk.Init(Network.Testnet, config);
    }

    [Fact]
    public async Task GetAllExecutedWebhooks()
    {
        var tatumSdk = await TatumSdk.InitAsync(Network.Testnet, config => config.EnableDebugMode = true);
        
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
    }
    
    [Fact]
    public async Task GetAll()
    {
        var tatumSdk = await TatumSdk.InitAsync(Network.Testnet, config => config.EnableDebugMode = true);
        
        var result = await tatumSdk.Notifications.GetAll();
        
        result.Should().NotBeNull();
        
        if (!result.Success)
        {
            Assert.True(false, result.ErrorMessage);
        }
    }
    
    [Fact]
    public async Task Unsubscribe_ShouldFailOnNonExisting()
    {
        var result = await _tatumSdk.Notifications.Unsubscribe("6411aa05d97910e25b46776d");

        result.Should().NotBeNull();
        result.Success.Should().BeFalse();
    }
    
    [Theory]
    [InlineData(AddressEventChain.Ethereum, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(AddressEventChain.Solana, "8Kvnpupqf2hPrMDJ4mK2kXnSSMihh1AjFg7RiF5Vn8wX")]
    [InlineData(AddressEventChain.Polygon, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(AddressEventChain.Celo, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(AddressEventChain.Klaytn, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(AddressEventChain.Bitcoin, "tb1qjzjyd3l3vh8an8w4mkr6dwur59lan60367kr04")]
    [InlineData(AddressEventChain.Litecoin, "mxz6DCurdU65oyzfUnE36enNUFG8soaRXi")]
    [InlineData(AddressEventChain.BitcoinCash, "bchtest:qrg27kw32qkeym2q8mdhw0lcqu2x7gw5fghy405gn7")]
    [InlineData(AddressEventChain.Dogecoin, "ndz9RPmJWwNiNt1aRvgxhG4G5xMgr61Wn8")]
    [InlineData(AddressEventChain.Tron, "TLZirVxP5m37d2ZEWDtmvk97KMJXiBsWGZ")]
    [InlineData(AddressEventChain.BinanceSmartChain, "0x58107193278ea4bb56c390185f4755e0a4239d68")]
    public async Task AddressEvent_Create_Get_Delete(AddressEventChain chain, string address)
    {
        AddressBasedNotification<AddressEventChain> notification = new AddressBasedNotification<AddressEventChain>
        {
            Chain = chain,
            Address = address,
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await AddressBased_Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.AddressEvent);
    }
    
    [Theory]
    [InlineData(FailedTxPerBlockChain.Ethereum)]
    [InlineData(FailedTxPerBlockChain.Polygon)]
    [InlineData(FailedTxPerBlockChain.Celo)]
    [InlineData(FailedTxPerBlockChain.Klaytn)]
    [InlineData(FailedTxPerBlockChain.BinanceSmartChain)]
    public async Task FailedTxPerBlock_Create_Get_Delete(FailedTxPerBlockChain chain)
    {
        BlockBasedNotification<FailedTxPerBlockChain> notification = new BlockBasedNotification<FailedTxPerBlockChain>
        {
            Chain = chain,
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await BlockBased_Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.FailedTxPerBlock);
    }
    
    [Theory]
    [InlineData(IncomingNativeTxChain.Ethereum, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingNativeTxChain.Polygon, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingNativeTxChain.Celo, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingNativeTxChain.Klaytn, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingNativeTxChain.Bitcoin, "tb1qjzjyd3l3vh8an8w4mkr6dwur59lan60367kr04")]
    [InlineData(IncomingNativeTxChain.Litecoin, "mxz6DCurdU65oyzfUnE36enNUFG8soaRXi")]
    [InlineData(IncomingNativeTxChain.Dogecoin, "ndz9RPmJWwNiNt1aRvgxhG4G5xMgr61Wn8")]
    [InlineData(IncomingNativeTxChain.Tron, "TLZirVxP5m37d2ZEWDtmvk97KMJXiBsWGZ")]
    [InlineData(IncomingNativeTxChain.BinanceSmartChain, "0x58107193278ea4bb56c390185f4755e0a4239d68")]
    public async Task IncomingNativeTx_Create_Get_Delete(IncomingNativeTxChain chain, string address)
    {
        AddressBasedNotification<IncomingNativeTxChain> notification = new AddressBasedNotification<IncomingNativeTxChain>
        {
            Chain = chain,
            Address = address,
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await AddressBased_Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.IncomingNativeTx);
    }
    
    [Theory]
    [InlineData(OutgoingNativeTxChain.Ethereum, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingNativeTxChain.Polygon, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingNativeTxChain.Celo, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingNativeTxChain.Klaytn, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingNativeTxChain.Bitcoin, "tb1qjzjyd3l3vh8an8w4mkr6dwur59lan60367kr04")]
    [InlineData(OutgoingNativeTxChain.Litecoin, "mxz6DCurdU65oyzfUnE36enNUFG8soaRXi")]
    [InlineData(OutgoingNativeTxChain.BinanceSmartChain, "0x58107193278ea4bb56c390185f4755e0a4239d68")]
    public async Task OutgoingNativeTx_Create_Get_Delete(OutgoingNativeTxChain chain, string address)
    {
        AddressBasedNotification<OutgoingNativeTxChain> notification = new AddressBasedNotification<OutgoingNativeTxChain>
        {
            Chain = chain,
            Address = address,
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await AddressBased_Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.OutgoingNativeTx);
    }
    
    [Theory]
    [InlineData(OutgoingFailedTxChain.Ethereum, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingFailedTxChain.Polygon, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingFailedTxChain.Celo, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingFailedTxChain.Klaytn, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingFailedTxChain.BinanceSmartChain, "0x58107193278ea4bb56c390185f4755e0a4239d68")]
    public async Task OutgoingFailedTx_Create_Get_Delete(OutgoingFailedTxChain chain, string address)
    {
        AddressBasedNotification<OutgoingFailedTxChain> notification = new AddressBasedNotification<OutgoingFailedTxChain>
        {
            Chain = chain,
            Address = address,
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await AddressBased_Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.OutgoingFailedTx);
    }
    
    [Theory]
    [InlineData(PaidFeeChain.Ethereum, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(PaidFeeChain.Polygon, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(PaidFeeChain.Celo, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(PaidFeeChain.Klaytn, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(PaidFeeChain.BinanceSmartChain, "0x58107193278ea4bb56c390185f4755e0a4239d68")]
    public async Task PaidFee_Create_Get_Delete(PaidFeeChain chain, string address)
    {
        AddressBasedNotification<PaidFeeChain> notification = new AddressBasedNotification<PaidFeeChain>
        {
            Chain = chain,
            Address = address,
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await AddressBased_Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.PaidFee);
    }
    
    [Theory]
    [InlineData(IncomingInternalTxChain.Ethereum, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingInternalTxChain.Polygon, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingInternalTxChain.Celo, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingInternalTxChain.Klaytn, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingInternalTxChain.BinanceSmartChain, "0x58107193278ea4bb56c390185f4755e0a4239d68")]
    public async Task IncomingInternalTx_Create_Get_Delete(IncomingInternalTxChain chain, string address)
    {
        AddressBasedNotification<IncomingInternalTxChain> notification = new AddressBasedNotification<IncomingInternalTxChain>
        {
            Chain = chain,
            Address = address,
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await AddressBased_Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.IncomingInternalTx);
    }
    
    [Theory]
    [InlineData(OutgoingInternalTxChain.Ethereum, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingInternalTxChain.Polygon, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingInternalTxChain.Celo, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingInternalTxChain.Klaytn, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingInternalTxChain.BinanceSmartChain, "0x58107193278ea4bb56c390185f4755e0a4239d68")]
    public async Task OutgoingInternalTx_Create_Get_Delete(OutgoingInternalTxChain chain, string address)
    {
        AddressBasedNotification<OutgoingInternalTxChain> notification = new AddressBasedNotification<OutgoingInternalTxChain>
        {
            Chain = chain,
            Address = address,
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await AddressBased_Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.OutgoingInternalTx);
    }
    
    [Theory]
    [InlineData(IncomingFungibleTxChain.Ethereum, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingFungibleTxChain.Polygon, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingFungibleTxChain.Celo, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingFungibleTxChain.Klaytn, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingFungibleTxChain.BinanceSmartChain, "0x58107193278ea4bb56c390185f4755e0a4239d68")]
    public async Task IncomingFungibleTx_Create_Get_Delete(IncomingFungibleTxChain chain, string address)
    {
        AddressBasedNotification<IncomingFungibleTxChain> notification = new AddressBasedNotification<IncomingFungibleTxChain>
        {
            Chain = chain,
            Address = address,
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await AddressBased_Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.IncomingFungibleTx);
    }
    
    [Theory]
    [InlineData(OutgoingFungibleTxChain.Ethereum, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingFungibleTxChain.Polygon, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingFungibleTxChain.Celo, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingFungibleTxChain.Klaytn, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingFungibleTxChain.BinanceSmartChain, "0x58107193278ea4bb56c390185f4755e0a4239d68")]
    public async Task OutgoingFungibleTx_Create_Get_Delete(OutgoingFungibleTxChain chain, string address)
    {
        AddressBasedNotification<OutgoingFungibleTxChain> notification = new AddressBasedNotification<OutgoingFungibleTxChain>
        {
            Chain = chain,
            Address = address,
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await AddressBased_Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.OutgoingFungibleTx);
    }
    
    [Theory]
    [InlineData(IncomingNftTxChain.Ethereum, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingNftTxChain.Polygon, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingNftTxChain.Celo, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingNftTxChain.Klaytn, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingNftTxChain.BinanceSmartChain, "0x58107193278ea4bb56c390185f4755e0a4239d68")]
    public async Task IncomingNftTx_Create_Get_Delete(IncomingNftTxChain chain, string address)
    {
        AddressBasedNotification<IncomingNftTxChain> notification = new AddressBasedNotification<IncomingNftTxChain>
        {
            Chain = chain,
            Address = address,
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await AddressBased_Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.IncomingNftTx);
    }
    
    [Theory]
    [InlineData(OutgoingNftTxChain.Ethereum, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingNftTxChain.Polygon, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingNftTxChain.Celo, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingNftTxChain.Klaytn, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(OutgoingNftTxChain.BinanceSmartChain, "0x58107193278ea4bb56c390185f4755e0a4239d68")]
    public async Task OutgoingNftTx_Create_Get_Delete(OutgoingNftTxChain chain, string address)
    {
        AddressBasedNotification<OutgoingNftTxChain> notification = new AddressBasedNotification<OutgoingNftTxChain>
        {
            Chain = chain,
            Address = address,
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await AddressBased_Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.OutgoingNftTx);
    }
    
    [Theory]
    [InlineData(IncomingMultitokenTxChain.Ethereum, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingMultitokenTxChain.Polygon, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingMultitokenTxChain.Celo, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingMultitokenTxChain.Klaytn, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380")]
    [InlineData(IncomingMultitokenTxChain.BinanceSmartChain, "0x58107193278ea4bb56c390185f4755e0a4239d68")]
    public async Task IncomingMultitokenTx_Create_Get_Delete(IncomingMultitokenTxChain chain, string address)
    {
        AddressBasedNotification<IncomingMultitokenTxChain> notification = new AddressBasedNotification<IncomingMultitokenTxChain>
        {
            Chain = chain,
            Address = address,
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await AddressBased_Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.IncomingMultitokenTx);
    }

    private async Task AddressBased_Create_Get_Delete<TChainEnum>(AddressBasedNotification<TChainEnum> notification, Func<AddressBasedNotification<TChainEnum>, Task<Result<AddressBasedNotification<TChainEnum>>>> createFunc)
    {
        Result<AddressBasedNotification<TChainEnum>> createdNotificationResult = await createFunc(notification);

        if (!createdNotificationResult.Success)
        {
            Assert.True(false, createdNotificationResult.ErrorMessage);
        }

        AddressBasedNotification<TChainEnum> createdNotification = createdNotificationResult.Value;
        
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
        var notificationListed = (AddressBasedNotification<TChainEnum>)notifications.First(x => x.Id == createdNotification.Id);
        
        var expectedType = NotificationMapper.GetNotificationTypeFromChainEnum(notificationListed.Chain);

        notificationListed.Type.Should().Be(expectedType);

        var unsubscribeResult = await _tatumSdk.Notifications.Unsubscribe(createdNotification.Id);

        if (!unsubscribeResult.Success)
        {
            Assert.True(false, unsubscribeResult.ErrorMessage);
        }

        notificationsResult = await _tatumSdk.Notifications.GetAll();
        
        if (!notificationsResult.Success)
        {
            Assert.True(false, notificationsResult.ErrorMessage);
        }
        
        notifications = notificationsResult.Value;
        
        notifications.Should().NotContain(x => x.Id == createdNotification.Id);
    }
    
    private async Task BlockBased_Create_Get_Delete<TChainEnum>(BlockBasedNotification<TChainEnum> notification, Func<BlockBasedNotification<TChainEnum>, Task<Result<BlockBasedNotification<TChainEnum>>>> createFunc)
    {
        Result<BlockBasedNotification<TChainEnum>> createdNotificationResult = await createFunc(notification);

        if (!createdNotificationResult.Success)
        {
            Assert.True(false, createdNotificationResult.ErrorMessage);
        }

        BlockBasedNotification<TChainEnum> createdNotification = createdNotificationResult.Value;
        
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

        if (!unsubscribeResult.Success)
        {
            Assert.True(false, unsubscribeResult.ErrorMessage);
        }

        notificationsResult = await _tatumSdk.Notifications.GetAll();
        
        if (!notificationsResult.Success)
        {
            Assert.True(false, notificationsResult.ErrorMessage);
        }
        
        notifications = notificationsResult.Value;
        
        notifications.Should().NotContain(x => x.Id == createdNotification.Id);
    }
}