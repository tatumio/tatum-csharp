using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Tatum.Core;
using Tatum.Core.Configuration;
using Tatum.Core.Extensions;
using Tatum.Core.Serialization;
using Tatum.Notifications.Mappers;
using Tatum.Notifications.Models;
using Tatum.Notifications.Models.Notifications;
using Tatum.Notifications.Models.Notifications.SupportedChains;
using Tatum.Notifications.Models.Responses;

namespace Tatum.Notifications
{
    public class TatumNotifications : TatumClientBase, ITatumNotifications, ITatumNotificationSubscriptions
    {
        private const string NotificationsUrl = "/v1/subscription";

        public TatumNotifications(HttpClient httpClient, ITatumSdkConfiguration configuration) : base(httpClient, configuration)
        {
        }
        
        public TatumNotifications(IHttpClientFactory httpClientFactory, ITatumSdkConfiguration configuration) : base(httpClientFactory, configuration)
        {
        }

        public async Task<Result<List<INotification>>> GetAll(GetAllNotificationsQuery getAllNotificationsQuery)
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

            var response = await GetClient().GetAsync(sb.ToString()).ConfigureAwait(false);

            var result = await response.ToResultAsync<List<NotificationResponse>>().ConfigureAwait(false);

            if (result.Success)
            {
                return NotificationMapper.Map(result.Value);
            }

            return new Result<List<INotification>>(result.ErrorMessage);
        }

        public async Task<Result<List<INotification>>> GetAll()
        {
            return await GetAll(new GetAllNotificationsQuery()).ConfigureAwait(false);
        }

        public async Task<Result<List<WebhookExecutionResponse>>> GetAllExecutedWebhooks(GetAllExecutedWebhooksQuery getAllExecutedWebhooksQuery)
        {
            var sb = new StringBuilder();
            
            sb.Append(NotificationsUrl);
            sb.Append("/webhook");
            
            sb.Append($"?pageSize={getAllExecutedWebhooksQuery.PageSize}");
            
            sb.Append($"&direction={getAllExecutedWebhooksQuery.SortingDirection.ToString().ToLower()}");
            
            if (getAllExecutedWebhooksQuery.Offset > 0)
            {
                sb.Append($"&offset={getAllExecutedWebhooksQuery.Offset}");
            }

            if (getAllExecutedWebhooksQuery.FilterFailed != null)
            {
                sb.Append($"&failed={(getAllExecutedWebhooksQuery.FilterFailed.Value ? "true" : "false")}");
            }

            var response = await GetClient().GetAsync(sb.ToString()).ConfigureAwait(false);

            var result = await response.ToResultAsync<List<WebhookExecutionResponse>>().ConfigureAwait(false);

            if (result.Success)
            {
                return result;
            }

            return new Result<List<WebhookExecutionResponse>>(result.ErrorMessage);
        }

        public Task<Result<List<WebhookExecutionResponse>>> GetAllExecutedWebhooks()
        {
            return GetAllExecutedWebhooks(new GetAllExecutedWebhooksQuery());
        }

        public async Task<EmptyResult> Unsubscribe(string notificationId)
        {
            var url = $"{NotificationsUrl}/{notificationId}";
            
            var responseMessage = await GetClient().DeleteAsync(url).ConfigureAwait(false);
            
            return await responseMessage.ToEmptyResultAsync().ConfigureAwait(false);
        }

        public ITatumNotificationSubscriptions Subscribe => this;

        public async Task<Result<AddressBasedNotification<AddressEventChain>>> AddressEvent(AddressBasedNotification<AddressEventChain> addressBasedNotification)
        {
            return await CreateAddressBasedNotification(addressBasedNotification).ConfigureAwait(false);
        }

        public async Task<Result<BlockBasedNotification<FailedTxPerBlockChain>>> FailedTxPerBlock(BlockBasedNotification<FailedTxPerBlockChain> addressBasedNotification)
        {
            return await CreateBlockBasedNotification(addressBasedNotification).ConfigureAwait(false);
        }

        public async Task<Result<AddressBasedNotification<IncomingNativeTxChain>>> IncomingNativeTx(AddressBasedNotification<IncomingNativeTxChain> addressBasedNotification)
        {
            return await CreateAddressBasedNotification(addressBasedNotification).ConfigureAwait(false);
        }

        public async Task<Result<AddressBasedNotification<OutgoingNativeTxChain>>> OutgoingNativeTx(AddressBasedNotification<OutgoingNativeTxChain> addressBasedNotification)
        {
            return await CreateAddressBasedNotification(addressBasedNotification).ConfigureAwait(false);
        }

        public async Task<Result<AddressBasedNotification<OutgoingFailedTxChain>>> OutgoingFailedTx(AddressBasedNotification<OutgoingFailedTxChain> addressBasedNotification)
        {
            return await CreateAddressBasedNotification(addressBasedNotification).ConfigureAwait(false);
        }

        public async Task<Result<AddressBasedNotification<PaidFeeChain>>> PaidFee(AddressBasedNotification<PaidFeeChain> addressBasedNotification)
        {
            return await CreateAddressBasedNotification(addressBasedNotification).ConfigureAwait(false);
        }

        public async Task<Result<AddressBasedNotification<IncomingInternalTxChain>>> IncomingInternalTx(AddressBasedNotification<IncomingInternalTxChain> addressBasedNotification)
        {
            return await CreateAddressBasedNotification(addressBasedNotification).ConfigureAwait(false);
        }

        public async Task<Result<AddressBasedNotification<OutgoingInternalTxChain>>> OutgoingInternalTx(AddressBasedNotification<OutgoingInternalTxChain> addressBasedNotification)
        {
            return await CreateAddressBasedNotification(addressBasedNotification).ConfigureAwait(false);
        }

        public async Task<Result<AddressBasedNotification<IncomingFungibleTxChain>>> IncomingFungibleTx(AddressBasedNotification<IncomingFungibleTxChain> addressBasedNotification)
        {
            return await CreateAddressBasedNotification(addressBasedNotification).ConfigureAwait(false);
        }

        public async Task<Result<AddressBasedNotification<OutgoingFungibleTxChain>>> OutgoingFungibleTx(AddressBasedNotification<OutgoingFungibleTxChain> addressBasedNotification)
        {
            return await CreateAddressBasedNotification(addressBasedNotification).ConfigureAwait(false);
        }

        public async Task<Result<AddressBasedNotification<IncomingNftTxChain>>> IncomingNftTx(AddressBasedNotification<IncomingNftTxChain> addressBasedNotification)
        {
            return await CreateAddressBasedNotification(addressBasedNotification).ConfigureAwait(false);
        }

        public async Task<Result<AddressBasedNotification<OutgoingNftTxChain>>> OutgoingNftTx(AddressBasedNotification<OutgoingNftTxChain> addressBasedNotification)
        {
            return await CreateAddressBasedNotification(addressBasedNotification).ConfigureAwait(false);
        }

        public async Task<Result<AddressBasedNotification<IncomingMultitokenTxChain>>> IncomingMultitokenTx(AddressBasedNotification<IncomingMultitokenTxChain> addressBasedNotification)
        {
            return await CreateAddressBasedNotification(addressBasedNotification).ConfigureAwait(false);
        }

        public async Task<Result<AddressBasedNotification<OutgoingMultitokenTxChain>>> OutgoingMultitokenTx(AddressBasedNotification<OutgoingMultitokenTxChain> addressBasedNotification)
        {
            return await CreateAddressBasedNotification(addressBasedNotification).ConfigureAwait(false);
        }

        private async Task<Result<AddressBasedNotification<TChainEnum>>> CreateAddressBasedNotification<TChainEnum>(AddressBasedNotification<TChainEnum> notification)
        {
            var notificationRequest = NotificationMapper.Map(notification);
            
            var responseMessage = await GetClient().PostAsJsonAsync(NotificationsUrl, notificationRequest, TatumSerializerOptions.Default).ConfigureAwait(false);

            var result = await responseMessage.ToResultAsync<AddressBasedNotification<TChainEnum>>().ConfigureAwait(false);

            if (result.Success)
            {
                notification.Id = result.Value.Id;
                notification.Type = notificationRequest.Type;
                return notification;
            }

            return result;
        }
        
        private async Task<Result<BlockBasedNotification<TChainEnum>>> CreateBlockBasedNotification<TChainEnum>(BlockBasedNotification<TChainEnum> notification)
        {
            var notificationRequest = NotificationMapper.Map(notification);
            
            var responseMessage = await GetClient().PostAsJsonAsync(NotificationsUrl, notificationRequest, TatumSerializerOptions.Default).ConfigureAwait(false);

            var result = await responseMessage.ToResultAsync<BlockBasedNotification<TChainEnum>>().ConfigureAwait(false);

            if (result.Success)
            {
                notification.Id = result.Value.Id;
                notification.Type = notificationRequest.Type;
                return notification;
            }

            return result;
        }
    }
}