using System;
using Tatum.CSharp.Harmony.Utils;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.Evm.Local.Models;
using Tatum.CSharp.Harmony.Clients;
using Tatum.CSharp.Harmony.Core.Model;
using Tatum.CSharp.Harmony.Tests.Integration.TestDataModels;
using Xunit;

namespace Tatum.CSharp.Harmony.Tests.Integration.Scenarios;

[Collection("Harmony")]
public class MintErc20AndTransfer
{
    /// <summary>
    /// This example shows how to mint NFT on Harmony (ONE).
    /// You can find all the relevant documentation one https://apidoc.tatum.io/tag/NFT-(ERC-721-or-compatible)#operation/NftMintErc721
    /// </summary>
    public async Task<OneTx> MintErc20AndTransfer_Harmony_Example()
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

        // THIS IS NOT PART OF THE ACTUAL FLOW - for testing purposes we replace private key from generated wallet with our own private key containing some ONE
        // --- IGNORE ---
        address = JsonSerializer.Deserialize<TestData>(Environment.GetEnvironmentVariable("TEST_DATA")!)?.HarmonyTestData.StorageAddress;
        privateKey = JsonSerializer.Deserialize<TestData>(Environment.GetEnvironmentVariable("TEST_DATA")!)?.HarmonyTestData.StoragePrivKey;
        // --- /IGNORE ---

        // Deploy custom ERC20 contract
        var deployErc20 = new ChainDeployErc20(
            "TOKEN_SYMBOL",
            "TokenName",
            "1000000000", // Maximal number of tokens that can exist at a time
            "1000000", // Number of tokens to mint initially
            18, // Number of decimals the token can be divided into
            address, // Address to mint the initial tokens to
            privateKey // Private key of the address paying gas fee for contract deployment
            );
        
        var deployTransactionHash = await harmonyClient.HarmonyFungibleTokens.Erc20DeployAsync(deployErc20);
        
        // Wait for transaction to be processed on the blockchain
        await harmonyClient.Utils.WaitForTransactionAsync(deployTransactionHash.TxId);
        
        // Get deployed contract address
        var deployTransaction = await harmonyClient.HarmonyBlockchain.OneGetTransactionAsync(deployTransactionHash.TxId);
        var contract = deployTransaction.ContractAddress;

        // Mint additional ERC20 tokens
        var chainMintErc20 = new ChainMintErc20(
            "1000000", // Number of tokens to mint
            address, // Address to mint the tokens to
            contract, // Address of the deployed ERC20 contract
            privateKey // Private key of the address paying gas fee for the minting
            );
        
        var mintTransactionHash = await harmonyClient.HarmonyFungibleTokens.Erc20MintAsync(chainMintErc20);
        
        // Wait for transaction to be processed on the blockchain
        await harmonyClient.Utils.WaitForTransactionAsync(mintTransactionHash.TxId);

        // Before transferring the tokens we need to approve the transfer
        var approveErc20 = new ApproveErc20(
            contract, // Address of the deployed ERC20 contract
            address, // The blockchain address to be allowed to transfer or burn the fungible tokens
            "2000", // Number of tokens to be approved
            privateKey // Private key of the contract owner address - it will be paying gas fee for the approval
            );

        var approveTransactionHash = await harmonyClient.HarmonyFungibleTokens.Erc20ApproveAsync(approveErc20);
        
        // Wait for transaction to be processed on the blockchain
        await harmonyClient.Utils.WaitForTransactionAsync(approveTransactionHash.TxId);
        
        // Generate another wallet and accompanying address on index 0
        var wallet2 = harmonyClient.Local.GenerateWallet();
        var address2 = harmonyClient.Local.GenerateAddress(wallet2.Xpub, 0).Address;
        
        // Transfer ERC20 tokens to another address
        var chainTransferEthErc20 = new ChainTransferEthErc20(
            address2, // Address to transfer the tokens to
            contract, // Address of the deployed ERC20 contract
            "1000", // Number of tokens to transfer
            18, // Number of decimals the token can be divided into defined in the contract
            privateKey // Private key of the address paying gas fee for the transfer
            );
        
        var transferTransactionHash = await harmonyClient.HarmonyFungibleTokens.Erc20TransferAsync(chainTransferEthErc20);
        
        // Wait for transaction to be processed on the blockchain
        await harmonyClient.Utils.WaitForTransactionAsync(transferTransactionHash.TxId);
        
        // Get transaction details
        var transaction = await harmonyClient.HarmonyBlockchain.OneGetTransactionAsync(transferTransactionHash.TxId);

        // Status = true means that transaction was processed correctly.
        Console.WriteLine(transaction.Status ? "Transaction successful" : "Transaction failed");

        // Check address to see if ERC20 is there
        var tokens = await harmonyClient.HarmonyFungibleTokens.Erc20GetBalanceAsync(address2, contract);
        var isTokenOnTheAddress = decimal.Parse(tokens.Balance) > 0;
        Console.WriteLine(isTokenOnTheAddress ? "ERC20 token found on the address :)" : "no such ERC20 token on the address :(");
        
        // Now burns some tokens
        var burnErc20 = new ChainBurnErc20(
            "1000", // Number of tokens to burn
            contract, // Address of the deployed ERC20 contract
            privateKey // Private key of the address paying gas fee for the burn (needs to be approved)
        );
        
        var burnTransactionHash = await harmonyClient.HarmonyFungibleTokens.Erc20BurnAsync(burnErc20);
        
        // Wait for transaction to be processed on the blockchain
        await harmonyClient.Utils.WaitForTransactionAsync(burnTransactionHash.TxId);
        
        return transaction;
    }
    
    [Fact] 
    public async Task Test_MintErc20AndTransfer_Harmony_Example() => 
        (await MintErc20AndTransfer_Harmony_Example()).Status
        .Should()
        .BeTrue();
}