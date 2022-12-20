/*
 * Tatum API Reference
 *
 * # Welcome to the Tatum API Reference!  ## What is Tatum?  Tatum offers a flexible framework to build, run, and scale blockchain apps fast. To learn more about the Tatum blockchain development framework, visit [our website](https://tatum.io/framework).  The Tatum API features powerful endpoints that simplify a complex blockchain into single API requests. Code for all supported blockchains using unified API calls.  ## Need help?  To chat with other developers, get help from the Support team, and engage with the thriving Tatum community, join  our [Discord server](https://discord.com/invite/tatum). For more information about how to work with Tatum, review the [online documentation](https://docs.tatum.io/).  ## About this API Reference  The Tatum API Reference is based on OpenAPI Specification v3.1.0 with a few [vendor extensions](https://github.com/Redocly/redoc/blob/master/docs/redoc-vendor-extensions.md) applied.  # Authentication  When using the Tatum API, you authenticate yourself with an **API key**. <SecurityDefinitions /> 
 *
 * The version of the OpenAPI document: 3.17.1
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
using FileParameter = Tatum.CSharp.Bsc.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.Bsc.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.Bsc.Core.Model
{
    /// <summary>
    /// FeeBtc
    /// </summary>
    [DataContract(Name = "FeeBtc")]
    public partial class FeeBtc : IEquatable<FeeBtc>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeeBtc" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FeeBtc() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FeeBtc" /> class.
        /// </summary>
        /// <param name="fast">Transaction fee in BTC|LTC to be paid, if transaction should be included in next 1-2 blocks. (required).</param>
        /// <param name="medium">Transaction fee in BTC|LTC to be paid, if transaction should be included in next 5-6 blocks. (required).</param>
        /// <param name="slow">Transaction fee in BTC|LTC to be paid, if transaction should be included in next 7+ blocks. (required).</param>
        public FeeBtc(string fast = default(string), string medium = default(string), string slow = default(string))
        {
            // to ensure "fast" is required (not null)
            if (fast == null)
            {
                throw new ArgumentNullException("fast is a required property for FeeBtc and cannot be null");
            }
            this.Fast = fast;
            // to ensure "medium" is required (not null)
            if (medium == null)
            {
                throw new ArgumentNullException("medium is a required property for FeeBtc and cannot be null");
            }
            this.Medium = medium;
            // to ensure "slow" is required (not null)
            if (slow == null)
            {
                throw new ArgumentNullException("slow is a required property for FeeBtc and cannot be null");
            }
            this.Slow = slow;
        }


        /// <summary>
        /// Transaction fee in BTC|LTC to be paid, if transaction should be included in next 1-2 blocks.
        /// </summary>
        /// <value>Transaction fee in BTC|LTC to be paid, if transaction should be included in next 1-2 blocks.</value>
        [DataMember(Name = "fast", IsRequired = true, EmitDefaultValue = true)]
        public string Fast { get; set; }

        /// <summary>
        /// Transaction fee in BTC|LTC to be paid, if transaction should be included in next 5-6 blocks.
        /// </summary>
        /// <value>Transaction fee in BTC|LTC to be paid, if transaction should be included in next 5-6 blocks.</value>
        [DataMember(Name = "medium", IsRequired = true, EmitDefaultValue = true)]
        public string Medium { get; set; }

        /// <summary>
        /// Transaction fee in BTC|LTC to be paid, if transaction should be included in next 7+ blocks.
        /// </summary>
        /// <value>Transaction fee in BTC|LTC to be paid, if transaction should be included in next 7+ blocks.</value>
        [DataMember(Name = "slow", IsRequired = true, EmitDefaultValue = true)]
        public string Slow { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FeeBtc {\n");
            sb.Append("  Fast: ").Append(Fast).Append("\n");
            sb.Append("  Medium: ").Append(Medium).Append("\n");
            sb.Append("  Slow: ").Append(Slow).Append("\n");
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
            return this.Equals(input as FeeBtc);
        }

        /// <summary>
        /// Returns true if FeeBtc instances are equal
        /// </summary>
        /// <param name="input">Instance of FeeBtc to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FeeBtc input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Fast == input.Fast ||
                    (this.Fast != null &&
                    this.Fast.Equals(input.Fast))
                ) && 
                (
                    this.Medium == input.Medium ||
                    (this.Medium != null &&
                    this.Medium.Equals(input.Medium))
                ) && 
                (
                    this.Slow == input.Slow ||
                    (this.Slow != null &&
                    this.Slow.Equals(input.Slow))
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
                if (this.Fast != null)
                {
                    hashCode = (hashCode * 59) + this.Fast.GetHashCode();
                }
                if (this.Medium != null)
                {
                    hashCode = (hashCode * 59) + this.Medium.GetHashCode();
                }
                if (this.Slow != null)
                {
                    hashCode = (hashCode * 59) + this.Slow.GetHashCode();
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
