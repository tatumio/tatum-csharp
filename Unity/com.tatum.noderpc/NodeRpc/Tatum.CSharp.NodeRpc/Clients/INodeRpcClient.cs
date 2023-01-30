using Tatum.CSharp.NodeRpc.Core.Api;
using Tatum.CSharp.NodeRpc.Core.Client;

namespace Tatum.CSharp.NodeRpc.Clients
{
    public interface INodeRpcClient
    {
         /// <summary>
        /// Client wrapping all operations related to the Bitcoin NodeRpc.
        /// </summary>
        INodeRPCBtcApiAsync BitcoinNodeRpc { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bitcoin NodeRpc with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INodeRPCBtcApiWithHttpInfoAsync BitcoinNodeRpcWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Ethereum NodeRpc.
        /// </summary>
        INodeRPCEthApiAsync EthereumNodeRpc { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Ethereum NodeRpc with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INodeRPCEthApiWithHttpInfoAsync EthereumNodeRpcWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon NodeRpc.
        /// </summary>
        INodeRPCMaticApiAsync PolygonNodeRpc { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon NodeRpc with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INodeRPCMaticApiWithHttpInfoAsync PolygonNodeRpcWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc NodeRpc.
        /// </summary>
        INodeRPCBscApiAsync BscNodeRpc { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc NodeRpc with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INodeRPCBscApiWithHttpInfoAsync BscNodeRpcWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Harmony NodeRpc.
        /// </summary>
        INodeRPCOneApiAsync HarmonyNodeRpc { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Harmony NodeRpc with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INodeRPCOneApiWithHttpInfoAsync HarmonyNodeRpcWithHttpInfo { get; }
    }
}