using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.Utils.DebugMode;
using Tatum.CSharp.MultiTokens.Tests.Integration.TestDataModels;
using Tatum.CSharp.Polygon.Clients;
using Tatum.CSharp.Polygon.Core.Model;
using VerifyXunit;
using Xunit;

namespace Tatum.CSharp.Ipfs.Tests.Integration.Clients;

[UsesVerify]
public class IpfsApiTests
{
    private readonly IIPFSClient _IpfsApi;
    private readonly PolygonTestData _testData;

    private const string TestSmartContractAddress = "0x4eA4187B91175343E71b2dd79EA5A4Ab2384612e";

    public PolygonIpfsApiTests()
    {
        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        var secrets = Environment.GetEnvironmentVariable("TEST_DATA");

        _testData = JsonSerializer.Deserialize<TestData>(secrets!)?.PolygonTestData;

        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();
        
        _IpfsApi = new IpfsClient(new HttpClient(httpClient), apiKey, true);
    }
}
