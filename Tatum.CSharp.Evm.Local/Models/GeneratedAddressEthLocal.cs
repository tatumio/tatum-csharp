namespace Tatum.CSharp.Evm.Local.Models
{
    /// <summary>
    /// GeneratedAddressEth
    /// </summary>
    public class GeneratedAddressEthLocal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneratedAddressEthLocal" /> class.
        /// </summary>
        /// <param name="address">Ethereum address.</param>
        public GeneratedAddressEthLocal(string address = default(string))
        {
            this.Address = address;
        }


        /// <summary>
        /// Ethereum address
        /// </summary>
        /// <value>Ethereum address</value>
        public string Address { get; set; }
    }

}
