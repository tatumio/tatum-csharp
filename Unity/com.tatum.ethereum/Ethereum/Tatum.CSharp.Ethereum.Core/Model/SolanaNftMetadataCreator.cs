/*
 * Tatum API Reference
 *
 * # Welcome to the Tatum API Reference!  ## What is Tatum?  Tatum offers a flexible framework to build, run, and scale blockchain apps fast. To learn more about the Tatum blockchain development framework, visit [our website](https://tatum.io/framework).  The Tatum API features powerful endpoints that simplify a complex blockchain into single API requests. Code for all supported blockchains using unified API calls.  ## Supported blockchains  Tatum supports multiple blockchains and various blockchain features.  Because not all blockchains function identically, Tatum supports a different set of features on each blockchain.  To see all the blockchains that Tatum supports, please refer to [this article](https://docs.tatum.io/introduction/supported-blockchains).  ## Need help?  To chat with other developers, get help from the Support team, and engage with the thriving Tatum community, join  our [Discord server](https://discord.com/invite/tatum). For more information about how to work with Tatum, review the [online documentation](https://docs.tatum.io/).  # Authentication  When using the Tatum API, you authenticate yourself with an **API key**. <SecurityDefinitions /> 
 *
 * The version of the OpenAPI document: 3.17.2
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
using FileParameter = Tatum.CSharp.Ethereum.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.Ethereum.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.Ethereum.Core.Model
{
    /// <summary>
    /// SolanaNftMetadataCreator
    /// </summary>
    [DataContract(Name = "SolanaNftMetadataCreator")]
    public partial class SolanaNftMetadataCreator : IEquatable<SolanaNftMetadataCreator>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SolanaNftMetadataCreator" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SolanaNftMetadataCreator() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SolanaNftMetadataCreator" /> class.
        /// </summary>
        /// <param name="address">The blockchain address of the NFT creator (required).</param>
        /// <param name="verified">If set to \&quot;true\&quot;, the NFT creator was verified. Only the address whose private key was used during the minting of the NFT can be a verified creator. If you are minting the NFT using NFT Express, set this parameter to \&quot;false\&quot;. (required).</param>
        /// <param name="share">The share to be sent to the NFT creator (in %) (required).</param>
        public SolanaNftMetadataCreator(string address = default(string), bool verified = default(bool), decimal share = default(decimal))
        {
            // to ensure "address" is required (not null)
            if (address == null)
            {
                throw new ArgumentNullException("address is a required property for SolanaNftMetadataCreator and cannot be null");
            }
            this.Address = address;
            this.Verified = verified;
            this.Share = share;
        }


        /// <summary>
        /// The blockchain address of the NFT creator
        /// </summary>
        /// <value>The blockchain address of the NFT creator</value>
        [DataMember(Name = "address", IsRequired = true, EmitDefaultValue = true)]
        public string Address { get; set; }

        /// <summary>
        /// If set to \&quot;true\&quot;, the NFT creator was verified. Only the address whose private key was used during the minting of the NFT can be a verified creator. If you are minting the NFT using NFT Express, set this parameter to \&quot;false\&quot;.
        /// </summary>
        /// <value>If set to \&quot;true\&quot;, the NFT creator was verified. Only the address whose private key was used during the minting of the NFT can be a verified creator. If you are minting the NFT using NFT Express, set this parameter to \&quot;false\&quot;.</value>
        [DataMember(Name = "verified", IsRequired = true, EmitDefaultValue = true)]
        public bool Verified { get; set; }

        /// <summary>
        /// The share to be sent to the NFT creator (in %)
        /// </summary>
        /// <value>The share to be sent to the NFT creator (in %)</value>
        [DataMember(Name = "share", IsRequired = true, EmitDefaultValue = true)]
        public decimal Share { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SolanaNftMetadataCreator {\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Verified: ").Append(Verified).Append("\n");
            sb.Append("  Share: ").Append(Share).Append("\n");
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
            return this.Equals(input as SolanaNftMetadataCreator);
        }

        /// <summary>
        /// Returns true if SolanaNftMetadataCreator instances are equal
        /// </summary>
        /// <param name="input">Instance of SolanaNftMetadataCreator to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SolanaNftMetadataCreator input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.Verified == input.Verified ||
                    this.Verified.Equals(input.Verified)
                ) && 
                (
                    this.Share == input.Share ||
                    this.Share.Equals(input.Share)
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
                if (this.Address != null)
                {
                    hashCode = (hashCode * 59) + this.Address.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Verified.GetHashCode();
                hashCode = (hashCode * 59) + this.Share.GetHashCode();
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
            // Address (string) maxLength
            if (this.Address != null && this.Address.Length > 44)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Address, length must be less than 44.", new [] { "Address" });
            }

            // Address (string) minLength
            if (this.Address != null && this.Address.Length < 43)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Address, length must be greater than 43.", new [] { "Address" });
            }

            yield break;
        }
    }

}
