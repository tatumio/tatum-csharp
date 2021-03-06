﻿using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;
using Tatum.Clients;

namespace Tatum.Tests
{
    public class XrpTests
    {
        IXrpClient xrpClient;

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

            xrpClient = XrpClient.Create(baseUrl, xApiKey);
        }

        [Test]
        public async Task EndpointTest()
        {
            var response = await xrpClient.GetBlockchainInfo();
            Assert.Pass();
        }
    }
}
