/*
 * Tatum API Reference
 *
 * # Welcome to the Tatum API Reference!  ## What is Tatum?  Tatum offers a flexible framework to build, run, and scale blockchain apps fast. To learn more about the Tatum blockchain development framework, visit [our website](https://tatum.io/framework).  The Tatum API features powerful endpoints that simplify a complex blockchain into single API requests. Code for all supported blockchains using unified API calls.  ## Need help?  To chat with other developers, get help from the Support team, and engage with the thriving Tatum community, join  our [Discord server](https://discord.com/invite/tatum). For more information about how to work with Tatum, review the [online documentation](https://docs.tatum.io/).  ## About this API Reference  The Tatum API Reference is based on OpenAPI Specification v3.1.0 with a few [vendor extensions](https://github.com/Redocly/redoc/blob/master/docs/redoc-vendor-extensions.md) applied.  # Authentication  When using the Tatum API, you authenticate yourself with an **API key**. <SecurityDefinitions /> 
 *
 * The version of the OpenAPI document: 3.17.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Tatum.CSharp.Core.Model
{
    /// <summary>
    /// BtcTransactionFromAddress
    /// </summary>
    [DataContract(Name = "BtcTransactionFromAddress")]
    public partial class BtcTransactionFromAddress : IEquatable<BtcTransactionFromAddress>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BtcTransactionFromAddress" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected BtcTransactionFromAddress() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="BtcTransactionFromAddress" /> class.
        /// </summary>
        /// <param name="fromAddress">The array of blockchain addresses to send the assets from and their private keys. For each address, the last 100 transactions are scanned for any UTXO to be included in the transaction. (required).</param>
        /// <param name="to">The array of blockchain addresses to send the assets to and the amounts that each address should receive (in BTC). The difference between the UTXOs calculated in the &lt;code&gt;fromAddress&lt;/code&gt; section and the total amount to receive calculated in the &lt;code&gt;to&lt;/code&gt; section will be used as the gas fee. To explicitly specify the fee amount and the blockchain address where any extra funds remaining after covering the fee will be sent, set the &lt;code&gt;fee&lt;/code&gt; and &lt;code&gt;changeAddress&lt;/code&gt; parameters. (required).</param>
        /// <param name="fee">The fee to be paid for the transaction (in BTC); if you are using this parameter, you have to also use the &lt;code&gt;changeAddress&lt;/code&gt; parameter because these two parameters only work together..</param>
        /// <param name="changeAddress">The blockchain address to send any extra assets remaning after covering the fee to; if you are using this parameter, you have to also use the &lt;code&gt;fee&lt;/code&gt; parameter because these two parameters only work together..</param>
        public BtcTransactionFromAddress(List<BtcTransactionFromAddressSource> fromAddress = default(List<BtcTransactionFromAddressSource>), List<BtcTransactionFromAddressTarget> to = default(List<BtcTransactionFromAddressTarget>), string fee = default(string), string changeAddress = default(string))
        {
            // to ensure "fromAddress" is required (not null)
            if (fromAddress == null)
            {
                throw new ArgumentNullException("fromAddress is a required property for BtcTransactionFromAddress and cannot be null");
            }
            this.FromAddress = fromAddress;
            // to ensure "to" is required (not null)
            if (to == null)
            {
                throw new ArgumentNullException("to is a required property for BtcTransactionFromAddress and cannot be null");
            }
            this.To = to;
            this.Fee = fee;
            this.ChangeAddress = changeAddress;
        }

        /// <summary>
        /// The array of blockchain addresses to send the assets from and their private keys. For each address, the last 100 transactions are scanned for any UTXO to be included in the transaction.
        /// </summary>
        /// <value>The array of blockchain addresses to send the assets from and their private keys. For each address, the last 100 transactions are scanned for any UTXO to be included in the transaction.</value>
        [DataMember(Name = "fromAddress", IsRequired = true, EmitDefaultValue = true)]
        public List<BtcTransactionFromAddressSource> FromAddress { get; set; }

        /// <summary>
        /// The array of blockchain addresses to send the assets to and the amounts that each address should receive (in BTC). The difference between the UTXOs calculated in the &lt;code&gt;fromAddress&lt;/code&gt; section and the total amount to receive calculated in the &lt;code&gt;to&lt;/code&gt; section will be used as the gas fee. To explicitly specify the fee amount and the blockchain address where any extra funds remaining after covering the fee will be sent, set the &lt;code&gt;fee&lt;/code&gt; and &lt;code&gt;changeAddress&lt;/code&gt; parameters.
        /// </summary>
        /// <value>The array of blockchain addresses to send the assets to and the amounts that each address should receive (in BTC). The difference between the UTXOs calculated in the &lt;code&gt;fromAddress&lt;/code&gt; section and the total amount to receive calculated in the &lt;code&gt;to&lt;/code&gt; section will be used as the gas fee. To explicitly specify the fee amount and the blockchain address where any extra funds remaining after covering the fee will be sent, set the &lt;code&gt;fee&lt;/code&gt; and &lt;code&gt;changeAddress&lt;/code&gt; parameters.</value>
        [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = true)]
        public List<BtcTransactionFromAddressTarget> To { get; set; }

        /// <summary>
        /// The fee to be paid for the transaction (in BTC); if you are using this parameter, you have to also use the &lt;code&gt;changeAddress&lt;/code&gt; parameter because these two parameters only work together.
        /// </summary>
        /// <value>The fee to be paid for the transaction (in BTC); if you are using this parameter, you have to also use the &lt;code&gt;changeAddress&lt;/code&gt; parameter because these two parameters only work together.</value>
        [DataMember(Name = "fee", EmitDefaultValue = false)]
        public string Fee { get; set; }

        /// <summary>
        /// The blockchain address to send any extra assets remaning after covering the fee to; if you are using this parameter, you have to also use the &lt;code&gt;fee&lt;/code&gt; parameter because these two parameters only work together.
        /// </summary>
        /// <value>The blockchain address to send any extra assets remaning after covering the fee to; if you are using this parameter, you have to also use the &lt;code&gt;fee&lt;/code&gt; parameter because these two parameters only work together.</value>
        [DataMember(Name = "changeAddress", EmitDefaultValue = false)]
        public string ChangeAddress { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BtcTransactionFromAddress {\n");
            sb.Append("  FromAddress: ").Append(FromAddress).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  Fee: ").Append(Fee).Append("\n");
            sb.Append("  ChangeAddress: ").Append(ChangeAddress).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as BtcTransactionFromAddress);
        }

        /// <summary>
        /// Returns true if BtcTransactionFromAddress instances are equal
        /// </summary>
        /// <param name="input">Instance of BtcTransactionFromAddress to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BtcTransactionFromAddress input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.FromAddress == input.FromAddress ||
                    this.FromAddress != null &&
                    input.FromAddress != null &&
                    this.FromAddress.SequenceEqual(input.FromAddress)
                ) && 
                (
                    this.To == input.To ||
                    this.To != null &&
                    input.To != null &&
                    this.To.SequenceEqual(input.To)
                ) && 
                (
                    this.Fee == input.Fee ||
                    (this.Fee != null &&
                    this.Fee.Equals(input.Fee))
                ) && 
                (
                    this.ChangeAddress == input.ChangeAddress ||
                    (this.ChangeAddress != null &&
                    this.ChangeAddress.Equals(input.ChangeAddress))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.FromAddress != null)
                {
                    hashCode = (hashCode * 59) + this.FromAddress.GetHashCode();
                }
                if (this.To != null)
                {
                    hashCode = (hashCode * 59) + this.To.GetHashCode();
                }
                if (this.Fee != null)
                {
                    hashCode = (hashCode * 59) + this.Fee.GetHashCode();
                }
                if (this.ChangeAddress != null)
                {
                    hashCode = (hashCode * 59) + this.ChangeAddress.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
