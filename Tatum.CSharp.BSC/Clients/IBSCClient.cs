using Tatum.CSharp.Core.Api;
using Tatum.CSharp.Core.Client;
using Tatum.CSharp.Evm.Local;

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
        INFTBscApiAsync BscNft { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Bsc NFTs with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        INFTBscApiWithHttpInfoAsync BscNftWithHttpInfo { get; }

        // Service for local operations that can be used to keep all sensitive information local.
        IEvmLocalService Local { get; }
    }
}