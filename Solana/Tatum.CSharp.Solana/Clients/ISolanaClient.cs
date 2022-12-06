using Tatum.CSharp.Solana.Core.Api;


namespace Tatum.CSharp.Solana.Clients
{
    public interface ISolanaClient
    {
        /// <summary>
        /// Client wrapping all operations related directly to the Solana blockchain.
        /// </summary>
        ISolanaApiAsync SolanaBlockchain { get; }
        
        /// <summary>
        /// Client wrapping all operations related directly to the Solana blockchain with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        ISolanaApiWithHttpInfoAsync SolanaBlockchainWithHttpInfo { get; }
    }
}