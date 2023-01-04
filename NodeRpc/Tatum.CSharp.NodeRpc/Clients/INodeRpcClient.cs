using Tatum.CSharp.NodeRpc.Core.Api;

namespace Tatum.CSharp.NodeRpc.Clients
{
    public interface INodeRpcClient
    {
        /// <summary>
        /// Client wrapping all operations related to the NodeRpc.
        /// </summary>
        INodeRPCApiAsync NodeRpc { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the NodeRpc with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INodeRPCApiWithHttpInfoAsync NodeRpcWithHttpInfo { get; }
    }
}