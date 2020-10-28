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
            var info = await bitcoinClient.GetBlock("00000000000000afe6c7bf8e1fdda62295d34da525b5bb214fa1df120e14fff8");
            Assert.Pass();
        }
    }
}