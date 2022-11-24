using Tatum.CSharp.Core.Api;
using Tatum.CSharp.Core.Client;
using Tatum.CSharp.Evm.Local;

namespace Tatum.CSharp.Nft.Clients
{
    public interface INftClient
    {
        /// <summary>
        /// Client wrapping all operations related to the Ethereum NFTs.
        /// </summary>
        INFTEthApiAsync EthereumNft { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Ethereum NFTs with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INFTEthApiWithHttpInfoAsync EthereumNftWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon NFTs.
        /// </summary>
        INFTMaticApiAsync PolygonNft { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon NFTs with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INFTMaticApiWithHttpInfoAsync PolygonNftWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc NFTs.
        /// </summary>
        INFTBscApiAsync BscNft { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc NFTs with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INFTBscApiWithHttpInfoAsync BscNftWithHttpInfo { get; }

        // Service for local operations that can be used to keep all sensitive information local.
        IEvmLocalService Local { get; }
    }
}