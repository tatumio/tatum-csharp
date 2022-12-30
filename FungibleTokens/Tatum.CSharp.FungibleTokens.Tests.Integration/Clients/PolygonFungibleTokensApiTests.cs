using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.FungibleTokens.Clients;
using Tatum.CSharp.FungibleTokens.Core.Client;
using Tatum.CSharp.FungibleTokens.Core.Model;
using Tatum.CSharp.FungibleTokens.Tests.Integration.TestDataModels;
using Tatum.CSharp.Polygon.Clients;
using VerifyTests;
using Xunit;

namespace Tatum.CSharp.FungibleTokens.Tests.Integration.Clients;

[Collection("Polygon")]
public class PolygonFungibleTokensApiTests
{
    private readonly IFungibleTokensClient _fungibleTokensApi;
    private readonly PolygonTestData _testData;
    private readonly PolygonClient _polygonApi;

    private const string TestSmartContractAddress = "0x87dcbd8e3eae528b50ddb1e94c85f16b30940a62";

    public PolygonFungibleTokensApiTests()
    {
        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        var secrets = Environment.GetEnvironmentVariable("TEST_DATA");

        _testData = JsonSerializer.Deserialize<TestData>(secrets!)?.PolygonTestData;

        _fungibleTokensApi = new FungibleTokensClient(new HttpClient(), apiKey, true);
        _polygonApi = new PolygonClient(new HttpClient(), apiKey, true);
    }
    
    [Fact]
    public async Task Erc20Deploy_ShouldReturnTxHash_WhenCalledValidData()
    {
        var name = Guid.NewGuid().ToString();

        var deployErc20 = new ChainDeployErc20(
            ChainDeployErc20.ChainEnum.MATIC,
            name.Substring(0,10),
            name.Replace("-", ""),
            "1000000000",
            "1000000",
            18,
            _testData.StorageAddress,
            _testData.StoragePrivKey);

        var deployTransactionHash = await _fungibleTokensApi.PolygonFungibleTokens.Erc20DeployAsync(deployErc20);
        
        deployTransactionHash.Should().NotBeNull();
        deployTransactionHash.TxId.Should().NotBeNullOrWhiteSpace();

        await WaitForTransactionSuccess(deployTransactionHash.TxId);
    }
    
    [Fact]
    public async Task Erc20Mint_ShouldReturnTxHash_WhenCalledValidData()
    {
        var chainMintErc20 = new ChainMintErc20(
            ChainMintErc20.ChainEnum.MATIC, 
            "1", 
            _testData.StorageAddress, 
            TestSmartContractAddress, 
            _testData.StoragePrivKey );
        
        var mintTransactionHash = await _fungibleTokensApi.PolygonFungibleTokens.Erc20MintAsync(chainMintErc20);
        
        mintTransactionHash.Should().NotBeNull();
        mintTransactionHash.TxId.Should().NotBeNullOrWhiteSpace();
        
        await WaitForTransactionSuccess(mintTransactionHash.TxId);
    }
    
    [Fact]
    public async Task Erc20Burn_ShouldReturnTxHash_WhenCalledValidData()
    {
        var chainBurnErc20 = new ChainBurnErc20(
            ChainBurnErc20.ChainEnum.MATIC,
            "1",
            TestSmartContractAddress,
            _testData.StoragePrivKey);
        
        var burnTransactionHash = await _fungibleTokensApi.PolygonFungibleTokens.Erc20BurnAsync(chainBurnErc20);
        
        burnTransactionHash.Should().NotBeNull();
        burnTransactionHash.TxId.Should().NotBeNullOrWhiteSpace();
        
        await WaitForTransactionSuccess(burnTransactionHash.TxId);
    }
    
    [Fact]
    public async Task Erc20Approve_ShouldReturnTxHash_WhenCalledValidData()
    {
        var approveErc20 = new ApproveErc20(
            ApproveErc20.ChainEnum.MATIC,
            TestSmartContractAddress,
            _testData.TargetAddress,
            "100",
            _testData.StoragePrivKey);
        
        var approveTransactionHash = await _fungibleTokensApi.PolygonFungibleTokens.Erc20ApproveAsync(approveErc20);
        
        approveTransactionHash.Should().NotBeNull();
        approveTransactionHash.TxId.Should().NotBeNullOrWhiteSpace();
        
        await WaitForTransactionSuccess(approveTransactionHash.TxId);
    }
    
    [Fact]
    public async Task Erc20Transfer_ShouldReturnTxHash_WhenCalledValidData()
    {
        var chainTransferEthErc20 = new ChainTransferEthErc20(
            ChainTransferEthErc20.ChainEnum.MATIC,
            _testData.TargetAddress,
            TestSmartContractAddress,
            "1",
            9,
            _testData.StoragePrivKey);
        
        var transferTransactionHash = await _fungibleTokensApi.PolygonFungibleTokens.Erc20TransferAsync(chainTransferEthErc20);
        
        transferTransactionHash.Should().NotBeNull();
        transferTransactionHash.TxId.Should().NotBeNullOrWhiteSpace();
        
        await WaitForTransactionSuccess(transferTransactionHash.TxId);
    }
    
    [Fact]
    public async Task Erc20GetBalanceAddress_ShouldReturnBalances_WhenCalledValidData()
    {
        var balancesForAddress = await _fungibleTokensApi.PolygonFungibleTokens.Erc20GetBalanceAddressAsync(_testData.StorageAddress);
        
        balancesForAddress.Should().HaveCountGreaterOrEqualTo(0);
        balancesForAddress.First().Amount.Should().NotBeNullOrWhiteSpace();
        balancesForAddress.First().ContractAddress.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async Task Erc20GetBalance_ShouldReturnBalances_WhenCalledValidData()
    {
        var balance = await _fungibleTokensApi.PolygonFungibleTokens.Erc20GetBalanceAsync(_testData.StorageAddress, TestSmartContractAddress);
        
        balance.Balance.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async Task Erc20GetTransactionByAddress_ShouldReturnBalances_WhenCalledValidData()
    {
        var transactions = await _fungibleTokensApi.PolygonFungibleTokens.Erc20GetTransactionByAddressAsync(_testData.StorageAddress, TestSmartContractAddress, 1);

        transactions.Should().HaveCountGreaterThan(0);
        transactions.First().Amount.Should().NotBeNullOrWhiteSpace();
        transactions.First().ContractAddress.Should().NotBeNullOrWhiteSpace();
        transactions.First().From.Should().NotBeNullOrWhiteSpace();
        transactions.First().To.Should().NotBeNullOrWhiteSpace();
        transactions.First().TxId.Should().NotBeNullOrWhiteSpace();
        transactions.First().BlockNumber.Should().BePositive();
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
    
                try
                {
                    var tx = await _polygonApi.PolygonBlockchain.PolygonGetTransactionAsync(hash,
                        cancellationToken: cts.Token);
                    if (tx.Status || tx.BlockNumber != null)
                    {
                        await Task.Delay(1000, cts.Token);
                        break;
                    }
                }
                catch (ApiException e)
                {
                    if (!e.Message.Contains(".tx.not.found"))
                        throw;
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
