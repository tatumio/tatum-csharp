using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tatum.Notifications.Models.NotificationExecutions;

namespace Tatum.Notifications.Converters
{
    public class WebhookExecutionChainConverter : JsonConverter<WebhookExecutionChain>
    {
        public override WebhookExecutionChain Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return value switch
            {
                "ethereum-sepolia" => WebhookExecutionChain.EthereumSepolia,
                "ethereum-sepolia-archive" => WebhookExecutionChain.EthereumSepoliaArchive,
                "ethereum-mainnet" => WebhookExecutionChain.EthereumMainnet,
                "ethereum-mainnet-archive" => WebhookExecutionChain.EthereumMainnetArchive,
                "ethereum-goerli" => WebhookExecutionChain.EthereumGoerli,
                "ethereum-goerli-archive" => WebhookExecutionChain.EthereumGoerliArchive,
                "polygon-mumbai" => WebhookExecutionChain.PolygonMumbai,
                "polygon-mainnet" => WebhookExecutionChain.PolygonMainnet,
                "klaytn-baobab" => WebhookExecutionChain.KlaytnBaobab,
                "klaytn-baobab-archive" => WebhookExecutionChain.KlaytnBaobabArchive,
                "klaytn-cypress" => WebhookExecutionChain.KlaytnCypress,
                "klaytn-cypress-archive" => WebhookExecutionChain.KlaytnCypressArchive,
                "solana-devnet" => WebhookExecutionChain.SolanaDevnet,
                "solana-devnet-archive" => WebhookExecutionChain.SolanaDevnetArchive,
                "solana-devnet-scanner" => WebhookExecutionChain.SolanaDevnetScanner,
                "solana-mainnet" => WebhookExecutionChain.SolanaMainnet,
                "solana-mainnet-archive" => WebhookExecutionChain.SolanaMainnetArchive,
                "solana-mainnet-scanner" => WebhookExecutionChain.SolanaMainnetScanner,
                "celo-mainnet" => WebhookExecutionChain.CeloMainnet,
                "celo-testnet" => WebhookExecutionChain.CeloTestnet,
                "bitcoin-mainnet" => WebhookExecutionChain.BitcoinMainnet,
                "bitcoin-testnet" => WebhookExecutionChain.BitcoinTestnet,
                "litecoin-core-mainnet" => WebhookExecutionChain.LitecoinCoreMainnet,
                "litecoin-core-testnet" => WebhookExecutionChain.LitecoinCoreTestnet,
                "tron-mainnet" => WebhookExecutionChain.TronMainnet,
                "tron-testnet" => WebhookExecutionChain.TronTestnet,
                "bsc-mainnet" => WebhookExecutionChain.BscMainnet,
                "bsc-mainnet-archive" => WebhookExecutionChain.BscMainnetArchive,
                "bsc-testnet" => WebhookExecutionChain.BscTestnet,
                "bch-mainnet" => WebhookExecutionChain.BchMainnet,
                "bch-testnet" => WebhookExecutionChain.BchTestnet,
                "doge-mainnet" => WebhookExecutionChain.DogeMainnet,
                "doge-testnet" => WebhookExecutionChain.DogeTestnet,
                _ => throw new ArgumentOutOfRangeException($"{value} is not a valid WebhookExecutionChain value"),
            };
        }

        public override void Write(Utf8JsonWriter writer, WebhookExecutionChain value, JsonSerializerOptions options)
        {
        }
    }
}