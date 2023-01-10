using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.Ipfs.Clients;
using Tatum.CSharp.Ipfs.Core.Client;
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
    private readonly IIpfsClient _ipfsApi;

    public IpfsApiTests()
    {
        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");

        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();
        
        _ipfsApi = new IpfsClient(new HttpClient(httpClient), apiKey, true);
    }
    
    [Fact]
    public async Task IPFS_ShouldWriteAndRead_WhenCalledWithFile()
    {
        await File.WriteAllTextAsync("test.txt", "test");
        
        var fileStream = File.OpenRead("test.txt");
        
        var ipfsResponse = await _ipfsApi.Ipfs.StoreIPFSAsync(new FileParameter(fileStream));

        var ipfsFile = await _ipfsApi.Ipfs.GetIPFSDataAsync(ipfsResponse.IpfsHash);
        
        var content = await new StreamReader(ipfsFile.Content).ReadToEndAsync();
        
        content.Should().Be("test");
    }
}
