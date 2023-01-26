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
using FileParameter = Tatum.CSharp.Bitcoin.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.Bitcoin.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.Bitcoin.Core.Model
{
    /// <summary>
    /// BtcTxInputCoin
    /// </summary>
    [DataContract(Name = "BtcTxInputCoin")]
    public partial class BtcTxInputCoin : IEquatable<BtcTxInputCoin>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BtcTxInputCoin" /> class.
        /// </summary>
        /// <param name="version">version.</param>
        /// <param name="blockNumber">blockNumber.</param>
        /// <param name="value">Amount of the transaction, in Satoshis (1 BTC &#x3D; 100 000 000 Satoshis).</param>
        /// <param name="script">script.</param>
        /// <param name="address">Sender address..</param>
        /// <param name="coinbase">Coinbase transaction - miner fee..</param>
        public BtcTxInputCoin(decimal version = default(decimal), decimal blockNumber = default(decimal), decimal value = default(decimal), string script = default(string), string address = default(string), bool coinbase = default(bool))
        {
            this._Version = version;
            this.BlockNumber = blockNumber;
            this.Value = value;
            this.Script = script;
            this.Address = address;
            this.Coinbase = coinbase;
        }


        /// <summary>
        /// Gets or Sets _Version
        /// </summary>
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public decimal _Version { get; set; }

        /// <summary>
        /// Gets or Sets BlockNumber
        /// </summary>
        [DataMember(Name = "blockNumber", EmitDefaultValue = false)]
        public decimal BlockNumber { get; set; }

        /// <summary>
        /// Amount of the transaction, in Satoshis (1 BTC &#x3D; 100 000 000 Satoshis)
        /// </summary>
        /// <value>Amount of the transaction, in Satoshis (1 BTC &#x3D; 100 000 000 Satoshis)</value>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or Sets Script
        /// </summary>
        [DataMember(Name = "script", EmitDefaultValue = false)]
        public string Script { get; set; }

        /// <summary>
        /// Sender address.
        /// </summary>
        /// <value>Sender address.</value>
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public string Address { get; set; }

        /// <summary>
        /// Coinbase transaction - miner fee.
        /// </summary>
        /// <value>Coinbase transaction - miner fee.</value>
        [DataMember(Name = "coinbase", EmitDefaultValue = true)]
        public bool Coinbase { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BtcTxInputCoin {\n");
            sb.Append("  _Version: ").Append(_Version).Append("\n");
            sb.Append("  BlockNumber: ").Append(BlockNumber).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  Script: ").Append(Script).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Coinbase: ").Append(Coinbase).Append("\n");
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
            return this.Equals(input as BtcTxInputCoin);
        }

        /// <summary>
        /// Returns true if BtcTxInputCoin instances are equal
        /// </summary>
        /// <param name="input">Instance of BtcTxInputCoin to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BtcTxInputCoin input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this._Version == input._Version ||
                    this._Version.Equals(input._Version)
                ) && 
                (
                    this.BlockNumber == input.BlockNumber ||
                    this.BlockNumber.Equals(input.BlockNumber)
                ) && 
                (
                    this.Value == input.Value ||
                    this.Value.Equals(input.Value)
                ) && 
                (
                    this.Script == input.Script ||
                    (this.Script != null &&
                    this.Script.Equals(input.Script))
                ) && 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.Coinbase == input.Coinbase ||
                    this.Coinbase.Equals(input.Coinbase)
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
                hashCode = (hashCode * 59) + this._Version.GetHashCode();
                hashCode = (hashCode * 59) + this.BlockNumber.GetHashCode();
                hashCode = (hashCode * 59) + this.Value.GetHashCode();
                if (this.Script != null)
                {
                    hashCode = (hashCode * 59) + this.Script.GetHashCode();
                }
                if (this.Address != null)
                {
                    hashCode = (hashCode * 59) + this.Address.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Coinbase.GetHashCode();
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
