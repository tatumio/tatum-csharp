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
    /// UpdateCashbackValueForAuthorNftKMSTron
    /// </summary>
    [DataContract(Name = "UpdateCashbackValueForAuthorNftKMSTron")]
    public partial class UpdateCashbackValueForAuthorNftKMSTron : IEquatable<UpdateCashbackValueForAuthorNftKMSTron>, IValidatableObject
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
        /// Initializes a new instance of the <see cref="UpdateCashbackValueForAuthorNftKMSTron" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected UpdateCashbackValueForAuthorNftKMSTron() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCashbackValueForAuthorNftKMSTron" /> class.
        /// </summary>
        /// <param name="chain">The blockchain to work with (required).</param>
        /// <param name="tokenId">The ID of the NFT to update royalty information for. (uint256 number) (required).</param>
        /// <param name="contractAddress">The blockchain address of the NFT to update royalty information for (required).</param>
        /// <param name="cashbackValue">The new value of the royalty cashback to be set for the author of the NFT; to disable the royalties for the NFT completely, set this parameter to 0 (required).</param>
        /// <param name="feeLimit">The maximum amount to be paid as the transaction fee (in TRX) (required).</param>
        /// <param name="account">The blockchain address of the NFT author from which the transaction will be performed (required).</param>
        /// <param name="signatureId">The KMS identifier of the private key of the NFT author&#39;s address (required).</param>
        /// <param name="index">(Only if the signature ID is mnemonic-based) The index of the NFT author&#39;s address that was generated from the mnemonic.</param>
        public UpdateCashbackValueForAuthorNftKMSTron(ChainEnum chain = default(ChainEnum), string tokenId = default(string), string contractAddress = default(string), string cashbackValue = default(string), decimal feeLimit = default(decimal), string account = default(string), Guid signatureId = default(Guid), decimal index = default(decimal))
        {
            this.Chain = chain;
            // to ensure "tokenId" is required (not null)
            if (tokenId == null)
            {
                throw new ArgumentNullException("tokenId is a required property for UpdateCashbackValueForAuthorNftKMSTron and cannot be null");
            }
            this.TokenId = tokenId;
            // to ensure "contractAddress" is required (not null)
            if (contractAddress == null)
            {
                throw new ArgumentNullException("contractAddress is a required property for UpdateCashbackValueForAuthorNftKMSTron and cannot be null");
            }
            this.ContractAddress = contractAddress;
            // to ensure "cashbackValue" is required (not null)
            if (cashbackValue == null)
            {
                throw new ArgumentNullException("cashbackValue is a required property for UpdateCashbackValueForAuthorNftKMSTron and cannot be null");
            }
            this.CashbackValue = cashbackValue;
            this.FeeLimit = feeLimit;
            // to ensure "account" is required (not null)
            if (account == null)
            {
                throw new ArgumentNullException("account is a required property for UpdateCashbackValueForAuthorNftKMSTron and cannot be null");
            }
            this.Account = account;
            this.SignatureId = signatureId;
            this.Index = index;
        }

        /// <summary>
        /// The ID of the NFT to update royalty information for. (uint256 number)
        /// </summary>
        /// <value>The ID of the NFT to update royalty information for. (uint256 number)</value>
        [DataMember(Name = "tokenId", IsRequired = true, EmitDefaultValue = true)]
        public string TokenId { get; set; }

        /// <summary>
        /// The blockchain address of the NFT to update royalty information for
        /// </summary>
        /// <value>The blockchain address of the NFT to update royalty information for</value>
        [DataMember(Name = "contractAddress", IsRequired = true, EmitDefaultValue = true)]
        public string ContractAddress { get; set; }

        /// <summary>
        /// The new value of the royalty cashback to be set for the author of the NFT; to disable the royalties for the NFT completely, set this parameter to 0
        /// </summary>
        /// <value>The new value of the royalty cashback to be set for the author of the NFT; to disable the royalties for the NFT completely, set this parameter to 0</value>
        [DataMember(Name = "cashbackValue", IsRequired = true, EmitDefaultValue = true)]
        public string CashbackValue { get; set; }

        /// <summary>
        /// The maximum amount to be paid as the transaction fee (in TRX)
        /// </summary>
        /// <value>The maximum amount to be paid as the transaction fee (in TRX)</value>
        [DataMember(Name = "feeLimit", IsRequired = true, EmitDefaultValue = true)]
        public decimal FeeLimit { get; set; }

        /// <summary>
        /// The blockchain address of the NFT author from which the transaction will be performed
        /// </summary>
        /// <value>The blockchain address of the NFT author from which the transaction will be performed</value>
        [DataMember(Name = "account", IsRequired = true, EmitDefaultValue = true)]
        public string Account { get; set; }

        /// <summary>
        /// The KMS identifier of the private key of the NFT author&#39;s address
        /// </summary>
        /// <value>The KMS identifier of the private key of the NFT author&#39;s address</value>
        [DataMember(Name = "signatureId", IsRequired = true, EmitDefaultValue = true)]
        public Guid SignatureId { get; set; }

        /// <summary>
        /// (Only if the signature ID is mnemonic-based) The index of the NFT author&#39;s address that was generated from the mnemonic
        /// </summary>
        /// <value>(Only if the signature ID is mnemonic-based) The index of the NFT author&#39;s address that was generated from the mnemonic</value>
        [DataMember(Name = "index", EmitDefaultValue = false)]
        public decimal Index { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UpdateCashbackValueForAuthorNftKMSTron {\n");
            sb.Append("  Chain: ").Append(Chain).Append("\n");
            sb.Append("  TokenId: ").Append(TokenId).Append("\n");
            sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
            sb.Append("  CashbackValue: ").Append(CashbackValue).Append("\n");
            sb.Append("  FeeLimit: ").Append(FeeLimit).Append("\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  SignatureId: ").Append(SignatureId).Append("\n");
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
            return this.Equals(input as UpdateCashbackValueForAuthorNftKMSTron);
        }

        /// <summary>
        /// Returns true if UpdateCashbackValueForAuthorNftKMSTron instances are equal
        /// </summary>
        /// <param name="input">Instance of UpdateCashbackValueForAuthorNftKMSTron to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdateCashbackValueForAuthorNftKMSTron input)
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
                    this.CashbackValue == input.CashbackValue ||
                    (this.CashbackValue != null &&
                    this.CashbackValue.Equals(input.CashbackValue))
                ) && 
                (
                    this.FeeLimit == input.FeeLimit ||
                    this.FeeLimit.Equals(input.FeeLimit)
                ) && 
                (
                    this.Account == input.Account ||
                    (this.Account != null &&
                    this.Account.Equals(input.Account))
                ) && 
                (
                    this.SignatureId == input.SignatureId ||
                    (this.SignatureId != null &&
                    this.SignatureId.Equals(input.SignatureId))
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
                if (this.TokenId != null)
                {
                    hashCode = (hashCode * 59) + this.TokenId.GetHashCode();
                }
                if (this.ContractAddress != null)
                {
                    hashCode = (hashCode * 59) + this.ContractAddress.GetHashCode();
                }
                if (this.CashbackValue != null)
                {
                    hashCode = (hashCode * 59) + this.CashbackValue.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.FeeLimit.GetHashCode();
                if (this.Account != null)
                {
                    hashCode = (hashCode * 59) + this.Account.GetHashCode();
                }
                if (this.SignatureId != null)
                {
                    hashCode = (hashCode * 59) + this.SignatureId.GetHashCode();
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
            // TokenId (string) maxLength
            if (this.TokenId != null && this.TokenId.Length > 78)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TokenId, length must be less than 78.", new [] { "TokenId" });
            }

            // ContractAddress (string) maxLength
            if (this.ContractAddress != null && this.ContractAddress.Length > 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ContractAddress, length must be less than 42.", new [] { "ContractAddress" });
            }

            // ContractAddress (string) minLength
            if (this.ContractAddress != null && this.ContractAddress.Length < 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ContractAddress, length must be greater than 42.", new [] { "ContractAddress" });
            }

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

            // Index (decimal) minimum
            if (this.Index < (decimal)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Index, must be a value greater than or equal to 0.", new [] { "Index" });
            }

            yield break;
        }
    }

}