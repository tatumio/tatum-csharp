using System;
using System.Collections.Generic;
using System.Globalization;
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
using Tatum.CSharp.Bsc.Clients;
using Tatum.CSharp.Core.Client;
using Tatum.CSharp.Core.Model;
using Tatum.CSharp.Bsc.Tests.Integration.TestDataModels;
using VerifyTests;
using VerifyXunit;
using Xunit;
using Transaction = Nethereum.RPC.Eth.DTOs.Transaction;

namespace Tatum.CSharp.Bsc.Tests.Integration.Clients;

[UsesVerify]
[Collection("Bsc")]
public class BscApiTests : IAsyncDisposable
{
    private readonly IBscClient _bscApi;
    private readonly Dictionary<string, decimal> _debts = new();

    private readonly BscTestData _testData;

    public BscApiTests()
    {
        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        var secrets = Environment.GetEnvironmentVariable("TEST_DATA");

        _testData = JsonSerializer.Deserialize<TestData>(secrets!)?.BscTestData;

        _bscApi = new BscClient(new HttpClient(), apiKey, true);
        VerifierSettings.IgnoreMember<ApiResponse<GeneratedAddressBsc>>(x => x.Headers);
    }

    [Fact]
    public async Task GenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithoutData()
    {
        var wallet = await _bscApi.BscBlockchain.BscGenerateWalletAsync();

        wallet.Mnemonic.Should().NotBeNullOrWhiteSpace();
        wallet.Xpub.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task GenerateWalletWithHttpInfo_ShouldReturnXpuAndMnemonic_WhenCalledWithoutData()
    {
        var response = await _bscApi.BscBlockchainWithHttpInfo.BscGenerateWalletWithHttpInfoAsync();

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Data.Mnemonic.Should().NotBeNullOrWhiteSpace();
        response.Data.Xpub.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task GenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithMnemonic()
    {
        var wallet = await _bscApi.BscBlockchain.BscGenerateWalletAsync(_testData.TestMnemonic);

        wallet.Mnemonic.Should().Be(_testData.TestMnemonic);
        wallet.Xpub.Should().Be(_testData.TestXPub);
    }

    [Fact]
    public async Task GenerateWalletWithHttpInfo_ShouldReturnXpuAndMnemonic_WhenCalledWithMnemonic()
    {
        var response = await _bscApi.BscBlockchainWithHttpInfo.BscGenerateWalletWithHttpInfoAsync(_testData.TestMnemonic);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Data.Mnemonic.Should().Be(_testData.TestMnemonic);
        response.Data.Xpub.Should().Be(_testData.TestXPub);
    }

    [Fact]
    public void LocalGenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithoutData()
    {
        var wallet = _bscApi.Local.GenerateWallet();

        wallet.Mnemonic.Should().NotBeNullOrWhiteSpace();
        wallet.Xpub.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public void LocalGenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithMnemonic()
    {
        var wallet = _bscApi.Local.GenerateWallet(_testData.TestMnemonic);

        wallet.Mnemonic.Should().Be(_testData.TestMnemonic);
        wallet.Xpub.Should().Be(_testData.TestXPub);
    }

    [Fact]
    public async Task GenerateAddress_ShouldReturnAddress_WhenCalledWithValidData()
    {
        var address = await _bscApi.BscBlockchain.BscGenerateAddressAsync(_testData.TestXPub, 0);

        await Verifier.Verify(address);
    }

    [Fact]
    public void GenerateAddress_ShouldThrowApiException_WhenCalledWithInvalidXpub()
    {
        Func<Task> action = async () => await _bscApi.BscBlockchain.BscGenerateAddressAsync("some random text", 0);

        action.Should().ThrowAsync<ApiException>()
            .WithMessage("Unable to generate address for some random text.");
    }

    [Fact]
    public async Task GenerateAddressWithHttpInfo_ShouldReturnAddress_WhenCalledWithValidData()
    {
        var address = await _bscApi.BscBlockchainWithHttpInfo.BscGenerateAddressWithHttpInfoAsync(_testData.TestXPub, 0);
        
        await Verifier.Verify(address);
    }

    [Fact]
    public async Task GenerateAddressWithHttpInfo_ShouldReturnNotSuccessApiResponse_WhenCalledWithInvalidData()
    {
        var address = await _bscApi.BscBlockchainWithHttpInfo.BscGenerateAddressWithHttpInfoAsync("some random text", 0);

        await Verifier.Verify(address);
    }

    [Fact]
    public async Task LocalGenerateAddress_ShouldReturnAddress_WhenCalledWithValidData()
    {
        var address = _bscApi.Local.GenerateAddress(_testData.TestXPub, 0);

        await Verifier.Verify(address);
    }

    [Fact]
    public void LocalGenerateAddress_ShouldThrowInvalidFormatException_WhenCalledWithInvalidXpub()
    {
        var action = () => _bscApi.Local.GenerateAddress("some random text", 0);

        action.Should().Throw<FormatException>()
            .WithMessage("Invalid base58 data");
    }

    [Fact]
    public async Task GenerateAddress_ShouldReturnSameAddress_WhenCalledWithSameDataOnLocal()
    {
        var address = await _bscApi.BscBlockchain.BscGenerateAddressAsync(_testData.TestXPub, 0);
        var addressLocal = _bscApi.Local.GenerateAddress(_testData.TestXPub, 0);

        address.Address.Should().Be(addressLocal.Address.ToLower());
    }

    [Fact]
    public async Task GenerateAddressPrivateKey_ShouldReturnPrivateKey_WhenCalledWithValidData()
    {
        var privKey = await _bscApi.BscBlockchain.BscGenerateAddressPrivateKeyAsync(new PrivKeyRequest(0, _testData.TestMnemonic));

        await Verifier.Verify(privKey);
    }

    [Fact]
    public async Task LocalGenerateAddressPrivateKey_ShouldReturnPrivateKey_WhenCalledWithValidData()
    {
        var privKey = _bscApi.Local.GenerateAddressPrivateKey(new PrivKeyRequest(0, _testData.TestMnemonic));

        await Verifier.Verify(privKey);
    }

    [Fact]
    public async Task GenerateAddressPrivateKey_ShouldReturnSamePrivateKey_WhenCalledWithSameDataOnLocal()
    {
        var privKeyRequest = new PrivKeyRequest(0, _testData.TestMnemonic);
        
        var privKey = await _bscApi.BscBlockchain.BscGenerateAddressPrivateKeyAsync(privKeyRequest);
        var privKeyLocal = _bscApi.Local.GenerateAddressPrivateKey(privKeyRequest);

        privKey.Key.Should().Be(privKeyLocal.Key);
    }

    [Fact]
    public async Task GetCurrentBlock_ShouldReturnBlockNumber_WhenCalledWithoutData()
    {
        var blockNumber = await _bscApi.BscBlockchain.BscGetCurrentBlockAsync();

        blockNumber.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task GetBlock_ShouldReturnBlockData_WhenCalledWithCorrectBlockNumber()
    {
        var block = await _bscApi.BscBlockchain.BscGetBlockAsync("0");

        await Verifier.Verify(block);
    }

    [Fact]
    public async Task GetBalance_ShouldReturnValue_WhenCalledOnExistingAccount()
    {
        var accountBalance = await _bscApi.BscBlockchain.BscGetBalanceAsync(_testData.StorageAddress);

        accountBalance.Balance.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task BscBlockchainTransfer_ShouldReturnTransactionHash_WhenCalledWithValidData()
    {
        var amount = 0.00005m;

        var transactionHash = await _bscApi.BscBlockchain.BscBlockchainTransferAsync(
            new TransferBscBlockchain(
            null, 
            0, 
            _testData.TargetAddress, 
            TransferBscBlockchain.CurrencyEnum.BSC, 
            null, 
            amount.ToString("0.00000", CultureInfo.InvariantCulture), 
            _testData.StoragePrivKey));

        _debts.Add(_testData.TargetPrivKey, amount);

        transactionHash.TxId.Should().NotBeNullOrWhiteSpace();
        
        await WaitForTransactionSuccess(transactionHash.TxId);
    }

    [Fact]
    public async Task BscGetTransaction_ShouldReturnTransaction_WhenCalledWithValidHash()
    {
        const string txHash = "0x5f20f580e8f51bedd85ab20b0640a1dfcbe0ed86385e2388aedc7e57feaf40bf";
        
        var transaction = await _bscApi.BscBlockchain.BscGetTransactionAsync(txHash);

        await Verifier.Verify(transaction);
    }

    [Fact]
    public async Task BscGetTransactionCount_ShouldReturnPositiveNumber_WhenCalledOnExistingAccount()
    {
        var accountBalance = await _bscApi.BscBlockchain.BscGetTransactionCountAsync(_testData.StorageAddress);

        accountBalance.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task BscBlockchainSmartContractInvocation_ShouldReturnTransactionHash_WhenCalledOnWithValidPayload()
    {
        const string contractAddress = "0x1157cbfbf7017f6bE0BA68fb272077cd2387a21A";
        
        var callSmartContractMethod = new CallBscSmartContractMethod(
            contractAddress,
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
            null,
            _testData.StoragePrivKey,
            0,
            new CustomFee("100000", "3")
        );
        
        var transaction = await _bscApi.BscBlockchain.BscBlockchainSmartContractInvocationAsync(callSmartContractMethod);

        transaction.TxId.Should().NotBeNullOrWhiteSpace();
        
        await WaitForTransactionSuccess(transaction.TxId);
    }

    [Fact]
    public async Task BscBlockchainSmartContractInvocation_ShouldReturnData_WhenCalledOnWithValidPayload()
    {
        const string contractAddress = "0x1157cbfbf7017f6bE0BA68fb272077cd2387a21A";
        
        var callReadSmartContractMethod = new CallBscSmartContractReadMethod(
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
        
        var data = await _bscApi.BscBlockchain.BscBlockchainSmartContractInvocationAsync(callReadSmartContractMethod);

        data._Data.Should().Be("0");
    }

    [Fact]
    public async Task BscBroadcastAsync_ShouldReturnTransactionHash_WhenCalledOnSignedTransaction()
    {
        var txCount = await _bscApi.BscBlockchain.BscGetTransactionCountAsync(_testData.StorageAddress);

        var transactionManager = new LegacyTransactionSigner();

        var signedTransaction = transactionManager.SignTransaction(
            _testData.StoragePrivKey, 
            97, 
            _testData.TargetAddress, 
            new BigInteger(50000000000000), 
            new BigInteger((int)txCount));

        var resultTransaction = await _bscApi.BscBlockchain.BscBroadcastAsync(new BroadcastKMS("0x" + signedTransaction));

        _debts.Add(_testData.TargetPrivKey, 0.00005M);
        
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
                    var tx = await _bscApi.BscBlockchain.BscGetTransactionAsync(hash,
                        cancellationToken: cts.Token);
                    if (tx.Status || tx.BlockNumber != null)
                    {
                        await Task.Delay(1000, cts.Token);
                        break;
                    }
                }
                catch (ApiException e)
                {
                    if (!e.Message.Contains("eth.tx.not.found"))
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
            var result = await _bscApi.BscBlockchain.BscBlockchainTransferAsync(
                new TransferBscBlockchain(
                    null,
                    0,
                    _testData.StorageAddress,
                    TransferBscBlockchain.CurrencyEnum.BSC,
                    null,
                    debt.Value.ToString("G"),
                    debt.Key));
            
            await WaitForTransactionSuccess(result.TxId);
        }
    }
}