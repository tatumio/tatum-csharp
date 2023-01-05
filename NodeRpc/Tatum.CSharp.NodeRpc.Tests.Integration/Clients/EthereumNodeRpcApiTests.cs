using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.NodeRpc.Clients;
using Tatum.CSharp.NodeRpc.Core.Model;
using Xunit;

namespace Tatum.CSharp.NodeRpc.Tests.Integration.Clients;

[Collection("Ethereum")]
public class PolygonNodeRpcApiTests
{
    private readonly INodeRpcClient _nodeRpcApi;

    public PolygonNodeRpcApiTests()
    {
        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");

        _nodeRpcApi = new NodeRpcClient(new HttpClient(), apiKey, true);
    }
    
    [Fact]
    public async Task PolygonEstimateGas_ShouldReturnFee_WhenCalled()
    {

    }
}
