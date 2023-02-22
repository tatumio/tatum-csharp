using System;
using System.Collections.Generic;
using Tatum.Notifications.Models;
using Tatum.Notifications.Models.Notifications;
using Tatum.Notifications.Models.Responses;

namespace Tatum.Notifications.Mappers
{
    internal static class NotificationMapper
    {
        public static List<WebhookExecution> Map(List<WebhookExecutionResponse> webhookExecutionResponses)
        {
            var webhookExecutions = new List<WebhookExecution>();
            foreach (var webhookExecutionResponse in webhookExecutionResponses)
            {
                webhookExecutions.Add(Map(webhookExecutionResponse));
            }

            return webhookExecutions;
        }
        
        public static WebhookExecution Map(WebhookExecutionResponse webhookExecutionResponse)
        {
            return new WebhookExecution();
        }
        
        public static List<INotification> Map(List<NotificationResponse> notificationList)
        {
            var notifications = new List<INotification>();

            foreach (var notification in notificationList)
            {
                switch (notification.Type)
                {
                    case NotificationType.ADDRESS_TRANSACTION:
                        notifications.Add(MapAddressTransaction(notification));
                        break;
                    case NotificationType.CONTRACT_LOG_EVENT:
                        notifications.Add(MapContractLogEvent(notification));
                        break;
                    case NotificationType.ACCOUNT_INCOMING_BLOCKCHAIN_TRANSACTION:
                        notifications.Add(MapAccountIncomingBlockchainTransaction(notification));
                        break;
                    case NotificationType.ACCOUNT_PENDING_BLOCKCHAIN_TRANSACTION:
                        notifications.Add(MapAccountPendingBlockchainTransaction(notification));
                        break;
                    case NotificationType.CUSTOMER_TRADE_MATCH:
                        notifications.Add(MapCustomerTradeMatch(notification));
                        break;
                    case NotificationType.CUSTOMER_PARTIAL_TRADE_MATCH:
                        notifications.Add(MapCustomerPartialTradeMatch(notification));
                        break;
                    case NotificationType.TRANSACTION_IN_THE_BLOCK:
                        notifications.Add(MapTransactionInTheBlock(notification));
                        break;
                    case NotificationType.KMS_FAILED_TX:
                        notifications.Add(MapKmsFailedTx(notification));
                        break;
                    case NotificationType.KMS_COMPLETED_TX:
                        notifications.Add(MapKmsCompletedTx(notification));
                        break;
                    case NotificationType.ACCOUNT_BALANCE_LIMIT:
                        notifications.Add(MapAccountBalanceLimit(notification));
                        break;
                    case NotificationType.TRANSACTION_HISTORY_REPORT:
                        notifications.Add(MapTransactionHistoryReport(notification));
                        break;
                    case NotificationType.CONTRACT_NFT_TXS_PER_BLOCK:
                        notifications.Add(MapContractNftTxsPerBlock(notification));
                        break;
                    case NotificationType.CONTRACT_MULTITOKEN_TXS_PER_BLOCK:
                        notifications.Add(MapContractMultitokenTxsPerBlock(notification));
                        break;
                }
            }
            
            return notifications;
        }

        
        public static AddressTransactionNotification MapAddressTransaction(NotificationResponse notificationResponse)
        {
            notificationResponse.Attributes.TryGetValue("chain", out var chainString);
            Enum.TryParse(chainString, out AddressTransactionChain chain);
            
            notificationResponse.Attributes.TryGetValue("address", out var address);
            notificationResponse.Attributes.TryGetValue("url", out var url);

            
            return new AddressTransactionNotification
            {
                Id = notificationResponse.Id,
                Chain = chain,
                Address = address,
                Url = url
            };
        }
        
        public static ContractLogEventNotification MapContractLogEvent(NotificationResponse notificationResponse)
        {
            notificationResponse.Attributes.TryGetValue("chain", out var chainString);
            Enum.TryParse(chainString, out ContractLogEventChain chain);
            
            notificationResponse.Attributes.TryGetValue("event", out var eventData);
            notificationResponse.Attributes.TryGetValue("url", out var url);

            return new ContractLogEventNotification
            {
                Id = notificationResponse.Id,
                Chain = chain,
                Event = eventData,
                Url = url
            };
        }
        
        private static ContractMultitokenTxsPerBlockNotification MapContractMultitokenTxsPerBlock(NotificationResponse notificationResponse)
        {
            notificationResponse.Attributes.TryGetValue("chain", out var chainString);
            Enum.TryParse(chainString, out ContractMultitokenTxsPerBlockChain chain);
            
            notificationResponse.Attributes.TryGetValue("url", out var url);

            return new ContractMultitokenTxsPerBlockNotification
            {
                Id = notificationResponse.Id,
                Chain = chain,
                Url = url
            };
        }

        private static ContractNftTxsPerBlockNotification MapContractNftTxsPerBlock(NotificationResponse notificationResponse)
        {
            notificationResponse.Attributes.TryGetValue("chain", out var chainString);
            Enum.TryParse(chainString, out ContractNftTxsPerBlockChain chain);
            
            notificationResponse.Attributes.TryGetValue("url", out var url);

            return new ContractNftTxsPerBlockNotification
            {
                Id = notificationResponse.Id,
                Chain = chain,
                Url = url
            };
        }

        private static TransactionHistoryReportNotification MapTransactionHistoryReport(NotificationResponse notificationResponse)
        {
            notificationResponse.Attributes.TryGetValue("interval", out var intervalString);

            int.TryParse(intervalString, out var interval);
            
            return new TransactionHistoryReportNotification
            {
                Id = notificationResponse.Id,
                Interval = interval
            };
        }

        private static AccountBalanceLimitNotification MapAccountBalanceLimit(NotificationResponse notificationResponse)
        {
            notificationResponse.Attributes.TryGetValue("typeOfBalance", out var typeOfBalanceString);
            notificationResponse.Attributes.TryGetValue("limit", out var limit);

            Enum.TryParse(typeOfBalanceString, out BalanceType typeOfBalance);

            return new AccountBalanceLimitNotification
            {
                Id = notificationResponse.Id,
                Limit = limit,
                TypeOfBalance = typeOfBalance
            };
        }

        private static KmsCompletedTxNotification MapKmsCompletedTx(NotificationResponse notificationResponse)
        {
            notificationResponse.Attributes.TryGetValue("url", out var url);

            return new KmsCompletedTxNotification
            {
                Id = notificationResponse.Id,
                Url = url
            };
        }

        private static KmsFailedTxNotification MapKmsFailedTx(NotificationResponse notificationResponse)
        {
            notificationResponse.Attributes.TryGetValue("url", out var url);

            return new KmsFailedTxNotification
            {
                Id = notificationResponse.Id,
                Url = url
            };
        }

        private static TransactionInTheBlockNotification MapTransactionInTheBlock(NotificationResponse notificationResponse)
        {
            notificationResponse.Attributes.TryGetValue("url", out var url);

            return new TransactionInTheBlockNotification
            {
                Id = notificationResponse.Id,
                Url = url
            };
        }

        private static CustomerPartialTradeMatchNotification MapCustomerPartialTradeMatch(NotificationResponse notificationResponse)
        {
            notificationResponse.Attributes.TryGetValue("id", out var accountId);
            notificationResponse.Attributes.TryGetValue("url", out var url);

            return new CustomerPartialTradeMatchNotification
            {
                Id = notificationResponse.Id,
                Url = url,
                AccountId = accountId
            };
        }

        private static CustomerTradeMatchNotification MapCustomerTradeMatch(NotificationResponse notificationResponse)
        {
            notificationResponse.Attributes.TryGetValue("id", out var accountId);
            notificationResponse.Attributes.TryGetValue("url", out var url);

            return new CustomerTradeMatchNotification
            {
                Id = notificationResponse.Id,
                Url = url,
                AccountId = accountId
            };
        }

        private static AccountPendingBlockchainTransactionNotification MapAccountPendingBlockchainTransaction(NotificationResponse notificationResponse)
        {
            notificationResponse.Attributes.TryGetValue("id", out var accountId);
            notificationResponse.Attributes.TryGetValue("url", out var url);

            return new AccountPendingBlockchainTransactionNotification
            {
                Id = notificationResponse.Id,
                Url = url,
                AccountId = accountId
            };
        }

        private static AccountIncomingBlockchainTransactionNotification MapAccountIncomingBlockchainTransaction(NotificationResponse notificationResponse)
        {
            notificationResponse.Attributes.TryGetValue("id", out var accountId);
            notificationResponse.Attributes.TryGetValue("url", out var url);

            return new AccountIncomingBlockchainTransactionNotification
            {
                Id = notificationResponse.Id,
                Url = url,
                AccountId = accountId
            };
        }

        public static NotificationResponse Map<T>(T notification) where T : Notification
        {
            switch (notification)
            { 
                case AddressTransactionNotification addressTransactionNotification:
                    return Map(addressTransactionNotification);
                case ContractLogEventNotification contractLogEventNotification:
                    return Map(contractLogEventNotification);
                case ContractNftTxsPerBlockNotification contractNftTxsPerBlockNotification:
                    return Map(contractNftTxsPerBlockNotification);
                case ContractMultitokenTxsPerBlockNotification contractMultitokenTxsPerBlockNotification:
                    return Map(contractMultitokenTxsPerBlockNotification);
                case AccountIncomingBlockchainTransactionNotification accountIncomingBlockchainTransactionNotification:
                    return Map(accountIncomingBlockchainTransactionNotification);
                case AccountPendingBlockchainTransactionNotification accountPendingBlockchainTransactionNotification:
                    return Map(accountPendingBlockchainTransactionNotification);
                case CustomerTradeMatchNotification customerTradeMatchNotification:
                    return Map(customerTradeMatchNotification);
                case CustomerPartialTradeMatchNotification customerPartialTradeMatchNotification:
                    return Map(customerPartialTradeMatchNotification);
                case TransactionInTheBlockNotification transactionInTheBlockNotification:
                    return Map(transactionInTheBlockNotification);
                case KmsFailedTxNotification kmsFailedTxNotification:
                    return Map(kmsFailedTxNotification);
                case KmsCompletedTxNotification kmsCompletedTxNotification:
                    return Map(kmsCompletedTxNotification);
                case AccountBalanceLimitNotification accountBalanceLimitNotification:
                    return Map(accountBalanceLimitNotification);
                case TransactionHistoryReportNotification transactionHistoryReportNotification:
                    return Map(transactionHistoryReportNotification);
                default:
                    throw new ArgumentOutOfRangeException(nameof(notification), notification, null);
            }
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
                    { "chain", addressTransactionNotification.Chain.ToString() },
                    { "url", addressTransactionNotification.Url }
                }
            };
        }
        
        public static NotificationResponse Map(ContractLogEventNotification contractLogEventNotification)
        {
            return new NotificationResponse
            {
                Id = contractLogEventNotification.Id,
                Type = NotificationType.CONTRACT_LOG_EVENT,
                Attributes = new Dictionary<string, string>()
                {
                    { "event", contractLogEventNotification.Event },
                    { "chain", contractLogEventNotification.Chain.ToString() },
                    { "url", contractLogEventNotification.Url }
                }
            };
        }
        
        public static NotificationResponse Map(ContractNftTxsPerBlockNotification contractNftTxsPerBlockNotification)
        {
            return new NotificationResponse
            {
                Id = contractNftTxsPerBlockNotification.Id,
                Type = NotificationType.CONTRACT_NFT_TXS_PER_BLOCK,
                Attributes = new Dictionary<string, string>()
                {
                    { "chain", contractNftTxsPerBlockNotification.Chain.ToString() },
                    { "url", contractNftTxsPerBlockNotification.Url }
                }
            };
        }
        
        public static NotificationResponse Map(ContractMultitokenTxsPerBlockNotification contractMultitokenTxsPerBlockNotification)
        {
            return new NotificationResponse
            {
                Id = contractMultitokenTxsPerBlockNotification.Id,
                Type = NotificationType.CONTRACT_MULTITOKEN_TXS_PER_BLOCK,
                Attributes = new Dictionary<string, string>()
                {
                    { "chain", contractMultitokenTxsPerBlockNotification.Chain.ToString() },
                    { "url", contractMultitokenTxsPerBlockNotification.Url }
                }
            };
        }
        
        public static NotificationResponse Map(AccountIncomingBlockchainTransactionNotification accountIncomingBlockchainTransactionNotification)
        {
            return new NotificationResponse
            {
                Id = accountIncomingBlockchainTransactionNotification.Id,
                Type = NotificationType.ACCOUNT_INCOMING_BLOCKCHAIN_TRANSACTION,
                Attributes = new Dictionary<string, string>()
                {
                    { "id", accountIncomingBlockchainTransactionNotification.AccountId },
                    { "url", accountIncomingBlockchainTransactionNotification.Url }
                }
            };
        }
        
        public static NotificationResponse Map(AccountPendingBlockchainTransactionNotification accountPendingBlockchainTransactionNotification)
        {
            return new NotificationResponse
            {
                Id = accountPendingBlockchainTransactionNotification.Id,
                Type = NotificationType.ACCOUNT_PENDING_BLOCKCHAIN_TRANSACTION,
                Attributes = new Dictionary<string, string>()
                {
                    { "id", accountPendingBlockchainTransactionNotification.AccountId },
                    { "url", accountPendingBlockchainTransactionNotification.Url }
                }
            };
        }
        
        public static NotificationResponse Map(CustomerTradeMatchNotification customerTradeMatchNotification)
        {
            return new NotificationResponse
            {
                Id = customerTradeMatchNotification.Id,
                Type = NotificationType.CUSTOMER_TRADE_MATCH,
                Attributes = new Dictionary<string, string>()
                {
                    { "id", customerTradeMatchNotification.AccountId },
                    { "url", customerTradeMatchNotification.Url }
                }
            };
        }
        
        public static NotificationResponse Map(CustomerPartialTradeMatchNotification customerPartialTradeMatchNotification)
        {
            return new NotificationResponse
            {
                Id = customerPartialTradeMatchNotification.Id,
                Type = NotificationType.CUSTOMER_PARTIAL_TRADE_MATCH,
                Attributes = new Dictionary<string, string>()
                {
                    { "id", customerPartialTradeMatchNotification.AccountId },
                    { "url", customerPartialTradeMatchNotification.Url }
                }
            };
        }
        
        public static NotificationResponse Map(TransactionInTheBlockNotification transactionInTheBlockNotification)
        {
            return new NotificationResponse
            {
                Id = transactionInTheBlockNotification.Id,
                Type = NotificationType.TRANSACTION_IN_THE_BLOCK,
                Attributes = new Dictionary<string, string>()
                {
                    { "url", transactionInTheBlockNotification.Url }
                }
            };
        }
        
        public static NotificationResponse Map(KmsFailedTxNotification kmsFailedTxNotification)
        {
            return new NotificationResponse
            {
                Id = kmsFailedTxNotification.Id,
                Type = NotificationType.KMS_FAILED_TX,
                Attributes = new Dictionary<string, string>()
                {
                    { "url", kmsFailedTxNotification.Url }
                }
            };
        }
        
        public static NotificationResponse Map(KmsCompletedTxNotification kmsCompletedTxNotification)
        {
            return new NotificationResponse
            {
                Id = kmsCompletedTxNotification.Id,
                Type = NotificationType.KMS_COMPLETED_TX,
                Attributes = new Dictionary<string, string>()
                {
                    { "url", kmsCompletedTxNotification.Url }
                }
            };
        }
        
        public static NotificationResponse Map(AccountBalanceLimitNotification contractLogEventNotification)
        {
            return new NotificationResponse
            {
                Id = contractLogEventNotification.Id,
                Type = NotificationType.ACCOUNT_BALANCE_LIMIT,
                Attributes = new Dictionary<string, string>()
                {
                    { "limit", contractLogEventNotification.Limit },
                    { "typeOfBalance", contractLogEventNotification.TypeOfBalance.ToString() }
                }
            };
        }
        
        public static NotificationResponse Map(TransactionHistoryReportNotification transactionHistoryReport)
        {
            return new NotificationResponse
            {
                Id = transactionHistoryReport.Id,
                Type = NotificationType.TRANSACTION_HISTORY_REPORT,
                Attributes = new Dictionary<string, string>()
                {
                    { "interval", transactionHistoryReport.Interval.ToString() }
                }
            };
        }
    }
}