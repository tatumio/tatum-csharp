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
    /// MintMultipleNftMinter
    /// </summary>
    [DataContract(Name = "MintMultipleNftMinter")]
    public partial class MintMultipleNftMinter : IEquatable<MintMultipleNftMinter>, IValidatableObject
    {
        /// <summary>
        /// Chain to work with.
        /// </summary>
        /// <value>Chain to work with.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ChainEnum
        {
            /// <summary>
            /// Enum ETH for value: ETH
            /// </summary>
            [EnumMember(Value = "ETH")]
            ETH = 1,

            /// <summary>
            /// Enum MATIC for value: MATIC
            /// </summary>
            [EnumMember(Value = "MATIC")]
            MATIC = 2,

            /// <summary>
            /// Enum CELO for value: CELO
            /// </summary>
            [EnumMember(Value = "CELO")]
            CELO = 3,

            /// <summary>
            /// Enum KCS for value: KCS
            /// </summary>
            [EnumMember(Value = "KCS")]
            KCS = 4,

            /// <summary>
            /// Enum ONE for value: ONE
            /// </summary>
            [EnumMember(Value = "ONE")]
            ONE = 5,

            /// <summary>
            /// Enum KLAY for value: KLAY
            /// </summary>
            [EnumMember(Value = "KLAY")]
            KLAY = 6,

            /// <summary>
            /// Enum BSC for value: BSC
            /// </summary>
            [EnumMember(Value = "BSC")]
            BSC = 7

        }


        /// <summary>
        /// Chain to work with.
        /// </summary>
        /// <value>Chain to work with.</value>
        [DataMember(Name = "chain", IsRequired = true, EmitDefaultValue = true)]
        public ChainEnum Chain { get; set; }
        /// <summary>
        /// Currency to pay for transaction gas, only valid for CELO chain.
        /// </summary>
        /// <value>Currency to pay for transaction gas, only valid for CELO chain.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum FeeCurrencyEnum
        {
            /// <summary>
            /// Enum CELO for value: CELO
            /// </summary>
            [EnumMember(Value = "CELO")]
            CELO = 1

        }


        /// <summary>
        /// Currency to pay for transaction gas, only valid for CELO chain.
        /// </summary>
        /// <value>Currency to pay for transaction gas, only valid for CELO chain.</value>
        [DataMember(Name = "feeCurrency", EmitDefaultValue = false)]
        public FeeCurrencyEnum? FeeCurrency { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MintMultipleNftMinter" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MintMultipleNftMinter() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MintMultipleNftMinter" /> class.
        /// </summary>
        /// <param name="chain">Chain to work with. (required).</param>
        /// <param name="to">Blockchain address to send NFT token to. (required).</param>
        /// <param name="tokenId">ID of token to be created. (required).</param>
        /// <param name="minter">Address of NFT minter, which will be used to mint the tokens. From this address, transaction fees will be deducted. (required).</param>
        /// <param name="url">The URL pointing to the NFT metadata; for more information, see &lt;a href&#x3D;\&quot;https://eips.ethereum.org/EIPS/eip-721#specification\&quot; target&#x3D;\&quot;_blank\&quot;&gt;EIP-721&lt;/a&gt; (required).</param>
        /// <param name="contractAddress">Address of NFT token (required).</param>
        /// <param name="feeCurrency">Currency to pay for transaction gas, only valid for CELO chain..</param>
        public MintMultipleNftMinter(ChainEnum chain = default(ChainEnum), List<string> to = default(List<string>), List<string> tokenId = default(List<string>), string minter = default(string), List<string> url = default(List<string>), string contractAddress = default(string), FeeCurrencyEnum? feeCurrency = default(FeeCurrencyEnum?))
        {
            this.Chain = chain;
            // to ensure "to" is required (not null)
            if (to == null)
            {
                throw new ArgumentNullException("to is a required property for MintMultipleNftMinter and cannot be null");
            }
            this.To = to;
            // to ensure "tokenId" is required (not null)
            if (tokenId == null)
            {
                throw new ArgumentNullException("tokenId is a required property for MintMultipleNftMinter and cannot be null");
            }
            this.TokenId = tokenId;
            // to ensure "minter" is required (not null)
            if (minter == null)
            {
                throw new ArgumentNullException("minter is a required property for MintMultipleNftMinter and cannot be null");
            }
            this.Minter = minter;
            // to ensure "url" is required (not null)
            if (url == null)
            {
                throw new ArgumentNullException("url is a required property for MintMultipleNftMinter and cannot be null");
            }
            this.Url = url;
            // to ensure "contractAddress" is required (not null)
            if (contractAddress == null)
            {
                throw new ArgumentNullException("contractAddress is a required property for MintMultipleNftMinter and cannot be null");
            }
            this.ContractAddress = contractAddress;
            this.FeeCurrency = feeCurrency;
        }

        /// <summary>
        /// Blockchain address to send NFT token to.
        /// </summary>
        /// <value>Blockchain address to send NFT token to.</value>
        [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = true)]
        public List<string> To { get; set; }

        /// <summary>
        /// ID of token to be created.
        /// </summary>
        /// <value>ID of token to be created.</value>
        [DataMember(Name = "tokenId", IsRequired = true, EmitDefaultValue = true)]
        public List<string> TokenId { get; set; }

        /// <summary>
        /// Address of NFT minter, which will be used to mint the tokens. From this address, transaction fees will be deducted.
        /// </summary>
        /// <value>Address of NFT minter, which will be used to mint the tokens. From this address, transaction fees will be deducted.</value>
        [DataMember(Name = "minter", IsRequired = true, EmitDefaultValue = true)]
        public string Minter { get; set; }

        /// <summary>
        /// The URL pointing to the NFT metadata; for more information, see &lt;a href&#x3D;\&quot;https://eips.ethereum.org/EIPS/eip-721#specification\&quot; target&#x3D;\&quot;_blank\&quot;&gt;EIP-721&lt;/a&gt;
        /// </summary>
        /// <value>The URL pointing to the NFT metadata; for more information, see &lt;a href&#x3D;\&quot;https://eips.ethereum.org/EIPS/eip-721#specification\&quot; target&#x3D;\&quot;_blank\&quot;&gt;EIP-721&lt;/a&gt;</value>
        [DataMember(Name = "url", IsRequired = true, EmitDefaultValue = true)]
        public List<string> Url { get; set; }

        /// <summary>
        /// Address of NFT token
        /// </summary>
        /// <value>Address of NFT token</value>
        [DataMember(Name = "contractAddress", IsRequired = true, EmitDefaultValue = true)]
        public string ContractAddress { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MintMultipleNftMinter {\n");
            sb.Append("  Chain: ").Append(Chain).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  TokenId: ").Append(TokenId).Append("\n");
            sb.Append("  Minter: ").Append(Minter).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
            sb.Append("  FeeCurrency: ").Append(FeeCurrency).Append("\n");
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
            return this.Equals(input as MintMultipleNftMinter);
        }

        /// <summary>
        /// Returns true if MintMultipleNftMinter instances are equal
        /// </summary>
        /// <param name="input">Instance of MintMultipleNftMinter to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MintMultipleNftMinter input)
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
                    this.To != null &&
                    input.To != null &&
                    this.To.SequenceEqual(input.To)
                ) && 
                (
                    this.TokenId == input.TokenId ||
                    this.TokenId != null &&
                    input.TokenId != null &&
                    this.TokenId.SequenceEqual(input.TokenId)
                ) && 
                (
                    this.Minter == input.Minter ||
                    (this.Minter != null &&
                    this.Minter.Equals(input.Minter))
                ) && 
                (
                    this.Url == input.Url ||
                    this.Url != null &&
                    input.Url != null &&
                    this.Url.SequenceEqual(input.Url)
                ) && 
                (
                    this.ContractAddress == input.ContractAddress ||
                    (this.ContractAddress != null &&
                    this.ContractAddress.Equals(input.ContractAddress))
                ) && 
                (
                    this.FeeCurrency == input.FeeCurrency ||
                    this.FeeCurrency.Equals(input.FeeCurrency)
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
                if (this.Minter != null)
                {
                    hashCode = (hashCode * 59) + this.Minter.GetHashCode();
                }
                if (this.Url != null)
                {
                    hashCode = (hashCode * 59) + this.Url.GetHashCode();
                }
                if (this.ContractAddress != null)
                {
                    hashCode = (hashCode * 59) + this.ContractAddress.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.FeeCurrency.GetHashCode();
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
            // Minter (string) maxLength
            if (this.Minter != null && this.Minter.Length > 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Minter, length must be less than 42.", new [] { "Minter" });
            }

            // Minter (string) minLength
            if (this.Minter != null && this.Minter.Length < 43)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Minter, length must be greater than 43.", new [] { "Minter" });
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

            yield break;
        }
    }

}
