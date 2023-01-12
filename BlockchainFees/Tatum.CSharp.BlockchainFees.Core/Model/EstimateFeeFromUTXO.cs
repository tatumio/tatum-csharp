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
    /// EstimateFeeFromUTXO
    /// </summary>
    [DataContract(Name = "EstimateFeeFromUTXO")]
    public partial class EstimateFeeFromUTXO : IEquatable<EstimateFeeFromUTXO>, IValidatableObject
    {
        /// <summary>
        /// Blockchain to estimate fee for.
        /// </summary>
        /// <value>Blockchain to estimate fee for.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ChainEnum
        {
            /// <summary>
            /// Enum BTC for value: BTC
            /// </summary>
            [EnumMember(Value = "BTC")]
            BTC = 1

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
            /// Enum TRANSFER for value: TRANSFER
            /// </summary>
            [EnumMember(Value = "TRANSFER")]
            TRANSFER = 1

        }


        /// <summary>
        /// Type of transaction
        /// </summary>
        /// <value>Type of transaction</value>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public TypeEnum Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateFeeFromUTXO" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EstimateFeeFromUTXO() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateFeeFromUTXO" /> class.
        /// </summary>
        /// <param name="chain">Blockchain to estimate fee for. (required).</param>
        /// <param name="type">Type of transaction (required).</param>
        /// <param name="fromUTXO">Array of transaction hashes, index of UTXO in it and corresponding private keys. Use this option if you want to calculate amount to send manually. Either fromUTXO or fromAddress must be present. (required).</param>
        /// <param name="to">Array of addresses and values to send bitcoins to. Values must be set in BTC. Difference between from and to is transaction fee. (required).</param>
        public EstimateFeeFromUTXO(ChainEnum chain = default(ChainEnum), TypeEnum type = default(TypeEnum), List<Object> fromUTXO = default(List<Object>), List<Object> to = default(List<Object>))
        {
            this.Chain = chain;
            this.Type = type;
            // to ensure "fromUTXO" is required (not null)
            if (fromUTXO == null)
            {
                throw new ArgumentNullException("fromUTXO is a required property for EstimateFeeFromUTXO and cannot be null");
            }
            this.FromUTXO = fromUTXO;
            // to ensure "to" is required (not null)
            if (to == null)
            {
                throw new ArgumentNullException("to is a required property for EstimateFeeFromUTXO and cannot be null");
            }
            this.To = to;
        }


        /// <summary>
        /// Array of transaction hashes, index of UTXO in it and corresponding private keys. Use this option if you want to calculate amount to send manually. Either fromUTXO or fromAddress must be present.
        /// </summary>
        /// <value>Array of transaction hashes, index of UTXO in it and corresponding private keys. Use this option if you want to calculate amount to send manually. Either fromUTXO or fromAddress must be present.</value>
        [DataMember(Name = "fromUTXO", IsRequired = true, EmitDefaultValue = true)]
        public List<Object> FromUTXO { get; set; }

        /// <summary>
        /// Array of addresses and values to send bitcoins to. Values must be set in BTC. Difference between from and to is transaction fee.
        /// </summary>
        /// <value>Array of addresses and values to send bitcoins to. Values must be set in BTC. Difference between from and to is transaction fee.</value>
        [DataMember(Name = "to", IsRequired = true, EmitDefaultValue = true)]
        public List<Object> To { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EstimateFeeFromUTXO {\n");
            sb.Append("  Chain: ").Append(Chain).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  FromUTXO: ").Append(FromUTXO).Append("\n");
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
            return this.Equals(input as EstimateFeeFromUTXO);
        }

        /// <summary>
        /// Returns true if EstimateFeeFromUTXO instances are equal
        /// </summary>
        /// <param name="input">Instance of EstimateFeeFromUTXO to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EstimateFeeFromUTXO input)
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
                    this.FromUTXO == input.FromUTXO ||
                    this.FromUTXO != null &&
                    input.FromUTXO != null &&
                    this.FromUTXO.SequenceEqual(input.FromUTXO)
                ) && 
                (
                    this.To == input.To ||
                    this.To != null &&
                    input.To != null &&
                    this.To.SequenceEqual(input.To)
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
                if (this.FromUTXO != null)
                {
                    hashCode = (hashCode * 59) + this.FromUTXO.GetHashCode();
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
