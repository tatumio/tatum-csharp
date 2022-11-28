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
using FileParameter = Tatum.CSharp.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.Core.Model
{
    /// <summary>
    /// ChainDeploySolanaSpl
    /// </summary>
    [DataContract(Name = "ChainDeploySolanaSpl")]
    public partial class ChainDeploySolanaSpl : IEquatable<ChainDeploySolanaSpl>, IValidatableObject
    {
        /// <summary>
        /// The blockchain to work with
        /// </summary>
        /// <value>The blockchain to work with</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ChainEnum
        {
            /// <summary>
            /// Enum SOL for value: SOL
            /// </summary>
            [EnumMember(Value = "SOL")]
            SOL = 1

        }


        /// <summary>
        /// The blockchain to work with
        /// </summary>
        /// <value>The blockchain to work with</value>
        [DataMember(Name = "chain", IsRequired = true, EmitDefaultValue = true)]
        public ChainEnum Chain { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainDeploySolanaSpl" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ChainDeploySolanaSpl() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainDeploySolanaSpl" /> class.
        /// </summary>
        /// <param name="chain">The blockchain to work with (required).</param>
        /// <param name="supply">Initial supply of SPL token. (required).</param>
        /// <param name="digits">Number of decimal points (required).</param>
        /// <param name="address">Address on Solana blockchain, where all created SPL tokens will be transferred. (required).</param>
        /// <param name="from">Address on Solana blockchain, from which the fee for the deployment of SPL will be paid. (required).</param>
        /// <param name="fromPrivateKey">Private key of Solana account address, from which the fee for the deployment of SPL will be paid. Private key, or signature Id must be present. (required).</param>
        public ChainDeploySolanaSpl(ChainEnum chain = default(ChainEnum), string supply = default(string), decimal digits = default(decimal), string address = default(string), string from = default(string), string fromPrivateKey = default(string))
        {
            this.Chain = chain;
            // to ensure "supply" is required (not null)
            if (supply == null)
            {
                throw new ArgumentNullException("supply is a required property for ChainDeploySolanaSpl and cannot be null");
            }
            this.Supply = supply;
            this.Digits = digits;
            // to ensure "address" is required (not null)
            if (address == null)
            {
                throw new ArgumentNullException("address is a required property for ChainDeploySolanaSpl and cannot be null");
            }
            this.Address = address;
            // to ensure "from" is required (not null)
            if (from == null)
            {
                throw new ArgumentNullException("from is a required property for ChainDeploySolanaSpl and cannot be null");
            }
            this.From = from;
            // to ensure "fromPrivateKey" is required (not null)
            if (fromPrivateKey == null)
            {
                throw new ArgumentNullException("fromPrivateKey is a required property for ChainDeploySolanaSpl and cannot be null");
            }
            this.FromPrivateKey = fromPrivateKey;
        }

        /// <summary>
        /// Initial supply of SPL token.
        /// </summary>
        /// <value>Initial supply of SPL token.</value>
        [DataMember(Name = "supply", IsRequired = true, EmitDefaultValue = true)]
        public string Supply { get; set; }

        /// <summary>
        /// Number of decimal points
        /// </summary>
        /// <value>Number of decimal points</value>
        [DataMember(Name = "digits", IsRequired = true, EmitDefaultValue = true)]
        public decimal Digits { get; set; }

        /// <summary>
        /// Address on Solana blockchain, where all created SPL tokens will be transferred.
        /// </summary>
        /// <value>Address on Solana blockchain, where all created SPL tokens will be transferred.</value>
        [DataMember(Name = "address", IsRequired = true, EmitDefaultValue = true)]
        public string Address { get; set; }

        /// <summary>
        /// Address on Solana blockchain, from which the fee for the deployment of SPL will be paid.
        /// </summary>
        /// <value>Address on Solana blockchain, from which the fee for the deployment of SPL will be paid.</value>
        [DataMember(Name = "from", IsRequired = true, EmitDefaultValue = true)]
        public string From { get; set; }

        /// <summary>
        /// Private key of Solana account address, from which the fee for the deployment of SPL will be paid. Private key, or signature Id must be present.
        /// </summary>
        /// <value>Private key of Solana account address, from which the fee for the deployment of SPL will be paid. Private key, or signature Id must be present.</value>
        [DataMember(Name = "fromPrivateKey", IsRequired = true, EmitDefaultValue = true)]
        public string FromPrivateKey { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ChainDeploySolanaSpl {\n");
            sb.Append("  Chain: ").Append(Chain).Append("\n");
            sb.Append("  Supply: ").Append(Supply).Append("\n");
            sb.Append("  Digits: ").Append(Digits).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  FromPrivateKey: ").Append(FromPrivateKey).Append("\n");
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
            return this.Equals(input as ChainDeploySolanaSpl);
        }

        /// <summary>
        /// Returns true if ChainDeploySolanaSpl instances are equal
        /// </summary>
        /// <param name="input">Instance of ChainDeploySolanaSpl to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChainDeploySolanaSpl input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Chain == input.Chain ||
                    this.Chain.Equals(input.Chain)
                ) && 
                (
                    this.Supply == input.Supply ||
                    (this.Supply != null &&
                    this.Supply.Equals(input.Supply))
                ) && 
                (
                    this.Digits == input.Digits ||
                    this.Digits.Equals(input.Digits)
                ) && 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.From == input.From ||
                    (this.From != null &&
                    this.From.Equals(input.From))
                ) && 
                (
                    this.FromPrivateKey == input.FromPrivateKey ||
                    (this.FromPrivateKey != null &&
                    this.FromPrivateKey.Equals(input.FromPrivateKey))
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
                hashCode = (hashCode * 59) + this.Chain.GetHashCode();
                if (this.Supply != null)
                {
                    hashCode = (hashCode * 59) + this.Supply.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Digits.GetHashCode();
                if (this.Address != null)
                {
                    hashCode = (hashCode * 59) + this.Address.GetHashCode();
                }
                if (this.From != null)
                {
                    hashCode = (hashCode * 59) + this.From.GetHashCode();
                }
                if (this.FromPrivateKey != null)
                {
                    hashCode = (hashCode * 59) + this.FromPrivateKey.GetHashCode();
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
            // Supply (string) maxLength
            if (this.Supply != null && this.Supply.Length > 38)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Supply, length must be less than 38.", new [] { "Supply" });
            }

            // Supply (string) pattern
            Regex regexSupply = new Regex(@"^[+]?((\\d+(\\.\\d*)?)|(\\.\\d+))$", RegexOptions.CultureInvariant);
            if (false == regexSupply.Match(this.Supply).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Supply, must match a pattern of " + regexSupply, new [] { "Supply" });
            }

            // Digits (decimal) maximum
            if (this.Digits > (decimal)30)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Digits, must be a value less than or equal to 30.", new [] { "Digits" });
            }

            // Digits (decimal) minimum
            if (this.Digits < (decimal)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Digits, must be a value greater than or equal to 0.", new [] { "Digits" });
            }

            // Address (string) maxLength
            if (this.Address != null && this.Address.Length > 43)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Address, length must be less than 43.", new [] { "Address" });
            }

            // Address (string) minLength
            if (this.Address != null && this.Address.Length < 44)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Address, length must be greater than 44.", new [] { "Address" });
            }

            // From (string) maxLength
            if (this.From != null && this.From.Length > 43)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for From, length must be less than 43.", new [] { "From" });
            }

            // From (string) minLength
            if (this.From != null && this.From.Length < 44)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for From, length must be greater than 44.", new [] { "From" });
            }

            // FromPrivateKey (string) maxLength
            if (this.FromPrivateKey != null && this.FromPrivateKey.Length > 103)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for FromPrivateKey, length must be less than 103.", new [] { "FromPrivateKey" });
            }

            // FromPrivateKey (string) minLength
            if (this.FromPrivateKey != null && this.FromPrivateKey.Length < 128)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for FromPrivateKey, length must be greater than 128.", new [] { "FromPrivateKey" });
            }

            yield break;
        }
    }

}
