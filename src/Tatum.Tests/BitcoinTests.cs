using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Tatum.Clients;
using Tatum.Model.Requests;

namespace Tatum.Tests
{
    public class BitcoinTests
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
        public async Task Test1()
        {
            var response = await bitcoinClient.GetBlockchainInfo();
            Assert.Pass();
        }

        [Test]
        public void CreateWalletMainNet()
        {
            string expectedXPub = "xpub6DtevPxud8AJUCqddtVqpqxAJvjFrYYvtt4co2kZF7ifPW3d5FJ3B9i5x7xL4CZirb2eNDEVqCtBgiGZR6Kkee5RdHsDoJVbtxi946axjXJ";
            Wallet wallet = bitcoinClient.CreateWallet(mnemonic, false);

            Assert.That(mnemonic, Is.EqualTo(wallet.Mnemonic));
            Assert.That(expectedXPub, Is.EqualTo(wallet.XPub));
        }

        [Test]
        public void CreateWalletTestNet()
        {
            string expectedTPub = "tpubDFjLw3ykn4aB7fFt96FaqRjSnvtDsU2wpVr8GQk3Eo612LS9jo9JgMkQRfYVG248J3pTBsxGg3PYUXFd7pReNLTeUzxFcUDL3zCvrp3H34a";
            Wallet wallet = bitcoinClient.CreateWallet(mnemonic, true);

            Assert.That(mnemonic, Is.EqualTo(wallet.Mnemonic));
            Assert.That(expectedTPub, Is.EqualTo(wallet.XPub));
        }

        [Test]
        public void GeneratePrivateKeyMainNet()
        {
            string expectedPrivateKey = "KwrYonf8pFfyQR87NTn124Ep9zoJsZMBCoVUi7mjMc1eTHDyLyBN";
            var privateKey = bitcoinClient.GeneratePrivateKey(mnemonic, 1, false);

            Assert.That(expectedPrivateKey, Is.EqualTo(privateKey));
        }

        [Test]
        public void GeneratePrivateKeyTestNet()
        {
            string expectedPrivateKey = "cQ1YZMep3CiAnMTA9y62ha6BjGaaTFsTvtDuGmucGvpAVmS89khV";
            var privateKey = bitcoinClient.GeneratePrivateKey(mnemonic, 1, true);

            Assert.That(expectedPrivateKey, Is.EqualTo(privateKey));
        }

        [Test]
        public void GenerateAddressMainNet()
        {
            string expectedAddress = "1HWYaP13JKtaW2Mhq69NVeSLjRYGpD3aKv";
            string address = bitcoinClient.GenerateAddress("xpub6EsCk1uU6cJzqvP9CdsTiJwT2rF748YkPnhv5Qo8q44DG7nn2vbyt48YRsNSUYS44jFCW9gwvD9kLQu9AuqXpTpM1c5hgg9PsuBLdeNncid", 1, false);

            Assert.That(expectedAddress, Is.EqualTo(address));
        }

        [Test]
        public void GenerateAddressTestNet()
        {
            string expectedAddress = "mjJotvHmzEuyXZJGJXXknS6N3PWQnw6jf5";
            string address = bitcoinClient.GenerateAddress("tpubDFjLw3ykn4aB7fFt96FaqRjSnvtDsU2wpVr8GQk3Eo612LS9jo9JgMkQRfYVG248J3pTBsxGg3PYUXFd7pReNLTeUzxFcUDL3zCvrp3H34a", 1, true);

            Assert.That(expectedAddress, Is.EqualTo(address));
        }

        [Test]
        public async Task Transactions()
        {
            var body = new TransferBtcBasedBlockchain
            {
                FromUtxos = new List<FromUtxo>
                {
                    new FromUtxo
                    {
                        TxHash = "53faa103e8217e1520f5149a4e8c84aeb58e55bdab11164a95e69a8ca50f8fcc",
                        Index = 0,
                        PrivateKey = "cVX7YtgL5muLTPncHFhP95oitV1mqUUA5VeSn8HeCRJbPqipzobf"
                    }
                },
                Tos = new List<To>
                {
                    new To
                    {
                        Address = "2MzNGwuKvMEvKMQogtgzSqJcH2UW3Tc5oc7",
                        Value = 0.02969944M
                    }
                }
            };

            var txData = await bitcoinClient.PrepareSignedTransaction(body, true);
            string expectedTxData = "0200000001cc8f0fa58c9ae6954a1611abbd558eb5ae848c4e9a14f520157e21e803a1fa53000000006a47304402205e49848369acc41719b669dcc9ba486c570f1ca4974f61a4321329fe35e3ff36022007485588ede47e17db992ba41aef35c72cb292f9889d471f2c592fb7f252672e012103b17a162956975765aa6951f6349f9ab5bf510584c5df9f6065924bfd94a08513ffffffff0158512d000000000017a9144e1e4321307c88ecd4ddd6aeec040c6f01e53c998700000000";

            Assert.That(expectedTxData, Is.EqualTo(txData));
        }

        [Test]
        public void FromAddressAndFromUtxoNotTogether()
        {
            var body = new TransferBtcBasedBlockchain
            {
                FromAddresses = new List<FromAddress>
                {
                    new FromAddress
                    {
                        Address = "2MzNGwuKvMEvKMQogtgzSqJcH2UW3Tc5oc7",
                        PrivateKey = "cVX7YtgL5muLTPncHFhP95oitV1mqUUA5VeSn8HeCRJbPqipzobf"
                    }
                },
                FromUtxos = new List<FromUtxo>
                {
                    new FromUtxo
                    {
                        TxHash = "53faa103e8217e1520f5149a4e8c84aeb58e55bdab11164a95e69a8ca50f8fcc",
                        Index = 0,
                        PrivateKey = "cVX7YtgL5muLTPncHFhP95oitV1mqUUA5VeSn8HeCRJbPqipzobf"
                    }
                },
                Tos = new List<To>
                {
                    new To
                    {
                        Address = "2MzNGwuKvMEvKMQogtgzSqJcH2UW3Tc5oc7",
                        Value = 0.02969944M
                    }
                }
            };

            var validationContext = new ValidationContext(body);

            Assert.That(
                () => Validator.ValidateObject(body, validationContext),
                Throws.TypeOf<ValidationException>()
                    .With
                    .Message
                    .EqualTo("Either FromAddresses, or FromUtxos must be present. Not both at the same time."));
        }
    }
}