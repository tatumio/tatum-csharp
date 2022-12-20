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
using FileParameter = Tatum.CSharp.Polygon.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.Polygon.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.Polygon.Core.Model
{
    /// <summary>
    /// PolygonTx
    /// </summary>
    [DataContract(Name = "PolygonTx")]
    public partial class PolygonTx : IEquatable<PolygonTx>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonTx" /> class.
        /// </summary>
        /// <param name="blockHash">Hash of the block where this transaction was in..</param>
        /// <param name="status">TRUE if the transaction was successful, FALSE, if the EVM reverted the transaction..</param>
        /// <param name="blockNumber">The number of the block that the transaction is included in; if not returned, the transaction has not been included in a block yet..</param>
        /// <param name="from">Address of the sender..</param>
        /// <param name="gas">Gas provided by the sender..</param>
        /// <param name="gasPrice">Gas price provided by the sender in wei..</param>
        /// <param name="transactionHash">Hash of the transaction..</param>
        /// <param name="input">The data sent along with the transaction..</param>
        /// <param name="nonce">The number of transactions made by the sender prior to this one..</param>
        /// <param name="to">Address of the receiver. &#39;null&#39; when its a contract creation transaction..</param>
        /// <param name="transactionIndex">The integer of the transactions index position in the block; if not returned, the transaction has not been included in a block yet..</param>
        /// <param name="value">Value transferred in wei..</param>
        /// <param name="gasUsed">The amount of gas used by this specific transaction alone; if not returned, the transaction has not been included in a block yet..</param>
        /// <param name="cumulativeGasUsed">The total amount of gas used when this transaction was executed in the block; if not returned, the transaction has not been included in a block yet..</param>
        /// <param name="contractAddress">The contract address created, if the transaction was a contract creation, otherwise null..</param>
        /// <param name="logs">Log events, that happened in this transaction..</param>
        public PolygonTx(string blockHash = default(string), bool status = default(bool), decimal? blockNumber = default(decimal?), string from = default(string), decimal gas = default(decimal), string gasPrice = default(string), string transactionHash = default(string), string input = default(string), decimal nonce = default(decimal), string to = default(string), decimal? transactionIndex = default(decimal?), string value = default(string), decimal? gasUsed = default(decimal?), decimal? cumulativeGasUsed = default(decimal?), string contractAddress = default(string), List<PolygonTxLog> logs = default(List<PolygonTxLog>))
        {
            this.BlockHash = blockHash;
            this.Status = status;
            this.BlockNumber = blockNumber;
            this.From = from;
            this.Gas = gas;
            this.GasPrice = gasPrice;
            this.TransactionHash = transactionHash;
            this.Input = input;
            this.Nonce = nonce;
            this.To = to;
            this.TransactionIndex = transactionIndex;
            this.Value = value;
            this.GasUsed = gasUsed;
            this.CumulativeGasUsed = cumulativeGasUsed;
            this.ContractAddress = contractAddress;
            this.Logs = logs;
        }


        /// <summary>
        /// Hash of the block where this transaction was in.
        /// </summary>
        /// <value>Hash of the block where this transaction was in.</value>
        [DataMember(Name = "blockHash", EmitDefaultValue = false)]
        public string BlockHash { get; set; }

        /// <summary>
        /// TRUE if the transaction was successful, FALSE, if the EVM reverted the transaction.
        /// </summary>
        /// <value>TRUE if the transaction was successful, FALSE, if the EVM reverted the transaction.</value>
        [DataMember(Name = "status", EmitDefaultValue = true)]
        public bool Status { get; set; }

        /// <summary>
        /// The number of the block that the transaction is included in; if not returned, the transaction has not been included in a block yet.
        /// </summary>
        /// <value>The number of the block that the transaction is included in; if not returned, the transaction has not been included in a block yet.</value>
        [DataMember(Name = "blockNumber", EmitDefaultValue = true)]
        public decimal? BlockNumber { get; set; }

        /// <summary>
        /// Address of the sender.
        /// </summary>
        /// <value>Address of the sender.</value>
        [DataMember(Name = "from", EmitDefaultValue = false)]
        public string From { get; set; }

        /// <summary>
        /// Gas provided by the sender.
        /// </summary>
        /// <value>Gas provided by the sender.</value>
        [DataMember(Name = "gas", EmitDefaultValue = false)]
        public decimal Gas { get; set; }

        /// <summary>
        /// Gas price provided by the sender in wei.
        /// </summary>
        /// <value>Gas price provided by the sender in wei.</value>
        [DataMember(Name = "gasPrice", EmitDefaultValue = false)]
        public string GasPrice { get; set; }

        /// <summary>
        /// Hash of the transaction.
        /// </summary>
        /// <value>Hash of the transaction.</value>
        [DataMember(Name = "transactionHash", EmitDefaultValue = false)]
        public string TransactionHash { get; set; }

        /// <summary>
        /// The data sent along with the transaction.
        /// </summary>
        /// <value>The data sent along with the transaction.</value>
        [DataMember(Name = "input", EmitDefaultValue = false)]
        public string Input { get; set; }

        /// <summary>
        /// The number of transactions made by the sender prior to this one.
        /// </summary>
        /// <value>The number of transactions made by the sender prior to this one.</value>
        [DataMember(Name = "nonce", EmitDefaultValue = false)]
        public decimal Nonce { get; set; }

        /// <summary>
        /// Address of the receiver. &#39;null&#39; when its a contract creation transaction.
        /// </summary>
        /// <value>Address of the receiver. &#39;null&#39; when its a contract creation transaction.</value>
        [DataMember(Name = "to", EmitDefaultValue = false)]
        public string To { get; set; }

        /// <summary>
        /// The integer of the transactions index position in the block; if not returned, the transaction has not been included in a block yet.
        /// </summary>
        /// <value>The integer of the transactions index position in the block; if not returned, the transaction has not been included in a block yet.</value>
        [DataMember(Name = "transactionIndex", EmitDefaultValue = true)]
        public decimal? TransactionIndex { get; set; }

        /// <summary>
        /// Value transferred in wei.
        /// </summary>
        /// <value>Value transferred in wei.</value>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }

        /// <summary>
        /// The amount of gas used by this specific transaction alone; if not returned, the transaction has not been included in a block yet.
        /// </summary>
        /// <value>The amount of gas used by this specific transaction alone; if not returned, the transaction has not been included in a block yet.</value>
        [DataMember(Name = "gasUsed", EmitDefaultValue = true)]
        public decimal? GasUsed { get; set; }

        /// <summary>
        /// The total amount of gas used when this transaction was executed in the block; if not returned, the transaction has not been included in a block yet.
        /// </summary>
        /// <value>The total amount of gas used when this transaction was executed in the block; if not returned, the transaction has not been included in a block yet.</value>
        [DataMember(Name = "cumulativeGasUsed", EmitDefaultValue = true)]
        public decimal? CumulativeGasUsed { get; set; }

        /// <summary>
        /// The contract address created, if the transaction was a contract creation, otherwise null.
        /// </summary>
        /// <value>The contract address created, if the transaction was a contract creation, otherwise null.</value>
        [DataMember(Name = "contractAddress", EmitDefaultValue = false)]
        public string ContractAddress { get; set; }

        /// <summary>
        /// Log events, that happened in this transaction.
        /// </summary>
        /// <value>Log events, that happened in this transaction.</value>
        [DataMember(Name = "logs", EmitDefaultValue = false)]
        public List<PolygonTxLog> Logs { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PolygonTx {\n");
            sb.Append("  BlockHash: ").Append(BlockHash).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  BlockNumber: ").Append(BlockNumber).Append("\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  Gas: ").Append(Gas).Append("\n");
            sb.Append("  GasPrice: ").Append(GasPrice).Append("\n");
            sb.Append("  TransactionHash: ").Append(TransactionHash).Append("\n");
            sb.Append("  Input: ").Append(Input).Append("\n");
            sb.Append("  Nonce: ").Append(Nonce).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  TransactionIndex: ").Append(TransactionIndex).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  GasUsed: ").Append(GasUsed).Append("\n");
            sb.Append("  CumulativeGasUsed: ").Append(CumulativeGasUsed).Append("\n");
            sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
            sb.Append("  Logs: ").Append(Logs).Append("\n");
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
            return this.Equals(input as PolygonTx);
        }

        /// <summary>
        /// Returns true if PolygonTx instances are equal
        /// </summary>
        /// <param name="input">Instance of PolygonTx to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PolygonTx input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.BlockHash == input.BlockHash ||
                    (this.BlockHash != null &&
                    this.BlockHash.Equals(input.BlockHash))
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.BlockNumber == input.BlockNumber ||
                    (this.BlockNumber != null &&
                    this.BlockNumber.Equals(input.BlockNumber))
                ) && 
                (
                    this.From == input.From ||
                    (this.From != null &&
                    this.From.Equals(input.From))
                ) && 
                (
                    this.Gas == input.Gas ||
                    this.Gas.Equals(input.Gas)
                ) && 
                (
                    this.GasPrice == input.GasPrice ||
                    (this.GasPrice != null &&
                    this.GasPrice.Equals(input.GasPrice))
                ) && 
                (
                    this.TransactionHash == input.TransactionHash ||
                    (this.TransactionHash != null &&
                    this.TransactionHash.Equals(input.TransactionHash))
                ) && 
                (
                    this.Input == input.Input ||
                    (this.Input != null &&
                    this.Input.Equals(input.Input))
                ) && 
                (
                    this.Nonce == input.Nonce ||
                    this.Nonce.Equals(input.Nonce)
                ) && 
                (
                    this.To == input.To ||
                    (this.To != null &&
                    this.To.Equals(input.To))
                ) && 
                (
                    this.TransactionIndex == input.TransactionIndex ||
                    (this.TransactionIndex != null &&
                    this.TransactionIndex.Equals(input.TransactionIndex))
                ) && 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
                ) && 
                (
                    this.GasUsed == input.GasUsed ||
                    (this.GasUsed != null &&
                    this.GasUsed.Equals(input.GasUsed))
                ) && 
                (
                    this.CumulativeGasUsed == input.CumulativeGasUsed ||
                    (this.CumulativeGasUsed != null &&
                    this.CumulativeGasUsed.Equals(input.CumulativeGasUsed))
                ) && 
                (
                    this.ContractAddress == input.ContractAddress ||
                    (this.ContractAddress != null &&
                    this.ContractAddress.Equals(input.ContractAddress))
                ) && 
                (
                    this.Logs == input.Logs ||
                    this.Logs != null &&
                    input.Logs != null &&
                    this.Logs.SequenceEqual(input.Logs)
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
                if (this.BlockHash != null)
                {
                    hashCode = (hashCode * 59) + this.BlockHash.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Status.GetHashCode();
                if (this.BlockNumber != null)
                {
                    hashCode = (hashCode * 59) + this.BlockNumber.GetHashCode();
                }
                if (this.From != null)
                {
                    hashCode = (hashCode * 59) + this.From.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Gas.GetHashCode();
                if (this.GasPrice != null)
                {
                    hashCode = (hashCode * 59) + this.GasPrice.GetHashCode();
                }
                if (this.TransactionHash != null)
                {
                    hashCode = (hashCode * 59) + this.TransactionHash.GetHashCode();
                }
                if (this.Input != null)
                {
                    hashCode = (hashCode * 59) + this.Input.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Nonce.GetHashCode();
                if (this.To != null)
                {
                    hashCode = (hashCode * 59) + this.To.GetHashCode();
                }
                if (this.TransactionIndex != null)
                {
                    hashCode = (hashCode * 59) + this.TransactionIndex.GetHashCode();
                }
                if (this.Value != null)
                {
                    hashCode = (hashCode * 59) + this.Value.GetHashCode();
                }
                if (this.GasUsed != null)
                {
                    hashCode = (hashCode * 59) + this.GasUsed.GetHashCode();
                }
                if (this.CumulativeGasUsed != null)
                {
                    hashCode = (hashCode * 59) + this.CumulativeGasUsed.GetHashCode();
                }
                if (this.ContractAddress != null)
                {
                    hashCode = (hashCode * 59) + this.ContractAddress.GetHashCode();
                }
                if (this.Logs != null)
                {
                    hashCode = (hashCode * 59) + this.Logs.GetHashCode();
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
