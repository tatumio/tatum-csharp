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
using FileParameter = Tatum.CSharp.MultiTokens.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.MultiTokens.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.MultiTokens.Core.Model
{
    /// <summary>
    /// EthTxLog
    /// </summary>
    [DataContract(Name = "EthTxLog")]
    public partial class EthTxLog : IEquatable<EthTxLog>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EthTxLog" /> class.
        /// </summary>
        /// <param name="address">From which this event originated from..</param>
        /// <param name="topics">An array with max 4 32 Byte topics, topic 1-3 contains indexed parameters of the log..</param>
        /// <param name="data">The data containing non-indexed log parameter..</param>
        /// <param name="logIndex">Integer of the event index position in the block..</param>
        /// <param name="transactionIndex">Integer of the transaction’s index position, the event was created in..</param>
        /// <param name="transactionHash">Hash of the transaction this event was created in..</param>
        public EthTxLog(string address = default(string), List<string> topics = default(List<string>), string data = default(string), decimal logIndex = default(decimal), decimal transactionIndex = default(decimal), string transactionHash = default(string))
        {
            this.Address = address;
            this.Topics = topics;
            this.Data = data;
            this.LogIndex = logIndex;
            this.TransactionIndex = transactionIndex;
            this.TransactionHash = transactionHash;
        }


        /// <summary>
        /// From which this event originated from.
        /// </summary>
        /// <value>From which this event originated from.</value>
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public string Address { get; set; }

        /// <summary>
        /// An array with max 4 32 Byte topics, topic 1-3 contains indexed parameters of the log.
        /// </summary>
        /// <value>An array with max 4 32 Byte topics, topic 1-3 contains indexed parameters of the log.</value>
        [DataMember(Name = "topics", EmitDefaultValue = false)]
        public List<string> Topics { get; set; }

        /// <summary>
        /// The data containing non-indexed log parameter.
        /// </summary>
        /// <value>The data containing non-indexed log parameter.</value>
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public string Data { get; set; }

        /// <summary>
        /// Integer of the event index position in the block.
        /// </summary>
        /// <value>Integer of the event index position in the block.</value>
        [DataMember(Name = "logIndex", EmitDefaultValue = false)]
        public decimal LogIndex { get; set; }

        /// <summary>
        /// Integer of the transaction’s index position, the event was created in.
        /// </summary>
        /// <value>Integer of the transaction’s index position, the event was created in.</value>
        [DataMember(Name = "transactionIndex", EmitDefaultValue = false)]
        public decimal TransactionIndex { get; set; }

        /// <summary>
        /// Hash of the transaction this event was created in.
        /// </summary>
        /// <value>Hash of the transaction this event was created in.</value>
        [DataMember(Name = "transactionHash", EmitDefaultValue = false)]
        public string TransactionHash { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EthTxLog {\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Topics: ").Append(Topics).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  LogIndex: ").Append(LogIndex).Append("\n");
            sb.Append("  TransactionIndex: ").Append(TransactionIndex).Append("\n");
            sb.Append("  TransactionHash: ").Append(TransactionHash).Append("\n");
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
            return this.Equals(input as EthTxLog);
        }

        /// <summary>
        /// Returns true if EthTxLog instances are equal
        /// </summary>
        /// <param name="input">Instance of EthTxLog to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EthTxLog input)
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
                    this.Topics == input.Topics ||
                    this.Topics != null &&
                    input.Topics != null &&
                    this.Topics.SequenceEqual(input.Topics)
                ) && 
                (
                    this.Data == input.Data ||
                    (this.Data != null &&
                    this.Data.Equals(input.Data))
                ) && 
                (
                    this.LogIndex == input.LogIndex ||
                    this.LogIndex.Equals(input.LogIndex)
                ) && 
                (
                    this.TransactionIndex == input.TransactionIndex ||
                    this.TransactionIndex.Equals(input.TransactionIndex)
                ) && 
                (
                    this.TransactionHash == input.TransactionHash ||
                    (this.TransactionHash != null &&
                    this.TransactionHash.Equals(input.TransactionHash))
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
                if (this.Topics != null)
                {
                    hashCode = (hashCode * 59) + this.Topics.GetHashCode();
                }
                if (this.Data != null)
                {
                    hashCode = (hashCode * 59) + this.Data.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.LogIndex.GetHashCode();
                hashCode = (hashCode * 59) + this.TransactionIndex.GetHashCode();
                if (this.TransactionHash != null)
                {
                    hashCode = (hashCode * 59) + this.TransactionHash.GetHashCode();
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
