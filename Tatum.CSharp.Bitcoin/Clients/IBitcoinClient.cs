using Tatum.CSharp.Bitcoin.Local;
using Tatum.CSharp.Core.Api;
using Tatum.CSharp.Core.Client;

namespace Tatum.CSharp.Bitcoin.Clients
{
    public interface IBitcoinClient
    {
        /// <summary>
        /// Client wrapping all operations related directly to the Bitcoin blockchain.
        /// </summary>
        IBitcoinApiAsync BitcoinBlockchain { get; }
        
        /// <summary>
        /// Client wrapping all operations related directly to the Bitcoin blockchain with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IBitcoinApiWithHttpInfoAsync BitcoinBlockchainWithHttpInfo { get; }

        // Service for local operations that can be used to keep all sensitive information local.
        IBitcoinLocalService Local { get; }
    }
}