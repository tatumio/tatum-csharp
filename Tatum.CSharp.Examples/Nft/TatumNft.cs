using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Utils.DebugMode;
using Xunit;

namespace Tatum.CSharp.Examples.Nft;

public class TatumNft
{
    [Fact]
    public async Task BalanceOfWallet()
    {
        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();

        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        
        var tatum = new Tatum(new HttpClient(httpClient), apiKey);

        var balances = await tatum.Nft.BalanceOfWallet(Chain.ETH, "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380");
        
        balances.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task GetNftMetadata()
    {
        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();

        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        
        var tatum = new Tatum(new HttpClient(httpClient), apiKey);

        var nftMetadata = await tatum.Nft.GetNftMetadata(Chain.ETH, "0xf04bc01d562ad9f750db0235a4ac396551a7f846", "10");
        
        nftMetadata.Should().NotBeNull();
    }
    
    [Fact]
    public async Task ListTransactionsByNft()
    {
        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();

        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        
        var tatum = new Tatum(new HttpClient(httpClient), apiKey);

        var transactions = await tatum.Nft.ListTransactionsByNft(Chain.ETH, "10", "0xf04bc01d562ad9f750db0235a4ac396551a7f846");
        
        transactions.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task ListOfNftsFromCollection()
    {
        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();

        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        
        var tatum = new Tatum(new HttpClient(httpClient), apiKey);

        var nftsInCollections = await tatum.Nft.ListOfNftsFromCollection(Chain.ETH, "0xf04bc01d562ad9f750db0235a4ac396551a7f846");

        nftsInCollections.Should().NotBeEmpty();
    }
}