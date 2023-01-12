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
using FileParameter = Tatum.CSharp.Bsc.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.Bsc.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.Bsc.Core.Model
{
    /// <summary>
    /// AddMultiTokenMinterKMS
    /// </summary>
    [DataContract(Name = "AddMultiTokenMinterKMS")]
    public partial class AddMultiTokenMinterKMS : IEquatable<AddMultiTokenMinterKMS>, IValidatableObject
    {
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
        /// Currency to pay for transaction gas, only valid for CELO chain.
        /// </summary>
        /// <value>Currency to pay for transaction gas, only valid for CELO chain.</value>
        [DataMember(Name = "feeCurrency", EmitDefaultValue = false)]
        public FeeCurrencyEnum? FeeCurrency { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddMultiTokenMinterKMS" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AddMultiTokenMinterKMS() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AddMultiTokenMinterKMS" /> class.
        /// </summary>
        /// <param name="contractAddress">Address of MultiToken token (required).</param>
        /// <param name="minter">Address of MultiToken minter (required).</param>
        /// <param name="index">If signatureId is mnemonic-based, this is the index to the specific address from that mnemonic..</param>
        /// <param name="signatureId">Identifier of the private key associated in signing application. Private key, or signature Id must be present. (required).</param>
        /// <param name="nonce">Nonce to be set to Ethereum transaction. If not present, last known nonce will be used..</param>
        /// <param name="fee">fee.</param>
        /// <param name="feeCurrency">Currency to pay for transaction gas, only valid for CELO chain..</param>
        public AddMultiTokenMinterKMS(string contractAddress = default(string), string minter = default(string), decimal index = default(decimal), Guid signatureId = default(Guid), decimal nonce = default(decimal), CustomFee fee = default(CustomFee), FeeCurrencyEnum? feeCurrency = default(FeeCurrencyEnum?))
        {
            // to ensure "contractAddress" is required (not null)
            if (contractAddress == null)
            {
                throw new ArgumentNullException("contractAddress is a required property for AddMultiTokenMinterKMS and cannot be null");
            }
            this.ContractAddress = contractAddress;
            // to ensure "minter" is required (not null)
            if (minter == null)
            {
                throw new ArgumentNullException("minter is a required property for AddMultiTokenMinterKMS and cannot be null");
            }
            this.Minter = minter;
            this.SignatureId = signatureId;
            this.Index = index;
            this.Nonce = nonce;
            this.Fee = fee;
            this.FeeCurrency = feeCurrency;
        }

        /// <summary>
        /// Chain to work with.
        /// </summary>
        /// <value>Chain to work with.</value>
        [DataMember(Name = "chain", IsRequired = true, EmitDefaultValue = true)]
        public string Chain { get; } = "BSC";


        /// <summary>
        /// Address of MultiToken token
        /// </summary>
        /// <value>Address of MultiToken token</value>
        [DataMember(Name = "contractAddress", IsRequired = true, EmitDefaultValue = true)]
        public string ContractAddress { get; set; }

        /// <summary>
        /// Address of MultiToken minter
        /// </summary>
        /// <value>Address of MultiToken minter</value>
        [DataMember(Name = "minter", IsRequired = true, EmitDefaultValue = true)]
        public string Minter { get; set; }

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
        /// Nonce to be set to Ethereum transaction. If not present, last known nonce will be used.
        /// </summary>
        /// <value>Nonce to be set to Ethereum transaction. If not present, last known nonce will be used.</value>
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
            sb.Append("class AddMultiTokenMinterKMS {\n");
            sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
            sb.Append("  Minter: ").Append(Minter).Append("\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
            sb.Append("  SignatureId: ").Append(SignatureId).Append("\n");
            sb.Append("  Nonce: ").Append(Nonce).Append("\n");
            sb.Append("  Fee: ").Append(Fee).Append("\n");
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
            return this.Equals(input as AddMultiTokenMinterKMS);
        }

        /// <summary>
        /// Returns true if AddMultiTokenMinterKMS instances are equal
        /// </summary>
        /// <param name="input">Instance of AddMultiTokenMinterKMS to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AddMultiTokenMinterKMS input)
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
                    this.Minter == input.Minter ||
                    (this.Minter != null &&
                    this.Minter.Equals(input.Minter))
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
                if (this.ContractAddress != null)
                {
                    hashCode = (hashCode * 59) + this.ContractAddress.GetHashCode();
                }
                if (this.Minter != null)
                {
                    hashCode = (hashCode * 59) + this.Minter.GetHashCode();
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
            if (this.ContractAddress != null && this.ContractAddress.Length > 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ContractAddress, length must be less than 42.", new [] { "ContractAddress" });
            }

            // ContractAddress (string) minLength
            if (this.ContractAddress != null && this.ContractAddress.Length < 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ContractAddress, length must be greater than 42.", new [] { "ContractAddress" });
            }

            // Minter (string) maxLength
            if (this.Minter != null && this.Minter.Length > 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Minter, length must be less than 42.", new [] { "Minter" });
            }

            // Minter (string) minLength
            if (this.Minter != null && this.Minter.Length < 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Minter, length must be greater than 42.", new [] { "Minter" });
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
