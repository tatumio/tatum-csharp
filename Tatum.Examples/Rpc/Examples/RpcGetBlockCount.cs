using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Tatum.Core.Models;
using Tatum.Rpc;
using Tatum.Rpc.Models;
using Xunit;

namespace Tatum.Examples.Rpc.Examples;

[Collection("Rpc")]
public class RpcGetBlockCount
{
    [Fact]
    public async Task GetBlockCount_Example()
    {
        var tatumSdk = await TatumSdk.InitAsync(config => config.EnableDebugMode = true);

        var rpcCall = new JsonRpcCall
        {
            Id = "1",
            JsonRpc = "2.0",
            Method = "getblockcount"
        };

        var result = await tatumSdk.Rpc.Bitcoin.Call(rpcCall);

        Assert.True(result.Success);
    }
    
    [Fact]
    public async Task GetBlockCount_Example_Typed()
    {
        var tatumSdk = await TatumSdk.InitAsync(config => config.EnableDebugMode = true);

        var rpcCall = new JsonRpcCall
        {
            Id = "1",
            JsonRpc = "2.0",
            Method = "getblockcount"
        };

        var result = await tatumSdk.Rpc.Bitcoin.Call<StatusResponse>(rpcCall);

        Assert.True(result.Success);
        Assert.True(result.Value.Result > 0);
    }
    
    private class StatusResponse
    {
        [JsonPropertyName("result")] public int Result { get; set; }

        [JsonPropertyName("error")] public object Error { get; set; }

        [JsonPropertyName("id")] public string Id { get; set; }
    }
}