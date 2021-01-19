using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;
using Tatum.Clients;

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
    }
}
