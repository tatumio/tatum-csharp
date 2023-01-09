using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3.Accounts;
using Tatum.CSharp.Evm.Local.Models;
using Tatum.CSharp.Polygon.Clients;
using Tatum.CSharp.Polygon.Core.Client;
using Tatum.CSharp.Polygon.Core.Model;
using Tatum.CSharp.Polygon.Tests.Integration.TestDataModels;
using Tatum.CSharp.Utils.DebugMode;
using VerifyTests;
using VerifyXunit;
using Xunit;
using Transaction = Nethereum.RPC.Eth.DTOs.Transaction;

namespace Tatum.CSharp.Polygon.Tests.Integration.Clients;

[UsesVerify]
[Collection("Polygon")]
public class PolygonApiTests : IAsyncDisposable
{
    private readonly IPolygonClient _polygonApi;
    private readonly Dictionary<string, decimal> _debts = new();

    private readonly PolygonTestData _testData;

    public PolygonApiTests()
    {
        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        var secrets = Environment.GetEnvironmentVariable("TEST_DATA");

        _testData = JsonSerializer.Deserialize<TestData>(secrets!)?.PolygonTestData;

        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();
        
        _polygonApi = new PolygonClient(new HttpClient(httpClient), apiKey, true);
        VerifierSettings.IgnoreMember<ApiResponse<GeneratedAddressMatic>>(x => x.Headers);
    }
    
    [Fact]
    public async Task GenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithoutData()
    {
        var wallet = await _polygonApi.PolygonBlockchain.PolygonGenerateWalletAsync();
    
        wallet.Mnemonic.Should().NotBeNullOrWhiteSpace();
        wallet.Xpub.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async Task GenerateWalletWithHttpInfo_ShouldReturnXpuAndMnemonic_WhenCalledWithoutData()
    {
        var response = await _polygonApi.PolygonBlockchainWithHttpInfo.PolygonGenerateWalletWithHttpInfoAsync();
    
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Data.Mnemonic.Should().NotBeNullOrWhiteSpace();
        response.Data.Xpub.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async Task GenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithMnemonic()
    {
        var wallet = await _polygonApi.PolygonBlockchain.PolygonGenerateWalletAsync(_testData.TestMnemonic);
    
        wallet.Mnemonic.Should().Be(_testData.TestMnemonic);
        wallet.Xpub.Should().Be(_testData.TestXPub);
    }
    
    [Fact]
    public async Task GenerateWalletWithHttpInfo_ShouldReturnXpuAndMnemonic_WhenCalledWithMnemonic()
    {
        var response = await _polygonApi.PolygonBlockchainWithHttpInfo.PolygonGenerateWalletWithHttpInfoAsync(_testData.TestMnemonic);
    
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Data.Mnemonic.Should().Be(_testData.TestMnemonic);
        response.Data.Xpub.Should().Be(_testData.TestXPub);
    }
    
    [Fact]
    public void LocalGenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithoutData()
    {
        var wallet = _polygonApi.Local.GenerateWallet();
    
        wallet.Mnemonic.Should().NotBeNullOrWhiteSpace();
        wallet.Xpub.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public void LocalGenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithMnemonic()
    {
        var wallet = _polygonApi.Local.GenerateWallet(_testData.TestMnemonic);
    
        wallet.Mnemonic.Should().Be(_testData.TestMnemonic);
        wallet.Xpub.Should().Be(_testData.TestXPub);
    }
    
    [Fact]
    public async Task GenerateAddress_ShouldReturnAddress_WhenCalledWithValidData()
    {
        var address = await _polygonApi.PolygonBlockchain.PolygonGenerateAddressAsync(_testData.TestXPub, 0);
    
        await Verifier.Verify(address);
    }
    
    [Fact]
    public void GenerateAddress_ShouldThrowApiException_WhenCalledWithInvalidXpub()
    {
        Func<Task> action = async () => await _polygonApi.PolygonBlockchain.PolygonGenerateAddressAsync("some random text", 0);
    
        action.Should().ThrowAsync<ApiException>()
            .WithMessage("Unable to generate address for some random text.");
    }
    
    [Fact]
    public async Task GenerateAddressWithHttpInfo_ShouldReturnAddress_WhenCalledWithValidData()
    {
        var address = await _polygonApi.PolygonBlockchainWithHttpInfo.PolygonGenerateAddressWithHttpInfoAsync(_testData.TestXPub, 0);
        
        await Verifier.Verify(address);
    }
    
    [Fact]
    public async Task GenerateAddressWithHttpInfo_ShouldReturnNotSuccessApiResponse_WhenCalledWithInvalidData()
    {
        var address = await _polygonApi.PolygonBlockchainWithHttpInfo.PolygonGenerateAddressWithHttpInfoAsync("some random text", 0);
    
        await Verifier.Verify(address);
    }
    
    [Fact]
    public async Task LocalGenerateAddress_ShouldReturnAddress_WhenCalledWithValidData()
    {
        var address = _polygonApi.Local.GenerateAddress(_testData.TestXPub, 0);
    
        await Verifier.Verify(address);
    }
    
    [Fact]
    public void LocalGenerateAddress_ShouldThrowInvalidFormatException_WhenCalledWithInvalidXpub()
    {
        var action = () => _polygonApi.Local.GenerateAddress("some random text", 0);
    
        action.Should().Throw<FormatException>()
            .WithMessage("Invalid base58 data");
    }
    
    [Fact]
    public async Task GenerateAddress_ShouldReturnSameAddress_WhenCalledWithSameDataOnLocal()
    {
        var address = await _polygonApi.PolygonBlockchain.PolygonGenerateAddressAsync(_testData.TestXPub, 0);
        var addressLocal = _polygonApi.Local.GenerateAddress(_testData.TestXPub, 0);
    
        address.Address.Should().Be(addressLocal.Address.ToLower());
    }
    
    [Fact]
    public async Task GenerateAddressPrivateKey_ShouldReturnPrivateKey_WhenCalledWithValidData()
    {
        var privKey = await _polygonApi.PolygonBlockchain.PolygonGenerateAddressPrivateKeyAsync(new PrivKeyRequest(0, _testData.TestMnemonic));
    
        await Verifier.Verify(privKey);
    }
    
    [Fact]
    public async Task LocalGenerateAddressPrivateKey_ShouldReturnPrivateKey_WhenCalledWithValidData()
    {
        var privKey = _polygonApi.Local.GenerateAddressPrivateKey(new PrivKeyRequestLocal(0, _testData.TestMnemonic));
    
        await Verifier.Verify(privKey);
    }
    
    [Fact]
    public async Task GenerateAddressPrivateKey_ShouldReturnSamePrivateKey_WhenCalledWithSameDataOnLocal()
    {
        var privKeyRequest = new PrivKeyRequest(0, _testData.TestMnemonic);
        var privKeyRequestLocal = new PrivKeyRequestLocal(0, _testData.TestMnemonic);
        
        var privKey = await _polygonApi.PolygonBlockchain.PolygonGenerateAddressPrivateKeyAsync(privKeyRequest);
        var privKeyLocal = _polygonApi.Local.GenerateAddressPrivateKey(privKeyRequestLocal);
    
        privKey.Key.Should().Be(privKeyLocal.Key);
    }
    
    [Fact]
    public async Task GetCurrentBlock_ShouldReturnBlockNumber_WhenCalledWithoutData()
    {
        var blockNumber = await _polygonApi.PolygonBlockchain.PolygonGetCurrentBlockAsync();
    
        blockNumber.Should().BeGreaterThan(0);
    }
    
    [Fact]
    public async Task GetBlock_ShouldReturnBlockData_WhenCalledWithCorrectBlockNumber()
    {
        var block = await _polygonApi.PolygonBlockchain.PolygonGetBlockAsync("0");
    
        await Verifier.Verify(block);
    }
    
    [Fact]
    public async Task GetBalance_ShouldReturnValue_WhenCalledOnExistingAccount()
    {
        var accountBalance = await _polygonApi.PolygonBlockchain.PolygonGetBalanceAsync(_testData.StorageAddress);
    
        accountBalance.Balance.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async Task EthBlockchainTransfer_ShouldReturnTransactionHash_WhenCalledWithValidData()
    {
        var amount = 0.00005m;
    
        var transactionHash = await _polygonApi.PolygonBlockchain.PolygonBlockchainTransferAsync(
            new TransferPolygonBlockchain(
            null, 
            0, 
            _testData.TargetAddress, 
            TransferPolygonBlockchain.CurrencyEnum.MATIC, 
            null, 
            amount.ToString("0.00000", CultureInfo.InvariantCulture), 
            _testData.StoragePrivKey));
    
        _debts.Add(_testData.TargetPrivKey, amount);
    
        transactionHash.TxId.Should().NotBeNullOrWhiteSpace();
        
        await _polygonApi.Utils.WaitForTransactionAsync(transactionHash.TxId);
    }
    
    [Fact]
    public async Task EthGetTransaction_ShouldReturnTransaction_WhenCalledWithValidHash()
    {
        const string txHash = "0x56c5ea1b1cc9317dc2427b4d373b1a255eb2bad63eab9505a53c4f6d236eba73";
        
        var transaction = await _polygonApi.PolygonBlockchain.PolygonGetTransactionAsync(txHash);
    
        await Verifier.Verify(transaction);
    }
    
    [Fact]
    public async Task EthGetTransactionCount_ShouldReturnPositiveNumber_WhenCalledOnExistingAccount()
    {
        var accountBalance = await _polygonApi.PolygonBlockchain.PolygonGetTransactionCountAsync(_testData.StorageAddress);
    
        accountBalance.Should().BeGreaterThan(0);
    }
    
    [Fact]
    public async Task EthGetTransactionByAddress_ShouldReturnTransactionList_WhenCalledOnWithValidAddress()
    {
        var transaction = await _polygonApi.PolygonBlockchain.PolygonGetTransactionByAddressAsync(_testData.StorageAddress, 10);
    
        transaction.Should()
            .NotBeNull()
            .And.NotBeEmpty()
            .And.HaveCountGreaterThan(0);
    }

    [Fact]
    public async Task EthBlockchainSmartContractInvocation_ShouldReturnTransactionHash_WhenCalledOnWithValidPayload()
    {
        const string contractAddress = "0x87dcbd8e3eae528b50ddb1e94c85f16b30940a62";
        
        var callSmartContractMethod = new CallPolygonSmartContractMethod(
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
                "0xda54cb99712957c10b9f73279c2e84af4ff45ff0",
                "0x409eb7cafdec6aa83a8221b3af227e67841c1c0d", 
                "100"
            },
            _testData.StoragePrivKey,
            0,
            new CustomFee("100000", "3")
        );
        
        var transaction = await _polygonApi.PolygonBlockchain.PolygonBlockchainSmartContractInvocationAsync(callSmartContractMethod);
    
        transaction.TxId.Should().NotBeNullOrWhiteSpace();
        
        await _polygonApi.Utils.WaitForTransactionAsync(transaction.TxId);
    }
    
    [Fact]
    public async Task EthBlockchainSmartContractInvocation_ShouldReturnData_WhenCalledOnWithValidPayload()
    {
        const string contractAddress = "0x87dcbd8e3eae528b50ddb1e94c85f16b30940a62";
        
        var callReadSmartContractMethod = new CallPolygonSmartContractReadMethod(
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
        
        var data = await _polygonApi.PolygonBlockchain.PolygonBlockchainSmartContractInvocationAsync(callReadSmartContractMethod);
    
        data._Data.Should().Be("0");
    }
    
    [Fact]
    public async Task EthBroadcastAsync_ShouldReturnTransactionHash_WhenCalledOnSignedTransaction()
    {
        var txCount = await _polygonApi.PolygonBlockchain.PolygonGetTransactionCountAsync(_testData.StorageAddress);
        var transaction = new Transaction
        {
            Type = new HexBigInteger(2),
            From = _testData.StorageAddress,
            To = _testData.TargetAddress,
            GasPrice = new HexBigInteger(1),
            Gas = new HexBigInteger(100000),
            MaxFeePerGas = new HexBigInteger(21000),
            MaxPriorityFeePerGas = new HexBigInteger(300),
            Value = new HexBigInteger(5000000000000),
            Nonce = new HexBigInteger((int)txCount),
            AccessList = new List<AccessList>()
        };
    
        var account = new Account(_testData.StoragePrivKey, 80001);
        
        var transactionManager = new AccountOfflineTransactionSigner();
        var transactionInput = transaction.ConvertToTransactionInput();
    
        var signedTransaction = transactionManager.SignTransaction(account, transactionInput);
    
        var resultTransaction = await _polygonApi.PolygonBlockchain.PolygonBroadcastAsync(new BroadcastKMS("0x" + signedTransaction));
    
        _debts.Add(_testData.TargetPrivKey, 0.000005M);
        
        resultTransaction.TxId.Should().NotBeNullOrWhiteSpace();
    
        await _polygonApi.Utils.WaitForTransactionAsync(resultTransaction.TxId);
    }
    
    public async ValueTask DisposeAsync()
    {
        await PayDebts();
    }
    
    private async Task PayDebts()
    {
        foreach (var debt in _debts)
        {
            var result = await _polygonApi.PolygonBlockchain.PolygonBlockchainTransferAsync(
                new TransferPolygonBlockchain(
                    null,
                    0,
                    _testData.StorageAddress,
                    TransferPolygonBlockchain.CurrencyEnum.MATIC,
                    null,
                    debt.Value.ToString("G"),
                    debt.Key));
            
            await _polygonApi.Utils.WaitForTransactionAsync(result.TxId);
        }
    }
}