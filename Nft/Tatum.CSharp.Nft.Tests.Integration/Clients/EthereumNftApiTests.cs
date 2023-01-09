using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.Nft.Clients;
using Tatum.CSharp.Nft.Core.Client;
using Tatum.CSharp.Nft.Core.Model;
using Tatum.CSharp.Nft.Tests.Integration.TestDataModels;
using Tatum.CSharp.Utils.DebugMode;
using VerifyTests;
using VerifyXunit;
using Xunit;

namespace Tatum.CSharp.Nft.Tests.Integration.Clients;

[UsesVerify]
[Collection("Ethereum")]
public class EthereumNftApiTests
{
    private readonly INftClient _nftApi;
    private readonly EthereumTestData _testData;

    private const string EthereumTestnetMinterAddress = "0x53e8577C4347C365E4e0DA5B57A589cB6f2AB848";
    private const string TestSmartContractAddress = "0xf04bc01d562ad9f750db0235a4ac396551a7f846";

    public EthereumNftApiTests()
    {
        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        var secrets = Environment.GetEnvironmentVariable("TEST_DATA");

        _testData = JsonSerializer.Deserialize<TestData>(secrets!)?.EthereumTestData;

        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();
        
        _nftApi = new NftClient(new HttpClient(httpClient), apiKey, true);
    }

    [Fact]
    public async Task NftDeployErc721_ShouldReturnTxHash_WhenCalledValidData()
    {
        var name = Guid.NewGuid().ToString();
        var deployNft = new DeployNft(
            DeployNft.ChainEnum.ETH, 
            Guid.NewGuid().ToString(), 
            name.Substring(0,10), 
            _testData.StoragePrivKey);

        var deployTransactionHash = await _nftApi.EthereumNft.NftDeployErc721Async(deployNft);
        
        deployTransactionHash.Should().NotBeNull();
        deployTransactionHash.TxId.Should().NotBeNullOrWhiteSpace();
        
        await WaitForTransactionSuccess(deployTransactionHash.TxId);
    }
    
    [Fact]
    public async Task NftAddMinter_ShouldReturnTxHash_WhenCalledValidData()
    {
        var addNftMinter = new AddNftMinter(
            AddNftMinter.ChainEnum.ETH, 
            TestSmartContractAddress, 
            EthereumTestnetMinterAddress, 
            _testData.StoragePrivKey);
        
        var addNftMinterTransactionHash = await _nftApi.EthereumNft.NftAddMinterAsync(addNftMinter); 
        
        addNftMinterTransactionHash.Should().NotBeNull();
        addNftMinterTransactionHash.TxId.Should().NotBeNullOrWhiteSpace();

        await WaitForTransactionSuccess(addNftMinterTransactionHash.TxId);
    }
    
    [Fact]
    public async Task NftMintTransferBurnFlow_ShouldReturnConfirmedTransactions_WhenCalledValidData()
    {
        var nextTokenId = await GetNextTokenId();

        var tokens = new[]
        {
            nextTokenId.ToString(),
            (nextTokenId + 1).ToString(),
            (nextTokenId + 2).ToString()
        };
        
        var mintNftMinter = new MintNftMinter(
            MintNftMinter.ChainEnum.ETH, 
            TestSmartContractAddress, 
            EthereumTestnetMinterAddress, 
            _testData.StorageAddress, 
            tokens[0], 
            "https://www.something.com");
        
        var mintTransactionHash = await _nftApi.EthereumNft.NftMintErc721Async(mintNftMinter);

        await WaitForTransactionSuccess(mintTransactionHash.TxId);
        
        var transferNft = new TransferNft(
            null, 
            TransferNft.ChainEnum.ETH, 
            _testData.TargetAddress, 
            tokens[0], 
            TestSmartContractAddress, 
            false, 
            null, 
            null, 
            _testData.StoragePrivKey);
        
        var transferTransactionHash = await _nftApi.EthereumNft.NftTransferErc721Async(transferNft);
        
        transferTransactionHash.Should().NotBeNull();
        transferTransactionHash.TxId.Should().NotBeNullOrWhiteSpace();
        
        await WaitForTransactionSuccess(transferTransactionHash.TxId);
        
        var mintMultipleNft = new MintMultipleNftMinter(
            MintMultipleNftMinter.ChainEnum.ETH, 
            new List<string>{_testData.StorageAddress, _testData.StorageAddress}, 
            new List<string>{tokens[1], tokens[2]}, 
            EthereumTestnetMinterAddress,
            new List<string>{"https://www.something2.com", "https://www.something3.com"},
            TestSmartContractAddress);
        
        var mintMultipleNftTransactionHash = await _nftApi.EthereumNft.NftMintMultipleErc721Async(mintMultipleNft);
        
        mintMultipleNftTransactionHash.Should().NotBeNull();
        mintMultipleNftTransactionHash.TxId.Should().NotBeNullOrWhiteSpace();
        
        await WaitForTransactionSuccess(mintMultipleNftTransactionHash.TxId);
        
        var burnNft = new BurnNft(
            BurnNft.ChainEnum.ETH, 
            tokens[1], 
            TestSmartContractAddress, 
            _testData.StoragePrivKey);
        
        var burnTransactionHash = await _nftApi.EthereumNft.NftBurnErc721Async(burnNft);
        
        burnTransactionHash.Should().NotBeNull();
        burnTransactionHash.TxId.Should().NotBeNullOrWhiteSpace();
        
        await WaitForTransactionSuccess(burnTransactionHash.TxId);
    }

    private async Task<int> GetNextTokenId()
    {
        var mintedSoFar = await _nftApi.EthereumNft.NftGetTokensByCollectionErc721Async(50, TestSmartContractAddress);

        var offset = 0;

        while (mintedSoFar.Count == 50)
        {
            offset += 50;
            mintedSoFar = await _nftApi.EthereumNft.NftGetTokensByCollectionErc721Async(50, TestSmartContractAddress, offset);
        }
        

        var nextTokenId = mintedSoFar.Select(x => int.Parse(x.TokenId)).Max() + 1;
        return nextTokenId;
    }

    [Fact]
    public async Task NftGetBalanceErc721_ShouldReturnTokenIds_WhenCalledValidData()
    {
        var availableNftStorage = await _nftApi.EthereumNft.NftGetBalanceErc721Async(_testData.StorageAddress, TestSmartContractAddress);

        availableNftStorage.Data.Should().HaveCountGreaterThan(0);
    }
    
    [Fact]
    public async Task NftGetTokensByAddressErc721Async_ShouldReturnTokensData_WhenCalledValidData()
    {
        var availableNftStorage = await _nftApi.EthereumNft.NftGetTokensByAddressErc721Async(_testData.StorageAddress);

        availableNftStorage.Should().HaveCountGreaterThan(0);
    }

    [Fact]
    public async Task NftGetTransactionByAddress_ShouldReturnNftTransactions_WhenCalledValidData()
    {
        var nftTransactions = await _nftApi.EthereumNft.NftGetTransactionByAddressAsync(_testData.StorageAddress, TestSmartContractAddress, 50);

        nftTransactions.Should().HaveCountGreaterThan(0);
    }
    
    [Fact]
    public async Task NftGetTransactionByToken_ShouldReturnNftTransactions_WhenCalledValidData()
    {
        var nftTransactions = await _nftApi.EthereumNft.NftGetTransactionByTokenAsync("1", TestSmartContractAddress, 50);

        nftTransactions.Should().HaveCountGreaterThan(0);
    }
    
    [Fact]
    public async Task NftGetTransactErc721_ShouldReturnTx_WhenCalledValidData()
    {
        var ethTx = await _nftApi.EthereumNft.NftGetTransactErc721Async("0x3434cfbb3325de0550cdefa8f2cba1bb3c09a17c3fe39aa62d81aaefdab156f2");

        await Verifier.Verify(ethTx);
    }
    
    [Fact]
    public async Task NftGetMetadataErc721_ShouldReturnMetadata_WhenCalledValidData()
    {
        var nftMetadata = await _nftApi.EthereumNft.NftGetMetadataErc721Async(TestSmartContractAddress, "5");

        await Verifier.Verify(nftMetadata);
    }

    [Fact]
    public async Task NftGetRoyaltyErc721_ShouldReturnRoyalties_WhenCalledValidData()
    {
        var nftMetadata = await _nftApi.EthereumNft.NftGetRoyaltyErc721Async("0xeB0AD2f01197029C8BFB5bcfb70d025C408ff923", "5");

        await Verifier.Verify(nftMetadata);
    }
    
    [Fact]
    public async Task NftGetProvenanceDataErc721_ShouldReturnProvenances_WhenCalledValidData()
    {
        var nftMetadata = await _nftApi.EthereumNft.NftGetProvenanceDataErc721Async("0xeB0AD2f01197029C8BFB5bcfb70d025C408ff923", "5");

        await Verifier.Verify(nftMetadata);
    }
    
    [Fact]
    public async Task NftUpdateCashbackErc721_ShouldReturnTxHash_WhenCalledValidData()
    {
        var updateCashback = new UpdateCashbackValueForAuthorNft(
            UpdateCashbackValueForAuthorNft.ChainEnum.ETH, 
            "666", 
            "0xeB0AD2f01197029C8BFB5bcfb70d025C408ff923", 
            "0.1", 
            _testData.StoragePrivKey);
        
        var transferTransactionHash = await _nftApi.EthereumNft.NftUpdateCashbackErc721Async(updateCashback);
        
        transferTransactionHash.Should().NotBeNull();
        transferTransactionHash.TxId.Should().NotBeNullOrWhiteSpace();
        
        await WaitForTransactionSuccess(transferTransactionHash.TxId);
    }

    private async Task WaitForTransactionSuccess(string hash)
    {
        var cts = new CancellationTokenSource(TimeSpan.FromMinutes(5));
        try
        {
            while (true)
            {
                if (cts.IsCancellationRequested)
                {
                    break;
                }

                var tx = await _nftApi.EthereumNft.NftGetTransactErc721Async(hash, cancellationToken: cts.Token);
                if (tx.Status)
                {
                    await Task.Delay(1000, cts.Token);
                    break;
                }

                await Task.Delay(1000, cts.Token);
            }
        }
        catch (TaskCanceledException)
        {
            // we don't care
        }
    }
}
