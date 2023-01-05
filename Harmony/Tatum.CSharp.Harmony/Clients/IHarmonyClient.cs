using Tatum.CSharp.Evm.Local;
using Tatum.CSharp.Harmony.Core.Api;
using Tatum.CSharp.Harmony.Core.Client;
using Tatum.CSharp.Utils;

namespace Tatum.CSharp.Harmony.Clients
{
    public interface IHarmonyClient
    {
        /// <summary>
        /// Client wrapping all operations related directly to the Harmony blockchain.
        /// </summary>
        IHarmonyApiAsync HarmonyBlockchain { get; }
        
        /// <summary>
        /// Client wrapping all operations related directly to the Harmony blockchain with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IHarmonyApiWithHttpInfoAsync HarmonyBlockchainWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Harmony NFTs.
        /// </summary>
        INFTApiAsync HarmonyNft { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Harmony NFTs with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INFTApiWithHttpInfoAsync HarmonyNftWithHttpInfo { get; }

        /// <summary>
        /// Client wrapping all operations related to the Harmony FungibleTokens.
        /// </summary>
        IFungibleTokensApiAsync HarmonyFungibleTokens { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Harmony FungibleTokens with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IFungibleTokensApiWithHttpInfoAsync HarmonyFungibleTokensWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Harmony MultiTokens.
        /// </summary>
        IMultiTokensApiAsync HarmonyMultiTokens { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Harmony MultiTokens with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IMultiTokensApiWithHttpInfoAsync HarmonyMultiTokensWithHttpInfo { get; }
                
        // Client wrapping all blockchain fee estimation operations.
        IBlockchainFeesApiAsync BlockchainFees { get; }
        
        // Client wrapping all blockchain fee estimation operations with full <see cref="ApiResponse{T}"/> return types.
        IBlockchainFeesApiWithHttpInfoAsync BlockchainFeesWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Harmony NodeRpc.
        /// </summary>
        INodeRPCApiAsync HarmonyNodeRpc { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Harmony NodeRpc with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INodeRPCApiWithHttpInfoAsync HarmonyNodeRpcWithHttpInfo { get; }

        // Service for local operations that can be used to keep all sensitive information local.
        IEvmLocalService Local { get; }
        
        // Utility tools for the client.
        ITatumUtils Utils { get; }
    }
}