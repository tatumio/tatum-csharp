using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Fees.Models;
using Tatum.CSharp.Utils.DebugMode;
using Xunit;

namespace Tatum.CSharp.Examples.FeeEstimations;

public class TatumFeeEstimations
{
    private readonly TatumSdk _tatumSdk;
    
    public TatumFeeEstimations()
    {
        var debugModeHandler = new DebugModeHandler();
        debugModeHandler.InnerHandler = new HttpClientHandler();
        
        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        
        _tatumSdk = TatumSdk.Init(true, apiKey, new HttpClient(debugModeHandler));
    }
    
    [Fact]
    public async Task GetCurrent_Single()
    {
        var currentFee = await _tatumSdk.Fees.GetCurrent(Chain.Ethereum);

        currentFee.Should().NotBeNull();
        currentFee.SlowGasPriceGwei.Should().MatchRegex("^\\d*\\.?\\d*$");
        currentFee.MediumGasPriceGwei.Should().MatchRegex("^\\d*\\.?\\d*$");
        currentFee.FastGasPriceGwei.Should().MatchRegex("^\\d*\\.?\\d*$");
        currentFee.BaseFeeGwei.Should().MatchRegex("^\\d*\\.?\\d*$");
        currentFee.LastRecalculated.Should().BeWithin(TimeSpan.FromDays(7));
        currentFee.BasedOnBlockNumber.Should().BePositive();
    }
    
    [Fact]
    public async Task GetCurrent_Many()
    {
        var currentFee = await _tatumSdk.Fees.GetCurrent(new []{Chain.Ethereum});

        currentFee.Should().NotBeNull();
        currentFee.Should().ContainKey(Chain.Ethereum);
        
        var currentFeeEthereum = currentFee[Chain.Ethereum];
        
        currentFeeEthereum.SlowGasPriceGwei.Should().MatchRegex("^\\d*\\.?\\d*$");
        currentFeeEthereum.MediumGasPriceGwei.Should().MatchRegex("^\\d*\\.?\\d*$");
        currentFeeEthereum.FastGasPriceGwei.Should().MatchRegex("^\\d*\\.?\\d*$");
        currentFeeEthereum.BaseFeeGwei.Should().MatchRegex("^\\d*\\.?\\d*$");
        currentFeeEthereum.LastRecalculated.Should().BeWithin(TimeSpan.FromDays(7));
        currentFeeEthereum.BasedOnBlockNumber.Should().BePositive();
    }
    
    [Fact]
    public async Task Estimate_Single()
    {
        var transactionDataForFeeEstimation = new NativeTransferFeeEstimationDetails
        {
            Chain = Chain.Ethereum,
            From = "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380",
            To = "0xd9cfbfe18fb9bf3871da5528061582ec08b97166",
            Value = "1"
        };
        
        var estimatedFee = await _tatumSdk.Fees.Estimate(transactionDataForFeeEstimation);

        estimatedFee.Should().NotBeNull();
        estimatedFee.ChainNativeTransferFeeEstimations.Should().ContainKey(Chain.Ethereum);
        
        var estimatedFeeEthereum = estimatedFee.ChainNativeTransferFeeEstimations[Chain.Ethereum];
        estimatedFeeEthereum.Should().NotBeEmpty();
        var estimatedFeeEthereumFirst = estimatedFeeEthereum[0];
        
        estimatedFeeEthereumFirst.GasLimit.Should().MatchRegex("^\\d*\\.?\\d*$");
        estimatedFeeEthereumFirst.GasPrice.Fast.Should().MatchRegex("^\\d*\\.?\\d*$");
        estimatedFeeEthereumFirst.GasPrice.Slow.Should().MatchRegex("^\\d*\\.?\\d*$");
        estimatedFeeEthereumFirst.GasPrice.Medium.Should().MatchRegex("^\\d*\\.?\\d*$");
        estimatedFeeEthereumFirst.GasPrice.BaseFee.Should().MatchRegex("^\\d*\\.?\\d*$");
        estimatedFeeEthereumFirst.GasPrice.Unit.Should().Be("Gwei");
    }
    
    [Fact]
    public async Task Estimate_Many()
    {
        var transactionDataForFeeEstimation = new NativeTransferFeeEstimationDetails
        {
            Chain = Chain.Ethereum,
            From = "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380",
            To = "0xd9cfbfe18fb9bf3871da5528061582ec08b97166",
            Value = "1"
        };
        
        var estimatedFee = await _tatumSdk.Fees.Estimate(new []{transactionDataForFeeEstimation});

        estimatedFee.Should().NotBeNull();
        estimatedFee.ChainNativeTransferFeeEstimations.Should().ContainKey(Chain.Ethereum);
        
        var estimatedFeeEthereum = estimatedFee.ChainNativeTransferFeeEstimations[Chain.Ethereum];
        estimatedFeeEthereum.Should().NotBeEmpty();
        var estimatedFeeEthereumFirst = estimatedFeeEthereum[0];
        
        estimatedFeeEthereumFirst.GasLimit.Should().MatchRegex("^\\d*\\.?\\d*$");
        estimatedFeeEthereumFirst.GasPrice.Fast.Should().MatchRegex("^\\d*\\.?\\d*$");
        estimatedFeeEthereumFirst.GasPrice.Slow.Should().MatchRegex("^\\d*\\.?\\d*$");
        estimatedFeeEthereumFirst.GasPrice.Medium.Should().MatchRegex("^\\d*\\.?\\d*$");
        estimatedFeeEthereumFirst.GasPrice.BaseFee.Should().MatchRegex("^\\d*\\.?\\d*$");
        estimatedFeeEthereumFirst.GasPrice.Unit.Should().Be("Gwei");
    }
}