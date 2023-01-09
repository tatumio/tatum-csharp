using Tatum.CSharp.Bitcoin.Core.Api;
using Tatum.CSharp.Bitcoin.Core.Client;
using Tatum.CSharp.Bitcoin.Local;

namespace Tatum.CSharp.Bitcoin.Clients
{
    public interface IBitcoinClient
    {
        /// <summary>
        /// Client wrapping all operations related directly to the Bitcoin blockchain.
        /// </summary>
        IBitcoinApiAsync BitcoinBlockchain { get; }
        
        /// <summary>
        /// Client wrapping all operations related directly to the Bitcoin blockchain with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IBitcoinApiWithHttpInfoAsync BitcoinBlockchainWithHttpInfo { get; }

        // Client wrapping all blockchain fee estimation operations.
        IBlockchainFeesApiAsync BlockchainFees { get; }
        
        // Client wrapping all blockchain fee estimation operations with full <see cref="ApiResponse{T}"/> return types.
        IBlockchainFeesApiWithHttpInfoAsync BlockchainFeesWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bitcoin NodeRpc.
        /// </summary>
        INodeRPCApiAsync BitcoinNodeRpc { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bitcoin NodeRpc with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INodeRPCApiWithHttpInfoAsync BitcoinNodeRpcWithHttpInfo { get; }
        
        // Service for local operations that can be used to keep all sensitive information local.
        IBitcoinLocalService Local { get; }
    }
}