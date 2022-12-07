using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.Solana.Clients;
using Tatum.CSharp.Solana.Core.Model;
using Tatum.CSharp.Solana.Tests.Integration.TestDataModels;
using VerifyXunit;
using Xunit;

namespace Tatum.CSharp.Solana.Tests.Integration.Clients;

[UsesVerify]
[Collection("Solana")]
public class SolanaApiTests
{
    private readonly ISolanaClient _solanaApi;

    private readonly SolanaTestData _testData;

    public SolanaApiTests()
    {
        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        var secrets = Environment.GetEnvironmentVariable("TEST_DATA");

        _testData = JsonSerializer.Deserialize<TestData>(secrets!)?.SolanaTestData;

        _solanaApi = new SolanaClient(new HttpClient(), apiKey, true);
    }

    [Fact]
    public async Task SolanaGenerateWalletWallet_ShouldReturnWalletData_WhenCalledWithoutData()
    {
        var wallet = await _solanaApi.SolanaBlockchain.SolanaGenerateWalletAsync();

        wallet.Address.Should().NotBeNullOrWhiteSpace();
        wallet.PrivateKey.Should().NotBeNullOrWhiteSpace();
        wallet.Mnemonic.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task SolanaGetCurrentBlock_ShouldReturnBlockNumber_WhenCalledWithoutData()
    {
        var blockNumber = await _solanaApi.SolanaBlockchain.SolanaGetCurrentBlockAsync();

        blockNumber.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task SolanaGetBalance_ShouldReturnBalance_WhenCalledWithCorrectAddress()
    {
        var balance = await _solanaApi.SolanaBlockchain.SolanaGetBalanceAsync(_testData.StorageAddress);

        balance.Balance.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task SolanaGetTransaction_ShouldReturnTransaction_WhenCalledWithCorrectTransactionHash()
    {
        var solanaTx = await _solanaApi.SolanaBlockchain.SolanaGetTransactionAsync("5DQWDgw2HGfYqaNKAD8KkZu2QqMLM7YtsdhhxvwBgBZqg3xft6rmgMKE4vKetuz9TvFiu9jfbrVB2hR2S6ncmkEU");

        await Verifier.Verify(solanaTx);
    }
    
    [Fact]
    public async Task SolanaGetBlock_ShouldReturnBlockData_WhenCalledWithCorrectBlockNumber()
    {
        var solanaBlock = await _solanaApi.SolanaBlockchain.SolanaGetBlockAsync(180490340);

        await Verifier.Verify(solanaBlock);
    }
    
    [Fact]
    public async Task SolanaBlockchainTransfer_ShouldReturnTransactionHash_WhenCalledWithCorrectData()
    {
        var transferSolanaBlockchain = new TransferSolanaBlockchain(
            _testData.StorageAddress, 
            _testData.TargetAddress, 
            "0.05", 
            _testData.StoragePrivKey);
        
        var solanaTx = await _solanaApi.SolanaBlockchain.SolanaBlockchainTransferAsync(transferSolanaBlockchain);

        solanaTx.TxId.Should().NotBeNullOrWhiteSpace();
    }
}