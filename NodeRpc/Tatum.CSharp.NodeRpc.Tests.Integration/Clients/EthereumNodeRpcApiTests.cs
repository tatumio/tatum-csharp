using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Tatum.CSharp.NodeRpc.Clients;
using Tatum.CSharp.Utils;
using Xunit;

namespace Tatum.CSharp.NodeRpc.Tests.Integration.Clients;

[Collection("Ethereum")]
public class PolygonNodeRpcApiTests
{
    private readonly INodeRpcClient _nodeRpcApi;

    public PolygonNodeRpcApiTests()
    {
        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");

        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();
        
        _nodeRpcApi = new NodeRpcClient(new HttpClient(httpClient), apiKey, true);
    }
    
    [Fact]
    public async Task PolygonEstimateGas_ShouldReturnFee_WhenCalled()
    {
        var rpcPostDriverRequest = new NodeJsonRpcPostDriverRequest()
        {
            Jsonrpc = "2.0",
            Id = 1,
            Method = "web3_clientVersion",
            Params = new List<string>()
        };
        
        var result = await _nodeRpcApi.EthereumNodeRpc.NodeJsonRpcPostDriverAsync(rpcPostDriverRequest);

        var jResult = (JObject)result;

        var typedResult = jResult.ToObject<NodeJsonPrcPostDriverResponse>();
        
        result.Should().NotBeNull();
        typedResult.Id.Should().Be(1);
        typedResult.Jsonrpc.Should().Be("2.0");
        typedResult.Result.Should().NotBeNullOrEmpty();
    }
    
    private class NodeJsonRpcPostDriverRequest
    {
        public string Jsonrpc { get; set; }
        public string Method { get; set; }
        public int Id { get; set; }
        public List<string> Params { get; set; }
    }
    
    private class NodeJsonPrcPostDriverResponse
    {
        public string Jsonrpc { get; set; }
        public int Id { get; set; }
        public string Result { get; set; }
    }
}
