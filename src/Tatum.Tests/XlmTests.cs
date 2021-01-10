using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;
using Tatum.Clients;

namespace Tatum.Tests
{
    public class XlmTests
    {
        IXlmClient xlmClient;

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
            xlmClient = new XlmClient(baseUrl, xApiKey);
        }

        [Test]
        public async Task EndpointTest()
        {
            var response = await xlmClient.GetBlockchainInfo();
            Assert.Pass();
        }

        [Test]
        public void CreateWallet()
        {
            string privateKey = "SAVZVDW4CPQX7VJFE3MDLNB3JICVBNSTKTDA4QTPOQA7CLAYMDVS4DH7";
            Wallet wallet = xlmClient.CreateWallet(privateKey);

            Assert.That(wallet.Address, Is.EqualTo("GCXRS2TKINAGXBWOLSQHJURKKGUDWKS4YOUZ2HTA27PIK6IKFI7KKML2"));
            Assert.That(wallet.PrivateKey, Is.EqualTo(privateKey));
        }
    }
}
