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
    /// EstimateFeeFromAddressTo
    /// </summary>
    [DataContract(Name = "EstimateFeeFromAddressTo")]
    public partial class EstimateFeeFromAddressTo : IEquatable<EstimateFeeFromAddressTo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateFeeFromAddressTo" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EstimateFeeFromAddressTo() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateFeeFromAddressTo" /> class.
        /// </summary>
        /// <param name="address">Destination address. (required).</param>
        /// <param name="value">Amount to be sent, in BTC. (required).</param>
        public EstimateFeeFromAddressTo(string address = default(string), decimal value = default(decimal))
        {
            // to ensure "address" is required (not null)
            if (address == null)
            {
                throw new ArgumentNullException("address is a required property for EstimateFeeFromAddressTo and cannot be null");
            }
            this.Address = address;
            this.Value = value;
        }


        /// <summary>
        /// Destination address.
        /// </summary>
        /// <value>Destination address.</value>
        [DataMember(Name = "address", IsRequired = true, EmitDefaultValue = true)]
        public string Address { get; set; }

        /// <summary>
        /// Amount to be sent, in BTC.
        /// </summary>
        /// <value>Amount to be sent, in BTC.</value>
        [DataMember(Name = "value", IsRequired = true, EmitDefaultValue = true)]
        public decimal Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EstimateFeeFromAddressTo {\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
            return this.Equals(input as EstimateFeeFromAddressTo);
        }

        /// <summary>
        /// Returns true if EstimateFeeFromAddressTo instances are equal
        /// </summary>
        /// <param name="input">Instance of EstimateFeeFromAddressTo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EstimateFeeFromAddressTo input)
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
                    this.Value == input.Value ||
                    this.Value.Equals(input.Value)
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
                hashCode = (hashCode * 59) + this.Value.GetHashCode();
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
            // Value (decimal) minimum
            if (this.Value < (decimal)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Value, must be a value greater than or equal to 0.", new [] { "Value" });
            }

            yield break;
        }
    }

}
