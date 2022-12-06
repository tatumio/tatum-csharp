using Tatum.CSharp.Solana.Core.Api;
using Tatum.CSharp.Evm.Local;

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

        // Service for local operations that can be used to keep all sensitive information local.
        ISolanaLocalService Local { get; }
    }
}