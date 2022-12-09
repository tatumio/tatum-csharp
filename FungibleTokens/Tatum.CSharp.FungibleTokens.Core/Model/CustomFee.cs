/*
 * Tatum API Reference
 *
 * # Welcome to the Tatum API Reference!  ## What is Tatum?  Tatum offers a flexible framework to build, run, and scale blockchain apps fast. To learn more about the Tatum blockchain development framework, visit [our website](https://tatum.io/framework).  The Tatum API features powerful endpoints that simplify a complex blockchain into single API requests. Code for all supported blockchains using unified API calls.  ## Need help?  To chat with other developers, get help from the Support team, and engage with the thriving Tatum community, join  our [Discord server](https://discord.com/invite/tatum). For more information about how to work with Tatum, review the [online documentation](https://docs.tatum.io/).  ## About this API Reference  The Tatum API Reference is based on OpenAPI Specification v3.1.0 with a few [vendor extensions](https://github.com/Redocly/redoc/blob/master/docs/redoc-vendor-extensions.md) applied.  # Authentication  When using the Tatum API, you authenticate yourself with an **API key**. <SecurityDefinitions /> 
 *
 * The version of the OpenAPI document: 3.17.0
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
using FileParameter = Tatum.CSharp.FungibleTokens.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.FungibleTokens.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.FungibleTokens.Core.Model
{
    /// <summary>
    /// The custom defined fee; if not present, will be calculated automatically
    /// </summary>
    [DataContract(Name = "CustomFee")]
    public partial class CustomFee : IEquatable<CustomFee>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFee" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CustomFee() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFee" /> class.
        /// </summary>
        /// <param name="gasLimit">Gas limit for transaction in gas price. (required).</param>
        /// <param name="gasPrice">Gas price in Gwei. (required).</param>
        public CustomFee(string gasLimit = default(string), string gasPrice = default(string))
        {
            // to ensure "gasLimit" is required (not null)
            if (gasLimit == null)
            {
                throw new ArgumentNullException("gasLimit is a required property for CustomFee and cannot be null");
            }
            this.GasLimit = gasLimit;
            // to ensure "gasPrice" is required (not null)
            if (gasPrice == null)
            {
                throw new ArgumentNullException("gasPrice is a required property for CustomFee and cannot be null");
            }
            this.GasPrice = gasPrice;
        }


        /// <summary>
        /// Gas limit for transaction in gas price.
        /// </summary>
        /// <value>Gas limit for transaction in gas price.</value>
        [DataMember(Name = "gasLimit", IsRequired = true, EmitDefaultValue = true)]
        public string GasLimit { get; set; }

        /// <summary>
        /// Gas price in Gwei.
        /// </summary>
        /// <value>Gas price in Gwei.</value>
        [DataMember(Name = "gasPrice", IsRequired = true, EmitDefaultValue = true)]
        public string GasPrice { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CustomFee {\n");
            sb.Append("  GasLimit: ").Append(GasLimit).Append("\n");
            sb.Append("  GasPrice: ").Append(GasPrice).Append("\n");
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
            return this.Equals(input as CustomFee);
        }

        /// <summary>
        /// Returns true if CustomFee instances are equal
        /// </summary>
        /// <param name="input">Instance of CustomFee to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CustomFee input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.GasLimit == input.GasLimit ||
                    (this.GasLimit != null &&
                    this.GasLimit.Equals(input.GasLimit))
                ) && 
                (
                    this.GasPrice == input.GasPrice ||
                    (this.GasPrice != null &&
                    this.GasPrice.Equals(input.GasPrice))
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
                if (this.GasLimit != null)
                {
                    hashCode = (hashCode * 59) + this.GasLimit.GetHashCode();
                }
                if (this.GasPrice != null)
                {
                    hashCode = (hashCode * 59) + this.GasPrice.GetHashCode();
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
            // GasLimit (string) pattern
            Regex regexGasLimit = new Regex(@"^[+]?\\d+$", RegexOptions.CultureInvariant);
            if (false == regexGasLimit.Match(this.GasLimit).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for GasLimit, must match a pattern of " + regexGasLimit, new [] { "GasLimit" });
            }

            // GasPrice (string) pattern
            Regex regexGasPrice = new Regex(@"^[+]?\\d+$", RegexOptions.CultureInvariant);
            if (false == regexGasPrice.Match(this.GasPrice).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for GasPrice, must match a pattern of " + regexGasPrice, new [] { "GasPrice" });
            }

            yield break;
        }
    }

}
