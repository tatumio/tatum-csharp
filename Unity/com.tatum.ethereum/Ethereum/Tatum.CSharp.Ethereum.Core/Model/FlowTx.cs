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
    /// FlowTx
    /// </summary>
    [DataContract(Name = "FlowTx")]
    public partial class FlowTx : IEquatable<FlowTx>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlowTx" /> class.
        /// </summary>
        /// <param name="referenceBlockId">Id of the block.</param>
        /// <param name="script">Script to execute in the transaction.</param>
        /// <param name="args">Args to the transaction.</param>
        /// <param name="gasLimit">Gas limit for the transaction.</param>
        /// <param name="proposalKey">proposalKey.</param>
        /// <param name="payer">Address from which the assets and fees were debited.</param>
        /// <param name="payloadSignatures">Array of payload signatures..</param>
        /// <param name="envelopeSignatures">Array of envelope signatures..</param>
        /// <param name="status">Status of the transaction.</param>
        /// <param name="statusCode">Status cofe of the transaction.</param>
        /// <param name="errorMessage">errorMessage.</param>
        /// <param name="events">events.</param>
        public FlowTx(string referenceBlockId = default(string), string script = default(string), List<Object> args = default(List<Object>), decimal gasLimit = default(decimal), Object proposalKey = default(Object), string payer = default(string), List<Object> payloadSignatures = default(List<Object>), List<Object> envelopeSignatures = default(List<Object>), decimal status = default(decimal), decimal statusCode = default(decimal), string errorMessage = default(string), List<Object> events = default(List<Object>))
        {
            this.ReferenceBlockId = referenceBlockId;
            this.Script = script;
            this.Args = args;
            this.GasLimit = gasLimit;
            this.ProposalKey = proposalKey;
            this.Payer = payer;
            this.PayloadSignatures = payloadSignatures;
            this.EnvelopeSignatures = envelopeSignatures;
            this.Status = status;
            this.StatusCode = statusCode;
            this.ErrorMessage = errorMessage;
            this.Events = events;
        }


        /// <summary>
        /// Id of the block
        /// </summary>
        /// <value>Id of the block</value>
        [DataMember(Name = "referenceBlockId", EmitDefaultValue = false)]
        public string ReferenceBlockId { get; set; }

        /// <summary>
        /// Script to execute in the transaction
        /// </summary>
        /// <value>Script to execute in the transaction</value>
        [DataMember(Name = "script", EmitDefaultValue = false)]
        public string Script { get; set; }

        /// <summary>
        /// Args to the transaction
        /// </summary>
        /// <value>Args to the transaction</value>
        [DataMember(Name = "args", EmitDefaultValue = false)]
        public List<Object> Args { get; set; }

        /// <summary>
        /// Gas limit for the transaction
        /// </summary>
        /// <value>Gas limit for the transaction</value>
        [DataMember(Name = "gasLimit", EmitDefaultValue = false)]
        public decimal GasLimit { get; set; }

        /// <summary>
        /// Gets or Sets ProposalKey
        /// </summary>
        [DataMember(Name = "proposalKey", EmitDefaultValue = false)]
        public Object ProposalKey { get; set; }

        /// <summary>
        /// Address from which the assets and fees were debited
        /// </summary>
        /// <value>Address from which the assets and fees were debited</value>
        [DataMember(Name = "payer", EmitDefaultValue = false)]
        public string Payer { get; set; }

        /// <summary>
        /// Array of payload signatures.
        /// </summary>
        /// <value>Array of payload signatures.</value>
        [DataMember(Name = "payloadSignatures", EmitDefaultValue = false)]
        public List<Object> PayloadSignatures { get; set; }

        /// <summary>
        /// Array of envelope signatures.
        /// </summary>
        /// <value>Array of envelope signatures.</value>
        [DataMember(Name = "envelopeSignatures", EmitDefaultValue = false)]
        public List<Object> EnvelopeSignatures { get; set; }

        /// <summary>
        /// Status of the transaction
        /// </summary>
        /// <value>Status of the transaction</value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public decimal Status { get; set; }

        /// <summary>
        /// Status cofe of the transaction
        /// </summary>
        /// <value>Status cofe of the transaction</value>
        [DataMember(Name = "statusCode", EmitDefaultValue = false)]
        public decimal StatusCode { get; set; }

        /// <summary>
        /// Gets or Sets ErrorMessage
        /// </summary>
        [DataMember(Name = "errorMessage", EmitDefaultValue = false)]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or Sets Events
        /// </summary>
        [DataMember(Name = "events", EmitDefaultValue = false)]
        public List<Object> Events { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FlowTx {\n");
            sb.Append("  ReferenceBlockId: ").Append(ReferenceBlockId).Append("\n");
            sb.Append("  Script: ").Append(Script).Append("\n");
            sb.Append("  Args: ").Append(Args).Append("\n");
            sb.Append("  GasLimit: ").Append(GasLimit).Append("\n");
            sb.Append("  ProposalKey: ").Append(ProposalKey).Append("\n");
            sb.Append("  Payer: ").Append(Payer).Append("\n");
            sb.Append("  PayloadSignatures: ").Append(PayloadSignatures).Append("\n");
            sb.Append("  EnvelopeSignatures: ").Append(EnvelopeSignatures).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  StatusCode: ").Append(StatusCode).Append("\n");
            sb.Append("  ErrorMessage: ").Append(ErrorMessage).Append("\n");
            sb.Append("  Events: ").Append(Events).Append("\n");
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
            return this.Equals(input as FlowTx);
        }

        /// <summary>
        /// Returns true if FlowTx instances are equal
        /// </summary>
        /// <param name="input">Instance of FlowTx to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FlowTx input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ReferenceBlockId == input.ReferenceBlockId ||
                    (this.ReferenceBlockId != null &&
                    this.ReferenceBlockId.Equals(input.ReferenceBlockId))
                ) && 
                (
                    this.Script == input.Script ||
                    (this.Script != null &&
                    this.Script.Equals(input.Script))
                ) && 
                (
                    this.Args == input.Args ||
                    this.Args != null &&
                    input.Args != null &&
                    this.Args.SequenceEqual(input.Args)
                ) && 
                (
                    this.GasLimit == input.GasLimit ||
                    this.GasLimit.Equals(input.GasLimit)
                ) && 
                (
                    this.ProposalKey == input.ProposalKey ||
                    (this.ProposalKey != null &&
                    this.ProposalKey.Equals(input.ProposalKey))
                ) && 
                (
                    this.Payer == input.Payer ||
                    (this.Payer != null &&
                    this.Payer.Equals(input.Payer))
                ) && 
                (
                    this.PayloadSignatures == input.PayloadSignatures ||
                    this.PayloadSignatures != null &&
                    input.PayloadSignatures != null &&
                    this.PayloadSignatures.SequenceEqual(input.PayloadSignatures)
                ) && 
                (
                    this.EnvelopeSignatures == input.EnvelopeSignatures ||
                    this.EnvelopeSignatures != null &&
                    input.EnvelopeSignatures != null &&
                    this.EnvelopeSignatures.SequenceEqual(input.EnvelopeSignatures)
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.StatusCode == input.StatusCode ||
                    this.StatusCode.Equals(input.StatusCode)
                ) && 
                (
                    this.ErrorMessage == input.ErrorMessage ||
                    (this.ErrorMessage != null &&
                    this.ErrorMessage.Equals(input.ErrorMessage))
                ) && 
                (
                    this.Events == input.Events ||
                    this.Events != null &&
                    input.Events != null &&
                    this.Events.SequenceEqual(input.Events)
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
                if (this.ReferenceBlockId != null)
                {
                    hashCode = (hashCode * 59) + this.ReferenceBlockId.GetHashCode();
                }
                if (this.Script != null)
                {
                    hashCode = (hashCode * 59) + this.Script.GetHashCode();
                }
                if (this.Args != null)
                {
                    hashCode = (hashCode * 59) + this.Args.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.GasLimit.GetHashCode();
                if (this.ProposalKey != null)
                {
                    hashCode = (hashCode * 59) + this.ProposalKey.GetHashCode();
                }
                if (this.Payer != null)
                {
                    hashCode = (hashCode * 59) + this.Payer.GetHashCode();
                }
                if (this.PayloadSignatures != null)
                {
                    hashCode = (hashCode * 59) + this.PayloadSignatures.GetHashCode();
                }
                if (this.EnvelopeSignatures != null)
                {
                    hashCode = (hashCode * 59) + this.EnvelopeSignatures.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Status.GetHashCode();
                hashCode = (hashCode * 59) + this.StatusCode.GetHashCode();
                if (this.ErrorMessage != null)
                {
                    hashCode = (hashCode * 59) + this.ErrorMessage.GetHashCode();
                }
                if (this.Events != null)
                {
                    hashCode = (hashCode * 59) + this.Events.GetHashCode();
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