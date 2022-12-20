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
using FileParameter = Tatum.CSharp.Bitcoin.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.Bitcoin.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.Bitcoin.Core.Model
{
    /// <summary>
    /// BroadcastKMS
    /// </summary>
    [DataContract(Name = "BroadcastKMS")]
    public partial class BroadcastKMS : IEquatable<BroadcastKMS>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BroadcastKMS" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected BroadcastKMS() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="BroadcastKMS" /> class.
        /// </summary>
        /// <param name="txData">Raw signed transaction to be published to network. (required).</param>
        /// <param name="signatureId">ID of prepared payment template to sign. Required only, when broadcasting transaction signed by Tatum KMS..</param>
        public BroadcastKMS(string txData = default(string), Guid signatureId = default(Guid))
        {
            // to ensure "txData" is required (not null)
            if (txData == null)
            {
                throw new ArgumentNullException("txData is a required property for BroadcastKMS and cannot be null");
            }
            this.TxData = txData;
            this.SignatureId = signatureId;
        }


        /// <summary>
        /// Raw signed transaction to be published to network.
        /// </summary>
        /// <value>Raw signed transaction to be published to network.</value>
        [DataMember(Name = "txData", IsRequired = true, EmitDefaultValue = true)]
        public string TxData { get; set; }

        /// <summary>
        /// ID of prepared payment template to sign. Required only, when broadcasting transaction signed by Tatum KMS.
        /// </summary>
        /// <value>ID of prepared payment template to sign. Required only, when broadcasting transaction signed by Tatum KMS.</value>
        [DataMember(Name = "signatureId", EmitDefaultValue = false)]
        public Guid SignatureId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BroadcastKMS {\n");
            sb.Append("  TxData: ").Append(TxData).Append("\n");
            sb.Append("  SignatureId: ").Append(SignatureId).Append("\n");
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
            return this.Equals(input as BroadcastKMS);
        }

        /// <summary>
        /// Returns true if BroadcastKMS instances are equal
        /// </summary>
        /// <param name="input">Instance of BroadcastKMS to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BroadcastKMS input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.TxData == input.TxData ||
                    (this.TxData != null &&
                    this.TxData.Equals(input.TxData))
                ) && 
                (
                    this.SignatureId == input.SignatureId ||
                    (this.SignatureId != null &&
                    this.SignatureId.Equals(input.SignatureId))
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
                if (this.TxData != null)
                {
                    hashCode = (hashCode * 59) + this.TxData.GetHashCode();
                }
                if (this.SignatureId != null)
                {
                    hashCode = (hashCode * 59) + this.SignatureId.GetHashCode();
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
            // TxData (string) maxLength
            if (this.TxData != null && this.TxData.Length > 500000)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TxData, length must be less than 500000.", new [] { "TxData" });
            }

            // TxData (string) minLength
            if (this.TxData != null && this.TxData.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TxData, length must be greater than 1.", new [] { "TxData" });
            }

            yield break;
        }
    }

}
