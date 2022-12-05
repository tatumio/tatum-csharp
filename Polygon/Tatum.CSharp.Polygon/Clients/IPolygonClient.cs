using Tatum.CSharp.Evm.Local;
using Tatum.CSharp.Polygon.Core.Api;

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
        INFTMaticApiAsync PolygonNft { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon NFTs with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INFTMaticApiWithHttpInfoAsync PolygonNftWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon FungibleTokens.
        /// </summary>
        IFungibleTokensMaticApiAsync PolygonFungibleTokens { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon FungibleTokens with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IFungibleTokensMaticApiWithHttpInfoAsync PolygonFungibleTokensWithHttpInfo { get; }

        // Service for local operations that can be used to keep all sensitive information local.
        IEvmLocalService Local { get; }
    }
}