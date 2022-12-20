using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.BlockchainFees.Clients;
using Tatum.CSharp.BlockchainFees.Core.Model;
using Xunit;

namespace Tatum.CSharp.BlockchainFees.Tests.Integration.Clients;

[Collection("Ethereum")]
public class PolygonBlockchainFeesApiTests
{
    private readonly IBlockchainFeesClient _blockchainFeesApi;

    public PolygonBlockchainFeesApiTests()
    {
        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");

        _blockchainFeesApi = new BlockchainFeesClient(new HttpClient(), apiKey, true);
    }
    
    [Theory]
    [InlineData(EstimateFee.ChainEnum.MATIC, EstimateFee.TypeEnum.BURNNFT)]
    [InlineData(EstimateFee.ChainEnum.MATIC, EstimateFee.TypeEnum.MINTNFT)]
    [InlineData(EstimateFee.ChainEnum.MATIC, EstimateFee.TypeEnum.DEPLOYERC20)]
    [InlineData(EstimateFee.ChainEnum.MATIC, EstimateFee.TypeEnum.DEPLOYNFT)]
    [InlineData(EstimateFee.ChainEnum.MATIC, EstimateFee.TypeEnum.TRANSFERERC20)]
    [InlineData(EstimateFee.ChainEnum.MATIC, EstimateFee.TypeEnum.TRANSFERNFT)]
    [InlineData(EstimateFee.ChainEnum.MATIC, EstimateFee.TypeEnum.DEPLOYAUCTION)]
    [InlineData(EstimateFee.ChainEnum.MATIC, EstimateFee.TypeEnum.DEPLOYMARKETPLACE)]
    [InlineData(EstimateFee.ChainEnum.ONE, EstimateFee.TypeEnum.BURNNFT)]
    [InlineData(EstimateFee.ChainEnum.ONE, EstimateFee.TypeEnum.MINTNFT)]
    [InlineData(EstimateFee.ChainEnum.ONE, EstimateFee.TypeEnum.DEPLOYERC20)]
    [InlineData(EstimateFee.ChainEnum.ONE, EstimateFee.TypeEnum.DEPLOYNFT)]
    [InlineData(EstimateFee.ChainEnum.ONE, EstimateFee.TypeEnum.TRANSFERERC20)]
    [InlineData(EstimateFee.ChainEnum.ONE, EstimateFee.TypeEnum.TRANSFERNFT)]
    [InlineData(EstimateFee.ChainEnum.ONE, EstimateFee.TypeEnum.DEPLOYAUCTION)]
    [InlineData(EstimateFee.ChainEnum.ONE, EstimateFee.TypeEnum.DEPLOYMARKETPLACE)]
    [InlineData(EstimateFee.ChainEnum.BSC, EstimateFee.TypeEnum.BURNNFT)]
    [InlineData(EstimateFee.ChainEnum.BSC, EstimateFee.TypeEnum.MINTNFT)]
    [InlineData(EstimateFee.ChainEnum.BSC, EstimateFee.TypeEnum.DEPLOYERC20)]
    [InlineData(EstimateFee.ChainEnum.BSC, EstimateFee.TypeEnum.DEPLOYNFT)]
    [InlineData(EstimateFee.ChainEnum.BSC, EstimateFee.TypeEnum.TRANSFERERC20)]
    [InlineData(EstimateFee.ChainEnum.BSC, EstimateFee.TypeEnum.TRANSFERNFT)]
    [InlineData(EstimateFee.ChainEnum.BSC, EstimateFee.TypeEnum.DEPLOYAUCTION)]
    [InlineData(EstimateFee.ChainEnum.BSC, EstimateFee.TypeEnum.DEPLOYMARKETPLACE)]
    [InlineData(EstimateFee.ChainEnum.ETH, EstimateFee.TypeEnum.BURNNFT)]
    [InlineData(EstimateFee.ChainEnum.ETH, EstimateFee.TypeEnum.MINTNFT)]
    [InlineData(EstimateFee.ChainEnum.ETH, EstimateFee.TypeEnum.DEPLOYERC20)]
    [InlineData(EstimateFee.ChainEnum.ETH, EstimateFee.TypeEnum.DEPLOYNFT)]
    [InlineData(EstimateFee.ChainEnum.ETH, EstimateFee.TypeEnum.TRANSFERERC20)]
    [InlineData(EstimateFee.ChainEnum.ETH, EstimateFee.TypeEnum.TRANSFERNFT)]
    [InlineData(EstimateFee.ChainEnum.ETH, EstimateFee.TypeEnum.DEPLOYAUCTION)]
    [InlineData(EstimateFee.ChainEnum.ETH, EstimateFee.TypeEnum.DEPLOYMARKETPLACE)]
    
    public async Task EstimateFeeBlockchain_ShouldReturnFee_WhenCalledForBurnNft(EstimateFee.ChainEnum chain, EstimateFee.TypeEnum type)
    {
        var result = await _blockchainFeesApi.PolygonBlockchainFees.EstimateFeeBlockchainAsync(new EstimateFee(chain, type));

        result.GasLimit.Should().BePositive();
        result.GasPrice.Should().BePositive();
    }
    
    [Fact]
    public async Task PolygonEstimateGas_ShouldReturnFee_WhenCalled()
    {
        var result = await _blockchainFeesApi.PolygonBlockchainFees.PolygonEstimateGasAsync(new PolygonEstimateGas("0xda54cb99712957c10b9f73279c2e84af4ff45ff0", "0x409eb7cafdec6aa83a8221b3af227e67841c1c0d", "1"));

        result.GasLimit.Should().NotBeNullOrWhiteSpace();
        result.GasPrice.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async Task EstimateFeeBlockchain_ShouldReturnFee_WhenCalled()
    {
        var result = await _blockchainFeesApi.BitcoinBlockchainFees.EstimateFeeBlockchainAsync(
            new EstimateFeeFromAddress(
                EstimateFeeFromAddress.ChainEnum.BTC, 
                EstimateFeeFromAddress.TypeEnum.TRANSFER, 
                new List<string>{"tb1qjzjyd3l3vh8an8w4mkr6dwur59lan60367kr04"},
                new List<EstimateFeeFromAddressTo>{new EstimateFeeFromAddressTo("tb1q5gtkjxguam0mlvevwxf2q9ldnq8ladenlhn3mw" ,1000000)}
                ));

        result.Fast.Should().NotBeNullOrWhiteSpace();
        result.Medium.Should().NotBeNullOrWhiteSpace();
        result.Slow.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async Task GetBlockchainFee_ShouldReturnFee_WhenCalled()
    {
        var result = await _blockchainFeesApi.BitcoinBlockchainFees.GetBlockchainFeeAsync();

        result.Fast.Should().BePositive();
        result.Medium.Should().BePositive();
        result.Slow.Should().BePositive();
    }
    
    [Fact]
    public async Task EthEstimateGas_ShouldReturnFee_WhenCalled()
    {
        var result = await _blockchainFeesApi.EthereumBlockchainFees.EthEstimateGasAsync(new EthEstimateGas("0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380", "0xd9cfbfe18fb9bf3871da5528061582ec08b97166", null, "1"));

        result.GasLimit.Should().NotBeNullOrWhiteSpace();
        result.GasPrice.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async Task BscEstimateGas_ShouldReturnFee_WhenCalled()
    {
        var result = await _blockchainFeesApi.BscBlockchainFees.BscEstimateGasAsync(new BscEstimateGas("0x3466bc2d2b5f425a8655611eb0e526eaeb103c16", "0xd3f039d5629df5753fcb36ee7db826bdd2d574e3", "1"));

        result.GasLimit.Should().NotBeNullOrWhiteSpace();
        result.GasPrice.Should().NotBeNullOrWhiteSpace();
    }
}
