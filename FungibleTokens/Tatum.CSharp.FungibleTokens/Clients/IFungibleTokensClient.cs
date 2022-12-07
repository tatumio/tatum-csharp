using Tatum.CSharp.Evm.Local;
using Tatum.CSharp.FungibleTokens.Core.Api;

namespace Tatum.CSharp.FungibleTokens.Clients
{
    public interface IFungibleTokensClient
    {
        /// <summary>
        /// Client wrapping all operations related to the Ethereum FungibleTokens.
        /// </summary>
        IFungibleTokensEthApiAsync EthereumFungibleTokens { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Ethereum FungibleTokens with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IFungibleTokensEthApiWithHttpInfoAsync EthereumFungibleTokensWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon FungibleTokens.
        /// </summary>
        IFungibleTokensMaticApiAsync PolygonFungibleTokens { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon FungibleTokens with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IFungibleTokensMaticApiWithHttpInfoAsync PolygonFungibleTokensWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc FungibleTokens.
        /// </summary>
        IFungibleTokensBscApiAsync BscFungibleTokens { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc FungibleTokens with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IFungibleTokensBscApiWithHttpInfoAsync BscFungibleTokensWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Harmony FungibleTokens.
        /// </summary>
        IFungibleTokensOneApiAsync HarmonyFungibleTokens { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Harmony FungibleTokens with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IFungibleTokensOneApiWithHttpInfoAsync HarmonyFungibleTokensWithHttpInfo { get; }

        // Service for local operations that can be used to keep all sensitive information local.
        IEvmLocalService Local { get; }
    }
}