using Tatum.CSharp.Solana.Local.Models;

namespace Tatum.CSharp.Solana.Local
{
    public interface ISolanaLocalService
    {
        /// <summary>
        /// Generate Solana private key and account address.
        /// </summary>
        SolanaWalletLocal GenerateSolanaWallet();
    }
}