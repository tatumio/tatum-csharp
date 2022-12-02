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
using FileParameter = Tatum.CSharp.Ethereum.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.Ethereum.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.Ethereum.Core.Model
{
    /// <summary>
    /// EthTxInternal
    /// </summary>
    [DataContract(Name = "EthTxInternal")]
    public partial class EthTxInternal : IEquatable<EthTxInternal>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EthTxInternal" /> class.
        /// </summary>
        /// <param name="from">Address of the sender..</param>
        /// <param name="to">Address of the receiver. &#39;null&#39; when its a contract creation transaction..</param>
        /// <param name="value">Value transferred in wei..</param>
        /// <param name="blockNumber">Block number where this transaction was in..</param>
        /// <param name="timeStamp">Time of the transaction in seconds..</param>
        /// <param name="hash">Hash of the transaction..</param>
        /// <param name="input">The data sent along with the transaction..</param>
        /// <param name="traceId">Trace ID..</param>
        /// <param name="type">Type of the transaction..</param>
        /// <param name="errCode">Error code..</param>
        /// <param name="gas">Gas provided by the sender..</param>
        /// <param name="isError">1 if the transaction was not successful, 0 otherwise..</param>
        /// <param name="gasUsed">The amount of gas used by this specific transaction alone..</param>
        /// <param name="contractAddress">The contract address created, if the transaction was a contract creation, otherwise null..</param>
        public EthTxInternal(string from = default(string), string to = default(string), string value = default(string), decimal blockNumber = default(decimal), string timeStamp = default(string), string hash = default(string), string input = default(string), string traceId = default(string), string type = default(string), string errCode = default(string), decimal gas = default(decimal), string isError = default(string), decimal gasUsed = default(decimal), string contractAddress = default(string))
        {
            this.From = from;
            this.To = to;
            this.Value = value;
            this.BlockNumber = blockNumber;
            this.TimeStamp = timeStamp;
            this.Hash = hash;
            this.Input = input;
            this.TraceId = traceId;
            this.Type = type;
            this.ErrCode = errCode;
            this.Gas = gas;
            this.IsError = isError;
            this.GasUsed = gasUsed;
            this.ContractAddress = contractAddress;
        }


        /// <summary>
        /// Address of the sender.
        /// </summary>
        /// <value>Address of the sender.</value>
        [DataMember(Name = "from", EmitDefaultValue = false)]
        public string From { get; set; }

        /// <summary>
        /// Address of the receiver. &#39;null&#39; when its a contract creation transaction.
        /// </summary>
        /// <value>Address of the receiver. &#39;null&#39; when its a contract creation transaction.</value>
        [DataMember(Name = "to", EmitDefaultValue = false)]
        public string To { get; set; }

        /// <summary>
        /// Value transferred in wei.
        /// </summary>
        /// <value>Value transferred in wei.</value>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }

        /// <summary>
        /// Block number where this transaction was in.
        /// </summary>
        /// <value>Block number where this transaction was in.</value>
        [DataMember(Name = "blockNumber", EmitDefaultValue = false)]
        public decimal BlockNumber { get; set; }

        /// <summary>
        /// Time of the transaction in seconds.
        /// </summary>
        /// <value>Time of the transaction in seconds.</value>
        [DataMember(Name = "timeStamp", EmitDefaultValue = false)]
        public string TimeStamp { get; set; }

        /// <summary>
        /// Hash of the transaction.
        /// </summary>
        /// <value>Hash of the transaction.</value>
        [DataMember(Name = "hash", EmitDefaultValue = false)]
        public string Hash { get; set; }

        /// <summary>
        /// The data sent along with the transaction.
        /// </summary>
        /// <value>The data sent along with the transaction.</value>
        [DataMember(Name = "input", EmitDefaultValue = false)]
        public string Input { get; set; }

        /// <summary>
        /// Trace ID.
        /// </summary>
        /// <value>Trace ID.</value>
        [DataMember(Name = "traceId", EmitDefaultValue = false)]
        public string TraceId { get; set; }

        /// <summary>
        /// Type of the transaction.
        /// </summary>
        /// <value>Type of the transaction.</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Error code.
        /// </summary>
        /// <value>Error code.</value>
        [DataMember(Name = "errCode", EmitDefaultValue = false)]
        public string ErrCode { get; set; }

        /// <summary>
        /// Gas provided by the sender.
        /// </summary>
        /// <value>Gas provided by the sender.</value>
        [DataMember(Name = "gas", EmitDefaultValue = false)]
        public decimal Gas { get; set; }

        /// <summary>
        /// 1 if the transaction was not successful, 0 otherwise.
        /// </summary>
        /// <value>1 if the transaction was not successful, 0 otherwise.</value>
        [DataMember(Name = "isError", EmitDefaultValue = false)]
        public string IsError { get; set; }

        /// <summary>
        /// The amount of gas used by this specific transaction alone.
        /// </summary>
        /// <value>The amount of gas used by this specific transaction alone.</value>
        [DataMember(Name = "gasUsed", EmitDefaultValue = false)]
        public decimal GasUsed { get; set; }

        /// <summary>
        /// The contract address created, if the transaction was a contract creation, otherwise null.
        /// </summary>
        /// <value>The contract address created, if the transaction was a contract creation, otherwise null.</value>
        [DataMember(Name = "contractAddress", EmitDefaultValue = false)]
        public string ContractAddress { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EthTxInternal {\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  BlockNumber: ").Append(BlockNumber).Append("\n");
            sb.Append("  TimeStamp: ").Append(TimeStamp).Append("\n");
            sb.Append("  Hash: ").Append(Hash).Append("\n");
            sb.Append("  Input: ").Append(Input).Append("\n");
            sb.Append("  TraceId: ").Append(TraceId).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  ErrCode: ").Append(ErrCode).Append("\n");
            sb.Append("  Gas: ").Append(Gas).Append("\n");
            sb.Append("  IsError: ").Append(IsError).Append("\n");
            sb.Append("  GasUsed: ").Append(GasUsed).Append("\n");
            sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
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
            return this.Equals(input as EthTxInternal);
        }

        /// <summary>
        /// Returns true if EthTxInternal instances are equal
        /// </summary>
        /// <param name="input">Instance of EthTxInternal to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EthTxInternal input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.From == input.From ||
                    (this.From != null &&
                    this.From.Equals(input.From))
                ) && 
                (
                    this.To == input.To ||
                    (this.To != null &&
                    this.To.Equals(input.To))
                ) && 
                (
                    this.Value == input.Value ||
                    (this.Value != null &&
                    this.Value.Equals(input.Value))
                ) && 
                (
                    this.BlockNumber == input.BlockNumber ||
                    this.BlockNumber.Equals(input.BlockNumber)
                ) && 
                (
                    this.TimeStamp == input.TimeStamp ||
                    (this.TimeStamp != null &&
                    this.TimeStamp.Equals(input.TimeStamp))
                ) && 
                (
                    this.Hash == input.Hash ||
                    (this.Hash != null &&
                    this.Hash.Equals(input.Hash))
                ) && 
                (
                    this.Input == input.Input ||
                    (this.Input != null &&
                    this.Input.Equals(input.Input))
                ) && 
                (
                    this.TraceId == input.TraceId ||
                    (this.TraceId != null &&
                    this.TraceId.Equals(input.TraceId))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.ErrCode == input.ErrCode ||
                    (this.ErrCode != null &&
                    this.ErrCode.Equals(input.ErrCode))
                ) && 
                (
                    this.Gas == input.Gas ||
                    this.Gas.Equals(input.Gas)
                ) && 
                (
                    this.IsError == input.IsError ||
                    (this.IsError != null &&
                    this.IsError.Equals(input.IsError))
                ) && 
                (
                    this.GasUsed == input.GasUsed ||
                    this.GasUsed.Equals(input.GasUsed)
                ) && 
                (
                    this.ContractAddress == input.ContractAddress ||
                    (this.ContractAddress != null &&
                    this.ContractAddress.Equals(input.ContractAddress))
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
                if (this.From != null)
                {
                    hashCode = (hashCode * 59) + this.From.GetHashCode();
                }
                if (this.To != null)
                {
                    hashCode = (hashCode * 59) + this.To.GetHashCode();
                }
                if (this.Value != null)
                {
                    hashCode = (hashCode * 59) + this.Value.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.BlockNumber.GetHashCode();
                if (this.TimeStamp != null)
                {
                    hashCode = (hashCode * 59) + this.TimeStamp.GetHashCode();
                }
                if (this.Hash != null)
                {
                    hashCode = (hashCode * 59) + this.Hash.GetHashCode();
                }
                if (this.Input != null)
                {
                    hashCode = (hashCode * 59) + this.Input.GetHashCode();
                }
                if (this.TraceId != null)
                {
                    hashCode = (hashCode * 59) + this.TraceId.GetHashCode();
                }
                if (this.Type != null)
                {
                    hashCode = (hashCode * 59) + this.Type.GetHashCode();
                }
                if (this.ErrCode != null)
                {
                    hashCode = (hashCode * 59) + this.ErrCode.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Gas.GetHashCode();
                if (this.IsError != null)
                {
                    hashCode = (hashCode * 59) + this.IsError.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.GasUsed.GetHashCode();
                if (this.ContractAddress != null)
                {
                    hashCode = (hashCode * 59) + this.ContractAddress.GetHashCode();
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
