namespace Tatum.CSharp.Bitcoin.Local.Models
{
    /// <summary>
    /// GeneratedAddressBtc
    /// </summary>
    public class GeneratedAddressBtcLocal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneratedAddressBtcLocal" /> class.
        /// </summary>
        /// <param name="address">Bitcoin address.</param>
        public GeneratedAddressBtcLocal(string address = default(string))
        {
            this.Address = address;
        }


        /// <summary>
        /// Bitcoin address
        /// </summary>
        /// <value>Bitcoin address</value>
        public string Address { get; set; }
    }

}
