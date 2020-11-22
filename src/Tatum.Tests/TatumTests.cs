using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.IO;
using Tatum.Clients;

namespace Tatum.Tests
{
    public class TatumTests
    {
        ITatumClient tatumClient;

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

            tatumClient = new TatumClient(baseUrl, xApiKey);
        }

        [Test]
        public void EndpointTest()
        {
            var credits = tatumClient.GetCreditUsageForLastMonth();
        }
    }
}
