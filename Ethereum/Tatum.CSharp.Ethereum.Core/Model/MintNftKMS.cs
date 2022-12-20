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
using FileParameter = Tatum.CSharp.Ethereum.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.Ethereum.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.Ethereum.Core.Model
{
    /// <summary>
    /// &lt;p&gt;The &lt;code&gt;MintNftKMS&lt;/code&gt; schema lets you mint NFTs natively on BNB Smart Chain, Ethereum, Harmony, Klaytn, KuCoin Community Chain, and Polygon and sign the transaction with your signature ID.&lt;br/&gt;For more information, see \&quot;Minting NFTs natively on a blockchain\&quot; in &lt;a href&#x3D;\&quot;#operation/NftMintErc721\&quot;&gt;Mint an NFT&lt;/a&gt;.&lt;/p&gt;&lt;br/&gt;
    /// </summary>
    [DataContract(Name = "MintNftKMS")]
    public partial class MintNftKMS : IEquatable<MintNftKMS>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MintNftKMS" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MintNftKMS() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MintNftKMS" /> class.
        /// </summary>
        /// <param name="to">The blockchain address to send the NFT to (required).</param>
        /// <param name="contractAddress">The blockchain address of the smart contract to build the NFT on (required).</param>
        /// <param name="tokenId">The ID of the NFT (required).</param>
        /// <param name="url">The URL pointing to the NFT metadata; for more information, see &lt;a href&#x3D;\&quot;https://eips.ethereum.org/EIPS/eip-721#specification\&quot; target&#x3D;\&quot;_blank\&quot;&gt;EIP-721&lt;/a&gt; (required).</param>
        /// <param name="signatureId">The KMS identifier of the private key of the blockchain address that will pay the fee for the transaction (required).</param>
        /// <param name="index">(Only if the signature ID is mnemonic-based) The index of the address to pay the transaction fee that was generated from the mnemonic.</param>
        /// <param name="erc20">The blockchain address of the custom fungible token.</param>
        /// <param name="provenance">Set to \&quot;true\&quot; if the NFT smart contract is of the &lt;a href&#x3D;\&quot;#operation/NftDeployErc721\&quot;&gt;provenance type&lt;/a&gt;; otherwise, set to \&quot;false\&quot;..</param>
        /// <param name="authorAddresses">The blockchain addresses where the royalties will be sent every time the minted NFT is transferred; the royalties are paid in a native blockchain currency such as ETH on Ethereum, MATIC on Polygon, and so on.</param>
        /// <param name="cashbackValues">The amounts of the royalties that will be paid to the authors of the minted NFT every time the NFT is transferred; the amount is defined as a fixed amount of the native blockchain currency for &lt;a href&#x3D;\&quot;#operation/NftDeployErc721\&quot;&gt;cashback smart contracts&lt;/a&gt; or as a percentage of the NFT price for &lt;a href&#x3D;\&quot;#operation/NftDeployErc721\&quot;&gt;provenance smart contracts&lt;/a&gt;.</param>
        /// <param name="fixedValues">The fixed amounts of the native blockchain currency to which the cashback royalty amounts will be compared to; if the fixed amount specified in this parameter is greater than the amount of the cashback royalties, this fixed amount will be sent to the NFT authors instead of the cashback royalties.</param>
        /// <param name="nonce">The nonce to be set to the transaction; if not present, the last known nonce will be used.</param>
        /// <param name="fee">fee.</param>
        public MintNftKMS(string to = default(string), string contractAddress = default(string), string tokenId = default(string), string url = default(string), Guid signatureId = default(Guid), decimal index = default(decimal), string erc20 = default(string), bool provenance = default(bool), List<string> authorAddresses = default(List<string>), List<string> cashbackValues = default(List<string>), List<string> fixedValues = default(List<string>), decimal nonce = default(decimal), CustomFee fee = default(CustomFee))
        {
            // to ensure "to" is required (not null)
            if (to == null)
            {
                throw new ArgumentNullException("to is a required property for MintNftKMS and cannot be null");
            }
            this.To = to;
            // to ensure "contractAddress" is required (not null)
            if (contractAddress == null)
            {
                throw new ArgumentNullException("contractAddress is a required property for MintNftKMS and cannot be null");
            }
            this.ContractAddress = contractAddress;
            // to ensure "tokenId" is required (not null)
            if (tokenId == null)
            {
                throw new ArgumentNullException("tokenId is a required property for MintNftKMS and cannot be null");
            }
            this.TokenId = tokenId;
            // to ensure "url" is required (not null)
            if (url == null)
            {
                throw new ArgumentNullException("url is a required property for MintNftKMS and cannot be null");
            }
            this.Url = url;
            this.SignatureId = signatureId;
            this.Index = index;
            this.Erc20 = erc20;
            this.Provenance = provenance;
            this.AuthorAddresses = authorAddresses;
            this.CashbackValues = cashbackValues;
            this.FixedValues = fixedValues;
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
        /// The blockchain address to send the NFT to
        /// </summary>
        /// <value>The blockchain address to send the NFT to</value>
        [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = true)]
        public string To { get; set; }

        /// <summary>
        /// The blockchain address of the smart contract to build the NFT on
        /// </summary>
        /// <value>The blockchain address of the smart contract to build the NFT on</value>
        [DataMember(Name = "contractAddress", IsRequired = true, EmitDefaultValue = true)]
        public string ContractAddress { get; set; }

        /// <summary>
        /// The ID of the NFT
        /// </summary>
        /// <value>The ID of the NFT</value>
        [DataMember(Name = "tokenId", IsRequired = true, EmitDefaultValue = true)]
        public string TokenId { get; set; }

        /// <summary>
        /// The URL pointing to the NFT metadata; for more information, see &lt;a href&#x3D;\&quot;https://eips.ethereum.org/EIPS/eip-721#specification\&quot; target&#x3D;\&quot;_blank\&quot;&gt;EIP-721&lt;/a&gt;
        /// </summary>
        /// <value>The URL pointing to the NFT metadata; for more information, see &lt;a href&#x3D;\&quot;https://eips.ethereum.org/EIPS/eip-721#specification\&quot; target&#x3D;\&quot;_blank\&quot;&gt;EIP-721&lt;/a&gt;</value>
        [DataMember(Name = "url", IsRequired = true, EmitDefaultValue = true)]
        public string Url { get; set; }

        /// <summary>
        /// The KMS identifier of the private key of the blockchain address that will pay the fee for the transaction
        /// </summary>
        /// <value>The KMS identifier of the private key of the blockchain address that will pay the fee for the transaction</value>
        [DataMember(Name = "signatureId", IsRequired = true, EmitDefaultValue = true)]
        public Guid SignatureId { get; set; }

        /// <summary>
        /// (Only if the signature ID is mnemonic-based) The index of the address to pay the transaction fee that was generated from the mnemonic
        /// </summary>
        /// <value>(Only if the signature ID is mnemonic-based) The index of the address to pay the transaction fee that was generated from the mnemonic</value>
        [DataMember(Name = "index", EmitDefaultValue = false)]
        public decimal Index { get; set; }

        /// <summary>
        /// The blockchain address of the custom fungible token
        /// </summary>
        /// <value>The blockchain address of the custom fungible token</value>
        [DataMember(Name = "erc20", EmitDefaultValue = false)]
        public string Erc20 { get; set; }

        /// <summary>
        /// Set to \&quot;true\&quot; if the NFT smart contract is of the &lt;a href&#x3D;\&quot;#operation/NftDeployErc721\&quot;&gt;provenance type&lt;/a&gt;; otherwise, set to \&quot;false\&quot;.
        /// </summary>
        /// <value>Set to \&quot;true\&quot; if the NFT smart contract is of the &lt;a href&#x3D;\&quot;#operation/NftDeployErc721\&quot;&gt;provenance type&lt;/a&gt;; otherwise, set to \&quot;false\&quot;.</value>
        [DataMember(Name = "provenance", EmitDefaultValue = true)]
        public bool Provenance { get; set; }

        /// <summary>
        /// The blockchain addresses where the royalties will be sent every time the minted NFT is transferred; the royalties are paid in a native blockchain currency such as ETH on Ethereum, MATIC on Polygon, and so on
        /// </summary>
        /// <value>The blockchain addresses where the royalties will be sent every time the minted NFT is transferred; the royalties are paid in a native blockchain currency such as ETH on Ethereum, MATIC on Polygon, and so on</value>
        [DataMember(Name = "authorAddresses", EmitDefaultValue = false)]
        public List<string> AuthorAddresses { get; set; }

        /// <summary>
        /// The amounts of the royalties that will be paid to the authors of the minted NFT every time the NFT is transferred; the amount is defined as a fixed amount of the native blockchain currency for &lt;a href&#x3D;\&quot;#operation/NftDeployErc721\&quot;&gt;cashback smart contracts&lt;/a&gt; or as a percentage of the NFT price for &lt;a href&#x3D;\&quot;#operation/NftDeployErc721\&quot;&gt;provenance smart contracts&lt;/a&gt;
        /// </summary>
        /// <value>The amounts of the royalties that will be paid to the authors of the minted NFT every time the NFT is transferred; the amount is defined as a fixed amount of the native blockchain currency for &lt;a href&#x3D;\&quot;#operation/NftDeployErc721\&quot;&gt;cashback smart contracts&lt;/a&gt; or as a percentage of the NFT price for &lt;a href&#x3D;\&quot;#operation/NftDeployErc721\&quot;&gt;provenance smart contracts&lt;/a&gt;</value>
        [DataMember(Name = "cashbackValues", EmitDefaultValue = false)]
        public List<string> CashbackValues { get; set; }

        /// <summary>
        /// The fixed amounts of the native blockchain currency to which the cashback royalty amounts will be compared to; if the fixed amount specified in this parameter is greater than the amount of the cashback royalties, this fixed amount will be sent to the NFT authors instead of the cashback royalties
        /// </summary>
        /// <value>The fixed amounts of the native blockchain currency to which the cashback royalty amounts will be compared to; if the fixed amount specified in this parameter is greater than the amount of the cashback royalties, this fixed amount will be sent to the NFT authors instead of the cashback royalties</value>
        [DataMember(Name = "fixedValues", EmitDefaultValue = false)]
        public List<string> FixedValues { get; set; }

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
            sb.Append("class MintNftKMS {\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
            sb.Append("  TokenId: ").Append(TokenId).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  SignatureId: ").Append(SignatureId).Append("\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
            sb.Append("  Erc20: ").Append(Erc20).Append("\n");
            sb.Append("  Provenance: ").Append(Provenance).Append("\n");
            sb.Append("  AuthorAddresses: ").Append(AuthorAddresses).Append("\n");
            sb.Append("  CashbackValues: ").Append(CashbackValues).Append("\n");
            sb.Append("  FixedValues: ").Append(FixedValues).Append("\n");
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
            return this.Equals(input as MintNftKMS);
        }

        /// <summary>
        /// Returns true if MintNftKMS instances are equal
        /// </summary>
        /// <param name="input">Instance of MintNftKMS to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MintNftKMS input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.To == input.To ||
                    (this.To != null &&
                    this.To.Equals(input.To))
                ) && 
                (
                    this.ContractAddress == input.ContractAddress ||
                    (this.ContractAddress != null &&
                    this.ContractAddress.Equals(input.ContractAddress))
                ) && 
                (
                    this.TokenId == input.TokenId ||
                    (this.TokenId != null &&
                    this.TokenId.Equals(input.TokenId))
                ) && 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) && 
                (
                    this.SignatureId == input.SignatureId ||
                    (this.SignatureId != null &&
                    this.SignatureId.Equals(input.SignatureId))
                ) && 
                (
                    this.Index == input.Index ||
                    this.Index.Equals(input.Index)
                ) && 
                (
                    this.Erc20 == input.Erc20 ||
                    (this.Erc20 != null &&
                    this.Erc20.Equals(input.Erc20))
                ) && 
                (
                    this.Provenance == input.Provenance ||
                    this.Provenance.Equals(input.Provenance)
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
                    this.FixedValues == input.FixedValues ||
                    this.FixedValues != null &&
                    input.FixedValues != null &&
                    this.FixedValues.SequenceEqual(input.FixedValues)
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
                if (this.To != null)
                {
                    hashCode = (hashCode * 59) + this.To.GetHashCode();
                }
                if (this.ContractAddress != null)
                {
                    hashCode = (hashCode * 59) + this.ContractAddress.GetHashCode();
                }
                if (this.TokenId != null)
                {
                    hashCode = (hashCode * 59) + this.TokenId.GetHashCode();
                }
                if (this.Url != null)
                {
                    hashCode = (hashCode * 59) + this.Url.GetHashCode();
                }
                if (this.SignatureId != null)
                {
                    hashCode = (hashCode * 59) + this.SignatureId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Index.GetHashCode();
                if (this.Erc20 != null)
                {
                    hashCode = (hashCode * 59) + this.Erc20.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Provenance.GetHashCode();
                if (this.AuthorAddresses != null)
                {
                    hashCode = (hashCode * 59) + this.AuthorAddresses.GetHashCode();
                }
                if (this.CashbackValues != null)
                {
                    hashCode = (hashCode * 59) + this.CashbackValues.GetHashCode();
                }
                if (this.FixedValues != null)
                {
                    hashCode = (hashCode * 59) + this.FixedValues.GetHashCode();
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
            // To (string) maxLength
            if (this.To != null && this.To.Length > 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for To, length must be less than 42.", new [] { "To" });
            }

            // To (string) minLength
            if (this.To != null && this.To.Length < 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for To, length must be greater than 42.", new [] { "To" });
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

            // TokenId (string) maxLength
            if (this.TokenId != null && this.TokenId.Length > 78)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TokenId, length must be less than 78.", new [] { "TokenId" });
            }

            // Url (string) maxLength
            if (this.Url != null && this.Url.Length > 256)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Url, length must be less than 256.", new [] { "Url" });
            }

            // Index (decimal) minimum
            if (this.Index < (decimal)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Index, must be a value greater than or equal to 0.", new [] { "Index" });
            }

            // Erc20 (string) maxLength
            if (this.Erc20 != null && this.Erc20.Length > 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Erc20, length must be less than 42.", new [] { "Erc20" });
            }

            // Erc20 (string) minLength
            if (this.Erc20 != null && this.Erc20.Length < 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Erc20, length must be greater than 42.", new [] { "Erc20" });
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
