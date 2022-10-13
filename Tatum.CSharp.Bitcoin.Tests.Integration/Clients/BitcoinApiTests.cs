using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using NBitcoin;
using Newtonsoft.Json.Linq;
using Tatum.CSharp.Bitcoin.Clients;
using Tatum.CSharp.Core.Client;
using Tatum.CSharp.Core.Model;
using VerifyTests;
using VerifyXunit;
using Xunit;

namespace Tatum.CSharp.Bitcoin.Tests.Integration.Clients;

[UsesVerify]
public class BitcoinApiTests : IAsyncDisposable
{
    private readonly IBitcoinClient _bitcoinApi;
    private readonly Dictionary<string, decimal> _debts = new();

    private readonly BitcoinTestData _testData;

    public BitcoinApiTests()
    {
        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        var secrets = Environment.GetEnvironmentVariable("TEST_DATA");

        _testData = JsonSerializer.Deserialize<TestData>(secrets)?.BitcoinTestData;

        _bitcoinApi = new BitcoinClient(new HttpClient(), apiKey, true);
        VerifierSettings.IgnoreMember<ApiResponse<GeneratedAddress>>(x => x.Headers);
    }

    [Fact]
    public async Task GenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithoutData()
    {
        var wallet = await _bitcoinApi.BitcoinBlockchain.BtcGenerateWalletAsync();

        wallet.Mnemonic.Should().NotBeNullOrWhiteSpace();
        wallet.Xpub.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task GenerateWalletWithHttpInfo_ShouldReturnXpuAndMnemonic_WhenCalledWithoutData()
    {
        var response = await _bitcoinApi.BitcoinBlockchainWithHttpInfo.BtcGenerateWalletWithHttpInfoAsync();

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Data.Mnemonic.Should().NotBeNullOrWhiteSpace();
        response.Data.Xpub.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task GenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithMnemonic()
    {
        var wallet = await _bitcoinApi.BitcoinBlockchain.BtcGenerateWalletAsync(_testData.TestMnemonic);

        wallet.Mnemonic.Should().Be(_testData.TestMnemonic);
        wallet.Xpub.Should().Be(_testData.TestXPub);
    }

    [Fact]
    public async Task GenerateWalletWithHttpInfo_ShouldReturnXpuAndMnemonic_WhenCalledWithMnemonic()
    {
        var response = await _bitcoinApi.BitcoinBlockchainWithHttpInfo.BtcGenerateWalletWithHttpInfoAsync(_testData.TestMnemonic);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Data.Mnemonic.Should().Be(_testData.TestMnemonic);
        response.Data.Xpub.Should().Be(_testData.TestXPub);
    }

    [Fact]
    public void LocalGenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithoutData()
    {
        var wallet = _bitcoinApi.Local.GenerateWallet();

        wallet.Mnemonic.Should().NotBeNullOrWhiteSpace();
        wallet.Xpub.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public void LocalGenerateWallet_ShouldReturnXpuAndMnemonic_WhenCalledWithMnemonic()
    {
        var wallet = _bitcoinApi.Local.GenerateWallet(_testData.TestMnemonic);

        wallet.Mnemonic.Should().Be(_testData.TestMnemonic);
        wallet.Xpub.Should().Be(_testData.TestXPub);
    }

    [Fact]
    public async Task GenerateAddress_ShouldReturnAddress_WhenCalledWithValidData()
    {
        var address = await _bitcoinApi.BitcoinBlockchain.BtcGenerateAddressAsync(_testData.TestXPub, 0);

        await Verifier.Verify(address);
    }

    [Fact]
    public void GenerateAddress_ShouldThrowApiException_WhenCalledWithInvalidXpub()
    {
        Func<Task> action = async () => await _bitcoinApi.BitcoinBlockchain.BtcGenerateAddressAsync("some random text", 0);

        action.Should().ThrowAsync<ApiException>()
            .WithMessage("Unable to generate address for some random text.");
    }

    [Fact]
    public async Task GenerateAddressWithHttpInfo_ShouldReturnAddress_WhenCalledWithValidData()
    {
        var address = await _bitcoinApi.BitcoinBlockchainWithHttpInfo.BtcGenerateAddressWithHttpInfoAsync(_testData.TestXPub, 0);
        
        await Verifier.Verify(address);
    }

    [Fact]
    public async Task GenerateAddressWithHttpInfo_ShouldReturnNotSuccessApiResponse_WhenCalledWithInvalidData()
    {
        var address = await _bitcoinApi.BitcoinBlockchainWithHttpInfo.BtcGenerateAddressWithHttpInfoAsync("some random text", 0);

        await Verifier.Verify(address);
    }

    [Fact]
    public async Task LocalGenerateAddress_ShouldReturnAddress_WhenCalledWithValidData()
    {
        var address = _bitcoinApi.Local.GenerateAddress(_testData.TestXPub, 0);

        await Verifier.Verify(address);
    }

    [Fact]
    public void LocalGenerateAddress_ShouldThrowInvalidFormatException_WhenCalledWithInvalidXpub()
    {
        var action = () => _bitcoinApi.Local.GenerateAddress("some random text", 0);

        action.Should().Throw<FormatException>()
            .WithMessage("Invalid base58 data");
    }

    [Fact]
    public async Task GenerateAddress_ShouldReturnSameAddress_WhenCalledWithSameDataOnLocal()
    {
        var address = await _bitcoinApi.BitcoinBlockchain.BtcGenerateAddressAsync(_testData.TestXPub, 0);
        var addressLocal = _bitcoinApi.Local.GenerateAddress(_testData.TestXPub, 0);

        address.Address.Should().Be(addressLocal.Address.ToLower());
    }

    [Fact]
    public async Task GenerateAddressPrivateKey_ShouldReturnPrivateKey_WhenCalledWithValidData()
    {
        var privKey = await _bitcoinApi.BitcoinBlockchain.BtcGenerateAddressPrivateKeyAsync(new PrivKeyRequest(0, _testData.TestMnemonic));

        await Verifier.Verify(privKey);
    }

    [Fact]
    public async Task LocalGenerateAddressPrivateKey_ShouldReturnPrivateKey_WhenCalledWithValidData()
    {
        var privKey = _bitcoinApi.Local.GenerateAddressPrivateKey(new PrivKeyRequest(0, _testData.TestMnemonic));

        await Verifier.Verify(privKey);
    }

    [Fact]
    public async Task GenerateAddressPrivateKey_ShouldReturnSamePrivateKey_WhenCalledWithSameDataOnLocal()
    {
        var privKeyRequest = new PrivKeyRequest(0, _testData.TestMnemonic);
        
        var privKey = await _bitcoinApi.BitcoinBlockchain.BtcGenerateAddressPrivateKeyAsync(privKeyRequest);
        var privKeyLocal = _bitcoinApi.Local.GenerateAddressPrivateKey(privKeyRequest);

        privKey.Key.Should().Be(privKeyLocal.Key);
    }

    [Fact]
    public async Task GetCurrentBlock_ShouldReturnBlockNumber_WhenCalledWithoutData()
    {
        var btcInfo = await _bitcoinApi.BitcoinBlockchain.BtcGetBlockChainInfoAsync();

        btcInfo.Should().NotBeNull();

        btcInfo.Chain.Should().NotBeNullOrWhiteSpace();
        btcInfo.Blocks.Should().BePositive();
        btcInfo.Headers.Should().BePositive();
        btcInfo.Bestblockhash.Should().NotBeNullOrWhiteSpace();
        btcInfo.Difficulty.Should().BePositive();
    }

    [Fact]
    public async Task GetBlock_ShouldReturnBlockData_WhenCalledWithCorrectBlockNumber()
    {
        var block = await _bitcoinApi.BitcoinBlockchain.BtcGetBlockAsync("0");

        await Verifier.Verify(block);
    }

    [Fact]
    public async Task GetBalance_ShouldReturnValue_WhenCalledOnExistingAccount()
    {
        var accountBalance = await _bitcoinApi.BitcoinBlockchain.BtcGetBalanceOfAddressAsync(_testData.StorageAddress);

        accountBalance.Incoming.Should().NotBeNullOrWhiteSpace();
        accountBalance.Outgoing.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task BtcTransferBlockchainAsync_ShouldReturnTransactionHash_WhenCalledWithValidData()
    {
        var amount = 0.005m;

        var transactionHash = await _bitcoinApi.BitcoinBlockchain.BtcTransferBlockchainAsync(
            new BtcTransactionFromAddress(
                new List<object>()
                {
                    new
                    {
                        address = _testData.StorageAddress,
                        privateKey = _testData.StoragePrivKey
                    }
                },
                new List<object>()
                {
                    new
                    {
                        address = _testData.TargetAddress,
                        value = amount
                    }
                }));

        _debts.Add(_testData.TargetPrivKey, amount);

        transactionHash.TxId.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task BtcGetRawTransactionAsync_ShouldReturnTransaction_WhenCalledWithValidHash()
    {
        var txHash = "fef757bcc18bac04459b263375d2bba9dc2e740b8ccb944999c5eaba2cb809cc";
        
        var transaction = await _bitcoinApi.BitcoinBlockchain.BtcGetRawTransactionAsync(txHash);

        await Verifier.Verify(transaction);
    }

    [Fact]
    public async Task BtcBroadcastAsync_ShouldReturnTransactionHash_WhenCalledOnSignedTransaction()
    {
        var transaction = Transaction
            .Create(Network.TestNet);

        var bitcoinPrivateKey = new BitcoinSecret(_testData.StoragePrivKey, Network.TestNet);
        
        var input = new TxIn(new OutPoint(new uint256("701c5eb2d28c04b619a9adb1501ca19c6d1b28965ecb3d1cda04fe7a01e2385e"), 0));

        //_testData.StorageAddress - hash
        input.ScriptSig = bitcoinPrivateKey.GetAddress(ScriptPubKeyType.Legacy).ScriptPubKey;

        transaction.Inputs.Add(input);

        transaction.Outputs.Add("0.01", BitcoinAddress.Create(_testData.TargetAddress, Network.TestNet).ScriptPubKey);

        var signedTransaction = _bitcoinApi.Local.SignTransaction(transaction, _testData.StoragePrivKey);

        var coins = transaction.Inputs.Select(i => new Coin(i.PrevOut, transaction.Inputs.Transaction.Outputs.CreateNewTxOut(Money.Coins(0.01m), new BitcoinSecret(_testData.StoragePrivKey, Network.TestNet).GetAddress(ScriptPubKeyType.Segwit).ScriptPubKey))).ToArray();

        transaction.Sign(bitcoinPrivateKey, coins);

        var transactions = await _bitcoinApi.BitcoinBlockchain.BtcGetTxByAddressAsync(_testData.StorageAddress, 50);

        //var coins = transactions.Select(tx => tx.Inputs.Select(i => new Coin(new OutPoint(new uint256(((JObject)i["prevout"])))))
        
        transaction = bitcoinPrivateKey.Network.CreateTransactionBuilder()
            .AddCoins(new Coin())
            .AddKeys(new ISecret[] { bitcoinPrivateKey })
            .Send(new BitcoinPubKeyAddress(_testData.TargetAddress, bitcoinPrivateKey.Network), Money.Coins(0.01m))
            .SubtractFees()
            .SendFees(Money.Coins(0.00001m))
            .SetChange(bitcoinPrivateKey)
            .BuildTransaction(true);

        signedTransaction = transaction.ToHex();
        
        var resultTransaction = await _bitcoinApi.BitcoinBlockchain.BtcBroadcastAsync(new BroadcastKMS(signedTransaction));

        _debts.Add(_testData.TargetPrivKey, 0.01m);
        
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
            await _bitcoinApi.BitcoinBlockchain.BtcTransferBlockchainAsync(
                new BtcTransactionFromAddress(
                    new List<object>()
                    {
                        new
                        {
                            Address = _testData.TargetAddress,
                            PrivateKey = debt.Key
                        }
                    },
                    new List<object>()
                    {
                        new
                        {
                            Address = _testData.StorageAddress,
                            Value = debt.Value
                        }
                    }));
        }
    }

    private class TestData
    {
        public BitcoinTestData BitcoinTestData { get; set; }
    }
    
    private class BitcoinTestData
    {
        public string TestMnemonic { get; set; }
        public string TestXPub { get; set; }
        public string StorageAddress { get; set; }
        public string StoragePrivKey { get; set; }
        public string TargetAddress { get; set; }
        public string TargetPrivKey { get; set; }
    }
}
