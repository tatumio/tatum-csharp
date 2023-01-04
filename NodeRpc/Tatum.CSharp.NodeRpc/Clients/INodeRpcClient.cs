using Tatum.CSharp.Evm.Local;
using Tatum.CSharp.NodeRpc.Core.Api;

namespace Tatum.CSharp.NodeRpc.Clients
{
    public interface INodeRpcClient
    {
        /// <summary>
        /// Client wrapping all operations related to the Bitcoin NodeRpc.
        /// </summary>
        INodeRpcBtcApiAsync BitcoinNodeRpc { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bitcoin NodeRpc with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INodeRpcBtcApiWithHttpInfoAsync BitcoinNodeRpcWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Ethereum NodeRpc.
        /// </summary>
        INodeRpcEthApiAsync EthereumNodeRpc { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Ethereum NodeRpc with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INodeRpcEthApiWithHttpInfoAsync EthereumNodeRpcWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon NodeRpc.
        /// </summary>
        INodeRpcMaticApiAsync PolygonNodeRpc { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon NodeRpc with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INodeRpcMaticApiWithHttpInfoAsync PolygonNodeRpcWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc NodeRpc.
        /// </summary>
        INodeRpcBscApiAsync BscNodeRpc { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc NodeRpc with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INodeRpcBscApiWithHttpInfoAsync BscNodeRpcWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Harmony NodeRpc.
        /// </summary>
        INodeRpcOneApiAsync HarmonyNodeRpc { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Harmony NodeRpc with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INodeRpcOneApiWithHttpInfoAsync HarmonyNodeRpcWithHttpInfo { get; }

        // Service for local operations that can be used to keep all sensitive information local.
        IEvmLocalService Local { get; }
    }
}