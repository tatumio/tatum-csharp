using System;
using System.Collections.Generic;
using Tatum.Notifications.Models;
using Tatum.Notifications.Models.Notifications;
using Tatum.Notifications.Models.Notifications.SupportedChains;
using Tatum.Notifications.Models.Responses;

namespace Tatum.Notifications.Mappers
{
    internal static class NotificationMapper
    {
        public static List<INotification> Map(List<NotificationResponse> notificationList)
        {
            var notifications = new List<INotification>();

            foreach (var notification in notificationList)
            {
                switch (notification.Type)
                {
                    case NotificationType.ADDRESS_EVENT:
                        notifications.Add(MapAddressBasedTransaction<AddressEventChain>(notification));
                        break;
                    case NotificationType.INCOMING_NATIVE_TX:
                        notifications.Add(MapAddressBasedTransaction<IncomingNativeTxChain>(notification));
                        break;
                    case NotificationType.OUTGOING_NATIVE_TX:
                        notifications.Add(MapAddressBasedTransaction<OutgoingNativeTxChain>(notification));
                        break;
                    case NotificationType.OUTGOING_FAILED_TX:
                        notifications.Add(MapAddressBasedTransaction<OutgoingFailedTxChain>(notification));
                        break;
                    case NotificationType.PAID_FEE:
                        notifications.Add(MapAddressBasedTransaction<PaidFeeChain>(notification));
                        break;
                    case NotificationType.INCOMING_INTERNAL_TX:
                        notifications.Add(MapAddressBasedTransaction<IncomingInternalTxChain>(notification));
                        break;
                    case NotificationType.OUTGOING_INTERNAL_TX:
                        notifications.Add(MapAddressBasedTransaction<OutgoingInternalTxChain>(notification));
                        break;
                    case NotificationType.INCOMING_FUNGIBLE_TX:
                        notifications.Add(MapAddressBasedTransaction<IncomingFungibleTxChain>(notification));
                        break;
                    case NotificationType.OUTGOING_FUNGIBLE_TX:
                        notifications.Add(MapAddressBasedTransaction<OutgoingFungibleTxChain>(notification));
                        break;
                    case NotificationType.INCOMING_NFT_TX:
                        notifications.Add(MapAddressBasedTransaction<IncomingNftTxChain>(notification));
                        break;
                    case NotificationType.OUTGOING_NFT_TX:
                        notifications.Add(MapAddressBasedTransaction<OutgoingNftTxChain>(notification));
                        break;
                    case NotificationType.INCOMING_MULTITOKEN_TX:
                        notifications.Add(MapAddressBasedTransaction<IncomingMultitokenTxChain>(notification));
                        break;
                    case NotificationType.OUTGOING_MULTITOKEN_TX:
                        notifications.Add(MapAddressBasedTransaction<OutgoingMultitokenTxChain>(notification));
                        break;
                    case NotificationType.FAILED_TXS_PER_BLOCK:
                        notifications.Add(MapBlockBasedTransaction<FailedTxPerBlockChain>(notification));
                        break;
                }
            }
            
            return notifications;
        }
        
        public static NotificationResponse Map<TChainEnum>(AddressBasedNotification<TChainEnum> addressBasedNotification)
        {
            var type = GetNotificationTypeFromChainEnum(addressBasedNotification.Chain);
            
            return new NotificationResponse
            {
                Id = addressBasedNotification.Id,
                Type = type,
                Attributes = new Dictionary<string, string>()
                {
                    { "address", addressBasedNotification.Address },
                    { "chain", addressBasedNotification.Chain.ToString() },
                    { "url", addressBasedNotification.Url }
                }
            };
        }
        
        public static NotificationResponse Map<TChainEnum>(BlockBasedNotification<TChainEnum> addressBasedNotification)
        {
            var type = GetNotificationTypeFromChainEnum(addressBasedNotification.Chain);
            
            return new NotificationResponse
            {
                Id = addressBasedNotification.Id,
                Type = type,
                Attributes = new Dictionary<string, string>()
                {
                    { "chain", addressBasedNotification.Chain.ToString() },
                    { "url", addressBasedNotification.Url }
                }
            };
        }

        
        public static AddressBasedNotification<TChainEnum> MapAddressBasedTransaction<TChainEnum>(NotificationResponse notificationResponse) where TChainEnum : struct
        {
            notificationResponse.Attributes.TryGetValue("chain", out var chainString);
            Enum.TryParse(chainString, out TChainEnum chain);
            
            notificationResponse.Attributes.TryGetValue("address", out var address);
            notificationResponse.Attributes.TryGetValue("url", out var url);

            return new AddressBasedNotification<TChainEnum>
            {
                Id = notificationResponse.Id,
                Chain = chain,
                Address = address,
                Url = url,
                Type = notificationResponse.Type
            };
        }
        
        public static BlockBasedNotification<TChainEnum> MapBlockBasedTransaction<TChainEnum>(NotificationResponse notificationResponse) where TChainEnum : struct
        {
            notificationResponse.Attributes.TryGetValue("chain", out var chainString);
            Enum.TryParse(chainString, out TChainEnum chain);
            
            notificationResponse.Attributes.TryGetValue("url", out var url);

            return new BlockBasedNotification<TChainEnum>
            {
                Id = notificationResponse.Id,
                Chain = chain,
                Url = url,
                Type = notificationResponse.Type
            };
        }

        
        public static NotificationType GetNotificationTypeFromChainEnum<TChainEnum>(TChainEnum chain)
        {
            switch (chain)
            {
                case AddressEventChain _:
                    return NotificationType.ADDRESS_EVENT;
                case FailedTxPerBlockChain _:
                    return NotificationType.FAILED_TXS_PER_BLOCK;
                case IncomingNativeTxChain _:
                    return NotificationType.INCOMING_NATIVE_TX;
                case OutgoingNativeTxChain _:
                    return NotificationType.OUTGOING_NATIVE_TX;
                case OutgoingFailedTxChain _:
                    return NotificationType.OUTGOING_FAILED_TX;
                case PaidFeeChain _:
                    return NotificationType.PAID_FEE;
                case IncomingInternalTxChain _:
                    return NotificationType.INCOMING_INTERNAL_TX;
                case OutgoingInternalTxChain _:
                    return NotificationType.OUTGOING_INTERNAL_TX;
                case IncomingFungibleTxChain _:
                    return NotificationType.INCOMING_FUNGIBLE_TX;
                case OutgoingFungibleTxChain _:
                    return NotificationType.OUTGOING_FUNGIBLE_TX;
                case IncomingNftTxChain _:
                    return NotificationType.INCOMING_NFT_TX;
                case OutgoingNftTxChain _:
                    return NotificationType.OUTGOING_NFT_TX;
                case IncomingMultitokenTxChain _:
                    return NotificationType.INCOMING_MULTITOKEN_TX;
                case OutgoingMultitokenTxChain _:
                    return NotificationType.OUTGOING_MULTITOKEN_TX;
                default:
                    throw new ArgumentOutOfRangeException(nameof(chain), "Unknown chain enum");
            }
        }
    }
}