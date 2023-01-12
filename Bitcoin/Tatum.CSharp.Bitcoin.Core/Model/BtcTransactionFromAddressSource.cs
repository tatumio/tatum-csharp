/*
 * Tatum API Reference
 *
 * # Welcome to the Tatum API Reference!  ## What is Tatum?  Tatum offers a flexible framework to build, run, and scale blockchain apps fast. To learn more about the Tatum blockchain development framework, visit [our website](https://tatum.io/framework).  The Tatum API features powerful endpoints that simplify a complex blockchain into single API requests. Code for all supported blockchains using unified API calls.  ## Supported blockchains  Tatum supports multiple blockchains and various blockchain features.  Because not all blockchains function identically, Tatum supports a different set of features on each blockchain.  To see all the blockchains that Tatum supports, please refer to [this article](https://docs.tatum.io/introduction/supported-blockchains).  ## Need help?  To chat with other developers, get help from the Support team, and engage with the thriving Tatum community, join  our [Discord server](https://discord.com/invite/tatum). For more information about how to work with Tatum, review the [online documentation](https://docs.tatum.io/).  # Authentication  When using the Tatum API, you authenticate yourself with an **API key**. <SecurityDefinitions /> 
 *
 * The version of the OpenAPI document: 3.17.2
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using FileParameter = Tatum.CSharp.Bitcoin.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.Bitcoin.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.Bitcoin.Core.Model
{
    /// <summary>
    /// BtcTransactionFromAddressSource
    /// </summary>
    [DataContract(Name = "BtcTransactionFromAddressSource")]
    public partial class BtcTransactionFromAddressSource : IEquatable<BtcTransactionFromAddressSource>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BtcTransactionFromAddressSource" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected BtcTransactionFromAddressSource() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="BtcTransactionFromAddressSource" /> class.
        /// </summary>
        /// <param name="address">The blockchain address to send the assets from (required).</param>
        /// <param name="privateKey">The private key of the address to send the assets from (required).</param>
        public BtcTransactionFromAddressSource(string address = default(string), string privateKey = default(string))
        {
            // to ensure "address" is required (not null)
            if (address == null)
            {
                throw new ArgumentNullException("address is a required property for BtcTransactionFromAddressSource and cannot be null");
            }
            this.Address = address;
            // to ensure "privateKey" is required (not null)
            if (privateKey == null)
            {
                throw new ArgumentNullException("privateKey is a required property for BtcTransactionFromAddressSource and cannot be null");
            }
            this.PrivateKey = privateKey;
        }


        /// <summary>
        /// The blockchain address to send the assets from
        /// </summary>
        /// <value>The blockchain address to send the assets from</value>
        [DataMember(Name = "address", IsRequired = true, EmitDefaultValue = true)]
        public string Address { get; set; }

        /// <summary>
        /// The private key of the address to send the assets from
        /// </summary>
        /// <value>The private key of the address to send the assets from</value>
        [DataMember(Name = "privateKey", IsRequired = true, EmitDefaultValue = true)]
        public string PrivateKey { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BtcTransactionFromAddressSource {\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  PrivateKey: ").Append(PrivateKey).Append("\n");
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
            return this.Equals(input as BtcTransactionFromAddressSource);
        }

        /// <summary>
        /// Returns true if BtcTransactionFromAddressSource instances are equal
        /// </summary>
        /// <param name="input">Instance of BtcTransactionFromAddressSource to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BtcTransactionFromAddressSource input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.PrivateKey == input.PrivateKey ||
                    (this.PrivateKey != null &&
                    this.PrivateKey.Equals(input.PrivateKey))
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
                if (this.Address != null)
                {
                    hashCode = (hashCode * 59) + this.Address.GetHashCode();
                }
                if (this.PrivateKey != null)
                {
                    hashCode = (hashCode * 59) + this.PrivateKey.GetHashCode();
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
