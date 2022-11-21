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

        // Service for local operations that can be used to keep all sensitive information local.
        IEvmLocalService Local { get; }
    }
}