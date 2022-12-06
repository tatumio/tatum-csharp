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
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Tatum.CSharp.Ethereum.Core.Model
{
    /// <summary>
    /// DeployNftKMS
    /// </summary>
    [DataContract(Name = "DeployNftKMS")]
    public partial class DeployNftKMS : IEquatable<DeployNftKMS>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeployNftKMS" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DeployNftKMS() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DeployNftKMS" /> class.
        /// </summary>
        /// <param name="name">Name of the NFT token (required).</param>
        /// <param name="provenance">True if the contract is provenance percentage royalty type. False by default. &lt;a href&#x3D;\&quot;https://github.com/tatumio/smart-contracts\&quot; target&#x3D;\&quot;_blank\&quot;&gt;Details and sources available here.&lt;/a&gt;.</param>
        /// <param name="cashback">True if the contract is fixed price royalty type. False by default. &lt;a href&#x3D;\&quot;https://github.com/tatumio/smart-contracts\&quot; target&#x3D;\&quot;_blank\&quot;&gt;Details and sources available here.&lt;/a&gt;.</param>
        /// <param name="publicMint">True if the contract is publicMint type. False by default..</param>
        /// <param name="symbol">Symbol of the NFT token (required).</param>
        /// <param name="index">If signatureId is mnemonic-based, this is the index to the specific address from that mnemonic..</param>
        /// <param name="signatureId">Identifier of the private key associated in signing application. Private key, or signature Id must be present. (required).</param>
        /// <param name="nonce">The nonce to be set to the transaction; if not present, the last known nonce will be used.</param>
        /// <param name="fee">fee.</param>
        public DeployNftKMS(string name = default(string), bool provenance = default(bool), bool cashback = default(bool), bool publicMint = default(bool), string symbol = default(string), decimal index = default(decimal), Guid signatureId = default(Guid), decimal nonce = default(decimal), CustomFee fee = default(CustomFee))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for DeployNftKMS and cannot be null");
            }
            this.Name = name;
            // to ensure "symbol" is required (not null)
            if (symbol == null)
            {
                throw new ArgumentNullException("symbol is a required property for DeployNftKMS and cannot be null");
            }
            this.Symbol = symbol;
            this.SignatureId = signatureId;
            this.Provenance = provenance;
            this.Cashback = cashback;
            this.PublicMint = publicMint;
            this.Index = index;
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
        /// Name of the NFT token
        /// </summary>
        /// <value>Name of the NFT token</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// True if the contract is provenance percentage royalty type. False by default. &lt;a href&#x3D;\&quot;https://github.com/tatumio/smart-contracts\&quot; target&#x3D;\&quot;_blank\&quot;&gt;Details and sources available here.&lt;/a&gt;
        /// </summary>
        /// <value>True if the contract is provenance percentage royalty type. False by default. &lt;a href&#x3D;\&quot;https://github.com/tatumio/smart-contracts\&quot; target&#x3D;\&quot;_blank\&quot;&gt;Details and sources available here.&lt;/a&gt;</value>
        [DataMember(Name = "provenance", EmitDefaultValue = true)]
        public bool Provenance { get; set; }

        /// <summary>
        /// True if the contract is fixed price royalty type. False by default. &lt;a href&#x3D;\&quot;https://github.com/tatumio/smart-contracts\&quot; target&#x3D;\&quot;_blank\&quot;&gt;Details and sources available here.&lt;/a&gt;
        /// </summary>
        /// <value>True if the contract is fixed price royalty type. False by default. &lt;a href&#x3D;\&quot;https://github.com/tatumio/smart-contracts\&quot; target&#x3D;\&quot;_blank\&quot;&gt;Details and sources available here.&lt;/a&gt;</value>
        [DataMember(Name = "cashback", EmitDefaultValue = true)]
        public bool Cashback { get; set; }

        /// <summary>
        /// True if the contract is publicMint type. False by default.
        /// </summary>
        /// <value>True if the contract is publicMint type. False by default.</value>
        [DataMember(Name = "publicMint", EmitDefaultValue = true)]
        public bool PublicMint { get; set; }

        /// <summary>
        /// Symbol of the NFT token
        /// </summary>
        /// <value>Symbol of the NFT token</value>
        [DataMember(Name = "symbol", IsRequired = true, EmitDefaultValue = true)]
        public string Symbol { get; set; }

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
            sb.Append("class DeployNftKMS {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Provenance: ").Append(Provenance).Append("\n");
            sb.Append("  Cashback: ").Append(Cashback).Append("\n");
            sb.Append("  PublicMint: ").Append(PublicMint).Append("\n");
            sb.Append("  Symbol: ").Append(Symbol).Append("\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
            sb.Append("  SignatureId: ").Append(SignatureId).Append("\n");
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
            return this.Equals(input as DeployNftKMS);
        }

        /// <summary>
        /// Returns true if DeployNftKMS instances are equal
        /// </summary>
        /// <param name="input">Instance of DeployNftKMS to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DeployNftKMS input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Provenance == input.Provenance ||
                    this.Provenance.Equals(input.Provenance)
                ) && 
                (
                    this.Cashback == input.Cashback ||
                    this.Cashback.Equals(input.Cashback)
                ) && 
                (
                    this.PublicMint == input.PublicMint ||
                    this.PublicMint.Equals(input.PublicMint)
                ) && 
                (
                    this.Symbol == input.Symbol ||
                    (this.Symbol != null &&
                    this.Symbol.Equals(input.Symbol))
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
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Provenance.GetHashCode();
                hashCode = (hashCode * 59) + this.Cashback.GetHashCode();
                hashCode = (hashCode * 59) + this.PublicMint.GetHashCode();
                if (this.Symbol != null)
                {
                    hashCode = (hashCode * 59) + this.Symbol.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Index.GetHashCode();
                if (this.SignatureId != null)
                {
                    hashCode = (hashCode * 59) + this.SignatureId.GetHashCode();
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
