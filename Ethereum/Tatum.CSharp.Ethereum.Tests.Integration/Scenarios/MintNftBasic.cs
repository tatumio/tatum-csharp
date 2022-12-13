using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.Ethereum.Clients;
using Tatum.CSharp.Ethereum.Core.Model;
using Tatum.CSharp.Ethereum.Utils;
using Xunit;

namespace Tatum.CSharp.Ethereum.Tests.Integration.Scenarios;

[Collection("Ethereum")]
public class MintNftBasic
{
    /// <summary>
    /// This example shows how to mint NFT on Ethereum (ETH).
    /// You can find all the relevant documentation one https://apidoc.tatum.io/tag/NFT-(ERC-721-or-compatible)#operation/NftMintErc721
    /// </summary>
    public async Task<EthTx> MintNft_Ethereum_Example()
    {
        var ethereumClient = new EthereumClient
            (
                new HttpClient(), 
                "75ea3138-d0a1-47df-932e-acb3ee807dab", // Use your API key from https://dashboard.tatum.io, this one is our public API Key for testing.
                isTestNet: true // If you use TestNet API key then argument isTestNet should be set to true
            );

        // Generate wallet and accompanying address on index 0
        var wallet = ethereumClient.Local.GenerateWallet();
        var address = ethereumClient.Local.GenerateAddress(wallet.Xpub, 0).Address;

        var yourNftUrl = "https://nft.url.com/";
        
        // We will be minting using NFT Express - this is only possible with paid plan on mainnet or on testnet with any plan.
        var mintRequest = new MintNftExpress
            (
                address, // The blockchain address to send the NFT to
                yourNftUrl // The URL pointing to the NFT
            );

        var transactionHash = await ethereumClient.EthereumNft.NftMintErc721Async(mintRequest);

        // Wait for transaction to be processed on the blockchain
        await ethereumClient.Utils.WaitForTransactionAsync(transactionHash.TxId);

        var transaction = await ethereumClient.EthereumNft.NftGetTransactErc721Async(transactionHash.TxId);

        // Status = true means that transaction was processed correctly.
        Console.WriteLine(transaction.Status ? "Transaction successful" : "Transaction failed");

        // Check address to see if Nft is there
        var tokens = await ethereumClient.EthereumNft.NftGetTokensByAddressErc721Async(address);
        var isTokenOnTheAddress = tokens.Any(token => token.Metadata.Any(x => x.Url == yourNftUrl));
        Console.WriteLine(isTokenOnTheAddress ? "NFT found on the address :)" : "no such NFT on the address :(");
        
        return transaction;
    }
    
    [Fact] 
    public async Task Test_MintNft_Ethereum_Example() => 
        (await MintNft_Ethereum_Example()).Status
        .Should()
        .BeTrue();
}