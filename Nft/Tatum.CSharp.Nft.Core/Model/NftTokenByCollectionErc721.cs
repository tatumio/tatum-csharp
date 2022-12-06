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
using FileParameter = Tatum.CSharp.Nft.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.Nft.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.Nft.Core.Model
{
    /// <summary>
    /// NftTokenByCollectionErc721
    /// </summary>
    [DataContract(Name = "NftTokenByCollectionErc721")]
    public partial class NftTokenByCollectionErc721 : IEquatable<NftTokenByCollectionErc721>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NftTokenByCollectionErc721" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected NftTokenByCollectionErc721() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="NftTokenByCollectionErc721" /> class.
        /// </summary>
        /// <param name="tokenId">ID of the token. (required).</param>
        /// <param name="metadata">metadata.</param>
        public NftTokenByCollectionErc721(string tokenId = default(string), NftTokenByCollectionErc721TokenMetadata metadata = default(NftTokenByCollectionErc721TokenMetadata))
        {
            // to ensure "tokenId" is required (not null)
            if (tokenId == null)
            {
                throw new ArgumentNullException("tokenId is a required property for NftTokenByCollectionErc721 and cannot be null");
            }
            this.TokenId = tokenId;
            this.Metadata = metadata;
        }


        /// <summary>
        /// ID of the token.
        /// </summary>
        /// <value>ID of the token.</value>
        [DataMember(Name = "tokenId", IsRequired = true, EmitDefaultValue = true)]
        public string TokenId { get; set; }

        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        [DataMember(Name = "metadata", EmitDefaultValue = false)]
        public NftTokenByCollectionErc721TokenMetadata Metadata { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class NftTokenByCollectionErc721 {\n");
            sb.Append("  TokenId: ").Append(TokenId).Append("\n");
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
            return this.Equals(input as NftTokenByCollectionErc721);
        }

        /// <summary>
        /// Returns true if NftTokenByCollectionErc721 instances are equal
        /// </summary>
        /// <param name="input">Instance of NftTokenByCollectionErc721 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NftTokenByCollectionErc721 input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.TokenId == input.TokenId ||
                    (this.TokenId != null &&
                    this.TokenId.Equals(input.TokenId))
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
                if (this.TokenId != null)
                {
                    hashCode = (hashCode * 59) + this.TokenId.GetHashCode();
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
            // TokenId (string) maxLength
            if (this.TokenId != null && this.TokenId.Length > 78)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TokenId, length must be less than 78.", new [] { "TokenId" });
            }

            yield break;
        }
    }

}
