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
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Tatum.CSharp.Ethereum.Core.Model
{
    /// <summary>
    /// ChainDeployErc20
    /// </summary>
    [DataContract(Name = "ChainDeployErc20")]
    public partial class ChainDeployErc20 : IEquatable<ChainDeployErc20>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainDeployErc20" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ChainDeployErc20() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ChainDeployErc20" /> class.
        /// </summary>
        /// <param name="symbol">Symbol of the ERC20 token (required).</param>
        /// <param name="name">Name of the ERC20 token (required).</param>
        /// <param name="totalCap">Max supply of ERC20 token..</param>
        /// <param name="supply">Initial supply of ERC20 token. If totalCap is not defined, this will be the total cap. (required).</param>
        /// <param name="digits">Number of decimal points (required).</param>
        /// <param name="address">Address on Ethereum blockchain, where all created ERC20 tokens will be transferred. (required).</param>
        /// <param name="fromPrivateKey">Private key of Ethereum account address, from which the fee for the deployment of ERC20 will be paid. Private key, or signature Id must be present. (required).</param>
        /// <param name="nonce">The nonce to be set to the transaction; if not present, the last known nonce will be used.</param>
        /// <param name="fee">fee.</param>
        public ChainDeployErc20(string symbol = default(string), string name = default(string), string totalCap = default(string), string supply = default(string), decimal digits = default(decimal), string address = default(string), string fromPrivateKey = default(string), decimal nonce = default(decimal), CustomFee fee = default(CustomFee))
        {
            // to ensure "symbol" is required (not null)
            if (symbol == null)
            {
                throw new ArgumentNullException("symbol is a required property for ChainDeployErc20 and cannot be null");
            }
            this.Symbol = symbol;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for ChainDeployErc20 and cannot be null");
            }
            this.Name = name;
            // to ensure "supply" is required (not null)
            if (supply == null)
            {
                throw new ArgumentNullException("supply is a required property for ChainDeployErc20 and cannot be null");
            }
            this.Supply = supply;
            this.Digits = digits;
            // to ensure "address" is required (not null)
            if (address == null)
            {
                throw new ArgumentNullException("address is a required property for ChainDeployErc20 and cannot be null");
            }
            this.Address = address;
            // to ensure "fromPrivateKey" is required (not null)
            if (fromPrivateKey == null)
            {
                throw new ArgumentNullException("fromPrivateKey is a required property for ChainDeployErc20 and cannot be null");
            }
            this.FromPrivateKey = fromPrivateKey;
            this.TotalCap = totalCap;
            this.Nonce = nonce;
            this.Fee = fee;
        }

        /// <summary>
        /// The blockchain to work with
        /// </summary>
        /// <value>The blockchain to work with</value>
        [DataMember(Name = "chain", IsRequired = true, EmitDefaultValue = true)]
        public string Chain { get; } = "ETH";


        /// <summary>
        /// Symbol of the ERC20 token
        /// </summary>
        /// <value>Symbol of the ERC20 token</value>
        [DataMember(Name = "symbol", IsRequired = true, EmitDefaultValue = true)]
        public string Symbol { get; set; }

        /// <summary>
        /// Name of the ERC20 token
        /// </summary>
        /// <value>Name of the ERC20 token</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Max supply of ERC20 token.
        /// </summary>
        /// <value>Max supply of ERC20 token.</value>
        [DataMember(Name = "totalCap", EmitDefaultValue = false)]
        public string TotalCap { get; set; }

        /// <summary>
        /// Initial supply of ERC20 token. If totalCap is not defined, this will be the total cap.
        /// </summary>
        /// <value>Initial supply of ERC20 token. If totalCap is not defined, this will be the total cap.</value>
        [DataMember(Name = "supply", IsRequired = true, EmitDefaultValue = true)]
        public string Supply { get; set; }

        /// <summary>
        /// Number of decimal points
        /// </summary>
        /// <value>Number of decimal points</value>
        [DataMember(Name = "digits", IsRequired = true, EmitDefaultValue = true)]
        public decimal Digits { get; set; }

        /// <summary>
        /// Address on Ethereum blockchain, where all created ERC20 tokens will be transferred.
        /// </summary>
        /// <value>Address on Ethereum blockchain, where all created ERC20 tokens will be transferred.</value>
        [DataMember(Name = "address", IsRequired = true, EmitDefaultValue = true)]
        public string Address { get; set; }

        /// <summary>
        /// Private key of Ethereum account address, from which the fee for the deployment of ERC20 will be paid. Private key, or signature Id must be present.
        /// </summary>
        /// <value>Private key of Ethereum account address, from which the fee for the deployment of ERC20 will be paid. Private key, or signature Id must be present.</value>
        [DataMember(Name = "fromPrivateKey", IsRequired = true, EmitDefaultValue = true)]
        public string FromPrivateKey { get; set; }

        /// <summary>
        /// The nonce to be set to the transaction; if not present, the last known nonce will be used
        /// </summary>
        /// <value>The nonce to be set to the transaction; if not present, the last known nonce will be used</value>
        [DataMember(Name = "nonce", EmitDefaultValue = false)]
        public decimal Nonce { get; set; }

        /// <summary>
        /// Gets or Sets Fee
        /// </summary>
        [DataMember(Name = "fee", EmitDefaultValue = false)]
        public CustomFee Fee { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ChainDeployErc20 {\n");
            sb.Append("  Symbol: ").Append(Symbol).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  TotalCap: ").Append(TotalCap).Append("\n");
            sb.Append("  Supply: ").Append(Supply).Append("\n");
            sb.Append("  Digits: ").Append(Digits).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  FromPrivateKey: ").Append(FromPrivateKey).Append("\n");
            sb.Append("  Nonce: ").Append(Nonce).Append("\n");
            sb.Append("  Fee: ").Append(Fee).Append("\n");
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
            return this.Equals(input as ChainDeployErc20);
        }

        /// <summary>
        /// Returns true if ChainDeployErc20 instances are equal
        /// </summary>
        /// <param name="input">Instance of ChainDeployErc20 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChainDeployErc20 input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Symbol == input.Symbol ||
                    (this.Symbol != null &&
                    this.Symbol.Equals(input.Symbol))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.TotalCap == input.TotalCap ||
                    (this.TotalCap != null &&
                    this.TotalCap.Equals(input.TotalCap))
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
                    this.FromPrivateKey == input.FromPrivateKey ||
                    (this.FromPrivateKey != null &&
                    this.FromPrivateKey.Equals(input.FromPrivateKey))
                ) && 
                (
                    this.Nonce == input.Nonce ||
                    this.Nonce.Equals(input.Nonce)
                ) && 
                (
                    this.Fee == input.Fee ||
                    (this.Fee != null &&
                    this.Fee.Equals(input.Fee))
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
                if (this.Symbol != null)
                {
                    hashCode = (hashCode * 59) + this.Symbol.GetHashCode();
                }
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.TotalCap != null)
                {
                    hashCode = (hashCode * 59) + this.TotalCap.GetHashCode();
                }
                if (this.Supply != null)
                {
                    hashCode = (hashCode * 59) + this.Supply.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Digits.GetHashCode();
                if (this.Address != null)
                {
                    hashCode = (hashCode * 59) + this.Address.GetHashCode();
                }
                if (this.FromPrivateKey != null)
                {
                    hashCode = (hashCode * 59) + this.FromPrivateKey.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Nonce.GetHashCode();
                if (this.Fee != null)
                {
                    hashCode = (hashCode * 59) + this.Fee.GetHashCode();
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
            // Symbol (string) maxLength
            if (this.Symbol != null && this.Symbol.Length > 30)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Symbol, length must be less than 30.", new [] { "Symbol" });
            }

            // Symbol (string) minLength
            if (this.Symbol != null && this.Symbol.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Symbol, length must be greater than 1.", new [] { "Symbol" });
            }

            // Name (string) maxLength
            if (this.Name != null && this.Name.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be less than 100.", new [] { "Name" });
            }

            // Name (string) minLength
            if (this.Name != null && this.Name.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be greater than 1.", new [] { "Name" });
            }

            // Name (string) pattern
            Regex regexName = new Regex(@"^[a-zA-Z0-9_]+$", RegexOptions.CultureInvariant);
            if (false == regexName.Match(this.Name).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, must match a pattern of " + regexName, new [] { "Name" });
            }

            // TotalCap (string) maxLength
            if (this.TotalCap != null && this.TotalCap.Length > 38)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TotalCap, length must be less than 38.", new [] { "TotalCap" });
            }

            // TotalCap (string) pattern
            Regex regexTotalCap = new Regex(@"^[+]?((\\d+(\\.\\d*)?)|(\\.\\d+))$", RegexOptions.CultureInvariant);
            if (false == regexTotalCap.Match(this.TotalCap).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TotalCap, must match a pattern of " + regexTotalCap, new [] { "TotalCap" });
            }

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
            if (this.Digits < (decimal)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Digits, must be a value greater than or equal to 1.", new [] { "Digits" });
            }

            // Address (string) maxLength
            if (this.Address != null && this.Address.Length > 43)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Address, length must be less than 43.", new [] { "Address" });
            }

            // Address (string) minLength
            if (this.Address != null && this.Address.Length < 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Address, length must be greater than 42.", new [] { "Address" });
            }

            // FromPrivateKey (string) maxLength
            if (this.FromPrivateKey != null && this.FromPrivateKey.Length > 66)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for FromPrivateKey, length must be less than 66.", new [] { "FromPrivateKey" });
            }

            // FromPrivateKey (string) minLength
            if (this.FromPrivateKey != null && this.FromPrivateKey.Length < 66)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for FromPrivateKey, length must be greater than 66.", new [] { "FromPrivateKey" });
            }

            // Nonce (decimal) minimum
            if (this.Nonce < (decimal)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Nonce, must be a value greater than or equal to 0.", new [] { "Nonce" });
            }

            yield break;
        }
    }

}