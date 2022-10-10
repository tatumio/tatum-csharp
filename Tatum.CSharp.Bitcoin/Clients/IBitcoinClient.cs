namespace Tatum.CSharp.Bitcoin.Clients
{
    public interface IBitcoinClient
    {
        /// <summary>
        /// Client wrapping all operations related directly to the Ethereum blockchain.
        /// </summary>
        IEthereumApiAsync EthereumBlockchain { get; }
        
        /// <summary>
        /// Client wrapping all operations related directly to the Ethereum blockchain with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IEthereumApiWithHttpInfoAsync EthereumBlockchainWithHttpInfo { get; }

        // Service for local operations that can be used to keep all sensitive information local.
        IEvmLocalService Local { get; }
    }
}