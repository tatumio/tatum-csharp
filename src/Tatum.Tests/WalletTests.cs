using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.IO;
using Tatum.Clients;

namespace Tatum.Tests
{
    public class WalletTests
    {
        IBitcoinClient bitcoinClient;
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

            bitcoinClient = new BitcoinClient(baseUrl, xApiKey);
        }

        [Test]
        public void CreateBitcoinWalletMainNet()
        {
            string expectedXPub = "xpub6DtevPxud8AJUCqddtVqpqxAJvjFrYYvtt4co2kZF7ifPW3d5FJ3B9i5x7xL4CZirb2eNDEVqCtBgiGZR6Kkee5RdHsDoJVbtxi946axjXJ";
            Wallet wallet = bitcoinClient.CreateWallet(mnemonic, false);

            Assert.That(mnemonic, Is.EqualTo(wallet.Mnemonic));
            Assert.That(expectedXPub, Is.EqualTo(wallet.XPub));
        }

        [Test]
        public void CreateBitcoinWalletTestNet()
        {
            string expectedTPub = "tpubDFjLw3ykn4aB7fFt96FaqRjSnvtDsU2wpVr8GQk3Eo612LS9jo9JgMkQRfYVG248J3pTBsxGg3PYUXFd7pReNLTeUzxFcUDL3zCvrp3H34a";
            Wallet wallet = bitcoinClient.CreateWallet(mnemonic, true);

            Assert.That(mnemonic, Is.EqualTo(wallet.Mnemonic));
            Assert.That(expectedTPub, Is.EqualTo(wallet.XPub));
        }
    }
}
