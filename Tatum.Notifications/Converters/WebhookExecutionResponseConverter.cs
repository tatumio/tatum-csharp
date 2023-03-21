using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tatum.Notifications.Models;
using Tatum.Notifications.Models.NotificationExecutions;
using Tatum.Notifications.Models.Responses;

namespace Tatum.Notifications.Converters
{
    public class WebhookExecutionResponseConverter : JsonConverter<WebhookExecutionResponse>
    {
        public override WebhookExecutionResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var response = new WebhookExecutionResponse();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return response;
                }

                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }

                var propertyName = reader.GetString();
                reader.Read();

                switch (propertyName)
                {
                    case "type":
                        response.Type = JsonSerializer.Deserialize<NotificationType>(ref reader, options);
                        break;
                    case "id":
                        response.Id = JsonSerializer.Deserialize<string>(ref reader, options);
                        break;
                    case "subscriptionId":
                        response.SubscriptionId = JsonSerializer.Deserialize<string>(ref reader, options);
                        break;
                    case "url":
                        response.Url = JsonSerializer.Deserialize<string>(ref reader, options);
                        break;
                    case "data":
                        // Based on the value of the "Type" property, deserialize the appropriate implementation of IWebhookExecution
                        switch (response.Type)
                        {
                            case NotificationType.ADDRESS_EVENT:
                                response.Data = JsonSerializer.Deserialize<AddressEventExecution>(ref reader, options);
                                break;
                            case NotificationType.INCOMING_NATIVE_TX:
                                response.Data = JsonSerializer.Deserialize<WebhookDataAssetTx>(ref reader, options);
                                break;
                            case NotificationType.OUTGOING_NATIVE_TX:
                                response.Data = JsonSerializer.Deserialize<WebhookDataAssetTx>(ref reader, options);
                                break;
                            case NotificationType.OUTGOING_FAILED_TX:
                                response.Data = JsonSerializer.Deserialize<WebhookData>(ref reader, options);
                                break;
                            case NotificationType.PAID_FEE:
                                response.Data = JsonSerializer.Deserialize<WebhookDataAssetTx>(ref reader, options);
                                break;
                            case NotificationType.INCOMING_INTERNAL_TX:
                                response.Data = JsonSerializer.Deserialize<WebhookDataAssetTx>(ref reader, options);
                                break;
                            case NotificationType.OUTGOING_INTERNAL_TX:
                                response.Data = JsonSerializer.Deserialize<WebhookDataAssetTx>(ref reader, options);
                                break;
                            case NotificationType.INCOMING_FUNGIBLE_TX:
                                response.Data = JsonSerializer.Deserialize<WebhookDataFungibleTx>(ref reader, options);
                                break;
                            case NotificationType.OUTGOING_FUNGIBLE_TX:
                                response.Data = JsonSerializer.Deserialize<WebhookDataFungibleTx>(ref reader, options);
                                break;
                            case NotificationType.INCOMING_NFT_TX:
                                response.Data = JsonSerializer.Deserialize<WebhookDataNftMultitokenTx>(ref reader, options);
                                break;
                            case NotificationType.OUTGOING_NFT_TX:
                                response.Data = JsonSerializer.Deserialize<WebhookDataNftMultitokenTx>(ref reader, options);
                                break;
                            case NotificationType.INCOMING_MULTITOKEN_TX:
                                response.Data = JsonSerializer.Deserialize<WebhookDataNftMultitokenTx>(ref reader, options);
                                break;
                            case NotificationType.OUTGOING_MULTITOKEN_TX:
                                response.Data = JsonSerializer.Deserialize<WebhookDataNftMultitokenTx>(ref reader, options);
                                break;
                            case NotificationType.FAILED_TXS_PER_BLOCK:
                                response.Data = JsonSerializer.Deserialize<WebhookBlockData>(ref reader, options);
                                break;
                            default:
                                throw new JsonException($"Unknown notification type: {response.Type}");
                        }
                        break;
                    case "nextTime":
                        response.NextTime = JsonSerializer.Deserialize<long>(ref reader, options);
                        break;
                    case "timestamp":
                        response.Timestamp = JsonSerializer.Deserialize<long>(ref reader, options);
                        break;
                    case "retryCount":
                        response.RetryCount = JsonSerializer.Deserialize<int>(ref reader, options);
                        break;
                    case "failed":
                        response.Failed = JsonSerializer.Deserialize<bool>(ref reader, options);
                        break;
                    case "response":
                        response.Response = JsonSerializer.Deserialize<WebhookResponse>(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, WebhookExecutionResponse value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("type");
            JsonSerializer.Serialize(writer, value.Type, options);

            writer.WritePropertyName("id");
            JsonSerializer.Serialize(writer, value.Id, options);

            writer.WritePropertyName("subscriptionId");
            JsonSerializer.Serialize(writer, value.SubscriptionId, options);

            writer.WritePropertyName("url");
            JsonSerializer.Serialize(writer, value.Url, options);

            writer.WritePropertyName("data");
            JsonSerializer.Serialize(writer, value.Data, value.Type.GetType(), options);

            writer.WritePropertyName("nextTime");
            JsonSerializer.Serialize(writer, value.NextTime, options);

            writer.WritePropertyName("timestamp");
            JsonSerializer.Serialize(writer, value.Timestamp, options);

            writer.WritePropertyName("retryCount");
            JsonSerializer.Serialize(writer, value.RetryCount, options);

            writer.WritePropertyName("failed");
            JsonSerializer.Serialize(writer, value.Failed, options);

            writer.WritePropertyName("response");
            JsonSerializer.Serialize(writer, value.Response, options);

            writer.WriteEndObject();
        }
    }
}