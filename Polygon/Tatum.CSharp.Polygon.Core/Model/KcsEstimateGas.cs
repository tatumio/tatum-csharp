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
using FileParameter = Tatum.CSharp.Polygon.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.Polygon.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.Polygon.Core.Model
{
    /// <summary>
    /// KcsEstimateGas
    /// </summary>
    [DataContract(Name = "KcsEstimateGas")]
    public partial class KcsEstimateGas : IEquatable<KcsEstimateGas>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KcsEstimateGas" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected KcsEstimateGas() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="KcsEstimateGas" /> class.
        /// </summary>
        /// <param name="from">Sender address. (required).</param>
        /// <param name="to">Blockchain address to send assets (required).</param>
        /// <param name="amount">Amount to be sent in KCS. (required).</param>
        /// <param name="data">Additional data that can be passed to a blockchain transaction as a data property; must be in the hexadecimal format.</param>
        public KcsEstimateGas(string from = default(string), string to = default(string), string amount = default(string), string data = default(string))
        {
            // to ensure "from" is required (not null)
            if (from == null)
            {
                throw new ArgumentNullException("from is a required property for KcsEstimateGas and cannot be null");
            }
            this.From = from;
            // to ensure "to" is required (not null)
            if (to == null)
            {
                throw new ArgumentNullException("to is a required property for KcsEstimateGas and cannot be null");
            }
            this.To = to;
            // to ensure "amount" is required (not null)
            if (amount == null)
            {
                throw new ArgumentNullException("amount is a required property for KcsEstimateGas and cannot be null");
            }
            this.Amount = amount;
            this.Data = data;
        }


        /// <summary>
        /// Sender address.
        /// </summary>
        /// <value>Sender address.</value>
        [DataMember(Name = "from", IsRequired = true, EmitDefaultValue = true)]
        public string From { get; set; }

        /// <summary>
        /// Blockchain address to send assets
        /// </summary>
        /// <value>Blockchain address to send assets</value>
        [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = true)]
        public string To { get; set; }

        /// <summary>
        /// Amount to be sent in KCS.
        /// </summary>
        /// <value>Amount to be sent in KCS.</value>
        [DataMember(Name = "amount", IsRequired = true, EmitDefaultValue = true)]
        public string Amount { get; set; }

        /// <summary>
        /// Additional data that can be passed to a blockchain transaction as a data property; must be in the hexadecimal format
        /// </summary>
        /// <value>Additional data that can be passed to a blockchain transaction as a data property; must be in the hexadecimal format</value>
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public string Data { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class KcsEstimateGas {\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
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
            return this.Equals(input as KcsEstimateGas);
        }

        /// <summary>
        /// Returns true if KcsEstimateGas instances are equal
        /// </summary>
        /// <param name="input">Instance of KcsEstimateGas to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(KcsEstimateGas input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.From == input.From ||
                    (this.From != null &&
                    this.From.Equals(input.From))
                ) && 
                (
                    this.To == input.To ||
                    (this.To != null &&
                    this.To.Equals(input.To))
                ) && 
                (
                    this.Amount == input.Amount ||
                    (this.Amount != null &&
                    this.Amount.Equals(input.Amount))
                ) && 
                (
                    this.Data == input.Data ||
                    (this.Data != null &&
                    this.Data.Equals(input.Data))
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
                if (this.From != null)
                {
                    hashCode = (hashCode * 59) + this.From.GetHashCode();
                }
                if (this.To != null)
                {
                    hashCode = (hashCode * 59) + this.To.GetHashCode();
                }
                if (this.Amount != null)
                {
                    hashCode = (hashCode * 59) + this.Amount.GetHashCode();
                }
                if (this.Data != null)
                {
                    hashCode = (hashCode * 59) + this.Data.GetHashCode();
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
            // From (string) maxLength
            if (this.From != null && this.From.Length > 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for From, length must be less than 42.", new [] { "From" });
            }

            // From (string) minLength
            if (this.From != null && this.From.Length < 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for From, length must be greater than 42.", new [] { "From" });
            }

            // To (string) maxLength
            if (this.To != null && this.To.Length > 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for To, length must be less than 42.", new [] { "To" });
            }

            // To (string) minLength
            if (this.To != null && this.To.Length < 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for To, length must be greater than 42.", new [] { "To" });
            }

            // Amount (string) pattern
            Regex regexAmount = new Regex(@"^[+]?((\\d+(\\.\\d*)?)|(\\.\\d+))$", RegexOptions.CultureInvariant);
            if (false == regexAmount.Match(this.Amount).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Amount, must match a pattern of " + regexAmount, new [] { "Amount" });
            }

            // Data (string) maxLength
            if (this.Data != null && this.Data.Length > 50000)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Data, length must be less than 50000.", new [] { "Data" });
            }

            // Data (string) pattern
            Regex regexData = new Regex(@"^(0x|0h)?[0-9A-F]+$", RegexOptions.CultureInvariant);
            if (false == regexData.Match(this.Data).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Data, must match a pattern of " + regexData, new [] { "Data" });
            }

            yield break;
        }
    }

}
