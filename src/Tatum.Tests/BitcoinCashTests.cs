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
    public class BitcoinCashTests
    {
        IBitcoinCashClient bitcoinCashClient;
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

            bitcoinCashClient = new BitcoinCashClient(baseUrl, xApiKey);
        }

        [Test]
        public async Task EndpointTest()
        {
            var response = await bitcoinCashClient.GetBlockchainInfo();
            Assert.Pass();
        }

        [Test]
        public void CreateWalletMainNet()
        {
            string expectedXPub = "xpub6EafivSZvqR8ysLKS52NDKfn16sB9uhCEfCKdYi7PpGqqK3fJGdd53DzUnWYvFRZKAC7pB8FVnvuJKkJparfjjfVPTQTmC7dfC6aVvw6f98";
            Wallet wallet = bitcoinCashClient.CreateWallet(mnemonic, false);

            Assert.That(mnemonic, Is.EqualTo(wallet.Mnemonic));
            Assert.That(expectedXPub, Is.EqualTo(wallet.XPub));
        }

        [Test]
        public void CreateWalletTestNet()
        {
            string expectedTPub = "tpubDExJFAGFe7NbFfXAtG1TRF19LDxq9JCFnHncz6mFjj2jabiNNVUiDUtpipbLSkNo74j2Rke82tkwzWEvDShudB7nT49mSimsF9gzFwTf4nw";
            Wallet wallet = bitcoinCashClient.CreateWallet(mnemonic, true);

            Assert.That(mnemonic, Is.EqualTo(wallet.Mnemonic));
            Assert.That(expectedTPub, Is.EqualTo(wallet.XPub));
        }

        [Test]
        public void GeneratePrivateKeyMainNet()
        {
            string expectedPrivateKey = "KzqM77kK7zqZGockuB2Tov1FXoH6BTMaT3ixeqTPXLAYp838W3KT";
            var privateKey = bitcoinCashClient.GeneratePrivateKey(mnemonic, 1, false);

            Assert.That(expectedPrivateKey, Is.EqualTo(privateKey));
        }

        [Test]
        public void GeneratePrivateKeyTestNet()
        {
            string expectedPrivateKey = "cRCLa2kAZ4XpSF62HaqbBEWKA2aVquTGX5sRmFuu2SpZ4s72vi5Y";
            var privateKey = bitcoinCashClient.GeneratePrivateKey(mnemonic, 1, true);

            Assert.That(expectedPrivateKey, Is.EqualTo(privateKey));
        }

        [Test]
        public void GenerateAddressMainNet()
        {
            string expectedAddress = "bitcoincash:qr9wgjtyjd4q60323gd2ytsv5w3thl92rclzrklply";
            string address = bitcoinCashClient.GenerateAddress("xpub6EafivSZvqR8ysLKS52NDKfn16sB9uhCEfCKdYi7PpGqqK3fJGdd53DzUnWYvFRZKAC7pB8FVnvuJKkJparfjjfVPTQTmC7dfC6aVvw6f98", 1, false);

            Assert.That(expectedAddress, Is.EqualTo(address));
        }

        [Test]
        public void GenerateAddressTestNet()
        {
            string expectedAddress = "bchtest:qr9wgjtyjd4q60323gd2ytsv5w3thl92rcms83akcc";
            string address = bitcoinCashClient.GenerateAddress("tpubDExJFAGFe7NbFfXAtG1TRF19LDxq9JCFnHncz6mFjj2jabiNNVUiDUtpipbLSkNo74j2Rke82tkwzWEvDShudB7nT49mSimsF9gzFwTf4nw", 1, true);

            Assert.That(expectedAddress, Is.EqualTo(address));
        }

        [Test]
        [SetCulture("en-US")]
        public void TransactionFromUtxo()
        {
            var body = new TransferBchBlockchain
            {
                FromUtxos = new List<FromUtxoBcash>
                {
                    new FromUtxoBcash
                    {
                        TxHash = "c98d3d32663b7c659e9768b0cd33b2b50843841dfa5c1af6b67a1caeb0c2b218",
                        Index = 1,
                        PrivateKey = "cSmnhYYG2mXRPvi1FoFDihT4bL5qy9DDhephoubJ7mwxb2sgLNGQ",
                        Value = "0.00096"
                    }
                },
                Tos = new List<To>
                {
                    new To
                    {
                        Address = "bchtest:qq66lcjtj40fvlhmfpkgu85hujsssear4q6g3z03g8",
                        Value = 0.00001m
                    },
                    new To
                    {
                        Address = "bchtest:qqp855jnqaguq9jjnxumsvv8gmph88nnqvkamae0pz",
                        Value = 0.00094m
                    }
                }
            };

            var txData = bitcoinCashClient.PrepareSignedTransaction(body, true);
            var expectedTxData = "010000000118b2c2b0ae1c7ab6f61a5cfa1d844308b5b233cdb068979e657c3b66323d8dc9010000006a473044022005afb0775ef33ccf0738f34ff024c8a498f8902f84450234ddc8766bd5ddbe86022034227a83416a347c09bfe2b1d6d905e19a17a5ebeb5c3ebc5ef2b7b53aaa8f6d412102de7edfed42e7b8166ffb37451595183435ab46e5fa715d7ffe77da90a238df87ffffffff02e8030000000000001976a91435afe24b955e967efb486c8e1e97e4a10867a3a888ac306f0100000000001976a914027a52530751c0165299b9b8318746c3739e730388ac00000000";
            Assert.That(expectedTxData, Is.EqualTo(txData));
        }

        [Test]
        [SetCulture("en-US")]
        public void MissingTo()
        {
            var body = new TransferBchBlockchain
            {
                FromUtxos = new List<FromUtxoBcash>
                {
                    new FromUtxoBcash
                    {
                        TxHash = "c98d3d32663b7c659e9768b0cd33b2b50843841dfa5c1af6b67a1caeb0c2b218",
                        Index = 1,
                        PrivateKey = "cSmnhYYG2mXRPvi1FoFDihT4bL5qy9DDhephoubJ7mwxb2sgLNGQ",
                        Value = "0.00096"
                    }
                }
            };

            Assert.That(
                () => bitcoinCashClient.PrepareSignedTransaction(body, true),
                Throws.TypeOf<ValidationException>()
                    .With
                    .Message
                    .EqualTo("Tos can not be empty."));
        }
    }
}
