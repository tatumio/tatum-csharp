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
    /// EthGasEstimationBatchResultData
    /// </summary>
    [DataContract(Name = "EthGasEstimationBatchResultData")]
    public partial class EthGasEstimationBatchResultData : IEquatable<EthGasEstimationBatchResultData>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EthGasEstimationBatchResultData" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EthGasEstimationBatchResultData() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EthGasEstimationBatchResultData" /> class.
        /// </summary>
        /// <param name="gasLimit">Gas limit for transaction in gas price. (required).</param>
        /// <param name="gasPrice">Gas price in wei. (required).</param>
        /// <param name="estimations">estimations (required).</param>
        public EthGasEstimationBatchResultData(string gasLimit = default(string), string gasPrice = default(string), EthGasEstimationDetails estimations = default(EthGasEstimationDetails))
        {
            // to ensure "gasLimit" is required (not null)
            if (gasLimit == null)
            {
                throw new ArgumentNullException("gasLimit is a required property for EthGasEstimationBatchResultData and cannot be null");
            }
            this.GasLimit = gasLimit;
            // to ensure "gasPrice" is required (not null)
            if (gasPrice == null)
            {
                throw new ArgumentNullException("gasPrice is a required property for EthGasEstimationBatchResultData and cannot be null");
            }
            this.GasPrice = gasPrice;
            // to ensure "estimations" is required (not null)
            if (estimations == null)
            {
                throw new ArgumentNullException("estimations is a required property for EthGasEstimationBatchResultData and cannot be null");
            }
            this.Estimations = estimations;
        }


        /// <summary>
        /// Gas limit for transaction in gas price.
        /// </summary>
        /// <value>Gas limit for transaction in gas price.</value>
        [DataMember(Name = "gasLimit", IsRequired = true, EmitDefaultValue = true)]
        public string GasLimit { get; set; }

        /// <summary>
        /// Gas price in wei.
        /// </summary>
        /// <value>Gas price in wei.</value>
        [DataMember(Name = "gasPrice", IsRequired = true, EmitDefaultValue = true)]
        public string GasPrice { get; set; }

        /// <summary>
        /// Gets or Sets Estimations
        /// </summary>
        [DataMember(Name = "estimations", IsRequired = true, EmitDefaultValue = true)]
        public EthGasEstimationDetails Estimations { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EthGasEstimationBatchResultData {\n");
            sb.Append("  GasLimit: ").Append(GasLimit).Append("\n");
            sb.Append("  GasPrice: ").Append(GasPrice).Append("\n");
            sb.Append("  Estimations: ").Append(Estimations).Append("\n");
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
            return this.Equals(input as EthGasEstimationBatchResultData);
        }

        /// <summary>
        /// Returns true if EthGasEstimationBatchResultData instances are equal
        /// </summary>
        /// <param name="input">Instance of EthGasEstimationBatchResultData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EthGasEstimationBatchResultData input)
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
                ) && 
                (
                    this.Estimations == input.Estimations ||
                    (this.Estimations != null &&
                    this.Estimations.Equals(input.Estimations))
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
                if (this.Estimations != null)
                {
                    hashCode = (hashCode * 59) + this.Estimations.GetHashCode();
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
