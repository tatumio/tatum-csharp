using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3.Accounts;
using Tatum.CSharp.Core.Api;
using Tatum.CSharp.Core.Client;
using Tatum.CSharp.Core.Model;
using Tatum.CSharp.Sdk.Clients;
using VerifyTests;
using VerifyXunit;
using Xunit;
using Transaction = Nethereum.RPC.Eth.DTOs.Transaction;

namespace Tatum.CSharp.Ethereum.Tests.Integration.Clients;

[UsesVerify]
public class EthereumApiTests : IAsyncDisposable
{
    private readonly IEthereumClient _ethereumApi;
    private readonly Dictionary<string, decimal> _debts = new();
    
    //Test Wallet:
    private const string TestMnemonic = "index diary once pigeon gather minor patient climb army funny end fortune amazing asset bounce assault stage bunker advice enroll leisure gate cake brush";
    private const string TestXPub = "xpub6F4jPr6xTbTqhdvWc9nBYCEEVQ9nYpG9jZmfm8JbNUxwseRPaUpVXmJLgGsgM6CKA5qzF4BygWNyZYvy9nBqJVvFvFVSvMyEQa38HomHj5W";
    
    //Eth storage:
    private const string StorageAddress = "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380";
    private const string StoragePrivKey = "0xf90c7ab9522a7e525349a9b9113e0758c7caeefbaaa69bcf6fd915a8c2e34d0e";
    
    //Target wallet:
    private const string TargetAddress = "0xd9cfbfe18fb9bf3871da5528061582ec08b97166";
    private const string TargetPrivKey = "0x14f391a24ebb50e9792362750429c178c7702e5d00ac7fb3d27d58e85ea1c0e8";

    
    public EthereumApiTests()
    {
        _ethereumApi = new EthereumClient(new HttpClient(), true);
        _ethereumApi.EthereumBlockchain.Configuration.ApiKey.Add("x-api-key", "798811c7-5e96-471a-8244-98f750dd8512");
        VerifierSettings.IgnoreMember<ApiResponse<GeneratedAddress>>(x => x.Headers);
    }

    [Fact]
    public async Task GenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithoutData()
    {
        var wallet = await _ethereumApi.EthereumBlockchain.EthGenerateWalletAsync();

        wallet.Mnemonic.Should().NotBeNullOrWhiteSpace();
        wallet.Xpub.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async Task GenerateWalletWithHttpInfo_ShouldReturnXpuAndMnemonic_WhenCalledWithoutData()
    {
        var response = await _ethereumApi.EthereumBlockchainWithHttpInfo.EthGenerateWalletWithHttpInfoAsync();

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Data.Mnemonic.Should().NotBeNullOrWhiteSpace();
        response.Data.Xpub.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async Task GenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithMnemonic()
    {
        var wallet = await _ethereumApi.EthereumBlockchain.EthGenerateWalletAsync(TestMnemonic);

        wallet.Mnemonic.Should().Be(TestMnemonic);
        wallet.Xpub.Should().Be(TestXPub);
    }
    
    [Fact]
    public async Task GenerateWalletWithHttpInfo_ShouldReturnXpuAndMnemonic_WhenCalledWithMnemonic()
    {
        var response = await _ethereumApi.EthereumBlockchainWithHttpInfo.EthGenerateWalletWithHttpInfoAsync(TestMnemonic);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Data.Mnemonic.Should().Be(TestMnemonic);
        response.Data.Xpub.Should().Be(TestXPub);
    }

    [Fact]
    public void LocalGenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithoutData()
    {
        var wallet = _ethereumApi.Local.EthGenerateWallet();

        wallet.Mnemonic.Should().NotBeNullOrWhiteSpace();
        wallet.Xpub.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public void LocalGenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithMnemonic()
    {
        var wallet = _ethereumApi.Local.EthGenerateWallet(TestMnemonic);

        wallet.Mnemonic.Should().Be(TestMnemonic);
        wallet.Xpub.Should().Be(TestXPub);
    }
    
    [Fact]
    public async Task GenerateAddress_ShouldReturnAddress_WhenCalledWithValidData()
    {
        var address = await _ethereumApi.EthereumBlockchain.EthGenerateAddressAsync(TestXPub, 0);

        await Verifier.Verify(address);
    }
    
    [Fact]
    public void GenerateAddress_ShouldThrowApiException_WhenCalledWithInvalidXpub()
    {
        Func<Task> action = async () => await _ethereumApi.EthereumBlockchain.EthGenerateAddressAsync("some random text", 0);

        action.Should().ThrowAsync<ApiException>()
            .WithMessage("Unable to generate address for some random text.");
    }
    
    [Fact]
    public async Task GenerateAddressWithHttpInfo_ShouldReturnAddress_WhenCalledWithValidData()
    {
        var address = await _ethereumApi.EthereumBlockchainWithHttpInfo.EthGenerateAddressWithHttpInfoAsync(TestXPub, 0);
        
        await Verifier.Verify(address);
    }
    
    [Fact]
    public async Task GenerateAddressWithHttpInfo_ShouldReturnNotSuccessApiResponse_WhenCalledWithInvalidData()
    {
        var address = await _ethereumApi.EthereumBlockchainWithHttpInfo.EthGenerateAddressWithHttpInfoAsync("some random text", 0);

        await Verifier.Verify(address);
    }
    
    [Fact]
    public async Task LocalGenerateAddress_ShouldReturnAddress_WhenCalledWithValidData()
    {
        var address = _ethereumApi.Local.EthGenerateAddress(TestXPub, 0);

        await Verifier.Verify(address);
    }
    
    [Fact]
    public void LocalGenerateAddress_ShouldThrowInvalidFormatException_WhenCalledWithInvalidXpub()
    {
        var action = () => _ethereumApi.Local.EthGenerateAddress("some random text", 0);

        action.Should().Throw<FormatException>()
            .WithMessage("Invalid base58 data");
    }
    
    [Fact]
    public async Task GenerateAddress_ShouldReturnSameAddress_WhenCalledWithSameDataOnLocal()
    {
        var address = await _ethereumApi.EthereumBlockchain.EthGenerateAddressAsync(TestXPub, 0);
        var addressLocal = _ethereumApi.Local.EthGenerateAddress(TestXPub, 0);

        address.Address.Should().Be(addressLocal.Address.ToLower());
    }
    
    [Fact]
    public async Task GenerateAddressPrivateKey_ShouldReturnPrivateKey_WhenCalledWithValidData()
    {
        var privKey = await _ethereumApi.EthereumBlockchain.EthGenerateAddressPrivateKeyAsync(new PrivKeyRequest(0, TestMnemonic));

        await Verifier.Verify(privKey);
    }
    
    [Fact]
    public async Task LocalGenerateAddressPrivateKey_ShouldReturnPrivateKey_WhenCalledWithValidData()
    {
        var privKey = _ethereumApi.Local.EthGenerateAddressPrivateKey(new PrivKeyRequest(0, TestMnemonic));

        await Verifier.Verify(privKey);
    }
    
    [Fact]
    public async Task GenerateAddressPrivateKey_ShouldReturnSamePrivateKey_WhenCalledWithSameDataOnLocal()
    {
        var privKeyRequest = new PrivKeyRequest(0, TestMnemonic);
        
        var privKey = await _ethereumApi.EthereumBlockchain.EthGenerateAddressPrivateKeyAsync(privKeyRequest);
        var privKeyLocal = _ethereumApi.Local.EthGenerateAddressPrivateKey(privKeyRequest);

        privKey.Key.Should().Be(privKeyLocal.Key);
    }
    
    [Fact]
    public async Task GetCurrentBlock_ShouldReturnBlockNumber_WhenCalledWithoutData()
    {
        var blockNumber = await _ethereumApi.EthereumBlockchain.EthGetCurrentBlockAsync();

        blockNumber.Should().BeGreaterThan(0);
    }
    
    [Fact]
    public async Task GetBlock_ShouldReturnBlockData_WhenCalledWithCorrectBlockNumber()
    {
        var block = await _ethereumApi.EthereumBlockchain.EthGetBlockAsync("0");

        await Verifier.Verify(block);
    }
    
    [Fact]
    public async Task GetBalance_ShouldReturnValue_WhenCalledOnExistingAccount()
    {
        var walletAddress = "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380";
        
        var accountBalance = await _ethereumApi.EthereumBlockchain.EthGetBalanceAsync(walletAddress);

        accountBalance.Balance.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async Task EthBlockchainTransfer_ShouldReturnTransactionHash_WhenCalledWithValidData()
    {
        var amount = 0.00005m;

        var transactionHash = await _ethereumApi.EthereumBlockchain.EthBlockchainTransferAsync(
            new TransferEthBlockchain(
            null, 
            0, 
            TargetAddress, 
            TransferEthBlockchain.CurrencyEnum.ETH, 
            null, 
            amount.ToString("0.00000", CultureInfo.InvariantCulture), 
            StoragePrivKey));

        _debts.Add(TargetPrivKey, amount);

        transactionHash.TxId.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async Task EthGetTransaction_ShouldReturnTransaction_WhenCalledWithValidHash()
    {
        var txHash = "0x3b525f0cfd92aeecfb80c1eb18c5251a0d259bada603513c4069f59c11e7938a";
        
        var transaction = await _ethereumApi.EthereumBlockchain.EthGetTransactionAsync(txHash);

        await Verifier.Verify(transaction);
    }
    
    [Fact]
    public async Task EthGetTransactionCount_ShouldReturnPositiveNumber_WhenCalledOnExistingAccount()
    {
        var walletAddress = "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380";
        
        var accountBalance = await _ethereumApi.EthereumBlockchain.EthGetTransactionCountAsync(walletAddress);

        accountBalance.Should().BeGreaterThan(0);
    }
    
    [Fact]
    public async Task EthGetTransactionByAddress_ShouldReturnTransactionList_WhenCalledOnWithValidAddress()
    {
        var address = "0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380";
        
        var transaction = await _ethereumApi.EthereumBlockchain.EthGetTransactionByAddressAsync(address, 10);

        transaction.Should()
            .NotBeNull()
            .And.NotBeEmpty()
            .And.HaveCountGreaterThan(0);
    }
    
    [Fact]
    public async Task EthGetInternalTransactionByAddress_ShouldReturnTransactionList_WhenCalledOnWithValidAddress()
    {
        var address = "0xAE682DFa32be2a60840a1499608Cb06F6E94F440";
        
        var transaction = await _ethereumApi.EthereumBlockchain.EthGetInternalTransactionByAddressAsync(address, 10);

        transaction.Should()
            .NotBeNull()
            .And.NotBeEmpty()
            .And.HaveCountGreaterThan(0);
    }
    
    [Fact]
    public async Task EthBlockchainSmartContractInvocation_ShouldReturnTransactionHash_WhenCalledOnWithValidPayload()
    {
        var contractAddress = "0xf659eb344f8226331a7c85778c4d02847e120d96";
        
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
            "0xf90c7ab9522a7e525349a9b9113e0758c7caeefbaaa69bcf6fd915a8c2e34d0e",
            0,
            new
            {
                gasLimit = "100000", 
                gasPrice = "3"
            }
        );
        
        var transaction = await _ethereumApi.EthereumBlockchain.EthBlockchainSmartContractInvocationAsync(callSmartContractMethod);

        transaction.TxId.Should().NotBeNullOrWhiteSpace();
    }
    
    [Fact]
    public async Task EthBlockchainSmartContractInvocation_ShouldReturnData_WhenCalledOnWithValidPayload()
    {
        var contractAddress = "0x485eac12e9dcf596358a2708437bfbf42040544c";
        
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
        
        var data = await _ethereumApi.EthereumBlockchain.EthBlockchainSmartContractInvocationAsync(callReadSmartContractMethod);

        data._Data.Should().Be("0");
    }
    
    [Fact]
    public async Task EthBroadcastAsync_ShouldReturnTransactionHash_WhenCalledOnSignedTransaction()
    {
        var txCount = await _ethereumApi.EthereumBlockchain.EthGetTransactionCountAsync("0x2be3e0a7fc9c0d0592ea49b05dde7f28baf8e380");
        var transaction = new Transaction
        {
            Type = new HexBigInteger(2),
            From = StorageAddress,
            To = TargetAddress,
            GasPrice = new HexBigInteger(1),
            Gas = new HexBigInteger(100000),
            MaxFeePerGas = new HexBigInteger(21000),
            MaxPriorityFeePerGas = new HexBigInteger(300),
            Value = new HexBigInteger(50000000000000),
            Nonce = new HexBigInteger((int)txCount + 1),
            AccessList = new List<AccessList>()
        };

        var account = new Account(StoragePrivKey, 11155111);

        var signedTransaction = _ethereumApi.Local.EthSignTransaction(transaction, account);

        var resultTransaction = await _ethereumApi.EthereumBlockchain.EthBroadcastAsync(new BroadcastKMS("0x" + signedTransaction));

        _debts.Add(TargetPrivKey, 0.00005M);
        
        resultTransaction.TxId.Should().NotBeNullOrWhiteSpace();
    }
    
    public async ValueTask DisposeAsync()
    {
        await PayDebts();
    }

    private async Task PayDebts()
    {
        foreach (var debt in _debts)
        {
            await _ethereumApi.EthereumBlockchain.EthBlockchainTransferAsync(
                new TransferEthBlockchain(
                    null,
                    0,
                    StorageAddress,
                    TransferEthBlockchain.CurrencyEnum.ETH,
                    null,
                    debt.Value.ToString("G"),
                    debt.Key));
        }
    }
}