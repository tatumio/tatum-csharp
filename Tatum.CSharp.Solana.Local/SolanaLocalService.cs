using Solnet.Wallet;
using Solnet.Wallet.Bip39;
using Tatum.CSharp.Solana.Local.Models;

namespace Tatum.CSharp.Solana.Local
{
    public class SolanaLocalService : ISolanaLocalService
    {
        /// <inheritdoc />
        public SolanaWalletLocal GenerateSolanaWallet()
        {
            var wallet =  new Wallet(WordCount.TwentyFour, WordList.English);

            return new SolanaWalletLocal()
            {
                Mnemonic = string.Join(" ", wallet.Mnemonic.Words),
                Address = wallet.GetAccount(0).PrivateKey,
                PrivateKey = wallet.GetAccount(0).PrivateKey
            };
        }
    }
}