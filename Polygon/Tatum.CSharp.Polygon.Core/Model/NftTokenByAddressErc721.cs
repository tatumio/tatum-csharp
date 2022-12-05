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
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Tatum.CSharp.Polygon.Core.Model
{
    /// <summary>
    /// NftTokenByAddressErc721
    /// </summary>
    [DataContract(Name = "NftTokenByAddressErc721")]
    public partial class NftTokenByAddressErc721 : IEquatable<NftTokenByAddressErc721>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NftTokenByAddressErc721" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected NftTokenByAddressErc721() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="NftTokenByAddressErc721" /> class.
        /// </summary>
        /// <param name="contractAddress">On Algorand, this is the asset ID (the ID of the NFT); on the other blockchains, this is the address of the NFT smart contract (required).</param>
        /// <param name="balances">On Algorand, this is an array of &lt;code&gt;1&lt;/code&gt; to indicate that the NFTs with the specified IDs exist; on the other blockchains, this is an array of the IDs of the NFTs. (required).</param>
        /// <param name="blockNumber">(EVM-based blockchains only) On EVM-based blockchains like Celo, Polygon or Ethereum, this is an array of block numbers, in which the NFT was received by the address.</param>
        /// <param name="metadata">metadata (required).</param>
        public NftTokenByAddressErc721(string contractAddress = default(string), List<string> balances = default(List<string>), List<decimal> blockNumber = default(List<decimal>), List<NftTokenByAddressErc721TokenMetadata> metadata = default(List<NftTokenByAddressErc721TokenMetadata>))
        {
            // to ensure "contractAddress" is required (not null)
            if (contractAddress == null)
            {
                throw new ArgumentNullException("contractAddress is a required property for NftTokenByAddressErc721 and cannot be null");
            }
            this.ContractAddress = contractAddress;
            // to ensure "balances" is required (not null)
            if (balances == null)
            {
                throw new ArgumentNullException("balances is a required property for NftTokenByAddressErc721 and cannot be null");
            }
            this.Balances = balances;
            // to ensure "metadata" is required (not null)
            if (metadata == null)
            {
                throw new ArgumentNullException("metadata is a required property for NftTokenByAddressErc721 and cannot be null");
            }
            this.Metadata = metadata;
            this.BlockNumber = blockNumber;
        }


        /// <summary>
        /// On Algorand, this is the asset ID (the ID of the NFT); on the other blockchains, this is the address of the NFT smart contract
        /// </summary>
        /// <value>On Algorand, this is the asset ID (the ID of the NFT); on the other blockchains, this is the address of the NFT smart contract</value>
        [DataMember(Name = "contractAddress", IsRequired = true, EmitDefaultValue = true)]
        public string ContractAddress { get; set; }

        /// <summary>
        /// On Algorand, this is an array of &lt;code&gt;1&lt;/code&gt; to indicate that the NFTs with the specified IDs exist; on the other blockchains, this is an array of the IDs of the NFTs.
        /// </summary>
        /// <value>On Algorand, this is an array of &lt;code&gt;1&lt;/code&gt; to indicate that the NFTs with the specified IDs exist; on the other blockchains, this is an array of the IDs of the NFTs.</value>
        [DataMember(Name = "balances", IsRequired = true, EmitDefaultValue = true)]
        public List<string> Balances { get; set; }

        /// <summary>
        /// (EVM-based blockchains only) On EVM-based blockchains like Celo, Polygon or Ethereum, this is an array of block numbers, in which the NFT was received by the address
        /// </summary>
        /// <value>(EVM-based blockchains only) On EVM-based blockchains like Celo, Polygon or Ethereum, this is an array of block numbers, in which the NFT was received by the address</value>
        [DataMember(Name = "blockNumber", EmitDefaultValue = false)]
        public List<decimal> BlockNumber { get; set; }

        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        [DataMember(Name = "metadata", IsRequired = true, EmitDefaultValue = true)]
        public List<NftTokenByAddressErc721TokenMetadata> Metadata { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class NftTokenByAddressErc721 {\n");
            sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
            sb.Append("  Balances: ").Append(Balances).Append("\n");
            sb.Append("  BlockNumber: ").Append(BlockNumber).Append("\n");
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
            return this.Equals(input as NftTokenByAddressErc721);
        }

        /// <summary>
        /// Returns true if NftTokenByAddressErc721 instances are equal
        /// </summary>
        /// <param name="input">Instance of NftTokenByAddressErc721 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NftTokenByAddressErc721 input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ContractAddress == input.ContractAddress ||
                    (this.ContractAddress != null &&
                    this.ContractAddress.Equals(input.ContractAddress))
                ) && 
                (
                    this.Balances == input.Balances ||
                    this.Balances != null &&
                    input.Balances != null &&
                    this.Balances.SequenceEqual(input.Balances)
                ) && 
                (
                    this.BlockNumber == input.BlockNumber ||
                    this.BlockNumber != null &&
                    input.BlockNumber != null &&
                    this.BlockNumber.SequenceEqual(input.BlockNumber)
                ) && 
                (
                    this.Metadata == input.Metadata ||
                    this.Metadata != null &&
                    input.Metadata != null &&
                    this.Metadata.SequenceEqual(input.Metadata)
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
                if (this.ContractAddress != null)
                {
                    hashCode = (hashCode * 59) + this.ContractAddress.GetHashCode();
                }
                if (this.Balances != null)
                {
                    hashCode = (hashCode * 59) + this.Balances.GetHashCode();
                }
                if (this.BlockNumber != null)
                {
                    hashCode = (hashCode * 59) + this.BlockNumber.GetHashCode();
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
            yield break;
        }
    }

}