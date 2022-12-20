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
    /// EstimateFeeDeployCustodialWallet
    /// </summary>
    [DataContract(Name = "EstimateFeeDeployCustodialWallet")]
    public partial class EstimateFeeDeployCustodialWallet : IEquatable<EstimateFeeDeployCustodialWallet>, IValidatableObject
    {
        /// <summary>
        /// Type of transaction
        /// </summary>
        /// <value>Type of transaction</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum DEPLOYCUSTODIALWALLETBATCH for value: DEPLOY_CUSTODIAL_WALLET_BATCH
            /// </summary>
            [EnumMember(Value = "DEPLOY_CUSTODIAL_WALLET_BATCH")]
            DEPLOYCUSTODIALWALLETBATCH = 1

        }


        /// <summary>
        /// Type of transaction
        /// </summary>
        /// <value>Type of transaction</value>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public TypeEnum Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateFeeDeployCustodialWallet" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected EstimateFeeDeployCustodialWallet() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateFeeDeployCustodialWallet" /> class.
        /// </summary>
        /// <param name="type">Type of transaction (required).</param>
        /// <param name="batchCount">Number of addresses to create (required).</param>
        public EstimateFeeDeployCustodialWallet(TypeEnum type = default(TypeEnum), decimal batchCount = default(decimal))
        {
            this.Type = type;
            this.BatchCount = batchCount;
        }

        /// <summary>
        /// Blockchain to estimate fee for.
        /// </summary>
        /// <value>Blockchain to estimate fee for.</value>
        [DataMember(Name = "chain", IsRequired = true, EmitDefaultValue = true)]
        public string Chain { get; } = "MATIC";


        /// <summary>
        /// Number of addresses to create
        /// </summary>
        /// <value>Number of addresses to create</value>
        [DataMember(Name = "batchCount", IsRequired = true, EmitDefaultValue = true)]
        public decimal BatchCount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class EstimateFeeDeployCustodialWallet {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  BatchCount: ").Append(BatchCount).Append("\n");
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
            return this.Equals(input as EstimateFeeDeployCustodialWallet);
        }

        /// <summary>
        /// Returns true if EstimateFeeDeployCustodialWallet instances are equal
        /// </summary>
        /// <param name="input">Instance of EstimateFeeDeployCustodialWallet to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EstimateFeeDeployCustodialWallet input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) && 
                (
                    this.BatchCount == input.BatchCount ||
                    this.BatchCount.Equals(input.BatchCount)
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
                hashCode = (hashCode * 59) + this.Type.GetHashCode();
                hashCode = (hashCode * 59) + this.BatchCount.GetHashCode();
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
            // BatchCount (decimal) maximum
            if (this.BatchCount > (decimal)300)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for BatchCount, must be a value less than or equal to 300.", new [] { "BatchCount" });
            }

            // BatchCount (decimal) minimum
            if (this.BatchCount < (decimal)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for BatchCount, must be a value greater than or equal to 1.", new [] { "BatchCount" });
            }

            yield break;
        }
    }

}
