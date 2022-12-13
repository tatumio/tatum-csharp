using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.Evm.Local.Models;
using Tatum.CSharp.Ethereum.Clients;
using Tatum.CSharp.Ethereum.Core.Model;
using Tatum.CSharp.Ethereum.Tests.Integration.TestDataModels;
using Tatum.CSharp.Ethereum.Utils;
using Xunit;

namespace Tatum.CSharp.Ethereum.Tests.Integration.Scenarios;

[Collection("Ethereum")]
public class MintErc20AndTransfer
{
    /// <summary>
    /// This example shows how to mint NFT on Ethereum (ETH).
    /// You can find all the relevant documentation one https://apidoc.tatum.io/tag/NFT-(ERC-721-or-compatible)#operation/NftMintErc721
    /// </summary>
    public async Task<EthTx> MintErc20AndTransfer_Ethereum_Example()
    {
        var ethereumClient = new EthereumClient
            (
                new HttpClient(), 
                "75ea3138-d0a1-47df-932e-acb3ee807dab", // Use your API key from https://dashboard.tatum.io, this one is our public API Key for testing.
                isTestNet: true // If you use TestNet API key then argument isTestNet should be set to true
            );

        // Generate wallet and accompanying address on index 0 with private key
        var wallet = ethereumClient.Local.GenerateWallet();
        var address = ethereumClient.Local.GenerateAddress(wallet.Xpub, 0).Address;
        var privateKey = ethereumClient.Local.GenerateAddressPrivateKey(new PrivKeyRequestLocal(0, wallet.Mnemonic)).Key;

        // THIS IS NOT PART OF THE ACTUAL FLOW - for testing purposes we replace private key from generated wallet with our own private key containing some ETH
        // --- IGNORE ---
        address = JsonSerializer.Deserialize<TestData>(Environment.GetEnvironmentVariable("TEST_DATA")!)?.EthereumTestData.StorageAddress;
        privateKey = JsonSerializer.Deserialize<TestData>(Environment.GetEnvironmentVariable("TEST_DATA")!)?.EthereumTestData.StoragePrivKey;
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
        
        var deployTransactionHash = await ethereumClient.EthereumFungibleTokens.Erc20DeployAsync(deployErc20);
        
        // Wait for transaction to be processed on the blockchain
        await ethereumClient.Utils.WaitForTransactionAsync(deployTransactionHash.TxId);
        
        // Get deployed contract address
        var deployTransaction = await ethereumClient.EthereumBlockchain.EthGetTransactionAsync(deployTransactionHash.TxId);
        var contract = deployTransaction.ContractAddress;

        // Mint additional ERC20 tokens
        var chainMintErc20 = new ChainMintErc20(
            "1000000", // Number of tokens to mint
            address, // Address to mint the tokens to
            contract, // Address of the deployed ERC20 contract
            privateKey // Private key of the address paying gas fee for the minting
            );
        
        var mintTransactionHash = await ethereumClient.EthereumFungibleTokens.Erc20MintAsync(chainMintErc20);
        
        // Wait for transaction to be processed on the blockchain
        await ethereumClient.Utils.WaitForTransactionAsync(mintTransactionHash.TxId);

        // Before transferring the tokens we need to approve the transfer
        var approveErc20 = new ApproveErc20(
            contract, // Address of the deployed ERC20 contract
            address, // The blockchain address to be allowed to transfer or burn the fungible tokens
            "1000", // Number of tokens to be approved
            privateKey // Private key of the contract owner address - it will be paying gas fee for the approval
            );

        var approveTransactionHash = await ethereumClient.EthereumFungibleTokens.Erc20ApproveAsync(approveErc20);
        
        // Wait for transaction to be processed on the blockchain
        await ethereumClient.Utils.WaitForTransactionAsync(approveTransactionHash.TxId);
        
        // Generate another wallet and accompanying address on index 0
        var wallet2 = ethereumClient.Local.GenerateWallet();
        var address2 = ethereumClient.Local.GenerateAddress(wallet2.Xpub, 0).Address;
        
        // Transfer ERC20 tokens to another address
        var chainTransferEthErc20 = new ChainTransferEthErc20(
            address2, // Address to transfer the tokens to
            contract, // Address of the deployed ERC20 contract
            "1000", // Number of tokens to transfer
            18, // Number of decimals the token can be divided into defined in the contract
            privateKey // Private key of the address paying gas fee for the transfer
            );
        
        var transferTransactionHash = await ethereumClient.EthereumFungibleTokens.Erc20TransferAsync(chainTransferEthErc20);
        
        // Wait for transaction to be processed on the blockchain
        await ethereumClient.Utils.WaitForTransactionAsync(transferTransactionHash.TxId);
        
        // Get transaction details
        var transaction = await ethereumClient.EthereumBlockchain.EthGetTransactionAsync(transferTransactionHash.TxId);

        // Status = true means that transaction was processed correctly.
        Console.WriteLine(transaction.Status ? "Transaction successful" : "Transaction failed");

        // Check address to see if ERC20 is there
        var tokens = await ethereumClient.EthereumFungibleTokens.Erc20GetBalanceAsync(address2, contract);
        var isTokenOnTheAddress = decimal.Parse(tokens.Balance) > 0;
        Console.WriteLine(isTokenOnTheAddress ? "ERC20 token found on the address :)" : "no such ERC20 token on the address :(");
        
        return transaction;
    }
    
    [Fact] 
    public async Task Test_MintErc20AndTransfer_Ethereum_Example() => 
        (await MintErc20AndTransfer_Ethereum_Example()).Status
        .Should()
        .BeTrue();
}