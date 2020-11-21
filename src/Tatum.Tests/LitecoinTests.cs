using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;
using Tatum.Clients;

namespace Tatum.Tests
{
    public class LitecoinTests
    {
        ILitecoinClient litecoinClient;

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
    }
}
