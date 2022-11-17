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
    /// &lt;p&gt;The &lt;code&gt;MintNftExpressSolana&lt;/code&gt; schema lets you mint NFTs on Solana using &lt;b&gt;NTF Express&lt;/b&gt; with the pre-built smart contract provided by Tatum.&lt;br/&gt;For more information, see \&quot;Use the pre-built smart contract provided by Tatum to mint NFTs\&quot; in &lt;a href&#x3D;\&quot;#operation/NftMintErc721\&quot;&gt;Mint an NFT&lt;/a&gt;.&lt;/p&gt;&lt;br/&gt;
    /// </summary>
    [DataContract(Name = "MintNftExpressSolana")]
    public partial class MintNftExpressSolana : IEquatable<MintNftExpressSolana>, IValidatableObject
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
        /// Initializes a new instance of the <see cref="MintNftExpressSolana" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MintNftExpressSolana() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MintNftExpressSolana" /> class.
        /// </summary>
        /// <param name="chain">The blockchain to work with (required).</param>
        /// <param name="to">The blockchain address to send the NFT to (required).</param>
        /// <param name="metadata">metadata (required).</param>
        public MintNftExpressSolana(ChainEnum chain = default(ChainEnum), string to = default(string), SolanaNftExpressMetadata metadata = default(SolanaNftExpressMetadata))
        {
            this.Chain = chain;
            // to ensure "to" is required (not null)
            if (to == null)
            {
                throw new ArgumentNullException("to is a required property for MintNftExpressSolana and cannot be null");
            }
            this.To = to;
            // to ensure "metadata" is required (not null)
            if (metadata == null)
            {
                throw new ArgumentNullException("metadata is a required property for MintNftExpressSolana and cannot be null");
            }
            this.Metadata = metadata;
        }

        /// <summary>
        /// The blockchain address to send the NFT to
        /// </summary>
        /// <value>The blockchain address to send the NFT to</value>
        [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = true)]
        public string To { get; set; }

        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        [DataMember(Name = "metadata", IsRequired = true, EmitDefaultValue = true)]
        public SolanaNftExpressMetadata Metadata { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class MintNftExpressSolana {\n");
            sb.Append("  Chain: ").Append(Chain).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
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
            return this.Equals(input as MintNftExpressSolana);
        }

        /// <summary>
        /// Returns true if MintNftExpressSolana instances are equal
        /// </summary>
        /// <param name="input">Instance of MintNftExpressSolana to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MintNftExpressSolana input)
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
                    this.Metadata == input.Metadata ||
                    (this.Metadata != null &&
                    this.Metadata.Equals(input.Metadata))
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
                if (this.Metadata != null)
                {
                    hashCode = (hashCode * 59) + this.Metadata.GetHashCode();
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
            // To (string) maxLength
            if (this.To != null && this.To.Length > 44)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for To, length must be less than 44.", new [] { "To" });
            }

            // To (string) minLength
            if (this.To != null && this.To.Length < 43)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for To, length must be greater than 43.", new [] { "To" });
            }

            yield break;
        }
    }

}