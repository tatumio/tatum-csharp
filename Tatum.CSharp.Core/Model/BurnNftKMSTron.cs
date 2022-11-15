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
    /// BurnNftKMSTron
    /// </summary>
    [DataContract(Name = "BurnNftKMSTron")]
    public partial class BurnNftKMSTron : IEquatable<BurnNftKMSTron>, IValidatableObject
    {
        /// <summary>
        /// The blockchain to work with
        /// </summary>
        /// <value>The blockchain to work with</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ChainEnum
        {
            /// <summary>
            /// Enum TRON for value: TRON
            /// </summary>
            [EnumMember(Value = "TRON")]
            TRON = 1

        }


        /// <summary>
        /// The blockchain to work with
        /// </summary>
        /// <value>The blockchain to work with</value>
        [DataMember(Name = "chain", IsRequired = true, EmitDefaultValue = true)]
        public ChainEnum Chain { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="BurnNftKMSTron" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected BurnNftKMSTron() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="BurnNftKMSTron" /> class.
        /// </summary>
        /// <param name="chain">The blockchain to work with (required).</param>
        /// <param name="account">Blockchain address to perform transaction from (required).</param>
        /// <param name="tokenId">ID of token to be destroyed. (required).</param>
        /// <param name="contractAddress">Address of NFT token (required).</param>
        /// <param name="index">If signatureId is mnemonic-based, this is the index to the specific address from that mnemonic..</param>
        /// <param name="signatureId">Identifier of the private key associated in signing application. Private key, or signature Id must be present. (required).</param>
        /// <param name="feeLimit">The maximum amount to be paid as the transaction fee (in TRX) (required).</param>
        public BurnNftKMSTron(ChainEnum chain = default(ChainEnum), string account = default(string), string tokenId = default(string), string contractAddress = default(string), decimal index = default(decimal), Guid signatureId = default(Guid), decimal feeLimit = default(decimal))
        {
            this.Chain = chain;
            // to ensure "account" is required (not null)
            if (account == null)
            {
                throw new ArgumentNullException("account is a required property for BurnNftKMSTron and cannot be null");
            }
            this.Account = account;
            // to ensure "tokenId" is required (not null)
            if (tokenId == null)
            {
                throw new ArgumentNullException("tokenId is a required property for BurnNftKMSTron and cannot be null");
            }
            this.TokenId = tokenId;
            // to ensure "contractAddress" is required (not null)
            if (contractAddress == null)
            {
                throw new ArgumentNullException("contractAddress is a required property for BurnNftKMSTron and cannot be null");
            }
            this.ContractAddress = contractAddress;
            this.SignatureId = signatureId;
            this.FeeLimit = feeLimit;
            this.Index = index;
        }

        /// <summary>
        /// Blockchain address to perform transaction from
        /// </summary>
        /// <value>Blockchain address to perform transaction from</value>
        [DataMember(Name = "account", IsRequired = true, EmitDefaultValue = true)]
        public string Account { get; set; }

        /// <summary>
        /// ID of token to be destroyed.
        /// </summary>
        /// <value>ID of token to be destroyed.</value>
        [DataMember(Name = "tokenId", IsRequired = true, EmitDefaultValue = true)]
        public string TokenId { get; set; }

        /// <summary>
        /// Address of NFT token
        /// </summary>
        /// <value>Address of NFT token</value>
        [DataMember(Name = "contractAddress", IsRequired = true, EmitDefaultValue = true)]
        public string ContractAddress { get; set; }

        /// <summary>
        /// If signatureId is mnemonic-based, this is the index to the specific address from that mnemonic.
        /// </summary>
        /// <value>If signatureId is mnemonic-based, this is the index to the specific address from that mnemonic.</value>
        [DataMember(Name = "index", EmitDefaultValue = false)]
        public decimal Index { get; set; }

        /// <summary>
        /// Identifier of the private key associated in signing application. Private key, or signature Id must be present.
        /// </summary>
        /// <value>Identifier of the private key associated in signing application. Private key, or signature Id must be present.</value>
        [DataMember(Name = "signatureId", IsRequired = true, EmitDefaultValue = true)]
        public Guid SignatureId { get; set; }

        /// <summary>
        /// The maximum amount to be paid as the transaction fee (in TRX)
        /// </summary>
        /// <value>The maximum amount to be paid as the transaction fee (in TRX)</value>
        [DataMember(Name = "feeLimit", IsRequired = true, EmitDefaultValue = true)]
        public decimal FeeLimit { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BurnNftKMSTron {\n");
            sb.Append("  Chain: ").Append(Chain).Append("\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  TokenId: ").Append(TokenId).Append("\n");
            sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
            sb.Append("  SignatureId: ").Append(SignatureId).Append("\n");
            sb.Append("  FeeLimit: ").Append(FeeLimit).Append("\n");
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
            return this.Equals(input as BurnNftKMSTron);
        }

        /// <summary>
        /// Returns true if BurnNftKMSTron instances are equal
        /// </summary>
        /// <param name="input">Instance of BurnNftKMSTron to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BurnNftKMSTron input)
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
                    this.Account == input.Account ||
                    (this.Account != null &&
                    this.Account.Equals(input.Account))
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
                    this.Index == input.Index ||
                    this.Index.Equals(input.Index)
                ) && 
                (
                    this.SignatureId == input.SignatureId ||
                    (this.SignatureId != null &&
                    this.SignatureId.Equals(input.SignatureId))
                ) && 
                (
                    this.FeeLimit == input.FeeLimit ||
                    this.FeeLimit.Equals(input.FeeLimit)
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
                if (this.Account != null)
                {
                    hashCode = (hashCode * 59) + this.Account.GetHashCode();
                }
                if (this.TokenId != null)
                {
                    hashCode = (hashCode * 59) + this.TokenId.GetHashCode();
                }
                if (this.ContractAddress != null)
                {
                    hashCode = (hashCode * 59) + this.ContractAddress.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Index.GetHashCode();
                if (this.SignatureId != null)
                {
                    hashCode = (hashCode * 59) + this.SignatureId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.FeeLimit.GetHashCode();
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
            // Account (string) maxLength
            if (this.Account != null && this.Account.Length > 34)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Account, length must be less than 34.", new [] { "Account" });
            }

            // Account (string) minLength
            if (this.Account != null && this.Account.Length < 34)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Account, length must be greater than 34.", new [] { "Account" });
            }

            // TokenId (string) maxLength
            if (this.TokenId != null && this.TokenId.Length > 32)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TokenId, length must be less than 32.", new [] { "TokenId" });
            }

            // ContractAddress (string) maxLength
            if (this.ContractAddress != null && this.ContractAddress.Length > 34)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ContractAddress, length must be less than 34.", new [] { "ContractAddress" });
            }

            // ContractAddress (string) minLength
            if (this.ContractAddress != null && this.ContractAddress.Length < 34)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ContractAddress, length must be greater than 34.", new [] { "ContractAddress" });
            }

            // Index (decimal) minimum
            if (this.Index < (decimal)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Index, must be a value greater than or equal to 0.", new [] { "Index" });
            }

            yield break;
        }
    }

}
