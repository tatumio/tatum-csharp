using Tatum.CSharp.Evm.Local;
using Tatum.CSharp.Polygon.Core.Api;
using Tatum.CSharp.Polygon.Core.Client;
using Tatum.CSharp.Utils;

namespace Tatum.CSharp.Polygon.Clients
{
    public interface IPolygonClient
    {
        /// <summary>
        /// Client wrapping all operations related directly to the Polygon blockchain.
        /// </summary>
        IPolygonApiAsync PolygonBlockchain { get; }
        
        /// <summary>
        /// Client wrapping all operations related directly to the Polygon blockchain with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IPolygonApiWithHttpInfoAsync PolygonBlockchainWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon NFTs.
        /// </summary>
        INFTApiAsync PolygonNft { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon NFTs with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INFTApiWithHttpInfoAsync PolygonNftWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon FungibleTokens.
        /// </summary>
        IFungibleTokensApiAsync PolygonFungibleTokens { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon FungibleTokens with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IFungibleTokensApiWithHttpInfoAsync PolygonFungibleTokensWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon MultiTokens.
        /// </summary>
        IMultiTokensApiAsync PolygonMultiTokens { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon MultiTokens with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IMultiTokensApiWithHttpInfoAsync PolygonMultiTokensWithHttpInfo { get; }
                
        // Client wrapping all blockchain fee estimation operations.
        IBlockchainFeesApiAsync BlockchainFees { get; }
        
        // Client wrapping all blockchain fee estimation operations with full <see cref="ApiResponse{T}"/> return types.
        IBlockchainFeesApiWithHttpInfoAsync BlockchainFeesWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon NodeRpc.
        /// </summary>
        INodeRPCApiAsync PolygonNodeRpc { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon NodeRpc with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INodeRPCApiWithHttpInfoAsync PolygonNodeRpcWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the IPFS.
        /// </summary>
        IIPFSApiAsync Ipfs { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the IPFS with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IIPFSApiWithHttpInfoAsync IpfsWithHttpInfo { get; }

        // Service for local operations that can be used to keep all sensitive information local.
        IEvmLocalService Local { get; }
        
        // Utility tools for the client.
        ITatumUtils Utils { get; }
    }
}