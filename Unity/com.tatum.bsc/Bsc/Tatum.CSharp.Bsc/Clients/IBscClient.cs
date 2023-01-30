using Tatum.CSharp.Bsc.Core.Api;
using Tatum.CSharp.Bsc.Core.Client;
using Tatum.CSharp.Evm.Local;
using Tatum.CSharp.Utils;

namespace Tatum.CSharp.Bsc.Clients
{
    public interface IBscClient
    {
        /// <summary>
        /// Client wrapping all operations related directly to the Bsc blockchain.
        /// </summary>
        IBNBSmartChainApiAsync BscBlockchain { get; }
        
        /// <summary>
        /// Client wrapping all operations related directly to the Bsc blockchain with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IBNBSmartChainApiWithHttpInfoAsync BscBlockchainWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc NFTs.
        /// </summary>
        INFTApiAsync BscNft { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc NFTs with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INFTApiWithHttpInfoAsync BscNftWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc FungibleTokens.
        /// </summary>
        IFungibleTokensApiAsync BscFungibleTokens { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc FungibleTokens with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IFungibleTokensApiWithHttpInfoAsync BscFungibleTokensWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc MultiTokens.
        /// </summary>
        IMultiTokensApiAsync BscMultiTokens { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc MultiTokens with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IMultiTokensApiWithHttpInfoAsync BscMultiTokensWithHttpInfo { get; }
        
        // Client wrapping all blockchain fee estimation operations.
        IBlockchainFeesApiAsync BlockchainFees { get; }
        
        // Client wrapping all blockchain fee estimation operations with full <see cref="ApiResponse{T}"/> return types.
        IBlockchainFeesApiWithHttpInfoAsync BlockchainFeesWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc NodeRpc.
        /// </summary>
        INodeRPCApiAsync BscNodeRpc { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc NodeRpc with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INodeRPCApiWithHttpInfoAsync BscNodeRpcWithHttpInfo { get; }
        
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