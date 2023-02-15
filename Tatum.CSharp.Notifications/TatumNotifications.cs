using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Tatum.CSharp.Core;
using Tatum.CSharp.Core.Configuration;
using Tatum.CSharp.Core.Extensions;
using Tatum.CSharp.Core.Serialization;
using Tatum.CSharp.Notifications.Mappers;
using Tatum.CSharp.Notifications.Models;
using Tatum.CSharp.Notifications.Models.Notifications;
using Tatum.CSharp.Notifications.Models.Responses;

namespace Tatum.CSharp.Notifications
{
    public class TatumNotifications : TatumClientBase, ITatumNotifications, ITatumNotificationSubscriptions
    {
        private const string NotificationsUrl = "/v3/subscription";

        public TatumNotifications(HttpClient httpClient, TatumSdkConfiguration configuration) : base(httpClient, configuration)
        {
        }
        
        public TatumNotifications(IHttpClientFactory httpClientFactory, TatumSdkConfiguration configuration) : base(httpClientFactory, configuration)
        {
        }

        public async Task<Result<NotificationsList>> GetAll(GetAllNotificationsQuery getAllNotificationsQuery)
        {
            var sb = new StringBuilder();
            
            sb.Append(NotificationsUrl);
            
            sb.Append($"?pageSize={getAllNotificationsQuery.PageSize}");
            
            if (getAllNotificationsQuery.Offset > 0)
            {
                sb.Append($"&offset={getAllNotificationsQuery.Offset}");
            }
            
            if (!string.IsNullOrEmpty(getAllNotificationsQuery.Address))
            {
                sb.Append($"&address={getAllNotificationsQuery.Address}");
            }

            var response = await GetClient().GetAsync(sb.ToString());

            var result = await response.ToResultAsync<List<NotificationResponse>>();

            if (result.Success)
            {
                return NotificationMapper.Map(result.Value);
            }

            return new Result<NotificationsList>(result.ErrorMessage);
        }

        public async Task<Result<NotificationsList>> GetAll()
        {
            return await GetAll(new GetAllNotificationsQuery());
        }

        public async Task Unsubscribe(string notificationId)
        {
            var url = $"{NotificationsUrl}/{notificationId}";
            
            await GetClient().DeleteAsync(url);
        }

        public ITatumNotificationSubscriptions Subscribe => this;

        public async Task<Result<AddressTransactionNotification>> AddressTransaction(AddressTransactionNotification addressTransactionNotification)
        {
            return await CreateNotification(addressTransactionNotification);
        }
        
        public async Task<Result<ContractLogEventNotification>> ContractLogEvent(ContractLogEventNotification contractLogEventNotification)
        {
            return await CreateNotification(contractLogEventNotification);
        }

        public async Task<Result<ContractNftTxsPerBlockNotification>> ContractNftTxsPerBlock(ContractNftTxsPerBlockNotification contractNftTxsPerBlockNotification)
        {
            return await CreateNotification(contractNftTxsPerBlockNotification);
        }

        public async Task<Result<ContractMultitokenTxsPerBlockNotification>> ContractMultitokenTxsPerBlock(ContractMultitokenTxsPerBlockNotification contractMultitokenTxsPerBlockNotification)
        {
            return await CreateNotification(contractMultitokenTxsPerBlockNotification);
        }

        public async Task<Result<AccountIncomingBlockchainTransactionNotification>> AccountIncomingBlockchainTransaction(
            AccountIncomingBlockchainTransactionNotification accountIncomingBlockchainTransactionNotification)
        {
            return await CreateNotification(accountIncomingBlockchainTransactionNotification);
        }

        public async Task<Result<AccountPendingBlockchainTransactionNotification>> AccountPendingBlockchainTransaction(
            AccountPendingBlockchainTransactionNotification accountPendingBlockchainTransactionNotification)
        {
            return await CreateNotification(accountPendingBlockchainTransactionNotification);
        }

        public async Task<Result<CustomerTradeMatchNotification>> CustomerTradeMatch(CustomerTradeMatchNotification customerTradeMatchNotification)
        {
            return await CreateNotification(customerTradeMatchNotification);
        }

        public async Task<Result<CustomerPartialTradeMatchNotification>> CustomerPartialTradeMatch(CustomerPartialTradeMatchNotification customerPartialTradeMatchNotification)
        {
            return await CreateNotification(customerPartialTradeMatchNotification);
        }

        public async Task<Result<TransactionInTheBlockNotification>> TransactionInTheBlock(TransactionInTheBlockNotification transactionInTheBlockNotification)
        {
            return await CreateNotification(transactionInTheBlockNotification);
        }

        public async Task<Result<KmsFailedTxNotification>> KmsFailedTx(KmsFailedTxNotification kmsFailedTxNotification)
        {
            return await CreateNotification(kmsFailedTxNotification);
        }

        public async Task<Result<KmsCompletedTxNotification>> KmsCompletedTx(KmsCompletedTxNotification kmsCompletedTxNotification)
        {
            return await CreateNotification(kmsCompletedTxNotification);
        }

        public async Task<Result<AccountBalanceLimitNotification>> AccountBalanceLimit(AccountBalanceLimitNotification accountBalanceLimitNotification)
        {
            return await CreateNotification(accountBalanceLimitNotification);
        }

        public async Task<Result<TransactionHistoryReportNotification>> TransactionHistoryReport(TransactionHistoryReportNotification transactionHistoryReportNotification)
        {
            var notificationRequest = NotificationMapper.Map(transactionHistoryReportNotification);
            
            var responseMessage = await GetClient().PostAsJsonAsync(NotificationsUrl, notificationRequest, TatumSerializerOptions.Default);

            var result = await responseMessage.ToResultAsync<TransactionHistoryReportNotification>();

            if (result.Success)
            {
                transactionHistoryReportNotification.Id = result.Value.Id;
                return transactionHistoryReportNotification;
            }

            return result;
        }

        private async Task<Result<T>> CreateNotification<T>(T notification) where T : Notification
        {
            var notificationRequest = NotificationMapper.Map(notification);
            
            var responseMessage = await GetClient().PostAsJsonAsync(NotificationsUrl, notificationRequest, TatumSerializerOptions.Default);

            var result = await responseMessage.ToResultAsync<T>();

            if (result.Success)
            {
                notification.Id = result.Value.Id;
                return notification;
            }

            return result;
        }
    }
}