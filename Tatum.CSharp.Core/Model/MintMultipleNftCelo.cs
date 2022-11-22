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
    /// MintMultipleNftCelo
    /// </summary>
    [DataContract(Name = "MintMultipleNftCelo")]
    public partial class MintMultipleNftCelo : IEquatable<MintMultipleNftCelo>, IValidatableObject
    {
        /// <summary>
        /// The blockchain to work with
        /// </summary>
        /// <value>The blockchain to work with</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ChainEnum
        {
            /// <summary>
            /// Enum CELO for value: CELO
            /// </summary>
            [EnumMember(Value = "CELO")]
            CELO = 1

        }


        /// <summary>
        /// The blockchain to work with
        /// </summary>
        /// <value>The blockchain to work with</value>
        [DataMember(Name = "chain", IsRequired = true, EmitDefaultValue = true)]
        public ChainEnum Chain { get; set; }
        /// <summary>
        /// The currency in which the transaction fee will be paid
        /// </summary>
        /// <value>The currency in which the transaction fee will be paid</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum FeeCurrencyEnum
        {
            /// <summary>
            /// Enum CELO for value: CELO
            /// </summary>
            [EnumMember(Value = "CELO")]
            CELO = 1,

            /// <summary>
            /// Enum CUSD for value: CUSD
            /// </summary>
            [EnumMember(Value = "CUSD")]
            CUSD = 2,

            /// <summary>
            /// Enum CEUR for value: CEUR
            /// </summary>
            [EnumMember(Value = "CEUR")]
            CEUR = 3

        }


        /// <summary>
        /// The currency in which the transaction fee will be paid
        /// </summary>
        /// <value>The currency in which the transaction fee will be paid</value>
        [DataMember(Name = "feeCurrency", IsRequired = true, EmitDefaultValue = true)]
        public FeeCurrencyEnum FeeCurrency { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MintMultipleNftCelo" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MintMultipleNftCelo() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MintMultipleNftCelo" /> class.
        /// </summary>
        /// <param name="chain">The blockchain to work with (required).</param>
        /// <param name="to">Blockchain address to send NFT token to. (required).</param>
        /// <param name="tokenId">ID of token to be created. (required).</param>
        /// <param name="url">The URL pointing to the NFT metadata; for more information, see &lt;a href&#x3D;\&quot;https://eips.ethereum.org/EIPS/eip-721#specification\&quot; target&#x3D;\&quot;_blank\&quot;&gt;EIP-721&lt;/a&gt; (required).</param>
        /// <param name="authorAddresses">List of addresses for every token, where royalty cashback for every transfer of this NFT will be send. Royalties are paid in native blockchain currency CELO..</param>
        /// <param name="cashbackValues">List of values for every token, which will be paid as a royalty for author of the NFT token with every token transfer. This is exact value in native blockchain currency..</param>
        /// <param name="contractAddress">Address of NFT token (required).</param>
        /// <param name="fromPrivateKey">Private key of sender address. Private key, or signature Id must be present. (required).</param>
        /// <param name="nonce">The nonce to be set to the transaction; if not present, the last known nonce will be used.</param>
        /// <param name="feeCurrency">The currency in which the transaction fee will be paid (required).</param>
        public MintMultipleNftCelo(ChainEnum chain = default(ChainEnum), List<string> to = default(List<string>), List<string> tokenId = default(List<string>), List<string> url = default(List<string>), List<List<string>> authorAddresses = default(List<List<string>>), List<List<string>> cashbackValues = default(List<List<string>>), string contractAddress = default(string), string fromPrivateKey = default(string), decimal nonce = default(decimal), FeeCurrencyEnum feeCurrency = default(FeeCurrencyEnum))
        {
            this.Chain = chain;
            // to ensure "to" is required (not null)
            if (to == null)
            {
                throw new ArgumentNullException("to is a required property for MintMultipleNftCelo and cannot be null");
            }
            this.To = to;
            // to ensure "tokenId" is required (not null)
            if (tokenId == null)
            {
                throw new ArgumentNullException("tokenId is a required property for MintMultipleNftCelo and cannot be null");
            }
            this.TokenId = tokenId;
            // to ensure "url" is required (not null)
            if (url == null)
            {
                throw new ArgumentNullException("url is a required property for MintMultipleNftCelo and cannot be null");
            }
            this.Url = url;
            // to ensure "contractAddress" is required (not null)
            if (contractAddress == null)
            {
                throw new ArgumentNullException("contractAddress is a required property for MintMultipleNftCelo and cannot be null");
            }
            this.ContractAddress = contractAddress;
            // to ensure "fromPrivateKey" is required (not null)
            if (fromPrivateKey == null)
            {
                throw new ArgumentNullException("fromPrivateKey is a required property for MintMultipleNftCelo and cannot be null");
            }
            this.FromPrivateKey = fromPrivateKey;
            this.FeeCurrency = feeCurrency;
            this.AuthorAddresses = authorAddresses;
            this.CashbackValues = cashbackValues;
            this.Nonce = nonce;
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
        /// The URL pointing to the NFT metadata; for more information, see &lt;a href&#x3D;\&quot;https://eips.ethereum.org/EIPS/eip-721#specification\&quot; target&#x3D;\&quot;_blank\&quot;&gt;EIP-721&lt;/a&gt;
        /// </summary>
        /// <value>The URL pointing to the NFT metadata; for more information, see &lt;a href&#x3D;\&quot;https://eips.ethereum.org/EIPS/eip-721#specification\&quot; target&#x3D;\&quot;_blank\&quot;&gt;EIP-721&lt;/a&gt;</value>
        [DataMember(Name = "url", IsRequired = true, EmitDefaultValue = true)]
        public List<string> Url { get; set; }

        /// <summary>
        /// List of addresses for every token, where royalty cashback for every transfer of this NFT will be send. Royalties are paid in native blockchain currency CELO.
        /// </summary>
        /// <value>List of addresses for every token, where royalty cashback for every transfer of this NFT will be send. Royalties are paid in native blockchain currency CELO.</value>
        [DataMember(Name = "authorAddresses", EmitDefaultValue = false)]
        public List<List<string>> AuthorAddresses { get; set; }

        /// <summary>
        /// List of values for every token, which will be paid as a royalty for author of the NFT token with every token transfer. This is exact value in native blockchain currency.
        /// </summary>
        /// <value>List of values for every token, which will be paid as a royalty for author of the NFT token with every token transfer. This is exact value in native blockchain currency.</value>
        [DataMember(Name = "cashbackValues", EmitDefaultValue = false)]
        public List<List<string>> CashbackValues { get; set; }

        /// <summary>
        /// Address of NFT token
        /// </summary>
        /// <value>Address of NFT token</value>
        [DataMember(Name = "contractAddress", IsRequired = true, EmitDefaultValue = true)]
        public string ContractAddress { get; set; }

        /// <summary>
        /// Private key of sender address. Private key, or signature Id must be present.
        /// </summary>
        /// <value>Private key of sender address. Private key, or signature Id must be present.</value>
        [DataMember(Name = "fromPrivateKey", IsRequired = true, EmitDefaultValue = true)]
        public string FromPrivateKey { get; set; }

        /// <summary>
        /// The nonce to be set to the transaction; if not present, the last known nonce will be used
        /// </summary>
        /// <value>The nonce to be set to the transaction; if not present, the last known nonce will be used</value>
        [DataMember(Name = "nonce", EmitDefaultValue = false)]
        public decimal Nonce { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MintMultipleNftCelo {\n");
            sb.Append("  Chain: ").Append(Chain).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  TokenId: ").Append(TokenId).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  AuthorAddresses: ").Append(AuthorAddresses).Append("\n");
            sb.Append("  CashbackValues: ").Append(CashbackValues).Append("\n");
            sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
            sb.Append("  FromPrivateKey: ").Append(FromPrivateKey).Append("\n");
            sb.Append("  Nonce: ").Append(Nonce).Append("\n");
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
            return this.Equals(input as MintMultipleNftCelo);
        }

        /// <summary>
        /// Returns true if MintMultipleNftCelo instances are equal
        /// </summary>
        /// <param name="input">Instance of MintMultipleNftCelo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MintMultipleNftCelo input)
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
                    this.Url == input.Url ||
                    this.Url != null &&
                    input.Url != null &&
                    this.Url.SequenceEqual(input.Url)
                ) && 
                (
                    this.AuthorAddresses == input.AuthorAddresses ||
                    this.AuthorAddresses != null &&
                    input.AuthorAddresses != null &&
                    this.AuthorAddresses.SequenceEqual(input.AuthorAddresses)
                ) && 
                (
                    this.CashbackValues == input.CashbackValues ||
                    this.CashbackValues != null &&
                    input.CashbackValues != null &&
                    this.CashbackValues.SequenceEqual(input.CashbackValues)
                ) && 
                (
                    this.ContractAddress == input.ContractAddress ||
                    (this.ContractAddress != null &&
                    this.ContractAddress.Equals(input.ContractAddress))
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
                if (this.Url != null)
                {
                    hashCode = (hashCode * 59) + this.Url.GetHashCode();
                }
                if (this.AuthorAddresses != null)
                {
                    hashCode = (hashCode * 59) + this.AuthorAddresses.GetHashCode();
                }
                if (this.CashbackValues != null)
                {
                    hashCode = (hashCode * 59) + this.CashbackValues.GetHashCode();
                }
                if (this.ContractAddress != null)
                {
                    hashCode = (hashCode * 59) + this.ContractAddress.GetHashCode();
                }
                if (this.FromPrivateKey != null)
                {
                    hashCode = (hashCode * 59) + this.FromPrivateKey.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Nonce.GetHashCode();
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
