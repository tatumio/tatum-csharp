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
    /// UpdateCashbackValueForAuthorNftKMS
    /// </summary>
    [DataContract(Name = "UpdateCashbackValueForAuthorNftKMS")]
    public partial class UpdateCashbackValueForAuthorNftKMS : IEquatable<UpdateCashbackValueForAuthorNftKMS>, IValidatableObject
    {
        /// <summary>
        /// The blockchain to work with
        /// </summary>
        /// <value>The blockchain to work with</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ChainEnum
        {
            /// <summary>
            /// Enum BSC for value: BSC
            /// </summary>
            [EnumMember(Value = "BSC")]
            BSC = 1,

            /// <summary>
            /// Enum ETH for value: ETH
            /// </summary>
            [EnumMember(Value = "ETH")]
            ETH = 2,

            /// <summary>
            /// Enum KCS for value: KCS
            /// </summary>
            [EnumMember(Value = "KCS")]
            KCS = 3,

            /// <summary>
            /// Enum KLAY for value: KLAY
            /// </summary>
            [EnumMember(Value = "KLAY")]
            KLAY = 4,

            /// <summary>
            /// Enum MATIC for value: MATIC
            /// </summary>
            [EnumMember(Value = "MATIC")]
            MATIC = 5,

            /// <summary>
            /// Enum ONE for value: ONE
            /// </summary>
            [EnumMember(Value = "ONE")]
            ONE = 6

        }


        /// <summary>
        /// The blockchain to work with
        /// </summary>
        /// <value>The blockchain to work with</value>
        [DataMember(Name = "chain", IsRequired = true, EmitDefaultValue = true)]
        public ChainEnum Chain { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCashbackValueForAuthorNftKMS" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected UpdateCashbackValueForAuthorNftKMS() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCashbackValueForAuthorNftKMS" /> class.
        /// </summary>
        /// <param name="chain">The blockchain to work with (required).</param>
        /// <param name="tokenId">The ID of the NFT to update royalty information for (required).</param>
        /// <param name="contractAddress">The blockchain address of the NFT to update royalty information for (required).</param>
        /// <param name="cashbackValue">The new value of the royalty cashback to be set for the author of the NFT; to disable the royalties for the NFT completely, set this parameter to 0 (required).</param>
        /// <param name="signatureId">The KMS identifier of the private key of the NFT author&#39;s address (required).</param>
        /// <param name="index">(Only if the signature ID is mnemonic-based) The index of the NFT author&#39;s address that was generated from the mnemonic.</param>
        /// <param name="nonce">The nonce to be set to the transaction; if not present, the last known nonce will be used.</param>
        /// <param name="fee">fee.</param>
        public UpdateCashbackValueForAuthorNftKMS(ChainEnum chain = default(ChainEnum), int tokenId = default(int), string contractAddress = default(string), string cashbackValue = default(string), Guid signatureId = default(Guid), decimal index = default(decimal), decimal nonce = default(decimal), CustomFee fee = default(CustomFee))
        {
            this.Chain = chain;
            this.TokenId = tokenId;
            // to ensure "contractAddress" is required (not null)
            if (contractAddress == null)
            {
                throw new ArgumentNullException("contractAddress is a required property for UpdateCashbackValueForAuthorNftKMS and cannot be null");
            }
            this.ContractAddress = contractAddress;
            // to ensure "cashbackValue" is required (not null)
            if (cashbackValue == null)
            {
                throw new ArgumentNullException("cashbackValue is a required property for UpdateCashbackValueForAuthorNftKMS and cannot be null");
            }
            this.CashbackValue = cashbackValue;
            this.SignatureId = signatureId;
            this.Index = index;
            this.Nonce = nonce;
            this.Fee = fee;
        }

        /// <summary>
        /// The ID of the NFT to update royalty information for
        /// </summary>
        /// <value>The ID of the NFT to update royalty information for</value>
        [DataMember(Name = "tokenId", IsRequired = true, EmitDefaultValue = true)]
        public int TokenId { get; set; }

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
            sb.Append("class UpdateCashbackValueForAuthorNftKMS {\n");
            sb.Append("  Chain: ").Append(Chain).Append("\n");
            sb.Append("  TokenId: ").Append(TokenId).Append("\n");
            sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
            sb.Append("  CashbackValue: ").Append(CashbackValue).Append("\n");
            sb.Append("  SignatureId: ").Append(SignatureId).Append("\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
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
            return this.Equals(input as UpdateCashbackValueForAuthorNftKMS);
        }

        /// <summary>
        /// Returns true if UpdateCashbackValueForAuthorNftKMS instances are equal
        /// </summary>
        /// <param name="input">Instance of UpdateCashbackValueForAuthorNftKMS to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdateCashbackValueForAuthorNftKMS input)
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
                    this.TokenId.Equals(input.TokenId)
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
                    this.SignatureId == input.SignatureId ||
                    (this.SignatureId != null &&
                    this.SignatureId.Equals(input.SignatureId))
                ) && 
                (
                    this.Index == input.Index ||
                    this.Index.Equals(input.Index)
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
                hashCode = (hashCode * 59) + this.Chain.GetHashCode();
                hashCode = (hashCode * 59) + this.TokenId.GetHashCode();
                if (this.ContractAddress != null)
                {
                    hashCode = (hashCode * 59) + this.ContractAddress.GetHashCode();
                }
                if (this.CashbackValue != null)
                {
                    hashCode = (hashCode * 59) + this.CashbackValue.GetHashCode();
                }
                if (this.SignatureId != null)
                {
                    hashCode = (hashCode * 59) + this.SignatureId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Index.GetHashCode();
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
            // TokenId (int) minimum
            if (this.TokenId < (int)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TokenId, must be a value greater than or equal to 0.", new [] { "TokenId" });
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

            // Index (decimal) minimum
            if (this.Index < (decimal)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Index, must be a value greater than or equal to 0.", new [] { "Index" });
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
