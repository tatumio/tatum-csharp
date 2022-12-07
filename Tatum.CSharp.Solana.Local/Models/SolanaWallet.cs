namespace Tatum.CSharp.Solana.Local.Models
{
    /// <summary>
    /// SolanaWallet
    /// </summary>
    public partial class SolanaWalletLocal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SolanaWalletLocal" /> class.
        /// </summary>
        /// <param name="mnemonic">Generated mnemonic for wallet..</param>
        /// <param name="address">Generated account address..</param>
        /// <param name="privateKey">Generated private key for account..</param>
        public SolanaWalletLocal(string mnemonic = default(string), string address = default(string), string privateKey = default(string))
        {
            this.Mnemonic = mnemonic;
            this.Address = address;
            this.PrivateKey = privateKey;
        }

        /// <summary>
        /// Generated mnemonic for wallet.
        /// </summary>
        /// <value>Generated mnemonic for wallet.</value>
        public string Mnemonic { get; set; }

        /// <summary>
        /// Generated account address.
        /// </summary>
        /// <value>Generated account address.</value>
        public string Address { get; set; }

        /// <summary>
        /// Generated private key for account.
        /// </summary>
        /// <value>Generated private key for account.</value>
        public string PrivateKey { get; set; }
    }

}
