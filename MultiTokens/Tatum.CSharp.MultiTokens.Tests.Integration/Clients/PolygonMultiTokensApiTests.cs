using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.MultiTokens.Clients;
using Tatum.CSharp.Utils;
using Tatum.CSharp.MultiTokens.Core.Model;
using Tatum.CSharp.MultiTokens.Tests.Integration.TestDataModels;
using Tatum.CSharp.Polygon.Clients;
using VerifyXunit;
using Xunit;

namespace Tatum.CSharp.MultiTokens.Tests.Integration.Clients;

[Collection("Polygon")]
[UsesVerify]
public class PolygonMultiTokensApiTests
{
    private readonly IMultiTokensClient _multiTokensApi;
    private readonly PolygonTestData _testData;
    private readonly PolygonClient _polygonApi;

    private const string TestSmartContractAddress = "0x4eA4187B91175343E71b2dd79EA5A4Ab2384612e";

    public PolygonMultiTokensApiTests()
    {
        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        var secrets = Environment.GetEnvironmentVariable("TEST_DATA");

        _testData = JsonSerializer.Deserialize<TestData>(secrets!)?.PolygonTestData;

        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();
        
        _multiTokensApi = new MultiTokensClient(new HttpClient(httpClient), apiKey, true);
        _polygonApi = new PolygonClient(new HttpClient(), apiKey, true);
    }
    
    [Fact(Skip = "Requires manual setup")]
    public async Task DeployMultiToken_ShouldReturnTxHash_WhenCalledValidData()
    {
        var deployMultiToken = new DeployMultiToken(
            DeployMultiToken.ChainEnum.MATIC, 
            "https://www.multitoken.com", 
            _testData.StoragePrivKey);
        
        var deployTransactionHash = await _multiTokensApi.PolygonMultiTokens.DeployMultiTokenAsync(deployMultiToken);
        
        deployTransactionHash.Should().NotBeNull();
        deployTransactionHash.TxId.Should().NotBeNullOrWhiteSpace();

        await _polygonApi.Utils.WaitForTransactionAsync(deployTransactionHash.TxId);
    }
    
    [Fact]
    public async Task MintMultiToken_ShouldReturnTxHash_WhenCalledValidData()
    {
        var mintMultiToken = new MintMultiToken(MintMultiToken.ChainEnum.MATIC,
            "10",
            _testData.StorageAddress,
            TestSmartContractAddress,
            "10",
            null,
            _testData.StoragePrivKey);
        
        var mintMultiTokenTransactionHash = await _multiTokensApi.PolygonMultiTokens.MintMultiTokenAsync(mintMultiToken);
        
        mintMultiTokenTransactionHash.Should().NotBeNull();
        mintMultiTokenTransactionHash.TxId.Should().NotBeNullOrWhiteSpace();

        await _polygonApi.Utils.WaitForTransactionAsync(mintMultiTokenTransactionHash.TxId);
    }
    
    [Fact]
    public async Task BurnMultiToken_ShouldReturnTxHash_WhenCalledValidData()
    {
        var burnMultiToken = new BurnMultiToken(BurnMultiToken.ChainEnum.MATIC,
            _testData.StorageAddress,
            "10",
            TestSmartContractAddress,
            _testData.StoragePrivKey,
            null,
            "1");
        
        var burnMultiTokenTransactionHash = await _multiTokensApi.PolygonMultiTokens.BurnMultiTokenAsync(burnMultiToken);
        
        burnMultiTokenTransactionHash.Should().NotBeNull();
        burnMultiTokenTransactionHash.TxId.Should().NotBeNullOrWhiteSpace();

        await _polygonApi.Utils.WaitForTransactionAsync(burnMultiTokenTransactionHash.TxId);
    }
    
    [Fact]
    public async Task TransferMultiToken_ShouldReturnTxHash_WhenCalledValidData()
    {
        var transferMultiToken = new TransferMultiToken(TransferMultiToken.ChainEnum.MATIC,
            _testData.TargetAddress,
            "10",
            "1",
            null,
            TestSmartContractAddress,
            _testData.StoragePrivKey);
        
        var transferMultiTokenTransactionHash = await _multiTokensApi.PolygonMultiTokens.TransferMultiTokenAsync(transferMultiToken);
        
        transferMultiTokenTransactionHash.Should().NotBeNull();
        transferMultiTokenTransactionHash.TxId.Should().NotBeNullOrWhiteSpace();

        await _polygonApi.Utils.WaitForTransactionAsync(transferMultiTokenTransactionHash.TxId);
    }
    
    [Fact]
    public async Task MultiTokenGetTransactionByAddress_ShouldReturnTxHash_WhenCalledValidData()
    {
        var transactionByAddress = await _multiTokensApi.PolygonMultiTokens.MultiTokenGetTransactionByAddressAsync(_testData.TargetAddress, TestSmartContractAddress, 10);

        transactionByAddress.Should().NotBeNull();
        transactionByAddress.Should().NotBeEmpty();
        transactionByAddress.Should().AllBeOfType<MultiTx>();
    }
    
    [Fact]
    public async Task MultiTokenGetTransaction_ShouldReturnTxHash_WhenCalledValidData()
    {
        var transactionByAddress = await _multiTokensApi.PolygonMultiTokens.MultiTokenGetTransactionAsync("0xa1433783a321232cea9ad30e1180eeee00490ce68e96568e954dde5d3d44007e");

        await Verifier.Verify(transactionByAddress);
    }
    
    [Fact]
    public async Task MultiTokenGetAddressBalance_ShouldReturnTxHash_WhenCalledValidData()
    {
        var tokenBalances = await _multiTokensApi.PolygonMultiTokens.MultiTokenGetAddressBalanceAsync(_testData.StorageAddress);

        tokenBalances.Should().NotBeNull();
        tokenBalances.Should().NotBeEmpty();
        tokenBalances.First().Balances.Should().NotBeEmpty();
        tokenBalances.First().Balances.First().Should().BeOfType<MultiTokenBalance>();
        tokenBalances.First().Balances.First().Amount.Should().NotBeNullOrWhiteSpace();
        tokenBalances.First().Balances.First().TokenId.Should().NotBeNullOrWhiteSpace();
        tokenBalances.First().ContractAddress.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async Task MultiTokenGetBalance_ShouldReturnTxHash_WhenCalledValidData()
    {
        var tokenBalance = await _multiTokensApi.PolygonMultiTokens.MultiTokenGetBalanceAsync(_testData.TargetAddress, TestSmartContractAddress, "10");

        tokenBalance.Should().NotBeNull();
        tokenBalance.Data.Should().MatchRegex("^[0-9]*$");
    }
    
    [Fact]
    public async Task MultiTokenGetBalanceBatch_ShouldReturnTxHash_WhenCalledValidData()
    {
        var tokenBalance = await _multiTokensApi.PolygonMultiTokens.MultiTokenGetBalanceBatchAsync(TestSmartContractAddress, "10,10", string.Join(",", _testData.StorageAddress, _testData.TargetAddress));

        tokenBalance.Should().NotBeNull();
        tokenBalance.Data.Should().HaveCount(2);
    }
    
    [Fact]
    public async Task MultiTokenGetMetadata_ShouldReturnTxHash_WhenCalledValidData()
    {
        var tokenMetadata = await _multiTokensApi.PolygonMultiTokens.MultiTokenGetMetadataAsync("10", TestSmartContractAddress);

        tokenMetadata.Data.Should().Be("example.com");
    }
    
}
