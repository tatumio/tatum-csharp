using System.Threading.Tasks;
using Tatum.Core;
using Tatum.Rpc.Models;

namespace Tatum.Rpc
{
    public interface ITatumRpcChain
    {
        Task<Result<object>> Call(JsonRpcCall request);
        Task<Result<T>> Call<T>(JsonRpcCall request);
    }
    
    public interface ITatumRpc
    {
        ITatumRpcChain Bitcoin { get; }
        ITatumRpcChain Litecoin { get; }
        ITatumRpcChain Polygon { get; }
        ITatumRpcChain Ethereum { get; }
        ITatumRpcChain Monero { get; }
    }
}