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
    /// FungibleTx
    /// </summary>
    [DataContract(Name = "FungibleTx")]
    public partial class FungibleTx : IEquatable<FungibleTx>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FungibleTx" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FungibleTx() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FungibleTx" /> class.
        /// </summary>
        /// <param name="blockNumber">Block number (required).</param>
        /// <param name="txId">Transaction ID (required).</param>
        /// <param name="contractAddress">Contract address (required).</param>
        /// <param name="amount">Amount of tokens transferred, in smallest decimals (required).</param>
        /// <param name="from">Sender (required).</param>
        /// <param name="to">recipient (required).</param>
        public FungibleTx(decimal blockNumber = default(decimal), string txId = default(string), string contractAddress = default(string), string amount = default(string), string from = default(string), string to = default(string))
        {
            this.BlockNumber = blockNumber;
            // to ensure "txId" is required (not null)
            if (txId == null)
            {
                throw new ArgumentNullException("txId is a required property for FungibleTx and cannot be null");
            }
            this.TxId = txId;
            // to ensure "contractAddress" is required (not null)
            if (contractAddress == null)
            {
                throw new ArgumentNullException("contractAddress is a required property for FungibleTx and cannot be null");
            }
            this.ContractAddress = contractAddress;
            // to ensure "amount" is required (not null)
            if (amount == null)
            {
                throw new ArgumentNullException("amount is a required property for FungibleTx and cannot be null");
            }
            this.Amount = amount;
            // to ensure "from" is required (not null)
            if (from == null)
            {
                throw new ArgumentNullException("from is a required property for FungibleTx and cannot be null");
            }
            this.From = from;
            // to ensure "to" is required (not null)
            if (to == null)
            {
                throw new ArgumentNullException("to is a required property for FungibleTx and cannot be null");
            }
            this.To = to;
        }


        /// <summary>
        /// Block number
        /// </summary>
        /// <value>Block number</value>
        [DataMember(Name = "blockNumber", IsRequired = true, EmitDefaultValue = true)]
        public decimal BlockNumber { get; set; }

        /// <summary>
        /// Transaction ID
        /// </summary>
        /// <value>Transaction ID</value>
        [DataMember(Name = "txId", IsRequired = true, EmitDefaultValue = true)]
        public string TxId { get; set; }

        /// <summary>
        /// Contract address
        /// </summary>
        /// <value>Contract address</value>
        [DataMember(Name = "contractAddress", IsRequired = true, EmitDefaultValue = true)]
        public string ContractAddress { get; set; }

        /// <summary>
        /// Amount of tokens transferred, in smallest decimals
        /// </summary>
        /// <value>Amount of tokens transferred, in smallest decimals</value>
        [DataMember(Name = "amount", IsRequired = true, EmitDefaultValue = true)]
        public string Amount { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        /// <value>Sender</value>
        [DataMember(Name = "from", IsRequired = true, EmitDefaultValue = true)]
        public string From { get; set; }

        /// <summary>
        /// recipient
        /// </summary>
        /// <value>recipient</value>
        [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = true)]
        public string To { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FungibleTx {\n");
            sb.Append("  BlockNumber: ").Append(BlockNumber).Append("\n");
            sb.Append("  TxId: ").Append(TxId).Append("\n");
            sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
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
            return this.Equals(input as FungibleTx);
        }

        /// <summary>
        /// Returns true if FungibleTx instances are equal
        /// </summary>
        /// <param name="input">Instance of FungibleTx to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FungibleTx input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.BlockNumber == input.BlockNumber ||
                    this.BlockNumber.Equals(input.BlockNumber)
                ) && 
                (
                    this.TxId == input.TxId ||
                    (this.TxId != null &&
                    this.TxId.Equals(input.TxId))
                ) && 
                (
                    this.ContractAddress == input.ContractAddress ||
                    (this.ContractAddress != null &&
                    this.ContractAddress.Equals(input.ContractAddress))
                ) && 
                (
                    this.Amount == input.Amount ||
                    (this.Amount != null &&
                    this.Amount.Equals(input.Amount))
                ) && 
                (
                    this.From == input.From ||
                    (this.From != null &&
                    this.From.Equals(input.From))
                ) && 
                (
                    this.To == input.To ||
                    (this.To != null &&
                    this.To.Equals(input.To))
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
                hashCode = (hashCode * 59) + this.BlockNumber.GetHashCode();
                if (this.TxId != null)
                {
                    hashCode = (hashCode * 59) + this.TxId.GetHashCode();
                }
                if (this.ContractAddress != null)
                {
                    hashCode = (hashCode * 59) + this.ContractAddress.GetHashCode();
                }
                if (this.Amount != null)
                {
                    hashCode = (hashCode * 59) + this.Amount.GetHashCode();
                }
                if (this.From != null)
                {
                    hashCode = (hashCode * 59) + this.From.GetHashCode();
                }
                if (this.To != null)
                {
                    hashCode = (hashCode * 59) + this.To.GetHashCode();
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
