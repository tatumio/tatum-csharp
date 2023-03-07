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
                    case NotificationType.ADDRESS_EVENT:
                        notifications.Add(MapAddressTransaction(notification));
                        break;
                }
            }
            
            return notifications;
        }
        
        public static AddressEventNotification MapAddressTransaction(NotificationResponse notificationResponse)
        {
            notificationResponse.Attributes.TryGetValue("chain", out var chainString);
            Enum.TryParse(chainString, out AddressTransactionChain chain);
            
            notificationResponse.Attributes.TryGetValue("address", out var address);
            notificationResponse.Attributes.TryGetValue("url", out var url);

            
            return new AddressEventNotification
            {
                Id = notificationResponse.Id,
                Chain = chain,
                Address = address,
                Url = url
            };
        }
        
        public static NotificationResponse Map<T>(T notification) where T : Notification
        {
            switch (notification)
            { 
                case AddressEventNotification addressTransactionNotification:
                    return Map(addressTransactionNotification);
                default:
                    throw new ArgumentOutOfRangeException(nameof(notification), notification, null);
            }
        }

        public static NotificationResponse Map(AddressEventNotification addressEventNotification)
        {
            return new NotificationResponse
            {
                Id = addressEventNotification.Id,
                Type = NotificationType.ADDRESS_EVENT,
                Attributes = new Dictionary<string, string>()
                {
                    { "address", addressEventNotification.Address },
                    { "chain", addressEventNotification.Chain.ToString() },
                    { "url", addressEventNotification.Url }
                }
            };
        }
    }
}