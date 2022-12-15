using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.Evm.Local.Models;
using Tatum.CSharp.Harmony.Clients;
using Tatum.CSharp.Harmony.Core.Model;
using Tatum.CSharp.Harmony.Utils;
using Tatum.CSharp.Harmony.Tests.Integration.TestDataModels;
using Xunit;

namespace Tatum.CSharp.Harmony.Tests.Integration.Scenarios;

[Collection("Harmony")]
public class MintNftNative
{
    /// <summary>
    /// This example shows how to mint NFT on Harmony (MATIC).
    /// You can find all the relevant documentation one https://apidoc.tatum.io/tag/NFT-(ERC-721-or-compatible)#operation/NftMintErc721
    /// </summary>
    public async Task<OneTx> MintNftNative_Harmony_Example()
    {
        var harmonyClient = new HarmonyClient
            (
                new HttpClient(), 
                "75ea3138-d0a1-47df-932e-acb3ee807dab", // Use your API key from https://dashboard.tatum.io, this one is our public API Key for testing.
                isTestNet: true // If you use TestNet API key then argument isTestNet should be set to true
            );

        // Generate wallet and accompanying address on index 0 with private key
        var wallet = harmonyClient.Local.GenerateWallet();
        var address = harmonyClient.Local.GenerateAddress(wallet.Xpub, 0).Address;
        var privateKey = harmonyClient.Local.GenerateAddressPrivateKey(new PrivKeyRequestLocal(0, wallet.Mnemonic)).Key;
        
        // THIS IS NOT PART OF THE ACTUAL FLOW - for testing purposes we replace private key from generated wallet with our own private key containing some MATIC
        // --- IGNORE ---
        privateKey = JsonSerializer.Deserialize<TestData>(Environment.GetEnvironmentVariable("TEST_DATA")!)?.HarmonyTestData.StoragePrivKey;
        // --- /IGNORE ---

        var deployRequest = new DeployNft
        (
            "NAME",
            "SYMBOL",
            privateKey // Private key of address paying fees - YOU NEED TO HAVE ONE ON THIS ADDRESS TO PAY FOR FEES
        );
        
        var deployTransactionHash = await harmonyClient.HarmonyNft.NftDeployErc721Async(deployRequest);
        
        // Wait for transaction to be processed on the blockchain
        await harmonyClient.Utils.WaitForTransactionAsync(deployTransactionHash.TxId);

        var deployTransaction = await harmonyClient.HarmonyBlockchain.OneGetTransactionAsync(deployTransactionHash.TxId);
        
        var yourNftUrl = "https://nft.url.com/";
        
        // We will be minting using Tatum NFT minter contract - you will pay for fees using your private key
        // (if testing on Test Net you can use https://faucet.pops.one/ faucet to get some ONE)
        var mintRequest = new MintNft
        (
            address, // Address to which NFT will be minted
            deployTransaction.ContractAddress, // Address of the minter contract
            "1", // Token ID
            yourNftUrl, // NFT URL
            privateKey  // Private key of address paying fees - YOU NEED TO HAVE ONE ON THIS ADDRESS TO PAY FOR FEES
        );

        var transactionHash = await harmonyClient.HarmonyNft.NftMintErc721Async(mintRequest);

        // Wait for transaction to be processed on the blockchain
        await harmonyClient.Utils.WaitForTransactionAsync(transactionHash.TxId);

        var transaction = await harmonyClient.HarmonyBlockchain.OneGetTransactionAsync(transactionHash.TxId);

        // Status = true means that transaction was processed correctly.
        Console.WriteLine(transaction.Status ? "Transaction successful" : "Transaction failed");

        // Check address to see if Nft is there
        var balance = await harmonyClient.HarmonyNft.NftGetBalanceErc721Async
        (
            address, 
            transaction.To // transaction.To contains the address of the NFT contract called
        );
        var isTokenOnTheAddress = balance.Data.Any();
        Console.WriteLine(isTokenOnTheAddress ? "NFT found on the address :)" : "no such NFT on the address :(");
        
        // Let's now burn the NFT
        var burnRequest = new BurnNft
        (
            "1", // Address to which NFT will be minted
            deployTransaction.ContractAddress, // Address of the minter contract
            privateKey // Private key of address paying fees - YOU NEED TO HAVE ONE ON THIS ADDRESS TO PAY FOR FEES
        );

        var burnTransactionHash = await harmonyClient.HarmonyNft.NftBurnErc721Async(burnRequest);

        // Wait for transaction to be processed on the blockchain
        await harmonyClient.Utils.WaitForTransactionAsync(burnTransactionHash.TxId);

        // Check address to see if Nft is no longer there
        balance = await harmonyClient.HarmonyNft.NftGetBalanceErc721Async
        (
            address, 
            transaction.To // transaction.To contains the address of the NFT contract called
        );
        isTokenOnTheAddress = balance.Data.Any();
        Console.WriteLine(isTokenOnTheAddress ? "NFT found on the address :)" : "no such NFT on the address :(");
        
        return transaction;
    }
    
    [Fact] 
    public async Task Test_MintNftNative_Harmony_Example() => 
        (await MintNftNative_Harmony_Example()).Status
        .Should()
        .BeTrue();
}