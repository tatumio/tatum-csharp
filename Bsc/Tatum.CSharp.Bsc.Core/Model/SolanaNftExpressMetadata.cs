/*
 * Tatum API Reference
 *
 * # Welcome to the Tatum API Reference!  ## What is Tatum?  Tatum offers a flexible framework to build, run, and scale blockchain apps fast. To learn more about the Tatum blockchain development framework, visit [our website](https://tatum.io/framework).  The Tatum API features powerful endpoints that simplify a complex blockchain into single API requests. Code for all supported blockchains using unified API calls.  ## Need help?  To chat with other developers, get help from the Support team, and engage with the thriving Tatum community, join  our [Discord server](https://discord.com/invite/tatum). For more information about how to work with Tatum, review the [online documentation](https://docs.tatum.io/).  ## About this API Reference  The Tatum API Reference is based on OpenAPI Specification v3.1.0 with a few [vendor extensions](https://github.com/Redocly/redoc/blob/master/docs/redoc-vendor-extensions.md) applied.  # Authentication  When using the Tatum API, you authenticate yourself with an **API key**. <SecurityDefinitions /> 
 *
 * The version of the OpenAPI document: 3.17.1
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
using FileParameter = Tatum.CSharp.Bsc.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.Bsc.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.Bsc.Core.Model
{
    /// <summary>
    /// SolanaNftExpressMetadata
    /// </summary>
    [DataContract(Name = "SolanaNftExpressMetadata")]
    public partial class SolanaNftExpressMetadata : IEquatable<SolanaNftExpressMetadata>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SolanaNftExpressMetadata" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SolanaNftExpressMetadata() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SolanaNftExpressMetadata" /> class.
        /// </summary>
        /// <param name="name">The name of the NFT (required).</param>
        /// <param name="symbol">The symbol or abbreviated name of the NFT (required).</param>
        /// <param name="sellerFeeBasisPoints">The royalty that will be paid to the authors of the minted NFT every time the NFT is transferred&lt;br/&gt;The royalty is calculated as a percentage of the NFT price. To set the royalty to 1%, set this parameter to &lt;code&gt;100&lt;/code&gt;; to set 10%, set this parameter to &lt;code&gt;1000&lt;/code&gt;; to set 50%, set this parameter to &lt;code&gt;5000&lt;/code&gt;, and so on.&lt;br/&gt;To specify the NFT authors and their shares in the royalty, set the &lt;code&gt;creators&lt;/code&gt; parameter.&lt;br/&gt;To disable the royalty for the NFT completely, set &lt;code&gt;sellerFeeBasisPoints&lt;/code&gt; to &lt;code&gt;0&lt;/code&gt; and do not set &lt;code&gt;creators&lt;/code&gt;. (required).</param>
        /// <param name="uri">The URL pointing to the NFT metadata; for more information, see &lt;a href&#x3D;\&quot;https://eips.ethereum.org/EIPS/eip-721#specification\&quot; target&#x3D;\&quot;_blank\&quot;&gt;EIP-721&lt;/a&gt; (required).</param>
        /// <param name="collection">The blockchain address of the NFT collection where the NFT will be minted in. By default, the NFT is minted as not verified (is not considered a part of the collection). To verify the NFT in the collection, use the &lt;a href&#x3D;\&quot;https://apidoc.tatum.io/tag/NFT-(ERC-721-or-compatible)#operation/NftVerifyInCollection\&quot; target&#x3D;\&quot;_blank\&quot;&gt;NFT verification API&lt;/a&gt;. To know more about Solana collections and verification, refer to the &lt;a href&#x3D;\&quot;https://docs.metaplex.com/programs/token-metadata/certified-collections\&quot; target&#x3D;\&quot;_blank\&quot;&gt;Solana user documentation&lt;/a&gt;..</param>
        /// <param name="mutable">Specifies whether the NFT metadata is mutable (\&quot;true\&quot;) or immutable (\&quot;false\&quot;); if not set, defaults to \&quot;true\&quot; (default to true).</param>
        /// <param name="creators">The blockchain addresses where the royalties will be sent every time the minted NFT is transferred.</param>
        public SolanaNftExpressMetadata(string name = default(string), string symbol = default(string), decimal sellerFeeBasisPoints = default(decimal), string uri = default(string), string collection = default(string), bool mutable = true, List<SolanaNftMetadataCreator> creators = default(List<SolanaNftMetadataCreator>))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for SolanaNftExpressMetadata and cannot be null");
            }
            this.Name = name;
            // to ensure "symbol" is required (not null)
            if (symbol == null)
            {
                throw new ArgumentNullException("symbol is a required property for SolanaNftExpressMetadata and cannot be null");
            }
            this.Symbol = symbol;
            this.SellerFeeBasisPoints = sellerFeeBasisPoints;
            // to ensure "uri" is required (not null)
            if (uri == null)
            {
                throw new ArgumentNullException("uri is a required property for SolanaNftExpressMetadata and cannot be null");
            }
            this.Uri = uri;
            this.Collection = collection;
            this.Mutable = mutable;
            this.Creators = creators;
        }


        /// <summary>
        /// The name of the NFT
        /// </summary>
        /// <value>The name of the NFT</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// The symbol or abbreviated name of the NFT
        /// </summary>
        /// <value>The symbol or abbreviated name of the NFT</value>
        [DataMember(Name = "symbol", IsRequired = true, EmitDefaultValue = true)]
        public string Symbol { get; set; }

        /// <summary>
        /// The royalty that will be paid to the authors of the minted NFT every time the NFT is transferred&lt;br/&gt;The royalty is calculated as a percentage of the NFT price. To set the royalty to 1%, set this parameter to &lt;code&gt;100&lt;/code&gt;; to set 10%, set this parameter to &lt;code&gt;1000&lt;/code&gt;; to set 50%, set this parameter to &lt;code&gt;5000&lt;/code&gt;, and so on.&lt;br/&gt;To specify the NFT authors and their shares in the royalty, set the &lt;code&gt;creators&lt;/code&gt; parameter.&lt;br/&gt;To disable the royalty for the NFT completely, set &lt;code&gt;sellerFeeBasisPoints&lt;/code&gt; to &lt;code&gt;0&lt;/code&gt; and do not set &lt;code&gt;creators&lt;/code&gt;.
        /// </summary>
        /// <value>The royalty that will be paid to the authors of the minted NFT every time the NFT is transferred&lt;br/&gt;The royalty is calculated as a percentage of the NFT price. To set the royalty to 1%, set this parameter to &lt;code&gt;100&lt;/code&gt;; to set 10%, set this parameter to &lt;code&gt;1000&lt;/code&gt;; to set 50%, set this parameter to &lt;code&gt;5000&lt;/code&gt;, and so on.&lt;br/&gt;To specify the NFT authors and their shares in the royalty, set the &lt;code&gt;creators&lt;/code&gt; parameter.&lt;br/&gt;To disable the royalty for the NFT completely, set &lt;code&gt;sellerFeeBasisPoints&lt;/code&gt; to &lt;code&gt;0&lt;/code&gt; and do not set &lt;code&gt;creators&lt;/code&gt;.</value>
        [DataMember(Name = "sellerFeeBasisPoints", IsRequired = true, EmitDefaultValue = true)]
        public decimal SellerFeeBasisPoints { get; set; }

        /// <summary>
        /// The URL pointing to the NFT metadata; for more information, see &lt;a href&#x3D;\&quot;https://eips.ethereum.org/EIPS/eip-721#specification\&quot; target&#x3D;\&quot;_blank\&quot;&gt;EIP-721&lt;/a&gt;
        /// </summary>
        /// <value>The URL pointing to the NFT metadata; for more information, see &lt;a href&#x3D;\&quot;https://eips.ethereum.org/EIPS/eip-721#specification\&quot; target&#x3D;\&quot;_blank\&quot;&gt;EIP-721&lt;/a&gt;</value>
        [DataMember(Name = "uri", IsRequired = true, EmitDefaultValue = true)]
        public string Uri { get; set; }

        /// <summary>
        /// The blockchain address of the NFT collection where the NFT will be minted in. By default, the NFT is minted as not verified (is not considered a part of the collection). To verify the NFT in the collection, use the &lt;a href&#x3D;\&quot;https://apidoc.tatum.io/tag/NFT-(ERC-721-or-compatible)#operation/NftVerifyInCollection\&quot; target&#x3D;\&quot;_blank\&quot;&gt;NFT verification API&lt;/a&gt;. To know more about Solana collections and verification, refer to the &lt;a href&#x3D;\&quot;https://docs.metaplex.com/programs/token-metadata/certified-collections\&quot; target&#x3D;\&quot;_blank\&quot;&gt;Solana user documentation&lt;/a&gt;.
        /// </summary>
        /// <value>The blockchain address of the NFT collection where the NFT will be minted in. By default, the NFT is minted as not verified (is not considered a part of the collection). To verify the NFT in the collection, use the &lt;a href&#x3D;\&quot;https://apidoc.tatum.io/tag/NFT-(ERC-721-or-compatible)#operation/NftVerifyInCollection\&quot; target&#x3D;\&quot;_blank\&quot;&gt;NFT verification API&lt;/a&gt;. To know more about Solana collections and verification, refer to the &lt;a href&#x3D;\&quot;https://docs.metaplex.com/programs/token-metadata/certified-collections\&quot; target&#x3D;\&quot;_blank\&quot;&gt;Solana user documentation&lt;/a&gt;.</value>
        [DataMember(Name = "collection", EmitDefaultValue = false)]
        public string Collection { get; set; }

        /// <summary>
        /// Specifies whether the NFT metadata is mutable (\&quot;true\&quot;) or immutable (\&quot;false\&quot;); if not set, defaults to \&quot;true\&quot;
        /// </summary>
        /// <value>Specifies whether the NFT metadata is mutable (\&quot;true\&quot;) or immutable (\&quot;false\&quot;); if not set, defaults to \&quot;true\&quot;</value>
        [DataMember(Name = "mutable", EmitDefaultValue = true)]
        public bool Mutable { get; set; }

        /// <summary>
        /// The blockchain addresses where the royalties will be sent every time the minted NFT is transferred
        /// </summary>
        /// <value>The blockchain addresses where the royalties will be sent every time the minted NFT is transferred</value>
        [DataMember(Name = "creators", EmitDefaultValue = false)]
        public List<SolanaNftMetadataCreator> Creators { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SolanaNftExpressMetadata {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Symbol: ").Append(Symbol).Append("\n");
            sb.Append("  SellerFeeBasisPoints: ").Append(SellerFeeBasisPoints).Append("\n");
            sb.Append("  Uri: ").Append(Uri).Append("\n");
            sb.Append("  Collection: ").Append(Collection).Append("\n");
            sb.Append("  Mutable: ").Append(Mutable).Append("\n");
            sb.Append("  Creators: ").Append(Creators).Append("\n");
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
            return this.Equals(input as SolanaNftExpressMetadata);
        }

        /// <summary>
        /// Returns true if SolanaNftExpressMetadata instances are equal
        /// </summary>
        /// <param name="input">Instance of SolanaNftExpressMetadata to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SolanaNftExpressMetadata input)
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
                    this.Symbol == input.Symbol ||
                    (this.Symbol != null &&
                    this.Symbol.Equals(input.Symbol))
                ) && 
                (
                    this.SellerFeeBasisPoints == input.SellerFeeBasisPoints ||
                    this.SellerFeeBasisPoints.Equals(input.SellerFeeBasisPoints)
                ) && 
                (
                    this.Uri == input.Uri ||
                    (this.Uri != null &&
                    this.Uri.Equals(input.Uri))
                ) && 
                (
                    this.Collection == input.Collection ||
                    (this.Collection != null &&
                    this.Collection.Equals(input.Collection))
                ) && 
                (
                    this.Mutable == input.Mutable ||
                    this.Mutable.Equals(input.Mutable)
                ) && 
                (
                    this.Creators == input.Creators ||
                    this.Creators != null &&
                    input.Creators != null &&
                    this.Creators.SequenceEqual(input.Creators)
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
                if (this.Symbol != null)
                {
                    hashCode = (hashCode * 59) + this.Symbol.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.SellerFeeBasisPoints.GetHashCode();
                if (this.Uri != null)
                {
                    hashCode = (hashCode * 59) + this.Uri.GetHashCode();
                }
                if (this.Collection != null)
                {
                    hashCode = (hashCode * 59) + this.Collection.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Mutable.GetHashCode();
                if (this.Creators != null)
                {
                    hashCode = (hashCode * 59) + this.Creators.GetHashCode();
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
            if (this.Name != null && this.Name.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be less than 255.", new [] { "Name" });
            }

            // Symbol (string) maxLength
            if (this.Symbol != null && this.Symbol.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Symbol, length must be less than 255.", new [] { "Symbol" });
            }

            // Uri (string) maxLength
            if (this.Uri != null && this.Uri.Length > 500)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Uri, length must be less than 500.", new [] { "Uri" });
            }

            // Collection (string) maxLength
            if (this.Collection != null && this.Collection.Length > 44)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Collection, length must be less than 44.", new [] { "Collection" });
            }

            // Collection (string) minLength
            if (this.Collection != null && this.Collection.Length < 43)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Collection, length must be greater than 43.", new [] { "Collection" });
            }

            yield break;
        }
    }

}
