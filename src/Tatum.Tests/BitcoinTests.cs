using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;
using Tatum.Clients;

namespace Tatum.Tests
{
    public class BitcoinTests
    {
        IBitcoinClient bitcoinClient;

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
            var response = await bitcoinClient.GetTransaction("bd5d6f2a606f45be09c28744bc3b707bc885ee6f5ca0bd5e90ff54c0159b958c");
            Assert.Pass();
        }
    }
}