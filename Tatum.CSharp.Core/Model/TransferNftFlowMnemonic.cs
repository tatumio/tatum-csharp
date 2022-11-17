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
    /// TransferNftFlowMnemonic
    /// </summary>
    [DataContract(Name = "TransferNftFlowMnemonic")]
    public partial class TransferNftFlowMnemonic : IEquatable<TransferNftFlowMnemonic>, IValidatableObject
    {
        /// <summary>
        /// The blockchain to work with
        /// </summary>
        /// <value>The blockchain to work with</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ChainEnum
        {
            /// <summary>
            /// Enum FLOW for value: FLOW
            /// </summary>
            [EnumMember(Value = "FLOW")]
            FLOW = 1

        }


        /// <summary>
        /// The blockchain to work with
        /// </summary>
        /// <value>The blockchain to work with</value>
        [DataMember(Name = "chain", IsRequired = true, EmitDefaultValue = true)]
        public ChainEnum Chain { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransferNftFlowMnemonic" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TransferNftFlowMnemonic() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransferNftFlowMnemonic" /> class.
        /// </summary>
        /// <param name="chain">The blockchain to work with (required).</param>
        /// <param name="to">Blockchain address to send NFT token to. (required).</param>
        /// <param name="tokenId">ID of token to be sent. (uint256 number) (required).</param>
        /// <param name="contractAddress">Address of NFT token (required).</param>
        /// <param name="account">Blockchain address of the sender account. (required).</param>
        /// <param name="mnemonic">Mnemonic to generate private key of sender address. (required).</param>
        /// <param name="index">Derivation index of sender address. (required).</param>
        public TransferNftFlowMnemonic(ChainEnum chain = default(ChainEnum), string to = default(string), string tokenId = default(string), string contractAddress = default(string), string account = default(string), string mnemonic = default(string), int index = default(int))
        {
            this.Chain = chain;
            // to ensure "to" is required (not null)
            if (to == null)
            {
                throw new ArgumentNullException("to is a required property for TransferNftFlowMnemonic and cannot be null");
            }
            this.To = to;
            // to ensure "tokenId" is required (not null)
            if (tokenId == null)
            {
                throw new ArgumentNullException("tokenId is a required property for TransferNftFlowMnemonic and cannot be null");
            }
            this.TokenId = tokenId;
            // to ensure "contractAddress" is required (not null)
            if (contractAddress == null)
            {
                throw new ArgumentNullException("contractAddress is a required property for TransferNftFlowMnemonic and cannot be null");
            }
            this.ContractAddress = contractAddress;
            // to ensure "account" is required (not null)
            if (account == null)
            {
                throw new ArgumentNullException("account is a required property for TransferNftFlowMnemonic and cannot be null");
            }
            this.Account = account;
            // to ensure "mnemonic" is required (not null)
            if (mnemonic == null)
            {
                throw new ArgumentNullException("mnemonic is a required property for TransferNftFlowMnemonic and cannot be null");
            }
            this.Mnemonic = mnemonic;
            this.Index = index;
        }

        /// <summary>
        /// Blockchain address to send NFT token to.
        /// </summary>
        /// <value>Blockchain address to send NFT token to.</value>
        [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = true)]
        public string To { get; set; }

        /// <summary>
        /// ID of token to be sent. (uint256 number)
        /// </summary>
        /// <value>ID of token to be sent. (uint256 number)</value>
        [DataMember(Name = "tokenId", IsRequired = true, EmitDefaultValue = true)]
        public string TokenId { get; set; }

        /// <summary>
        /// Address of NFT token
        /// </summary>
        /// <value>Address of NFT token</value>
        [DataMember(Name = "contractAddress", IsRequired = true, EmitDefaultValue = true)]
        public string ContractAddress { get; set; }

        /// <summary>
        /// Blockchain address of the sender account.
        /// </summary>
        /// <value>Blockchain address of the sender account.</value>
        [DataMember(Name = "account", IsRequired = true, EmitDefaultValue = true)]
        public string Account { get; set; }

        /// <summary>
        /// Mnemonic to generate private key of sender address.
        /// </summary>
        /// <value>Mnemonic to generate private key of sender address.</value>
        [DataMember(Name = "mnemonic", IsRequired = true, EmitDefaultValue = true)]
        public string Mnemonic { get; set; }

        /// <summary>
        /// Derivation index of sender address.
        /// </summary>
        /// <value>Derivation index of sender address.</value>
        [DataMember(Name = "index", IsRequired = true, EmitDefaultValue = true)]
        public int Index { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TransferNftFlowMnemonic {\n");
            sb.Append("  Chain: ").Append(Chain).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  TokenId: ").Append(TokenId).Append("\n");
            sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  Mnemonic: ").Append(Mnemonic).Append("\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
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
            return this.Equals(input as TransferNftFlowMnemonic);
        }

        /// <summary>
        /// Returns true if TransferNftFlowMnemonic instances are equal
        /// </summary>
        /// <param name="input">Instance of TransferNftFlowMnemonic to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransferNftFlowMnemonic input)
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
                    this.To == input.To ||
                    (this.To != null &&
                    this.To.Equals(input.To))
                ) && 
                (
                    this.TokenId == input.TokenId ||
                    (this.TokenId != null &&
                    this.TokenId.Equals(input.TokenId))
                ) && 
                (
                    this.ContractAddress == input.ContractAddress ||
                    (this.ContractAddress != null &&
                    this.ContractAddress.Equals(input.ContractAddress))
                ) && 
                (
                    this.Account == input.Account ||
                    (this.Account != null &&
                    this.Account.Equals(input.Account))
                ) && 
                (
                    this.Mnemonic == input.Mnemonic ||
                    (this.Mnemonic != null &&
                    this.Mnemonic.Equals(input.Mnemonic))
                ) && 
                (
                    this.Index == input.Index ||
                    this.Index.Equals(input.Index)
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
                if (this.To != null)
                {
                    hashCode = (hashCode * 59) + this.To.GetHashCode();
                }
                if (this.TokenId != null)
                {
                    hashCode = (hashCode * 59) + this.TokenId.GetHashCode();
                }
                if (this.ContractAddress != null)
                {
                    hashCode = (hashCode * 59) + this.ContractAddress.GetHashCode();
                }
                if (this.Account != null)
                {
                    hashCode = (hashCode * 59) + this.Account.GetHashCode();
                }
                if (this.Mnemonic != null)
                {
                    hashCode = (hashCode * 59) + this.Mnemonic.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Index.GetHashCode();
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
            // To (string) maxLength
            if (this.To != null && this.To.Length > 18)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for To, length must be less than 18.", new [] { "To" });
            }

            // To (string) minLength
            if (this.To != null && this.To.Length < 18)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for To, length must be greater than 18.", new [] { "To" });
            }

            // TokenId (string) maxLength
            if (this.TokenId != null && this.TokenId.Length > 78)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TokenId, length must be less than 78.", new [] { "TokenId" });
            }

            // ContractAddress (string) maxLength
            if (this.ContractAddress != null && this.ContractAddress.Length > 36)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ContractAddress, length must be less than 36.", new [] { "ContractAddress" });
            }

            // ContractAddress (string) minLength
            if (this.ContractAddress != null && this.ContractAddress.Length < 36)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ContractAddress, length must be greater than 36.", new [] { "ContractAddress" });
            }

            // Account (string) maxLength
            if (this.Account != null && this.Account.Length > 18)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Account, length must be less than 18.", new [] { "Account" });
            }

            // Account (string) minLength
            if (this.Account != null && this.Account.Length < 18)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Account, length must be greater than 18.", new [] { "Account" });
            }

            // Mnemonic (string) maxLength
            if (this.Mnemonic != null && this.Mnemonic.Length > 500)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Mnemonic, length must be less than 500.", new [] { "Mnemonic" });
            }

            // Mnemonic (string) minLength
            if (this.Mnemonic != null && this.Mnemonic.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Mnemonic, length must be greater than 1.", new [] { "Mnemonic" });
            }

            // Index (int) maximum
            if (this.Index > (int)2147483647)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Index, must be a value less than or equal to 2147483647.", new [] { "Index" });
            }

            yield break;
        }
    }

}
