using Tatum.CSharp.Ethereum.Core.Api;
using Tatum.CSharp.Evm.Local;
using Tatum.CSharp.Utils;

namespace Tatum.CSharp.Ethereum.Clients
{
    public interface IEthereumClient
    {
        /// <summary>
        /// Client wrapping all operations related directly to the Ethereum blockchain.
        /// </summary>
        IEthereumApiAsync EthereumBlockchain { get; }
        
        /// <summary>
        /// Client wrapping all operations related directly to the Ethereum blockchain with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IEthereumApiWithHttpInfoAsync EthereumBlockchainWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Ethereum NFTs.
        /// </summary>
        INFTApiAsync EthereumNft { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Ethereum NFTs with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INFTApiWithHttpInfoAsync EthereumNftWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Ethereum FungibleTokens.
        /// </summary>
        IFungibleTokensApiAsync EthereumFungibleTokens { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Ethereum FungibleTokens with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IFungibleTokensApiWithHttpInfoAsync EthereumFungibleTokensWithHttpInfo { get; }
                
        // Client wrapping all blockchain fee estimation operations.
        IBlockchainFeesApiAsync BlockchainFees { get; }
        
        // Client wrapping all blockchain fee estimation operations with full <see cref="ApiResponse{T}"/> return types.
        IBlockchainFeesApiWithHttpInfoAsync BlockchainFeesWithHttpInfo { get; }

        // Service for local operations that can be used to keep all sensitive information local.
        IEvmLocalService Local { get; }
        
        // Utility tools for the client.
        ITatumUtils Utils { get; }
    }
}