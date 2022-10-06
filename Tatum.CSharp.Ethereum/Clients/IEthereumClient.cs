using Tatum.CSharp.Core.Api;
using Tatum.CSharp.Core.Client;
using Tatum.CSharp.Ethereum.LocalServices;

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
        /// Client wrapping all operations related directly to the ERC-20 or compatible Fungible Tokens on the Ethereum blockchain.
        /// </summary>
        //IFungibleTokensApiAsync EthereumFungibleTokens { get; }
        
        EthereumLocalService Local { get; }
    }
}