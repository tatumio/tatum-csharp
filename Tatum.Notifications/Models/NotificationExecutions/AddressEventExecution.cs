using System.Text.Json.Serialization;
using Tatum.Core.Models;
using Tatum.Notifications.Converters;

namespace Tatum.Notifications.Models.NotificationExecutions
{
    public class AddressEventExecution : IWebhookExecution
    {
        [JsonPropertyName("address")] 
        public string Address { get; set; }

        [JsonPropertyName("txId")] 
        public string TxId { get; set; }

        [JsonPropertyName("blockNumber")] 
        public long BlockNumber { get; set; }

        [JsonPropertyName("asset")] 
        public string Asset { get; set; }

        [JsonPropertyName("amount")] 
        public string Amount { get; set; }

        [JsonPropertyName("tokenId")] 
        public string TokenId { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AddressEventExecutionType Type { get; set; }

        [JsonPropertyName("mempool")] 
        public bool Mempool { get; set; }

        [JsonPropertyName("counterAddress")] 
        public string CounterAddress { get; set; }
    }
    
    public class WebhookData : IWebhookExecution {
        [JsonPropertyName("currency")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Currency Currency { get; set; }
        
        [JsonPropertyName("chain")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Chain Chain { get; set; }
        
        [JsonPropertyName("address")] 
        public string Address { get; set; }
        
        [JsonPropertyName("counterAddress")] 
        public string CounterAddress { get; set; }
        
        [JsonPropertyName("txId")] 
        public string TxId { get; set; }
        
        [JsonPropertyName("blockNumber")] 
        public long BlockNumber { get; set; }
        
        [JsonPropertyName("amount")] 
        public string Amount { get; set; }
    }
    
    public class WebhookBlockData : IWebhookExecution {
        [JsonPropertyName("chain")]
        [JsonConverter(typeof(WebhookExecutionChainConverter))]
        public WebhookExecutionChain Chain { get; set; }

        [JsonPropertyName("txId")] 
        public string TxId { get; set; }
        
        [JsonPropertyName("blockNumber")] 
        public long BlockNumber { get; set; }
    }

    public class WebhookDataAssetTx : WebhookData {
        [JsonPropertyName("mempool")] 
        public bool? Mempool { get; set; }
    }

    public class WebhookDataFungibleTx : WebhookData {
        [JsonPropertyName("contractAddress")] 
        public string ContractAddress { get; set; }
    }

    public class WebhookDataNftMultitokenTx : WebhookData {
        [JsonPropertyName("contractAddress")] 
        public string ContractAddress { get; set; }
        
        [JsonPropertyName("tokenId")] 
        public string TokenId { get; set; }
        
        [JsonPropertyName("metadataURI")] 
        public string MetadataUri { get; set; }
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

    public enum WebhookExecutionChain
    {
        EthereumSepolia,
        EthereumSepoliaArchive,
        EthereumMainnet,
        EthereumMainnetArchive,
        EthereumGoerli,
        EthereumGoerliArchive,
        PolygonMumbai,
        PolygonMainnet,
        KlaytnBaobab,
        KlaytnBaobabArchive,
        KlaytnCypress,
        KlaytnCypressArchive,
        SolanaDevnet,
        SolanaDevnetArchive,
        SolanaDevnetScanner,
        SolanaMainnet,
        SolanaMainnetArchive,
        SolanaMainnetScanner,
        CeloMainnet,
        CeloTestnet,
        BitcoinMainnet,
        BitcoinTestnet,
        LitecoinCoreMainnet,
        LitecoinCoreTestnet,
        TronMainnet,
        TronTestnet,
        BscMainnet,
        BscMainnetArchive,
        BscTestnet,
        BchMainnet,
        BchTestnet,
        DogeMainnet,
        DogeTestnet
    }
}