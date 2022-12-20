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
using FileParameter = Tatum.CSharp.FungibleTokens.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.FungibleTokens.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.FungibleTokens.Core.Model
{
    /// <summary>
    /// TransactionHash
    /// </summary>
    [DataContract(Name = "TransactionHash")]
    public partial class TransactionHash : IEquatable<TransactionHash>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionHash" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TransactionHash() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionHash" /> class.
        /// </summary>
        /// <param name="txId">The hash (ID) of the transaction (required).</param>
        public TransactionHash(string txId = default(string))
        {
            // to ensure "txId" is required (not null)
            if (txId == null)
            {
                throw new ArgumentNullException("txId is a required property for TransactionHash and cannot be null");
            }
            this.TxId = txId;
        }


        /// <summary>
        /// The hash (ID) of the transaction
        /// </summary>
        /// <value>The hash (ID) of the transaction</value>
        [DataMember(Name = "txId", IsRequired = true, EmitDefaultValue = true)]
        public string TxId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TransactionHash {\n");
            sb.Append("  TxId: ").Append(TxId).Append("\n");
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
            return this.Equals(input as TransactionHash);
        }

        /// <summary>
        /// Returns true if TransactionHash instances are equal
        /// </summary>
        /// <param name="input">Instance of TransactionHash to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransactionHash input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.TxId == input.TxId ||
                    (this.TxId != null &&
                    this.TxId.Equals(input.TxId))
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
                if (this.TxId != null)
                {
                    hashCode = (hashCode * 59) + this.TxId.GetHashCode();
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
