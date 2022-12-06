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
using System.ComponentModel.DataAnnotations;

namespace Tatum.CSharp.Ethereum.Core.Model
{
    /// <summary>
    /// SolanaMintedResult
    /// </summary>
    [DataContract(Name = "SolanaMintedResult")]
    public partial class SolanaMintedResult : IEquatable<SolanaMintedResult>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SolanaMintedResult" /> class.
        /// </summary>
        /// <param name="txId">The ID of the transaction.</param>
        /// <param name="nftAddress">The blockchain address of the minted NFT.</param>
        /// <param name="nftAccountAddress">The blockchain address that received the minted NFT; this address was created under the recipient&#39;s account address (the one in the &lt;code&gt;to&lt;/code&gt; parameter of the request body), is owned by the recipient&#39;s address, and has the same private key.</param>
        public SolanaMintedResult(string txId = default(string), string nftAddress = default(string), string nftAccountAddress = default(string))
        {
            this.TxId = txId;
            this.NftAddress = nftAddress;
            this.NftAccountAddress = nftAccountAddress;
        }


        /// <summary>
        /// The ID of the transaction
        /// </summary>
        /// <value>The ID of the transaction</value>
        [DataMember(Name = "txId", EmitDefaultValue = false)]
        public string TxId { get; set; }

        /// <summary>
        /// The blockchain address of the minted NFT
        /// </summary>
        /// <value>The blockchain address of the minted NFT</value>
        [DataMember(Name = "nftAddress", EmitDefaultValue = false)]
        public string NftAddress { get; set; }

        /// <summary>
        /// The blockchain address that received the minted NFT; this address was created under the recipient&#39;s account address (the one in the &lt;code&gt;to&lt;/code&gt; parameter of the request body), is owned by the recipient&#39;s address, and has the same private key
        /// </summary>
        /// <value>The blockchain address that received the minted NFT; this address was created under the recipient&#39;s account address (the one in the &lt;code&gt;to&lt;/code&gt; parameter of the request body), is owned by the recipient&#39;s address, and has the same private key</value>
        [DataMember(Name = "nftAccountAddress", EmitDefaultValue = false)]
        public string NftAccountAddress { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SolanaMintedResult {\n");
            sb.Append("  TxId: ").Append(TxId).Append("\n");
            sb.Append("  NftAddress: ").Append(NftAddress).Append("\n");
            sb.Append("  NftAccountAddress: ").Append(NftAccountAddress).Append("\n");
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
            return this.Equals(input as SolanaMintedResult);
        }

        /// <summary>
        /// Returns true if SolanaMintedResult instances are equal
        /// </summary>
        /// <param name="input">Instance of SolanaMintedResult to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SolanaMintedResult input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.TxId == input.TxId ||
                    (this.TxId != null &&
                    this.TxId.Equals(input.TxId))
                ) && 
                (
                    this.NftAddress == input.NftAddress ||
                    (this.NftAddress != null &&
                    this.NftAddress.Equals(input.NftAddress))
                ) && 
                (
                    this.NftAccountAddress == input.NftAccountAddress ||
                    (this.NftAccountAddress != null &&
                    this.NftAccountAddress.Equals(input.NftAccountAddress))
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
                if (this.TxId != null)
                {
                    hashCode = (hashCode * 59) + this.TxId.GetHashCode();
                }
                if (this.NftAddress != null)
                {
                    hashCode = (hashCode * 59) + this.NftAddress.GetHashCode();
                }
                if (this.NftAccountAddress != null)
                {
                    hashCode = (hashCode * 59) + this.NftAccountAddress.GetHashCode();
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
            yield break;
        }
    }

}
