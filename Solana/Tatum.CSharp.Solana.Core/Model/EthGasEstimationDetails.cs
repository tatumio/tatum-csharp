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
using FileParameter = Tatum.CSharp.Solana.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.Solana.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.Solana.Core.Model
{
    /// <summary>
    /// Detailed estimations for safe (under 30 minutes), standard (under 5 minutes) and fast (under 2 minutes) transaction times.
    /// </summary>
    [DataContract(Name = "EthGasEstimationDetails")]
    public partial class EthGasEstimationDetails : IEquatable<EthGasEstimationDetails>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EthGasEstimationDetails" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EthGasEstimationDetails() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EthGasEstimationDetails" /> class.
        /// </summary>
        /// <param name="safe">Safe gas price in wei. (required).</param>
        /// <param name="standard">Standard gas price in wei. (required).</param>
        /// <param name="fast">Fast gas price in wei. (required).</param>
        /// <param name="baseFee">Base fee for EIP-1559 transactions in wei. (required).</param>
        public EthGasEstimationDetails(string safe = default(string), string standard = default(string), string fast = default(string), string baseFee = default(string))
        {
            // to ensure "safe" is required (not null)
            if (safe == null)
            {
                throw new ArgumentNullException("safe is a required property for EthGasEstimationDetails and cannot be null");
            }
            this.Safe = safe;
            // to ensure "standard" is required (not null)
            if (standard == null)
            {
                throw new ArgumentNullException("standard is a required property for EthGasEstimationDetails and cannot be null");
            }
            this.Standard = standard;
            // to ensure "fast" is required (not null)
            if (fast == null)
            {
                throw new ArgumentNullException("fast is a required property for EthGasEstimationDetails and cannot be null");
            }
            this.Fast = fast;
            // to ensure "baseFee" is required (not null)
            if (baseFee == null)
            {
                throw new ArgumentNullException("baseFee is a required property for EthGasEstimationDetails and cannot be null");
            }
            this.BaseFee = baseFee;
        }


        /// <summary>
        /// Safe gas price in wei.
        /// </summary>
        /// <value>Safe gas price in wei.</value>
        [DataMember(Name = "safe", IsRequired = true, EmitDefaultValue = true)]
        public string Safe { get; set; }

        /// <summary>
        /// Standard gas price in wei.
        /// </summary>
        /// <value>Standard gas price in wei.</value>
        [DataMember(Name = "standard", IsRequired = true, EmitDefaultValue = true)]
        public string Standard { get; set; }

        /// <summary>
        /// Fast gas price in wei.
        /// </summary>
        /// <value>Fast gas price in wei.</value>
        [DataMember(Name = "fast", IsRequired = true, EmitDefaultValue = true)]
        public string Fast { get; set; }

        /// <summary>
        /// Base fee for EIP-1559 transactions in wei.
        /// </summary>
        /// <value>Base fee for EIP-1559 transactions in wei.</value>
        [DataMember(Name = "baseFee", IsRequired = true, EmitDefaultValue = true)]
        public string BaseFee { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EthGasEstimationDetails {\n");
            sb.Append("  Safe: ").Append(Safe).Append("\n");
            sb.Append("  Standard: ").Append(Standard).Append("\n");
            sb.Append("  Fast: ").Append(Fast).Append("\n");
            sb.Append("  BaseFee: ").Append(BaseFee).Append("\n");
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
            return this.Equals(input as EthGasEstimationDetails);
        }

        /// <summary>
        /// Returns true if EthGasEstimationDetails instances are equal
        /// </summary>
        /// <param name="input">Instance of EthGasEstimationDetails to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EthGasEstimationDetails input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Safe == input.Safe ||
                    (this.Safe != null &&
                    this.Safe.Equals(input.Safe))
                ) && 
                (
                    this.Standard == input.Standard ||
                    (this.Standard != null &&
                    this.Standard.Equals(input.Standard))
                ) && 
                (
                    this.Fast == input.Fast ||
                    (this.Fast != null &&
                    this.Fast.Equals(input.Fast))
                ) && 
                (
                    this.BaseFee == input.BaseFee ||
                    (this.BaseFee != null &&
                    this.BaseFee.Equals(input.BaseFee))
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
                if (this.Safe != null)
                {
                    hashCode = (hashCode * 59) + this.Safe.GetHashCode();
                }
                if (this.Standard != null)
                {
                    hashCode = (hashCode * 59) + this.Standard.GetHashCode();
                }
                if (this.Fast != null)
                {
                    hashCode = (hashCode * 59) + this.Fast.GetHashCode();
                }
                if (this.BaseFee != null)
                {
                    hashCode = (hashCode * 59) + this.BaseFee.GetHashCode();
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
