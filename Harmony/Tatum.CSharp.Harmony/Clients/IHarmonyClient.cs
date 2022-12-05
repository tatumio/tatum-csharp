﻿using Tatum.CSharp.Evm.Local;
using Tatum.CSharp.Harmony.Core.Api;

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
        INFTOneApiAsync HarmonyNft { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Harmony NFTs with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INFTOneApiWithHttpInfoAsync HarmonyNftWithHttpInfo { get; }

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