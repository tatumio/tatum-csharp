using System.Text.Json.Serialization;

namespace Tatum.Notifications.Models.NotificationExecutions
{
    public class AddressEventExecution : IWebhookExecution
    {
        [JsonPropertyName("address")] public string Address { get; set; }

        [JsonPropertyName("txId")] public string TxId { get; set; }

        [JsonPropertyName("blockNumber")] public long BlockNumber { get; set; }

        [JsonPropertyName("asset")] public string Asset { get; set; }

        [JsonPropertyName("amount")] public string Amount { get; set; }

        [JsonPropertyName("tokenId")] public string TokenId { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AddressEventExecutionType Type { get; set; }

        [JsonPropertyName("mempool")] public bool Mempool { get; set; }

        [JsonPropertyName("counterAddress")] public string CounterAddress { get; set; }
        
    }

    public enum AddressEventExecutionType
    {
        native = 1,
        token,
        erc721,
        erc1155,
        @internal,
        fee,
        trc10,
        trc20
    }
}