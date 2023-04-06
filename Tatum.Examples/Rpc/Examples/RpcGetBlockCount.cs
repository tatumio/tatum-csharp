using System;
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
        var tatumSdk = await TatumSdk.InitAsync(Network.Testnet, config => config.EnableDebugMode = true);

        var rpcCall = new JsonRpcCall
        {
            Id = "1",
            JsonRpc = "2.0",
            Method = "getblockcount"
        };

        var result = await tatumSdk.Rpc.Bitcoin.Call(rpcCall);

        Assert.True(result.Success);
    }
}