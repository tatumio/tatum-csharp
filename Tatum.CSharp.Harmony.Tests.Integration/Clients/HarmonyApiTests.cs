using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Numerics;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Signer;
using Nethereum.Web3.Accounts;
using Tatum.CSharp.Core.Client;
using Tatum.CSharp.Core.Model;
using Tatum.CSharp.Harmony.Clients;
using Tatum.CSharp.Harmony.Tests.Integration.TestDataModels;
using VerifyTests;
using VerifyXunit;
using Xunit;
using Transaction = Nethereum.RPC.Eth.DTOs.Transaction;

namespace Tatum.CSharp.Harmony.Tests.Integration.Clients;

[UsesVerify]
[Collection("Harmony")]
public class HarmonyApiTests : IAsyncDisposable
{
    private readonly IHarmonyClient _harmonyApi;
    private readonly Dictionary<string, decimal> _debts = new();

    private readonly HarmonyTestData _testData;

    public HarmonyApiTests()
    {
        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        var secrets = Environment.GetEnvironmentVariable("TEST_DATA");

        _testData = JsonSerializer.Deserialize<TestData>(secrets!)?.HarmonyTestData;

        _harmonyApi = new HarmonyClient(new HttpClient(), apiKey, true);
        VerifierSettings.IgnoreMember<ApiResponse<GeneratedAddressOne>>(x => x.Headers);
    }

    [Fact]
    public async Task GenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithoutData()
    {
        var wallet = await _harmonyApi.HarmonyBlockchain.OneGenerateWalletAsync();

        wallet.Mnemonic.Should().NotBeNullOrWhiteSpace();
        wallet.Xpub.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task GenerateWalletWithHttpInfo_ShouldReturnXpuAndMnemonic_WhenCalledWithoutData()
    {
        var response = await _harmonyApi.HarmonyBlockchainWithHttpInfo.OneGenerateWalletWithHttpInfoAsync();

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Data.Mnemonic.Should().NotBeNullOrWhiteSpace();
        response.Data.Xpub.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task GenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithMnemonic()
    {
        var wallet = await _harmonyApi.HarmonyBlockchain.OneGenerateWalletAsync(_testData.TestMnemonic);

        wallet.Mnemonic.Should().Be(_testData.TestMnemonic);
        wallet.Xpub.Should().Be(_testData.TestXPub);
    }

    [Fact]
    public async Task GenerateWalletWithHttpInfo_ShouldReturnXpuAndMnemonic_WhenCalledWithMnemonic()
    {
        var response = await _harmonyApi.HarmonyBlockchainWithHttpInfo.OneGenerateWalletWithHttpInfoAsync(_testData.TestMnemonic);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Data.Mnemonic.Should().Be(_testData.TestMnemonic);
        response.Data.Xpub.Should().Be(_testData.TestXPub);
    }

    [Fact]
    public void LocalGenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithoutData()
    {
        var wallet = _harmonyApi.Local.GenerateWallet();

        wallet.Mnemonic.Should().NotBeNullOrWhiteSpace();
        wallet.Xpub.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public void LocalGenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithMnemonic()
    {
        var wallet = _harmonyApi.Local.GenerateWallet(_testData.TestMnemonic);

        wallet.Mnemonic.Should().Be(_testData.TestMnemonic);
        wallet.Xpub.Should().Be(_testData.TestXPub);
    }

    [Fact]
    public async Task GenerateAddress_ShouldReturnAddress_WhenCalledWithValidData()
    {
        var address = await _harmonyApi.HarmonyBlockchain.OneGenerateAddressAsync(_testData.TestXPub, 0);

        await Verifier.Verify(address);
    }
    
    [Fact]
    public async Task OneFormatAddress_ShouldReturnOneAddress_WhenCalledWithValidData()
    {
        var address = await _harmonyApi.HarmonyBlockchain.OneFormatAddressAsync(_testData.StorageAddress);

        await Verifier.Verify(address);
    }

    [Fact]
    public void GenerateAddress_ShouldThrowApiException_WhenCalledWithInvalidXpub()
    {
        Func<Task> action = async () => await _harmonyApi.HarmonyBlockchain.OneGenerateAddressAsync("some random text", 0);

        action.Should().ThrowAsync<ApiException>()
            .WithMessage("Unable to generate address for some random text.");
    }

    [Fact]
    public async Task GenerateAddressWithHttpInfo_ShouldReturnAddress_WhenCalledWithValidData()
    {
        var address = await _harmonyApi.HarmonyBlockchainWithHttpInfo.OneGenerateAddressWithHttpInfoAsync(_testData.TestXPub, 0);
        
        await Verifier.Verify(address);
    }

    [Fact]
    public async Task GenerateAddressWithHttpInfo_ShouldReturnNotSuccessApiResponse_WhenCalledWithInvalidData()
    {
        var address = await _harmonyApi.HarmonyBlockchainWithHttpInfo.OneGenerateAddressWithHttpInfoAsync("some random text", 0);

        await Verifier.Verify(address);
    }

    [Fact]
    public async Task LocalGenerateAddress_ShouldReturnAddress_WhenCalledWithValidData()
    {
        var address = _harmonyApi.Local.GenerateAddress(_testData.TestXPub, 0);

        await Verifier.Verify(address);
    }

    [Fact]
    public void LocalGenerateAddress_ShouldThrowInvalidFormatException_WhenCalledWithInvalidXpub()
    {
        var action = () => _harmonyApi.Local.GenerateAddress("some random text", 0);

        action.Should().Throw<FormatException>()
            .WithMessage("Invalid base58 data");
    }

    [Fact]
    public async Task GenerateAddress_ShouldReturnSameAddress_WhenCalledWithSameDataOnLocal()
    {
        var address = await _harmonyApi.HarmonyBlockchain.OneGenerateAddressAsync(_testData.TestXPub, 0);
        var addressLocal = _harmonyApi.Local.GenerateAddress(_testData.TestXPub, 0);

        address.Address.Should().Be(addressLocal.Address.ToLower());
    }

    [Fact]
    public async Task GenerateAddressPrivateKey_ShouldReturnPrivateKey_WhenCalledWithValidData()
    {
        var privKey = await _harmonyApi.HarmonyBlockchain.OneGenerateAddressPrivateKeyAsync(new PrivKeyRequest(0, _testData.TestMnemonic));

        await Verifier.Verify(privKey);
    }

    [Fact]
    public async Task LocalGenerateAddressPrivateKey_ShouldReturnPrivateKey_WhenCalledWithValidData()
    {
        var privKey = _harmonyApi.Local.GenerateAddressPrivateKey(new PrivKeyRequest(0, _testData.TestMnemonic));

        await Verifier.Verify(privKey);
    }

    [Fact]
    public async Task GenerateAddressPrivateKey_ShouldReturnSamePrivateKey_WhenCalledWithSameDataOnLocal()
    {
        var privKeyRequest = new PrivKeyRequest(0, _testData.TestMnemonic);
        
        var privKey = await _harmonyApi.HarmonyBlockchain.OneGenerateAddressPrivateKeyAsync(privKeyRequest);
        var privKeyLocal = _harmonyApi.Local.GenerateAddressPrivateKey(privKeyRequest);

        privKey.Key.Should().Be(privKeyLocal.Key);
    }

    [Fact]
    public async Task GetCurrentBlock_ShouldReturnBlockNumber_WhenCalledWithoutData()
    {
        var blockNumbers = await _harmonyApi.HarmonyBlockchain.OneGetCurrentBlockAsync();

        blockNumbers.Should().NotBeEmpty();
        blockNumbers.First().BlockNumber.Should().BeGreaterThan(0);
        blockNumbers.First().ShardID.Should().BeGreaterOrEqualTo(0);
    }

    [Fact]
    public async Task GetBlock_ShouldReturnBlockData_WhenCalledWithCorrectBlockNumber()
    {
        var block = await _harmonyApi.HarmonyBlockchain.OneGetBlockAsync("0");

        await Verifier.Verify(block);
    }

    [Fact]
    public async Task GetBalance_ShouldReturnValue_WhenCalledOnExistingAccount()
    {
        var accountBalance = await _harmonyApi.HarmonyBlockchain.OneGetBalanceAsync(_testData.StorageAddress);

        accountBalance.Balance.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task OneBlockchainTransfer_ShouldReturnTransactionHash_WhenCalledWithValidData()
    {
        var amount = 0.00005m;

        var transactionHash = await _harmonyApi.HarmonyBlockchain.OneBlockchainTransferAsync(
            new TransferOneBlockchain(
            null, 
            TransferOneBlockchain.CurrencyEnum.ONE, 
            0, 
            _testData.TargetAddress,
            null, 
            amount.ToString("0.00000", CultureInfo.InvariantCulture), 
            _testData.StoragePrivKey));

        _debts.Add(_testData.TargetPrivKey, amount);

        transactionHash.TxId.Should().NotBeNullOrWhiteSpace();
        
        await WaitForTransactionSuccess(transactionHash.TxId);
    }

    [Fact]
    public async Task OneGetTransaction_ShouldReturnTransaction_WhenCalledWithValidHash()
    {
        const string txHash = "0x4bdb1c348d006f4a95ddaf9f616387abc3735622e024cb1daf162ece9d468b77";
        
        var transaction = await _harmonyApi.HarmonyBlockchain.OneGetTransactionAsync(txHash);

        await Verifier.Verify(transaction);
    }

    [Fact]
    public async Task OneGetTransactionCount_ShouldReturnPositiveNumber_WhenCalledOnExistingAccount()
    {
        var accountBalance = await _harmonyApi.HarmonyBlockchain.OneGetTransactionCountAsync(_testData.StorageAddress);

        accountBalance.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task OneBlockchainSmartContractInvocation_ShouldReturnTransactionHash_WhenCalledOnWithValidPayload()
    {
        const string contractAddress = "0x4df043733b8d27d2921c3a80ee25e67f842aee63";
        
        var callSmartContractMethod = new CallOneSmartContractMethod(
            contractAddress,
            null,
            "transferFrom",
            new
            {
                constant = false, 
                inputs = new []
                {
                    new
                    {
                        name = "from", 
                        type = "address"
                    }, 
                    new
                    {
                        name = "to", 
                        type = "address"
                    }, 
                    new
                    {
                        name = "value", 
                        type = "uint256"
                    }
                },
                name = "transferFrom",
                outputs = new []
                {
                    new
                    {
                        name = "", 
                        type = "bool"
                    }
                },
                payable = false,
                stateMutability = "nonpayable",
                type = "function"
            },
            new List<string>
            {
                _testData.StorageAddress,
                _testData.TargetAddress, 
                "1"
            },
            _testData.StoragePrivKey,
            0,
            new CustomFee("100000", "1000")
        );
        
        var transaction = await _harmonyApi.HarmonyBlockchain.OneBlockchainSmartContractInvocationAsync(callSmartContractMethod);

        transaction.TxId.Should().NotBeNullOrWhiteSpace();
        
        await WaitForTransactionSuccess(transaction.TxId);
    }

    [Fact]
    public async Task OneBlockchainSmartContractInvocation_ShouldReturnData_WhenCalledOnWithValidPayload()
    {
        const string contractAddress = "0x4df043733b8d27d2921c3a80ee25e67f842aee63";
        
        var callReadSmartContractMethod = new CallOneReadSmartContractMethod(
            contractAddress,
            "balanceOf",
            new
            {
                constant = true, 
                inputs = new []
                {
                    new
                    {
                        name = "owner", 
                        type = "address"
                    }
                },
                name = "balanceOf",
                outputs = new []
                {
                    new
                    {
                        name = "", 
                        type = "uint256"
                    }
                },
                payable = false,
                stateMutability = "view",
                type = "function"
            },
            new List<string>
            {
                "0x9ac64cc6e4415144c455bd8e4837fea55603e5c3"
            }
        );
        
        var data = await _harmonyApi.HarmonyBlockchain.OneBlockchainSmartContractInvocationAsync(callReadSmartContractMethod);

        data._Data.Should().Be("0");
    }

    [Fact]
    public async Task OneBroadcastAsync_ShouldReturnTransactionHash_WhenCalledOnSignedTransaction()
    {
        var txCount = await _harmonyApi.HarmonyBlockchain.OneGetTransactionCountAsync(_testData.StorageAddress);
        
        var transactionManager = new LegacyTransactionSigner();

        var signedTransaction = transactionManager.SignTransaction(
            _testData.StoragePrivKey, 
            1666700000, 
            _testData.TargetAddress, 
            new BigInteger(5000000000000000), 
            new BigInteger((int)txCount),
            new BigInteger(1000000000000),
            new BigInteger(10000000));

        var resultTransaction = await _harmonyApi.HarmonyBlockchain.OneBroadcastAsync(new BroadcastKMS("0x" + signedTransaction));

        _debts.Add(_testData.TargetPrivKey, 0.005M);
        
        resultTransaction.TxId.Should().NotBeNullOrWhiteSpace();

        await WaitForTransactionSuccess(resultTransaction.TxId);
    }

    public async ValueTask DisposeAsync()
    {
        await PayDebts();
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
                    var tx = await _harmonyApi.HarmonyBlockchain.OneGetTransactionAsync(hash,
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

    private async Task PayDebts()
    {
        foreach (var debt in _debts)
        {
            var result = await _harmonyApi.HarmonyBlockchain.OneBlockchainTransferAsync(
                new TransferOneBlockchain(
                    null,
                    TransferOneBlockchain.CurrencyEnum.ONE,
                    0,
                    _testData.StorageAddress,
                    null,
                    debt.Value.ToString("G"),
                    debt.Key));
            
            await WaitForTransactionSuccess(result.TxId);
        }
    }
}