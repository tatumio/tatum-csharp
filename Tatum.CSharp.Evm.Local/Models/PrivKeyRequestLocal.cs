namespace Tatum.CSharp.Evm.Local.Models
{
    /// <summary>
    /// PrivKeyRequest
    /// </summary>
    public partial class PrivKeyRequestLocal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrivKeyRequestLocal" /> class.
        /// </summary>
        /// <param name="index">Derivation index of private key to generate. (required).</param>
        /// <param name="mnemonic">Mnemonic to generate private key from. (required).</param>
        public PrivKeyRequestLocal(int index = default(int), string mnemonic = default(string))
        {
            this.Index = index;
            this.Mnemonic = mnemonic;
        }


        /// <summary>
        /// Derivation index of private key to generate.
        /// </summary>
        /// <value>Derivation index of private key to generate.</value>
        public int Index { get; set; }

        /// <summary>
        /// Mnemonic to generate private key from.
        /// </summary>
        /// <value>Mnemonic to generate private key from.</value>
        public string Mnemonic { get; set; }

    }

}
