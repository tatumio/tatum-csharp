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
using FileParameter = Tatum.CSharp.BlockchainFees.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.BlockchainFees.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.BlockchainFees.Core.Model
{
    /// <summary>
    /// EstimateFeeTransferFromCustodial
    /// </summary>
    [DataContract(Name = "EstimateFeeTransferFromCustodial")]
    public partial class EstimateFeeTransferFromCustodial : IEquatable<EstimateFeeTransferFromCustodial>, IValidatableObject
    {
        /// <summary>
        /// Blockchain to estimate fee for.
        /// </summary>
        /// <value>Blockchain to estimate fee for.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ChainEnum
        {
            /// <summary>
            /// Enum ETH for value: ETH
            /// </summary>
            [EnumMember(Value = "ETH")]
            ETH = 1,

            /// <summary>
            /// Enum BSC for value: BSC
            /// </summary>
            [EnumMember(Value = "BSC")]
            BSC = 2,

            /// <summary>
            /// Enum ONE for value: ONE
            /// </summary>
            [EnumMember(Value = "ONE")]
            ONE = 3,

            /// <summary>
            /// Enum MATIC for value: MATIC
            /// </summary>
            [EnumMember(Value = "MATIC")]
            MATIC = 4

        }


        /// <summary>
        /// Blockchain to estimate fee for.
        /// </summary>
        /// <value>Blockchain to estimate fee for.</value>
        [DataMember(Name = "chain", IsRequired = true, EmitDefaultValue = true)]
        public ChainEnum Chain { get; set; }

        /// <summary>
        /// Type of transaction
        /// </summary>
        /// <value>Type of transaction</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum TRANSFERCUSTODIAL for value: TRANSFER_CUSTODIAL
            /// </summary>
            [EnumMember(Value = "TRANSFER_CUSTODIAL")]
            TRANSFERCUSTODIAL = 1

        }


        /// <summary>
        /// Type of transaction
        /// </summary>
        /// <value>Type of transaction</value>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public TypeEnum Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateFeeTransferFromCustodial" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EstimateFeeTransferFromCustodial() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateFeeTransferFromCustodial" /> class.
        /// </summary>
        /// <param name="chain">Blockchain to estimate fee for. (required).</param>
        /// <param name="type">Type of transaction (required).</param>
        /// <param name="sender">Sender address (required).</param>
        /// <param name="recipient">Blockchain address to send assets (required).</param>
        /// <param name="contractAddress">Contract address of the token (required).</param>
        /// <param name="custodialAddress">Contract address of custodial wallet contract (required).</param>
        /// <param name="amount">Amount to be sent in native asset, ERC20 or ERC1155 (required).</param>
        /// <param name="tokenType">Type of the token to transfer from gas pump wallet. 0 - ERC20, 1 - ERC721, 2 - ERC1155, 3 - native asset (required).</param>
        public EstimateFeeTransferFromCustodial(ChainEnum chain = default(ChainEnum), TypeEnum type = default(TypeEnum), string sender = default(string), string recipient = default(string), string contractAddress = default(string), string custodialAddress = default(string), string amount = default(string), decimal tokenType = default(decimal))
        {
            this.Chain = chain;
            this.Type = type;
            // to ensure "sender" is required (not null)
            if (sender == null)
            {
                throw new ArgumentNullException("sender is a required property for EstimateFeeTransferFromCustodial and cannot be null");
            }
            this.Sender = sender;
            // to ensure "recipient" is required (not null)
            if (recipient == null)
            {
                throw new ArgumentNullException("recipient is a required property for EstimateFeeTransferFromCustodial and cannot be null");
            }
            this.Recipient = recipient;
            // to ensure "contractAddress" is required (not null)
            if (contractAddress == null)
            {
                throw new ArgumentNullException("contractAddress is a required property for EstimateFeeTransferFromCustodial and cannot be null");
            }
            this.ContractAddress = contractAddress;
            // to ensure "custodialAddress" is required (not null)
            if (custodialAddress == null)
            {
                throw new ArgumentNullException("custodialAddress is a required property for EstimateFeeTransferFromCustodial and cannot be null");
            }
            this.CustodialAddress = custodialAddress;
            // to ensure "amount" is required (not null)
            if (amount == null)
            {
                throw new ArgumentNullException("amount is a required property for EstimateFeeTransferFromCustodial and cannot be null");
            }
            this.Amount = amount;
            this.TokenType = tokenType;
        }


        /// <summary>
        /// Sender address
        /// </summary>
        /// <value>Sender address</value>
        [DataMember(Name = "sender", IsRequired = true, EmitDefaultValue = true)]
        public string Sender { get; set; }

        /// <summary>
        /// Blockchain address to send assets
        /// </summary>
        /// <value>Blockchain address to send assets</value>
        [DataMember(Name = "recipient", IsRequired = true, EmitDefaultValue = true)]
        public string Recipient { get; set; }

        /// <summary>
        /// Contract address of the token
        /// </summary>
        /// <value>Contract address of the token</value>
        [DataMember(Name = "contractAddress", IsRequired = true, EmitDefaultValue = true)]
        public string ContractAddress { get; set; }

        /// <summary>
        /// Contract address of custodial wallet contract
        /// </summary>
        /// <value>Contract address of custodial wallet contract</value>
        [DataMember(Name = "custodialAddress", IsRequired = true, EmitDefaultValue = true)]
        public string CustodialAddress { get; set; }

        /// <summary>
        /// Amount to be sent in native asset, ERC20 or ERC1155
        /// </summary>
        /// <value>Amount to be sent in native asset, ERC20 or ERC1155</value>
        [DataMember(Name = "amount", IsRequired = true, EmitDefaultValue = true)]
        public string Amount { get; set; }

        /// <summary>
        /// Type of the token to transfer from gas pump wallet. 0 - ERC20, 1 - ERC721, 2 - ERC1155, 3 - native asset
        /// </summary>
        /// <value>Type of the token to transfer from gas pump wallet. 0 - ERC20, 1 - ERC721, 2 - ERC1155, 3 - native asset</value>
        [DataMember(Name = "tokenType", IsRequired = true, EmitDefaultValue = true)]
        public decimal TokenType { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EstimateFeeTransferFromCustodial {\n");
            sb.Append("  Chain: ").Append(Chain).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Sender: ").Append(Sender).Append("\n");
            sb.Append("  Recipient: ").Append(Recipient).Append("\n");
            sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
            sb.Append("  CustodialAddress: ").Append(CustodialAddress).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  TokenType: ").Append(TokenType).Append("\n");
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
            return this.Equals(input as EstimateFeeTransferFromCustodial);
        }

        /// <summary>
        /// Returns true if EstimateFeeTransferFromCustodial instances are equal
        /// </summary>
        /// <param name="input">Instance of EstimateFeeTransferFromCustodial to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EstimateFeeTransferFromCustodial input)
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
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) && 
                (
                    this.Sender == input.Sender ||
                    (this.Sender != null &&
                    this.Sender.Equals(input.Sender))
                ) && 
                (
                    this.Recipient == input.Recipient ||
                    (this.Recipient != null &&
                    this.Recipient.Equals(input.Recipient))
                ) && 
                (
                    this.ContractAddress == input.ContractAddress ||
                    (this.ContractAddress != null &&
                    this.ContractAddress.Equals(input.ContractAddress))
                ) && 
                (
                    this.CustodialAddress == input.CustodialAddress ||
                    (this.CustodialAddress != null &&
                    this.CustodialAddress.Equals(input.CustodialAddress))
                ) && 
                (
                    this.Amount == input.Amount ||
                    (this.Amount != null &&
                    this.Amount.Equals(input.Amount))
                ) && 
                (
                    this.TokenType == input.TokenType ||
                    this.TokenType.Equals(input.TokenType)
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
                hashCode = (hashCode * 59) + this.Type.GetHashCode();
                if (this.Sender != null)
                {
                    hashCode = (hashCode * 59) + this.Sender.GetHashCode();
                }
                if (this.Recipient != null)
                {
                    hashCode = (hashCode * 59) + this.Recipient.GetHashCode();
                }
                if (this.ContractAddress != null)
                {
                    hashCode = (hashCode * 59) + this.ContractAddress.GetHashCode();
                }
                if (this.CustodialAddress != null)
                {
                    hashCode = (hashCode * 59) + this.CustodialAddress.GetHashCode();
                }
                if (this.Amount != null)
                {
                    hashCode = (hashCode * 59) + this.Amount.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.TokenType.GetHashCode();
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
            // Sender (string) maxLength
            if (this.Sender != null && this.Sender.Length > 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Sender, length must be less than 42.", new [] { "Sender" });
            }

            // Sender (string) minLength
            if (this.Sender != null && this.Sender.Length < 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Sender, length must be greater than 42.", new [] { "Sender" });
            }

            // Recipient (string) maxLength
            if (this.Recipient != null && this.Recipient.Length > 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Recipient, length must be less than 42.", new [] { "Recipient" });
            }

            // Recipient (string) minLength
            if (this.Recipient != null && this.Recipient.Length < 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Recipient, length must be greater than 42.", new [] { "Recipient" });
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

            // CustodialAddress (string) maxLength
            if (this.CustodialAddress != null && this.CustodialAddress.Length > 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for CustodialAddress, length must be less than 42.", new [] { "CustodialAddress" });
            }

            // CustodialAddress (string) minLength
            if (this.CustodialAddress != null && this.CustodialAddress.Length < 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for CustodialAddress, length must be greater than 42.", new [] { "CustodialAddress" });
            }

            // Amount (string) pattern
            Regex regexAmount = new Regex(@"^[+]?((\\d+(\\.\\d*)?)|(\\.\\d+))$", RegexOptions.CultureInvariant);
            if (false == regexAmount.Match(this.Amount).Success)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Amount, must match a pattern of " + regexAmount, new [] { "Amount" });
            }

            // TokenType (decimal) maximum
            if (this.TokenType > (decimal)3)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TokenType, must be a value less than or equal to 3.", new [] { "TokenType" });
            }

            // TokenType (decimal) minimum
            if (this.TokenType < (decimal)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TokenType, must be a value greater than or equal to 0.", new [] { "TokenType" });
            }

            yield break;
        }
    }

}
