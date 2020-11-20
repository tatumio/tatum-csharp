using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Tatum.Clients;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

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
        public async Task EndpointTest()
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
        public async Task TransactionFromUtxo()
        {
            var body = new TransferBtcBasedBlockchain
            {
                FromUtxos = new List<FromUtxo>
                {
                    new FromUtxo
                    {
                        TxHash = "060d1bde52949044971b056aaec807e1189ca80db4d06e90d4f312a610de2aee",
                        Index = 0,
                        PrivateKey = "cSmnhYYG2mXRPvi1FoFDihT4bL5qy9DDhephoubJ7mwxb2sgLNGQ"
                    }
                },
                Tos = new List<To>
                {
                    new To
                    {
                        Address = "mkQporSV7myJLwfWEVyHMhphY9viiiEMWc",
                        Value = 0.00005m
                    }
                }
            };

            var txData = await bitcoinClient.PrepareSignedTransaction(body, true);
            var expectedTxData = "0100000001ee2ade10a612f3d4906ed0b40da89c18e107c8ae6a051b9744909452de1b0d06000000006a47304402204b3ecd334f1a179ce0e3697a53327853d6768226b95c50bad220096886c22bb3022014d80b20c3de681a496c8b9d5e33871ee53a0d04a23df388fa0c9bf6c9594c0d012102de7edfed42e7b8166ffb37451595183435ab46e5fa715d7ffe77da90a238df87ffffffff0188130000000000001976a91435afe24b955e967efb486c8e1e97e4a10867a3a888ac00000000";
            Assert.That(expectedTxData, Is.EqualTo(txData));
        }

        [Test]
        public async Task TransactionFromAddress()
        {
            var body = new TransferBtcBasedBlockchain
            {
                FromAddresses = new List<FromAddress>
                {
                    new FromAddress
                    {
                        Address = "mfk4BVNg4p4m7qPx3u398otHT97M9hotPR",
                        PrivateKey = "cSmnhYYG2mXRPvi1FoFDihT4bL5qy9DDhephoubJ7mwxb2sgLNGQ"
                    }
                },
                Tos = new List<To>
                {
                    new To
                    {
                        Address = "mkQporSV7myJLwfWEVyHMhphY9viiiEMWc",
                        Value = 0.00005m
                    }
                }
            };

            var txData = await bitcoinClient.PrepareSignedTransaction(body, true);
            var expectedTxData = "0100000001ee2ade10a612f3d4906ed0b40da89c18e107c8ae6a051b9744909452de1b0d06000000006a47304402204b3ecd334f1a179ce0e3697a53327853d6768226b95c50bad220096886c22bb3022014d80b20c3de681a496c8b9d5e33871ee53a0d04a23df388fa0c9bf6c9594c0d012102de7edfed42e7b8166ffb37451595183435ab46e5fa715d7ffe77da90a238df87ffffffff0188130000000000001976a91435afe24b955e967efb486c8e1e97e4a10867a3a888ac00000000";            
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