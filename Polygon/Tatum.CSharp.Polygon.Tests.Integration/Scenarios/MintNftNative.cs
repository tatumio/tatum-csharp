using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.Evm.Local.Models;
using Tatum.CSharp.Polygon.Clients;
using Tatum.CSharp.Polygon.Core.Model;
using Tatum.CSharp.Polygon.Tests.Integration.TestDataModels;
using Xunit;

namespace Tatum.CSharp.Polygon.Tests.Integration.Scenarios;

[Collection("Polygon")]
public class MintNftNative
{
    /// <summary>
    /// This example shows how to mint NFT on Polygon (MATIC).
    /// You can find all the relevant documentation one https://apidoc.tatum.io/tag/NFT-(ERC-721-or-compatible)#operation/NftMintErc721
    /// </summary>
    public async Task<EthTx> MintNftNative_Polygon_Example()
    {
        var polygonClient = new PolygonClient
            (
                new HttpClient(), 
                "75ea3138-d0a1-47df-932e-acb3ee807dab", // Use your API key from https://dashboard.tatum.io, this one is our public API Key for testing.
                isTestNet: true // If you use TestNet API key then argument isTestNet should be set to true
            );

        // Generate wallet and accompanying address on index 0 with private key
        var wallet = polygonClient.Local.GenerateWallet();
        var address = polygonClient.Local.GenerateAddress(wallet.Xpub, 0).Address;
        var privateKey = polygonClient.Local.GenerateAddressPrivateKey(new PrivKeyRequestLocal(0, wallet.Mnemonic)).Key;
        
        // THIS IS NOT PART OF THE ACTUAL FLOW - for testing purposes we replace private key from generated wallet with our own private key containing some MATIC
        // --- IGNORE ---
        privateKey = JsonSerializer.Deserialize<TestData>(Environment.GetEnvironmentVariable("TEST_DATA")!)?.PolygonTestData.StoragePrivKey;
        // --- /IGNORE ---

        var yourNftUrl = "https://nft.url.com/";
        
        // We will be minting using Tatum NFT minter contract - you will pay for fees using your private key
        // (if testing on Test Net you can use https://faucet.polygon.technology/ faucet to get some MATIC)
        var mintRequest = new MintNft
            (
                address, // Address to which NFT will be minted
                "0x542b9ac4945a3836fd12ad98acbc76a0c8b743f5", // Address of Tatum NFT minter contract from https://apidoc.tatum.io/tag/NFT-(ERC-721-or-compatible)#operation/NftMintErc721
                "1", // Token ID
                yourNftUrl, // NFT URL
                privateKey // Private key of address on index 0 - YOU NEED TO HAVE MATIC ON THIS ADDRESS TO PAY FOR FEES
            );

        var transactionHash = await polygonClient.PolygonNft.NftMintErc721Async(mintRequest);

        // Wait for transaction to be processed on the blockchain
        await polygonClient.Utils.WaitForTransactionAsync(transactionHash.TxId);

        var transaction = await polygonClient.PolygonNft.NftGetTransactErc721Async(transactionHash.TxId);

        // Status = true means that transaction was processed correctly.
        Console.WriteLine(transaction.Status ? "Transaction successful" : "Transaction failed");

        // Check address to see if Nft is there
        var tokens = await polygonClient.PolygonNft.NftGetTokensByAddressErc721Async(address);
        var isTokenOnTheAddress = tokens.Any(token => token.Metadata.Any(x => x.Url == yourNftUrl));
        Console.WriteLine(isTokenOnTheAddress ? "NFT found on the address :)" : "no such NFT on the address :(");
        
        return transaction;
    }
    
    [Fact] 
    public async Task Test_MintNftNative_Polygon_Example() => 
        (await MintNftNative_Polygon_Example()).Status
        .Should()
        .BeTrue();
}