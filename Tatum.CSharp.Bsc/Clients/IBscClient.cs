using Tatum.CSharp.Core.Api;
using Tatum.CSharp.Core.Client;
using Tatum.CSharp.Evm.Local;

namespace Tatum.CSharp.Bsc.Clients
{
    public interface IBSCClient
    {
        /// <summary>
        /// Client wrapping all operations related directly to the BSC blockchain.
        /// </summary>
        IBNBSmartChainApiAsync BSCBlockchain { get; }
        
        /// <summary>
        /// Client wrapping all operations related directly to the BSC blockchain with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IBNBSmartChainApiWithHttpInfoAsync BSCBlockchainWithHttpInfo { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the BSC NFTs.
        /// </summary>
        INFTBscApiAsync BSCNft { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the BSC NFTs with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INFTBscApiWithHttpInfoAsync BSCNftWithHttpInfo { get; }

        // Service for local operations that can be used to keep all sensitive information local.
        IEvmLocalService Local { get; }
    }
}