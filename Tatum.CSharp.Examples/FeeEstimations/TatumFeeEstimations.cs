using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.FeeEstimations.Models.Requests;
using Tatum.CSharp.Utils.DebugMode;
using Xunit;

namespace Tatum.CSharp.Examples.FeeEstimations;

public class TatumFeeEstimations
{
    [Fact]
    public async Task GetCurrentFee()
    {
        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();

        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        
        var tatum = new Tatum(new HttpClient(httpClient), apiKey);

        var currentFee = await tatum.Fees.GetCurrentFee(Chain.ETH);

        currentFee.Should().NotBeNull();
        currentFee.SlowGasPriceGwei.Should().MatchRegex("^\\d*\\.?\\d*$");
        currentFee.MediumGasPriceGwei.Should().MatchRegex("^\\d*\\.?\\d*$");
        currentFee.FastGasPriceGwei.Should().MatchRegex("^\\d*\\.?\\d*$");
        currentFee.BaseFeeGwei.Should().MatchRegex("^\\d*\\.?\\d*$");
        currentFee.LastRecalculated.Should().BeWithin(TimeSpan.FromDays(7));
        currentFee.BasedOnBlockNumber.Should().BePositive();

    }
    
    [Fact]
    public async Task EstimateFeeForBlockchainTransaction()
    {
        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();

        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        
        var tatum = new Tatum(new HttpClient(httpClient), apiKey);

        var transactionDataForFeeEstimation = new TransactionDataForFeeEstimation
        {
            Chain = Chain.ETH,
            Type = TransactionTypeForFeeEstimation.TRANSFER_NFT,
            SenderAddress = "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380",
            RecipientAddress = "0xd9cfbfe18fb9bf3871da5528061582ec08b97166",
            ContractAddress = "0xf04bc01d562ad9f750db0235a4ac396551a7f846",
            Amount = "1"
        };
        
        var estimatedFee = await tatum.Fees.EstimateFeeForBlockchainTransaction(transactionDataForFeeEstimation);

        estimatedFee.Should().NotBeNull();
        estimatedFee.GasLimit.Should().MatchRegex("^\\d*\\.?\\d*$");
        estimatedFee.GasPriceGwei.Should().MatchRegex("^\\d*\\.?\\d*$");
    }
}