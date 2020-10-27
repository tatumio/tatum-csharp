using NUnit.Framework;
using System.Threading.Tasks;
using Tatum.Blockchain;
using Tatum.Clients;

namespace Tatum.Tests
{
    public class BitcoinTests
    {
        IBitcoinClient bitcoinClient;

        [SetUp]
        public void Setup()
        {
            bitcoinClient = new BitcoinClient("https://api-eu1.tatum.io", "your_api_key");
        }

        [Test]
        public async Task Test1()
        {
            var info = await bitcoinClient.GetBlockchainInfo();
            Assert.Pass();
        }
    }
}