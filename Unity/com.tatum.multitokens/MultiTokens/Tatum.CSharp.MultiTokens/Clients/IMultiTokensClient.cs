using Tatum.CSharp.Evm.Local;
using Tatum.CSharp.MultiTokens.Core.Api;

namespace Tatum.CSharp.MultiTokens.Clients
{
    public interface IMultiTokensClient
    {
        /// <summary>
        /// Client wrapping all operations related to the Ethereum MultiTokens.
        /// </summary>
        IMultiTokensEthApiAsync EthereumMultiTokens { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Ethereum MultiTokens with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IMultiTokensEthApiWithHttpInfoAsync EthereumMultiTokensWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon MultiTokens.
        /// </summary>
        IMultiTokensMaticApiAsync PolygonMultiTokens { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon MultiTokens with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IMultiTokensMaticApiWithHttpInfoAsync PolygonMultiTokensWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc MultiTokens.
        /// </summary>
        IMultiTokensBscApiAsync BscMultiTokens { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc MultiTokens with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IMultiTokensBscApiWithHttpInfoAsync BscMultiTokensWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Harmony MultiTokens.
        /// </summary>
        IMultiTokensOneApiAsync HarmonyMultiTokens { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Harmony MultiTokens with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IMultiTokensOneApiWithHttpInfoAsync HarmonyMultiTokensWithHttpInfo { get; }

        // Service for local operations that can be used to keep all sensitive information local.
        IEvmLocalService Local { get; }
    }
}