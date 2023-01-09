using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.Solana.Clients;
using Tatum.CSharp.Solana.Core.Client;
using Tatum.CSharp.Solana.Core.Model;
using Tatum.CSharp.Solana.Tests.Integration.TestDataModels;
using Tatum.CSharp.Utils.DebugMode;
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

        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();
        
        _solanaApi = new SolanaClient(new HttpClient(httpClient), apiKey, true);
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

        SolanaBlock solanaBlock = null;
        var blockNotFound = true;
        
        var triesRemaining = 10;
        
        var blockNumber = await _solanaApi.SolanaBlockchain.SolanaGetCurrentBlockAsync();

        while (blockNotFound)
        {
            try
            {
                solanaBlock = await _solanaApi.SolanaBlockchain.SolanaGetBlockAsync(blockNumber - 2000);
                blockNotFound = false;
            }
            catch (ApiException e)
            {
                if (!e.Message.Contains("sol.block.not.found")) throw;
                if(triesRemaining == 0) throw;
                
                triesRemaining--;
                blockNumber--;
            }
        }

        solanaBlock.Blockhash.Should().NotBeNullOrWhiteSpace();
        solanaBlock.BlockHeight.Should().BeGreaterThan(0);
        solanaBlock.BlockTime.Should().BeGreaterThan(0);
        solanaBlock.ParentSlot.Should().BeGreaterThan(0);
        solanaBlock.PreviousBlockhash.Should().NotBeNullOrWhiteSpace();
        solanaBlock.Rewards.Should().NotBeEmpty();
        solanaBlock.Transactions.Should().NotBeEmpty();
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