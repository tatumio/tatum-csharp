using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3.Accounts;
using Tatum.CSharp.Core.Client;
using Tatum.CSharp.Core.Model;
using Tatum.CSharp.BSC.Clients;
using Tatum.CSharp.BSC.Tests.Integration.TestDataModels;
using VerifyTests;
using VerifyXunit;
using Xunit;
using Transaction = Nethereum.RPC.Eth.DTOs.Transaction;

namespace Tatum.CSharp.BSC.Tests.Integration.Clients;

[UsesVerify]
[Collection("BSC")]
public class BSCApiTests : IAsyncDisposable
{
    private readonly IBSCClient _bscApi;
    private readonly Dictionary<string, decimal> _debts = new();

    private readonly BSCTestData _testData;

    public BSCApiTests()
    {
        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        var secrets = Environment.GetEnvironmentVariable("TEST_DATA");

        _testData = JsonSerializer.Deserialize<TestData>(secrets!)?.BSCTestData;

        _bscApi = new BSCClient(new HttpClient(), apiKey, true);
        VerifierSettings.IgnoreMember<ApiResponse<GeneratedAddressEth>>(x => x.Headers);
    }

    [Fact]
    public async Task GenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithoutData()
    {
        var wallet = await _bscApi.BSCBlockchain.EthGenerateWalletAsync();

        wallet.Mnemonic.Should().NotBeNullOrWhiteSpace();
        wallet.Xpub.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task GenerateWalletWithHttpInfo_ShouldReturnXpuAndMnemonic_WhenCalledWithoutData()
    {
        var response = await _bscApi.BSCBlockchainWithHttpInfo.EthGenerateWalletWithHttpInfoAsync();

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Data.Mnemonic.Should().NotBeNullOrWhiteSpace();
        response.Data.Xpub.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task GenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithMnemonic()
    {
        var wallet = await _bscApi.BSCBlockchain.EthGenerateWalletAsync(_testData.TestMnemonic);

        wallet.Mnemonic.Should().Be(_testData.TestMnemonic);
        wallet.Xpub.Should().Be(_testData.TestXPub);
    }

    [Fact]
    public async Task GenerateWalletWithHttpInfo_ShouldReturnXpuAndMnemonic_WhenCalledWithMnemonic()
    {
        var response = await _bscApi.BSCBlockchainWithHttpInfo.EthGenerateWalletWithHttpInfoAsync(_testData.TestMnemonic);

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
        var address = await _bscApi.BSCBlockchain.EthGenerateAddressAsync(_testData.TestXPub, 0);

        await Verifier.Verify(address);
    }

    [Fact]
    public void GenerateAddress_ShouldThrowApiException_WhenCalledWithInvalidXpub()
    {
        Func<Task> action = async () => await _bscApi.BSCBlockchain.EthGenerateAddressAsync("some random text", 0);

        action.Should().ThrowAsync<ApiException>()
            .WithMessage("Unable to generate address for some random text.");
    }

    [Fact]
    public async Task GenerateAddressWithHttpInfo_ShouldReturnAddress_WhenCalledWithValidData()
    {
        var address = await _bscApi.BSCBlockchainWithHttpInfo.EthGenerateAddressWithHttpInfoAsync(_testData.TestXPub, 0);
        
        await Verifier.Verify(address);
    }

    [Fact]
    public async Task GenerateAddressWithHttpInfo_ShouldReturnNotSuccessApiResponse_WhenCalledWithInvalidData()
    {
        var address = await _bscApi.BSCBlockchainWithHttpInfo.EthGenerateAddressWithHttpInfoAsync("some random text", 0);

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
        var address = await _bscApi.BSCBlockchain.EthGenerateAddressAsync(_testData.TestXPub, 0);
        var addressLocal = _bscApi.Local.GenerateAddress(_testData.TestXPub, 0);

        address.Address.Should().Be(addressLocal.Address.ToLower());
    }

    [Fact]
    public async Task GenerateAddressPrivateKey_ShouldReturnPrivateKey_WhenCalledWithValidData()
    {
        var privKey = await _bscApi.BSCBlockchain.EthGenerateAddressPrivateKeyAsync(new PrivKeyRequest(0, _testData.TestMnemonic));

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
        
        var privKey = await _bscApi.BSCBlockchain.EthGenerateAddressPrivateKeyAsync(privKeyRequest);
        var privKeyLocal = _bscApi.Local.GenerateAddressPrivateKey(privKeyRequest);

        privKey.Key.Should().Be(privKeyLocal.Key);
    }

    [Fact]
    public async Task GetCurrentBlock_ShouldReturnBlockNumber_WhenCalledWithoutData()
    {
        var blockNumber = await _bscApi.BSCBlockchain.EthGetCurrentBlockAsync();

        blockNumber.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task GetBlock_ShouldReturnBlockData_WhenCalledWithCorrectBlockNumber()
    {
        var block = await _bscApi.BSCBlockchain.EthGetBlockAsync("0");

        await Verifier.Verify(block);
    }

    [Fact]
    public async Task GetBalance_ShouldReturnValue_WhenCalledOnExistingAccount()
    {
        var accountBalance = await _bscApi.BSCBlockchain.EthGetBalanceAsync(_testData.StorageAddress);

        accountBalance.Balance.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task EthBlockchainTransfer_ShouldReturnTransactionHash_WhenCalledWithValidData()
    {
        var amount = 0.00005m;

        var transactionHash = await _bscApi.BSCBlockchain.EthBlockchainTransferAsync(
            new TransferEthBlockchain(
            null, 
            0, 
            _testData.TargetAddress, 
            TransferEthBlockchain.CurrencyEnum.ETH, 
            null, 
            amount.ToString("0.00000", CultureInfo.InvariantCulture), 
            _testData.StoragePrivKey));

        _debts.Add(_testData.TargetPrivKey, amount);

        transactionHash.TxId.Should().NotBeNullOrWhiteSpace();
        
        await WaitForTransactionSuccess(transactionHash.TxId);
    }

    [Fact]
    public async Task EthGetTransaction_ShouldReturnTransaction_WhenCalledWithValidHash()
    {
        const string txHash = "0x3b525f0cfd92aeecfb80c1eb18c5251a0d259bada603513c4069f59c11e7938a";
        
        var transaction = await _bscApi.BSCBlockchain.EthGetTransactionAsync(txHash);

        await Verifier.Verify(transaction);
    }

    [Fact]
    public async Task EthGetTransactionCount_ShouldReturnPositiveNumber_WhenCalledOnExistingAccount()
    {
        var accountBalance = await _bscApi.BSCBlockchain.EthGetTransactionCountAsync(_testData.StorageAddress);

        accountBalance.Should().BeGreaterThan(0);
    }

    [Fact]
    public async Task EthGetTransactionByAddress_ShouldReturnTransactionList_WhenCalledOnWithValidAddress()
    {
        var transaction = await _bscApi.BSCBlockchain.EthGetTransactionByAddressAsync(_testData.StorageAddress, 10);

        transaction.Should()
            .NotBeNull()
            .And.NotBeEmpty()
            .And.HaveCountGreaterThan(0);
    }

    [Fact]
    public async Task EthGetInternalTransactionByAddress_ShouldReturnTransactionList_WhenCalledOnWithValidAddress()
    {
        const string address = "0xAE682DFa32be2a60840a1499608Cb06F6E94F440";
        
        var transaction = await _bscApi.BSCBlockchain.EthGetInternalTransactionByAddressAsync(address, 10);

        transaction.Should()
            .NotBeNull()
            .And.NotBeEmpty()
            .And.HaveCountGreaterThan(0);
    }

    [Fact]
    public async Task EthBlockchainSmartContractInvocation_ShouldReturnTransactionHash_WhenCalledOnWithValidPayload()
    {
        const string contractAddress = "0xf659eb344f8226331a7c85778c4d02847e120d96";
        
        var callSmartContractMethod = new CallSmartContractMethod(
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
            new List<object>
            {
                "0x811dfbff13adfbc3cf653dcc373c03616d3471c9",
                "0x8c76887d2e738371bd750362fb55887343472346", 
                "1"
            },
            null,
            _testData.StoragePrivKey,
            0,
            new CustomFee("100000", "3")
        );
        
        var transaction = await _bscApi.BSCBlockchain.EthBlockchainSmartContractInvocationAsync(callSmartContractMethod);

        transaction.TxId.Should().NotBeNullOrWhiteSpace();
        
        await WaitForTransactionSuccess(transaction.TxId);
    }

    [Fact]
    public async Task EthBlockchainSmartContractInvocation_ShouldReturnData_WhenCalledOnWithValidPayload()
    {
        const string contractAddress = "0x485eac12e9dcf596358a2708437bfbf42040544c";
        
        var callReadSmartContractMethod = new CallReadSmartContractMethod(
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
            new List<object>
            {
                "0x9ac64cc6e4415144c455bd8e4837fea55603e5c3"
            }
        );
        
        var data = await _bscApi.BSCBlockchain.EthBlockchainSmartContractInvocationAsync(callReadSmartContractMethod);

        data._Data.Should().Be("0");
    }

    [Fact]
    public async Task EthBroadcastAsync_ShouldReturnTransactionHash_WhenCalledOnSignedTransaction()
    {
        var txCount = await _bscApi.BSCBlockchain.EthGetTransactionCountAsync(_testData.StorageAddress);
        var transaction = new Transaction
        {
            Type = new HexBigInteger(2),
            From = _testData.StorageAddress,
            To = _testData.TargetAddress,
            GasPrice = new HexBigInteger(1),
            Gas = new HexBigInteger(100000),
            MaxFeePerGas = new HexBigInteger(21000),
            MaxPriorityFeePerGas = new HexBigInteger(300),
            Value = new HexBigInteger(50000000000000),
            Nonce = new HexBigInteger((int)txCount),
            AccessList = new List<AccessList>()
        };

        var account = new Account(_testData.StoragePrivKey, 11155111);
        
        var transactionManager = new AccountOfflineTransactionSigner();
        var transactionInput = transaction.ConvertToTransactionInput();

        var signedTransaction = transactionManager.SignTransaction(account, transactionInput);

        var resultTransaction = await _bscApi.BSCBlockchain.EthBroadcastAsync(new BroadcastKMS("0x" + signedTransaction));

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
                    var tx = await _bscApi.BSCBlockchain.EthGetTransactionAsync(hash,
                        cancellationToken: cts.Token);
                    if (tx.Status)
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
            var result = await _bscApi.BSCBlockchain.EthBlockchainTransferAsync(
                new TransferEthBlockchain(
                    null,
                    0,
                    _testData.StorageAddress,
                    TransferEthBlockchain.CurrencyEnum.ETH,
                    null,
                    debt.Value.ToString("G"),
                    debt.Key));
            
            await WaitForTransactionSuccess(result.TxId);
        }
    }
}