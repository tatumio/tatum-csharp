namespace Tatum.CSharp.Bitcoin.Local.Models
{
    /// <summary>
    /// Wallet
    /// </summary>
    public partial class WalletLocal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WalletLocal" /> class.
        /// </summary>
        /// <param name="mnemonic">Generated mnemonic for wallet..</param>
        /// <param name="xpub">Generated Extended public key for wallet with derivation path according to BIP44. This key can be used to generate addresses..</param>
        public WalletLocal(string mnemonic = default(string), string xpub = default(string))
        {
            this.Mnemonic = mnemonic;
            this.Xpub = xpub;
        }


        /// <summary>
        /// Generated mnemonic for wallet.
        /// </summary>
        /// <value>Generated mnemonic for wallet.</value>
        public string Mnemonic { get; set; }

        /// <summary>
        /// Generated Extended public key for wallet with derivation path according to BIP44. This key can be used to generate addresses.
        /// </summary>
        /// <value>Generated Extended public key for wallet with derivation path according to BIP44. This key can be used to generate addresses.</value>
        public string Xpub { get; set; }
    }

}
