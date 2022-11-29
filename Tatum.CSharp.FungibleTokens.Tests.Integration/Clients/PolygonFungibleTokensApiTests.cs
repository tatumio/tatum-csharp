using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.Core.Client;
using Tatum.CSharp.Core.Model;
using Tatum.CSharp.FungibleTokens.Clients;
using Tatum.CSharp.FungibleTokens.Tests.Integration.TestDataModels;
using VerifyTests;
using VerifyXunit;
using Xunit;

namespace Tatum.CSharp.FungibleTokens.Tests.Integration.Clients;

[UsesVerify]
[Collection("Ethereum")]
public class PolygonFungibleTokensApiTests
{
    private readonly IFungibleTokensClient _fungibleTokensApi;
    private readonly PolygonTestData _testData;
    
    private const string TestSmartContractAddress = "0x87dcbd8e3eae528b50ddb1e94c85f16b30940a62";

    public PolygonFungibleTokensApiTests()
    {
        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        var secrets = Environment.GetEnvironmentVariable("TEST_DATA");

        _testData = JsonSerializer.Deserialize<TestData>(secrets!)?.PolygonTestData;
        
        VerifierSettings.IgnoreMember<ApiResponse<GeneratedAddressEth>>(x => x.Headers);

        _fungibleTokensApi = new FungibleTokensClient(new HttpClient(), apiKey, true);
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
    }
    
    [Fact]
    public async Task Erc20Approve_ShouldReturnTxHash_WhenCalledValidData()
    {
        var approveErc20 = new ApproveErc20(
            ApproveErc20.ChainEnum.MATIC,
            "100",
            _testData.TargetAddress,
            TestSmartContractAddress,
            _testData.StoragePrivKey);
        
        var approveTransactionHash = await _fungibleTokensApi.PolygonFungibleTokens.Erc20ApproveAsync(approveErc20);
        
        approveTransactionHash.Should().NotBeNull();
        approveTransactionHash.TxId.Should().NotBeNullOrWhiteSpace();
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

        await Verifier.Verify(transactions);
    }
}
