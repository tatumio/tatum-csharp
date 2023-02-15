using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.Core;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Notifications.Models;
using Tatum.CSharp.Notifications.Models.Notifications;
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
    public async Task GetAll()
    {
        var notificationsResult = await _tatumSdk.Notifications.GetAll();
        
        notificationsResult.Success.Should().BeTrue();
    }

    [Fact]
    public async Task AddressTransaction_Create_Get_Delete()
    {
        var notification = new AddressTransactionNotification
        {
            Chain = Chain.Ethereum,
            Address = "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380",
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.AddressTransaction,
            x => x.AddressTransactions);
    }
    
    [Fact]
    public async Task ContractLogEvent_Create_Get_Delete()
    {
        var notification = new ContractLogEventNotification
        {
            Chain = Chain.Ethereum,
            Event = "0xddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef",
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.ContractLogEvent,
            x => x.ContractLogEvents);
    }
    
    [Fact]
    public async Task ContractNftTxsPerBlock_Create_Get_Delete()
    {
        var notification = new ContractNftTxsPerBlockNotification()
        {
            Chain = Chain.Ethereum,
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.ContractNftTxsPerBlock,
            x => x.ContractNftTxsPerBlock);
    }
    
    [Fact]
    public async Task ContractMultitokenTxsPerBlock_Create_Get_Delete()
    {
        var notification = new ContractMultitokenTxsPerBlockNotification
        {
            Chain = Chain.Ethereum,
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.ContractMultitokenTxsPerBlock,
            x => x.ContractMultitokenTxsPerBlock);
    }
    
    [Fact]
    public async Task AccountIncomingBlockchainTransaction_Create_Get_Delete()
    {
        var notification = new AccountIncomingBlockchainTransactionNotification
        {
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380",
            AccountId = "63ecc4c0cb3835070afffa88"
        };

        await Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.AccountIncomingBlockchainTransaction,
            x => x.AccountIncomingBlockchainTransactions);
    }
    
    [Fact]
    public async Task AccountPendingBlockchainTransaction_Create_Get_Delete()
    {
        var notification = new AccountPendingBlockchainTransactionNotification()
        {
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380",
            AccountId = "63ecc4c0cb3835070afffa88"
        };

        await Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.AccountPendingBlockchainTransaction,
            x => x.AccountPendingBlockchainTransactions);
    }
    
    [Fact]
    public async Task CustomerTradeMatch_Create_Get_Delete()
    {
        var notification = new CustomerTradeMatchNotification()
        {
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380",
            AccountId = "63ecc583ec2dbb9649bc86c2"
        };

        await Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.CustomerTradeMatch,
            x => x.CustomerTradeMatches);
    }
    
    [Fact]
    public async Task CustomerPartialTradeMatch_Create_Get_Delete()
    {
        var notification = new CustomerPartialTradeMatchNotification()
        {
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380",
            AccountId = "63ecc583ec2dbb9649bc86c2"
        };

        await Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.CustomerPartialTradeMatch,
            x => x.CustomerPartialTradeMatches);
    }
    
    [Fact]
    public async Task TransactionInTheBlock_Create_Get_Delete()
    {
        var notification = new TransactionInTheBlockNotification()
        {
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.TransactionInTheBlock,
            x => x.TransactionInTheBlocks);
    }
    
    [Fact]
    public async Task KmsFailedTx_Create_Get_Delete()
    {
        var notification = new KmsFailedTxNotification()
        {
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.KmsFailedTx,
            x => x.KmsFailedTxs);
    }
    
    [Fact]
    public async Task KmsCompletedTx_Create_Get_Delete()
    {
        var notification = new KmsCompletedTxNotification()
        {
            Url = "https://webhook.site/0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380"
        };

        await Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.KmsCompletedTx,
            x => x.KmsCompletedTxs);
    }
    
    [Fact]
    public async Task AccountBalanceLimit_Create_Get_Delete()
    {
        var notification = new AccountBalanceLimitNotification
        {
            Limit = "100",
            TypeOfBalance = BalanceType.account
        };

        await Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.AccountBalanceLimit,
            x => x.AccountBalanceLimits);
    }
    
    [Fact]
    public async Task TransactionHistoryReport_Create_Get_Delete()
    {
        var notification = new TransactionHistoryReportNotification()
        {
            Interval = 1
        };

        await Create_Get_Delete(
            notification, 
            _tatumSdk.Notifications.Subscribe.TransactionHistoryReport,
            x => x.TransactionHistoryReports);
    }

    private async Task Create_Get_Delete<T>(T notification, Func<T, Task<Result<T>>> createFunc, Func<NotificationsList, List<T>> getNotificationListFunc) where T : Notification
    {
        var createdNotificationResult = await createFunc(notification);
        
        createdNotificationResult.Success.Should().BeTrue();

        var createdNotification = createdNotificationResult.Value;
        
        createdNotification.Id.Should().NotBeNullOrEmpty();

        var notificationsResult = await _tatumSdk.Notifications.GetAll();
        
        notificationsResult.Success.Should().BeTrue();
        
        var notifications = notificationsResult.Value;

        notifications.Should().NotBeNull();
        getNotificationListFunc(notifications).Should().NotBeEmpty();
        getNotificationListFunc(notifications).Should().Contain(x => x.Id == createdNotification.Id);
        
        await _tatumSdk.Notifications.Unsubscribe(createdNotification.Id);
        
        notificationsResult = await _tatumSdk.Notifications.GetAll();
        
        notificationsResult.Success.Should().BeTrue();
        
        notifications = notificationsResult.Value;
        
        getNotificationListFunc(notifications).Should().NotContain(x => x.Id == createdNotification.Id);
    }
}