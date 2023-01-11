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
    /// BscGasEstimation
    /// </summary>
    [DataContract(Name = "BscGasEstimation")]
    public partial class BscGasEstimation : IEquatable<BscGasEstimation>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BscGasEstimation" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected BscGasEstimation() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="BscGasEstimation" /> class.
        /// </summary>
        /// <param name="gasLimit">The number of the gas units needed to process the transaction at the estimated gas price (required).</param>
        /// <param name="gasPrice">The estimated price for one gas unit (in wei) (required).</param>
        public BscGasEstimation(string gasLimit = default(string), string gasPrice = default(string))
        {
            // to ensure "gasLimit" is required (not null)
            if (gasLimit == null)
            {
                throw new ArgumentNullException("gasLimit is a required property for BscGasEstimation and cannot be null");
            }
            this.GasLimit = gasLimit;
            // to ensure "gasPrice" is required (not null)
            if (gasPrice == null)
            {
                throw new ArgumentNullException("gasPrice is a required property for BscGasEstimation and cannot be null");
            }
            this.GasPrice = gasPrice;
        }


        /// <summary>
        /// The number of the gas units needed to process the transaction at the estimated gas price
        /// </summary>
        /// <value>The number of the gas units needed to process the transaction at the estimated gas price</value>
        [DataMember(Name = "gasLimit", IsRequired = true, EmitDefaultValue = true)]
        public string GasLimit { get; set; }

        /// <summary>
        /// The estimated price for one gas unit (in wei)
        /// </summary>
        /// <value>The estimated price for one gas unit (in wei)</value>
        [DataMember(Name = "gasPrice", IsRequired = true, EmitDefaultValue = true)]
        public string GasPrice { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BscGasEstimation {\n");
            sb.Append("  GasLimit: ").Append(GasLimit).Append("\n");
            sb.Append("  GasPrice: ").Append(GasPrice).Append("\n");
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
            return this.Equals(input as BscGasEstimation);
        }

        /// <summary>
        /// Returns true if BscGasEstimation instances are equal
        /// </summary>
        /// <param name="input">Instance of BscGasEstimation to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BscGasEstimation input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.GasLimit == input.GasLimit ||
                    (this.GasLimit != null &&
                    this.GasLimit.Equals(input.GasLimit))
                ) && 
                (
                    this.GasPrice == input.GasPrice ||
                    (this.GasPrice != null &&
                    this.GasPrice.Equals(input.GasPrice))
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
                if (this.GasLimit != null)
                {
                    hashCode = (hashCode * 59) + this.GasLimit.GetHashCode();
                }
                if (this.GasPrice != null)
                {
                    hashCode = (hashCode * 59) + this.GasPrice.GetHashCode();
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
