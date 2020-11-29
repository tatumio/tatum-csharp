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
    public class LitecoinTests
    {
        ILitecoinClient litecoinClient;
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

            litecoinClient = new LitecoinClient(baseUrl, xApiKey);

        }

        [Test]
        public async Task EndpointTest()
        {
            var response = await litecoinClient.GetBlockchainInfo();
            Assert.Pass();
        }

        [Test]
        public void CreateWalletMainNet()
        {
            string expectedXPub = "Ltub2aXe9g8RPgAcY6jb6FftNJfQXHMV6UNBeZwrWH1K3vjpua9u8uj95xkZyCC4utdEbfYeh9TwxcUiFy2mGzBCJVBwW3ezHmLX2fHxv7HUt8J";
            Wallet wallet = litecoinClient.CreateWallet(mnemonic, false);

            Assert.That(mnemonic, Is.EqualTo(wallet.Mnemonic));
            Assert.That(expectedXPub, Is.EqualTo(wallet.XPub));
        }

        [Test]
        public void CreateWalletTestNet()
        {
            string expectedTPub = "ttub4giastL5S3AicjXRBEJt7uq22b611rJvVfTgJSRfYeyZkwXwKnZcctK3tEjMpqrgiNSnYAzkKPJDxGoKNWQzkzTJxSryHbaYxsYW9Vr6AYQ";
            Wallet wallet = litecoinClient.CreateWallet(mnemonic, true);

            Assert.That(mnemonic, Is.EqualTo(wallet.Mnemonic));
            Assert.That(expectedTPub, Is.EqualTo(wallet.XPub));
        }

        [Test]
        public void GeneratePrivateKeyMainNet()
        {
            string expectedPrivateKey = "T63MUovVt5GN5rmfwYMr4M6YqFmisjbrZrfZYZ53qWmCwiP6xCHa";
            var privateKey = litecoinClient.GeneratePrivateKey(mnemonic, 1, false);

            Assert.That(expectedPrivateKey, Is.EqualTo(privateKey));
        }

        [Test]
        public void GeneratePrivateKeyTestNet()
        {
            string expectedPrivateKey = "cQ1YZMep3CiAnMTA9y62ha6BjGaaTFsTvtDuGmucGvpAVmS89khV";
            var privateKey = litecoinClient.GeneratePrivateKey(mnemonic, 1, true);

            Assert.That(expectedPrivateKey, Is.EqualTo(privateKey));
        }

        [Test]
        public void GenerateAddressMainNet()
        {
            string expectedAddress = "LepMzqfXSgQommH2qu3fk7Gf5xgoHQsP1b";
            string address = litecoinClient.GenerateAddress("Ltub2aXe9g8RPgAcY6jb6FftNJfQXHMV6UNBeZwrWH1K3vjpua9u8uj95xkZyCC4utdEbfYeh9TwxcUiFy2mGzBCJVBwW3ezHmLX2fHxv7HUt8J", 1, false);

            Assert.That(expectedAddress, Is.EqualTo(address));
        }

        [Test]
        public void GenerateAddressTestNet()
        {
            string expectedAddress = "mjJotvHmzEuyXZJGJXXknS6N3PWQnw6jf5";
            string address = litecoinClient.GenerateAddress("ttub4giastL5S3AicjXRBEJt7uq22b611rJvVfTgJSRfYeyZkwXwKnZcctK3tEjMpqrgiNSnYAzkKPJDxGoKNWQzkzTJxSryHbaYxsYW9Vr6AYQ", 1, true);

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
                        TxHash = "90c5658971b4e27af291a5df6453822fd340c3818c3f5dfc75ffb96d0d290070",
                        Index = 1,
                        PrivateKey = "cSmnhYYG2mXRPvi1FoFDihT4bL5qy9DDhephoubJ7mwxb2sgLNGQ"
                    }
                },
                Tos = new List<To>
                {
                    new To
                    {
                        Address = "mkQporSV7myJLwfWEVyHMhphY9viiiEMWc",
                        Value = 0.00009m
                    },
                    new To
                    {
                        Address = "mfk4BVNg4p4m7qPx3u398otHT97M9hotPR",
                        Value = 0.0012m
                    },
                }
            };

            var txData = await litecoinClient.PrepareSignedTransaction(body, true);
            var expectedTxData = "01000000017000290d6db9ff75fc5d3f8c81c340d32f825364dfa591f27ae2b4718965c590010000006a47304402206c36307583e6a37a950fa57e16095b69c54f4919e9868d89da805fcd5db071490220179201182df4f696567c3fbd68dd6c7426a3015219fc57598afb156748e2e11c012102de7edfed42e7b8166ffb37451595183435ab46e5fa715d7ffe77da90a238df87ffffffff0228230000000000001976a91435afe24b955e967efb486c8e1e97e4a10867a3a888acc0d40100000000001976a914027a52530751c0165299b9b8318746c3739e730388ac00000000";

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
                        Address = "mjJotvHmzEuyXZJGJXXknS6N3PWQnw6jf5",
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
                        Address = "mjJotvHmzEuyXZJGJXXknS6N3PWQnw6jf5",
                        Value = 0.02969944m
                    }
                }
            };

            Assert.That(
                () => litecoinClient.PrepareSignedTransaction(body, true),
                Throws.TypeOf<ValidationException>()
                    .With
                    .Message
                    .EqualTo("Either FromAddresses, or FromUtxos must be present. Not both at the same time."));
        }
    }
}
