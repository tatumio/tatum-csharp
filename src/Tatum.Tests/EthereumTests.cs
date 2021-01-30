using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;
using Tatum.Clients;
using Tatum.Model.Requests;

namespace Tatum.Tests
{
    public class EthereumTests
    {
        IEthereumClient ethereumClient;
        readonly string mnemonic = "quantum tobacco key they maid mean crime youth chief jungle mind design broken tilt bus shoulder leaf good forward erupt split divert bread kitten";

        [SetUp]
        public void Setup()
        {
            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
            .Build();

            string baseUrl = config.GetValue<string>("TatumApiSettings:baseUrl");
            string xApiKey = config.GetValue<string>("TatumApiSettings:xApiKey");
            ethereumClient = EthereumClient.Create(baseUrl, xApiKey);
        }

        [Test]
        public async Task EndpointTest()
        {
            var response = await ethereumClient.GetCurrentBlock();
            Assert.Pass();
        }

        [Test]
        public void CreateWalletMainNet()
        {
            string expectedXPub = "xpub6DtR524VQx3ENj2E9pNZnjqkVp47YN5sRCP5y4Gs6KZTwDhH9HTVX8shJPt74WaPZRftRXFfnsyPbMPh6DMEmrQ2WBxDJzGxriStAB36bQM";
            Wallet wallet = ethereumClient.CreateWallet(mnemonic, false);

            Assert.That(mnemonic, Is.EqualTo(wallet.Mnemonic));
            Assert.That(expectedXPub, Is.EqualTo(wallet.XPub));
        }

        [Test]
        public void CreateWalletTestNet()
        {
            string expectedXPub = "xpub6FMiQpA54nciqs52guGVdWQ5TonZt5XtGsFpurgtttL7H3mSfaJDXv5aBdThjX6tW9HYaJSQ8wZVnLm1ixaQUu1MRQCwvwZ6U2cX6mwWT25";
            Wallet wallet = ethereumClient.CreateWallet(mnemonic, true);

            Assert.That(mnemonic, Is.EqualTo(wallet.Mnemonic));
            Assert.That(expectedXPub, Is.EqualTo(wallet.XPub));
        }

        [Test]
        public void GeneratePrivateKeyMainNet()
        {
            string expectedPrivateKey = "0xbc93ab7d2dbad88e64879569a9e3ceaa12d119c70d6dda4d1fc6e73765794a8d";
            var privateKey = ethereumClient.GeneratePrivateKey(mnemonic, 1, false);

            Assert.That(expectedPrivateKey, Is.EqualTo(privateKey));
        }

        [Test]
        public void GeneratePrivateKeyTestNet()
        {
            string expectedPrivateKey = "0x4874827a55d87f2309c55b835af509e3427aa4d52321eeb49a2b93b5c0f8edfb";
            var privateKey = ethereumClient.GeneratePrivateKey(mnemonic, 1, true);

            Assert.That(expectedPrivateKey, Is.EqualTo(privateKey));
        }

        [Test]
        public void GenerateAddressMainNet()
        {
            string expectedAddress = "0xaac8c73348f1f92b2f9647e1e4f3cf14e2a8b3cb";
            string address = ethereumClient.GenerateAddress("xpub6DtR524VQx3ENj2E9pNZnjqkVp47YN5sRCP5y4Gs6KZTwDhH9HTVX8shJPt74WaPZRftRXFfnsyPbMPh6DMEmrQ2WBxDJzGxriStAB36bQM", 1, false);

            Assert.That(expectedAddress, Is.EqualTo(address));
        }

        [Test]
        public void GenerateAddressTestNet()
        {
            string expectedAddress = "0x8cb76aed9c5e336ef961265c6079c14e9cd3d2ea";
            string address = ethereumClient.GenerateAddress("xpub6FMiQpA54nciqs52guGVdWQ5TonZt5XtGsFpurgtttL7H3mSfaJDXv5aBdThjX6tW9HYaJSQ8wZVnLm1ixaQUu1MRQCwvwZ6U2cX6mwWT25", 1, true);

            Assert.That(expectedAddress, Is.EqualTo(address));
        }

        [Test]
        public async Task Transaction()
        {
            var record = new CreateRecord
            {
                FromPrivateKey = "0x74d4a36458fda84a6ca850cfcf92e68b8334a399d6d24459c4a33acbe0f6ce5b",
                To = "0xbbc1bddbffbba42acb3eced8bf27b64eca104ce0",
                Data = "0x00"
            };

            var response = await ethereumClient.SendStoreDataTransaction(record, true);
        }

        [Test]
        public async Task CustomTransactionERC20()
        {
            var body = new TransferCustomErc20
            {
                FromPrivateKey = "0xdbae9af6f27e26e5171530f304e37dff04e65042e4d684535632c4d23f3e7862",
                Amount = "10000",
                To = "0xbbc1bddbffbba42acb3eced8bf27b64eca104ce0",
                Digits = 10,
                ContractAddress = "0x1d1c481ac62ba3803d55b5a5bc160d88e56a307d",
                Fee = new Fee
                {
                    GasLimit = 3000000,
                    GasPrice = new System.Numerics.BigInteger(1000000000)
                }
            };

            string txHash = await ethereumClient.PrepareCustomErc20SignedTransaction(body, true);

            var request = new BroadcastRequest
            {
                TxData = txHash
            };

            var response = await ethereumClient.BroadcastSignedTransaction(request);
        }

        [Test]
        public async Task DeployEthereumERC20()
        {
            var body = new DeployEthereumErc20
            {
                FromPrivateKey = "0x74d4a36458fda84a6ca850cfcf92e68b8334a399d6d24459c4a33acbe0f6ce5b",
                Symbol = "TTTMX",
                Name = "TestTatumX",
                Supply = "10000000",
                Address = "0x7df6e328b85aab9846b58380b98f7703f3bb495f",
                Digits = 10,
                Fee = new Fee
                {
                    GasLimit = 3000000,
                    GasPrice = new System.Numerics.BigInteger(10000000000)
                }
            };

            string txHash = await ethereumClient.PrepareDeployErc20SignedTransaction(body, true);

            var request = new BroadcastRequest
            {
                TxData = txHash
            };

            var response = await ethereumClient.BroadcastSignedTransaction(request);
        }
    }
}
