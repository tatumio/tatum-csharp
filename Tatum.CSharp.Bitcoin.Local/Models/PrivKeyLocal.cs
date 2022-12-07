namespace Tatum.CSharp.Bitcoin.Local.Models
{
    /// <summary>
    /// PrivKey
    /// </summary>
    public partial class PrivKeyLocal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrivKeyLocal" /> class.
        /// </summary>
        /// <param name="key">Generated private key..</param>
        public PrivKeyLocal(string key = default(string))
        {
            this.Key = key;
        }


        /// <summary>
        /// Generated private key.
        /// </summary>
        /// <value>Generated private key.</value>
        public string Key { get; set; }

    }
}
