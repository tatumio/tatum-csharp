using System.Collections.Generic;
using Tatum.Rpc.Models;

namespace Tatum.Rpc.Constants
{
    internal static class RpcConstants
    {
        internal static readonly Dictionary<RpcChain, string> ConfigUrls = new Dictionary<RpcChain, string>
        {
            { RpcChain.Bitcoin, "https://bitcoin.cdn.openrpc.io" },
            { RpcChain.Litecoin, "https://litecoin.cdn.openrpc.io" },
            { RpcChain.Ethereum, "https://ethereum.cdn.openrpc.io" },
            { RpcChain.Polygon, "https://polygon.cdn.openrpc.io" },
            { RpcChain.Monero, "https://monero.cdn.openrpc.io" },
        };
    }
}