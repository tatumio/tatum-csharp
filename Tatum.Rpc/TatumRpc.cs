using System.Net.Http;
using Tatum.Core.Configuration;
using Tatum.Rpc.Models;

namespace Tatum.Rpc
{
    public sealed class TatumRpc : ITatumRpc
    {
        public TatumRpc(HttpClient httpClient, ITatumSdkConfiguration configuration)
        {
            Bitcoin = new TatumRpcChain(RpcChain.Bitcoin, httpClient, configuration);
            Litecoin = new TatumRpcChain(RpcChain.Litecoin, httpClient, configuration);
            Polygon = new TatumRpcChain(RpcChain.Polygon, httpClient, configuration);
            Ethereum = new TatumRpcChain(RpcChain.Ethereum, httpClient, configuration);
            Monero = new TatumRpcChain(RpcChain.Monero, httpClient, configuration);
            Tron = new TatumRpcChain(RpcChain.Tron, httpClient, configuration);
        }
        
        public TatumRpc(IHttpClientFactory httpClientFactory, ITatumSdkConfiguration configuration)
        {
            Bitcoin = new TatumRpcChain(RpcChain.Bitcoin, httpClientFactory, configuration);
            Litecoin = new TatumRpcChain(RpcChain.Litecoin, httpClientFactory, configuration);
            Polygon = new TatumRpcChain(RpcChain.Polygon, httpClientFactory, configuration);
            Ethereum = new TatumRpcChain(RpcChain.Ethereum, httpClientFactory, configuration);
            Monero = new TatumRpcChain(RpcChain.Monero, httpClientFactory, configuration);
            Tron = new TatumRpcChain(RpcChain.Tron, httpClientFactory, configuration);
        }

        public ITatumRpcChain Bitcoin { get; }

        public ITatumRpcChain Litecoin { get; }

        public ITatumRpcChain Polygon { get; }

        public ITatumRpcChain Ethereum { get; }

        public ITatumRpcChain Monero { get; }
        
        public ITatumRpcChain Tron { get; }
    }
}