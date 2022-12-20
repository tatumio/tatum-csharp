using Tatum.CSharp.Evm.Local;
using Tatum.CSharp.BlockchainFees.Core.Api;

namespace Tatum.CSharp.BlockchainFees.Clients
{
    public interface IBlockchainFeesClient
    {
        /// <summary>
        /// Client wrapping all operations related to the Bitcoin BlockchainFees.
        /// </summary>
        IBlockchainFeesBtcApiAsync BitcoinBlockchainFees { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bitcoin BlockchainFees with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IBlockchainFeesBtcApiWithHttpInfoAsync BitcoinBlockchainFeesWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Ethereum BlockchainFees.
        /// </summary>
        IBlockchainFeesEthApiAsync EthereumBlockchainFees { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Ethereum BlockchainFees with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IBlockchainFeesEthApiWithHttpInfoAsync EthereumBlockchainFeesWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon BlockchainFees.
        /// </summary>
        IBlockchainFeesMaticApiAsync PolygonBlockchainFees { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Polygon BlockchainFees with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IBlockchainFeesMaticApiWithHttpInfoAsync PolygonBlockchainFeesWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc BlockchainFees.
        /// </summary>
        IBlockchainFeesBscApiAsync BscBlockchainFees { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc BlockchainFees with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IBlockchainFeesBscApiWithHttpInfoAsync BscBlockchainFeesWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Harmony BlockchainFees.
        /// </summary>
        IBlockchainFeesOneApiAsync HarmonyBlockchainFees { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Harmony BlockchainFees with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IBlockchainFeesOneApiWithHttpInfoAsync HarmonyBlockchainFeesWithHttpInfo { get; }

        // Service for local operations that can be used to keep all sensitive information local.
        IEvmLocalService Local { get; }
    }
}