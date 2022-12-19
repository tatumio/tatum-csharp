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
using FileParameter = Tatum.CSharp.BlockchainFees.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.BlockchainFees.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.BlockchainFees.Core.Model
{
    /// <summary>
    /// EstimateFeeBatchMintNft
    /// </summary>
    [DataContract(Name = "EstimateFeeBatchMintNft")]
    public partial class EstimateFeeBatchMintNft : IEquatable<EstimateFeeBatchMintNft>, IValidatableObject
    {
        /// <summary>
        /// Blockchain to estimate fee for.
        /// </summary>
        /// <value>Blockchain to estimate fee for.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ChainEnum
        {
            /// <summary>
            /// Enum ETH for value: ETH
            /// </summary>
            [EnumMember(Value = "ETH")]
            ETH = 1,

            /// <summary>
            /// Enum BSC for value: BSC
            /// </summary>
            [EnumMember(Value = "BSC")]
            BSC = 2,

            /// <summary>
            /// Enum ONE for value: ONE
            /// </summary>
            [EnumMember(Value = "ONE")]
            ONE = 3,

            /// <summary>
            /// Enum MATIC for value: MATIC
            /// </summary>
            [EnumMember(Value = "MATIC")]
            MATIC = 4

        }


        /// <summary>
        /// Blockchain to estimate fee for.
        /// </summary>
        /// <value>Blockchain to estimate fee for.</value>
        [DataMember(Name = "chain", IsRequired = true, EmitDefaultValue = true)]
        public ChainEnum Chain { get; set; }

        /// <summary>
        /// Type of transaction
        /// </summary>
        /// <value>Type of transaction</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum MINTNFTBATCH for value: MINT_NFT_BATCH
            /// </summary>
            [EnumMember(Value = "MINT_NFT_BATCH")]
            MINTNFTBATCH = 1

        }


        /// <summary>
        /// Type of transaction
        /// </summary>
        /// <value>Type of transaction</value>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public TypeEnum Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateFeeBatchMintNft" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EstimateFeeBatchMintNft() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateFeeBatchMintNft" /> class.
        /// </summary>
        /// <param name="chain">Blockchain to estimate fee for. (required).</param>
        /// <param name="type">Type of transaction (required).</param>
        /// <param name="sender">Address of the minter (required).</param>
        /// <param name="recipients">Blockchain addresses to mint tokens to (required).</param>
        /// <param name="contractAddress">Contract address of NFT token.</param>
        /// <param name="tokenIds">Token IDs (required).</param>
        /// <param name="urls">Metadata URLs (required).</param>
        public EstimateFeeBatchMintNft(ChainEnum chain = default(ChainEnum), TypeEnum type = default(TypeEnum), string sender = default(string), List<string> recipients = default(List<string>), string contractAddress = default(string), List<string> tokenIds = default(List<string>), List<string> urls = default(List<string>))
        {
            this.Chain = chain;
            this.Type = type;
            // to ensure "sender" is required (not null)
            if (sender == null)
            {
                throw new ArgumentNullException("sender is a required property for EstimateFeeBatchMintNft and cannot be null");
            }
            this.Sender = sender;
            // to ensure "recipients" is required (not null)
            if (recipients == null)
            {
                throw new ArgumentNullException("recipients is a required property for EstimateFeeBatchMintNft and cannot be null");
            }
            this.Recipients = recipients;
            // to ensure "tokenIds" is required (not null)
            if (tokenIds == null)
            {
                throw new ArgumentNullException("tokenIds is a required property for EstimateFeeBatchMintNft and cannot be null");
            }
            this.TokenIds = tokenIds;
            // to ensure "urls" is required (not null)
            if (urls == null)
            {
                throw new ArgumentNullException("urls is a required property for EstimateFeeBatchMintNft and cannot be null");
            }
            this.Urls = urls;
            this.ContractAddress = contractAddress;
        }


        /// <summary>
        /// Address of the minter
        /// </summary>
        /// <value>Address of the minter</value>
        [DataMember(Name = "sender", IsRequired = true, EmitDefaultValue = true)]
        public string Sender { get; set; }

        /// <summary>
        /// Blockchain addresses to mint tokens to
        /// </summary>
        /// <value>Blockchain addresses to mint tokens to</value>
        [DataMember(Name = "recipients", IsRequired = true, EmitDefaultValue = true)]
        public List<string> Recipients { get; set; }

        /// <summary>
        /// Contract address of NFT token
        /// </summary>
        /// <value>Contract address of NFT token</value>
        [DataMember(Name = "contractAddress", EmitDefaultValue = false)]
        public string ContractAddress { get; set; }

        /// <summary>
        /// Token IDs
        /// </summary>
        /// <value>Token IDs</value>
        [DataMember(Name = "tokenIds", IsRequired = true, EmitDefaultValue = true)]
        public List<string> TokenIds { get; set; }

        /// <summary>
        /// Metadata URLs
        /// </summary>
        /// <value>Metadata URLs</value>
        [DataMember(Name = "urls", IsRequired = true, EmitDefaultValue = true)]
        public List<string> Urls { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EstimateFeeBatchMintNft {\n");
            sb.Append("  Chain: ").Append(Chain).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Sender: ").Append(Sender).Append("\n");
            sb.Append("  Recipients: ").Append(Recipients).Append("\n");
            sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
            sb.Append("  TokenIds: ").Append(TokenIds).Append("\n");
            sb.Append("  Urls: ").Append(Urls).Append("\n");
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
            return this.Equals(input as EstimateFeeBatchMintNft);
        }

        /// <summary>
        /// Returns true if EstimateFeeBatchMintNft instances are equal
        /// </summary>
        /// <param name="input">Instance of EstimateFeeBatchMintNft to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EstimateFeeBatchMintNft input)
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
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) && 
                (
                    this.Sender == input.Sender ||
                    (this.Sender != null &&
                    this.Sender.Equals(input.Sender))
                ) && 
                (
                    this.Recipients == input.Recipients ||
                    this.Recipients != null &&
                    input.Recipients != null &&
                    this.Recipients.SequenceEqual(input.Recipients)
                ) && 
                (
                    this.ContractAddress == input.ContractAddress ||
                    (this.ContractAddress != null &&
                    this.ContractAddress.Equals(input.ContractAddress))
                ) && 
                (
                    this.TokenIds == input.TokenIds ||
                    this.TokenIds != null &&
                    input.TokenIds != null &&
                    this.TokenIds.SequenceEqual(input.TokenIds)
                ) && 
                (
                    this.Urls == input.Urls ||
                    this.Urls != null &&
                    input.Urls != null &&
                    this.Urls.SequenceEqual(input.Urls)
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
                hashCode = (hashCode * 59) + this.Type.GetHashCode();
                if (this.Sender != null)
                {
                    hashCode = (hashCode * 59) + this.Sender.GetHashCode();
                }
                if (this.Recipients != null)
                {
                    hashCode = (hashCode * 59) + this.Recipients.GetHashCode();
                }
                if (this.ContractAddress != null)
                {
                    hashCode = (hashCode * 59) + this.ContractAddress.GetHashCode();
                }
                if (this.TokenIds != null)
                {
                    hashCode = (hashCode * 59) + this.TokenIds.GetHashCode();
                }
                if (this.Urls != null)
                {
                    hashCode = (hashCode * 59) + this.Urls.GetHashCode();
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
            // Sender (string) maxLength
            if (this.Sender != null && this.Sender.Length > 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Sender, length must be less than 42.", new [] { "Sender" });
            }

            // Sender (string) minLength
            if (this.Sender != null && this.Sender.Length < 43)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Sender, length must be greater than 43.", new [] { "Sender" });
            }

            // ContractAddress (string) maxLength
            if (this.ContractAddress != null && this.ContractAddress.Length > 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ContractAddress, length must be less than 42.", new [] { "ContractAddress" });
            }

            // ContractAddress (string) minLength
            if (this.ContractAddress != null && this.ContractAddress.Length < 43)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ContractAddress, length must be greater than 43.", new [] { "ContractAddress" });
            }

            yield break;
        }
    }

}
