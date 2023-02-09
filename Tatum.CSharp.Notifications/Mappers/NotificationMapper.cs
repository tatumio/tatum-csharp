using System;
using System.Collections.Generic;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Notifications.Models;
using Tatum.CSharp.Notifications.Models.Responses;

namespace Tatum.CSharp.Notifications.Mappers
{
    public static class NotificationMapper
    {
        public static Models.Notifications Map(List<NotificationResponse> notificationList)
        {
            var notifications = new Models.Notifications();

            foreach (var notification in notificationList)
            {
                switch (notification.Type)
                {
                    case NotificationType.ADDRESS_TRANSACTION:
                        notifications.AddressTransactions.Add(MapAddressTransaction(notification));
                        break;
                    case NotificationType.CONTRACT_LOG_EVENT:
                        notifications.ContractLogEvents.Add(notification);
                        break;
                    case NotificationType.ACCOUNT_INCOMING_BLOCKCHAIN_TRANSACTION:
                        notifications.AccountIncomingBlockchainTransactions.Add(notification);
                        break;
                    case NotificationType.ACCOUNT_PENDING_BLOCKCHAIN_TRANSACTION:
                        notifications.AccountPendingBlockchainTransactions.Add(notification);
                        break;
                    case NotificationType.CUSTOMER_TRADE_MATCH:
                        notifications.CustomerTradeMatches.Add(notification);
                        break;
                    case NotificationType.CUSTOMER_PARTIAL_TRADE_MATCH:
                        notifications.CustomerPartialTradeMatches.Add(notification);
                        break;
                    case NotificationType.TRANSACTION_IN_THE_BLOCK:
                        notifications.TransactionInTheBlocks.Add(notification);
                        break;
                    case NotificationType.KMS_FAILED_TX:
                        notifications.KmsFailedTxs.Add(notification);
                        break;
                    case NotificationType.KMS_COMPLETED_TX:
                        notifications.KmsCompletedTxs.Add(notification);
                        break;
                    case NotificationType.ACCOUNT_BALANCE_LIMIT:
                        notifications.AccountBalanceLimits.Add(notification);
                        break;
                    case NotificationType.TRANSACTION_HISTORY_REPORT:
                        notifications.TransactionHistoryReports.Add(notification);
                        break;
                }
            }
            
            return notifications;
        }

        public static NotificationResponse Map(AddressTransactionNotification addressTransactionNotification)
        {
            return new NotificationResponse
            {
                Id = addressTransactionNotification.Id,
                Type = NotificationType.ADDRESS_TRANSACTION,
                Attributes = new Dictionary<string, string>()
                {
                    { "address", addressTransactionNotification.Address },
                    { "chain", ChainMapper.GetChainAbbreviation(addressTransactionNotification.Chain).ToString() },
                    { "url", addressTransactionNotification.Url }
                }
            };
        }
        
        public static AddressTransactionNotification MapAddressTransaction(NotificationResponse notificationResponse)
        {
            notificationResponse.Attributes.TryGetValue("chain", out var chainAbbreviation);
            notificationResponse.Attributes.TryGetValue("address", out var address);
            notificationResponse.Attributes.TryGetValue("url", out var url);

            Enum.TryParse(chainAbbreviation, out ChainAbbreviation chain);

            return new AddressTransactionNotification
            {
                Id = notificationResponse.Id,
                Chain = ChainMapper.GetChainName(chain),
                Address = address,
                Url = url
            };
        }
    }
}