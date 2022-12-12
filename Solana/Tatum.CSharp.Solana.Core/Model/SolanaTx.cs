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
using FileParameter = Tatum.CSharp.Solana.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.Solana.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.Solana.Core.Model
{
    /// <summary>
    /// SolanaTx
    /// </summary>
    [DataContract(Name = "SolanaTx")]
    public partial class SolanaTx : IEquatable<SolanaTx>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SolanaTx" /> class.
        /// </summary>
        /// <param name="blockTime">blockTime.</param>
        /// <param name="meta">meta.</param>
        /// <param name="transaction">transaction.</param>
        /// <param name="slot">slot.</param>
        public SolanaTx(decimal blockTime = default(decimal), SolanaTxMeta meta = default(SolanaTxMeta), SolanaTxTransaction transaction = default(SolanaTxTransaction), decimal slot = default(decimal))
        {
            this.BlockTime = blockTime;
            this.Meta = meta;
            this.Transaction = transaction;
            this.Slot = slot;
        }


        /// <summary>
        /// Gets or Sets BlockTime
        /// </summary>
        [DataMember(Name = "blockTime", EmitDefaultValue = false)]
        public decimal BlockTime { get; set; }

        /// <summary>
        /// Gets or Sets Meta
        /// </summary>
        [DataMember(Name = "meta", EmitDefaultValue = false)]
        public SolanaTxMeta Meta { get; set; }

        /// <summary>
        /// Gets or Sets Transaction
        /// </summary>
        [DataMember(Name = "transaction", EmitDefaultValue = false)]
        public SolanaTxTransaction Transaction { get; set; }

        /// <summary>
        /// Gets or Sets Slot
        /// </summary>
        [DataMember(Name = "slot", EmitDefaultValue = false)]
        public decimal Slot { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SolanaTx {\n");
            sb.Append("  BlockTime: ").Append(BlockTime).Append("\n");
            sb.Append("  Meta: ").Append(Meta).Append("\n");
            sb.Append("  Transaction: ").Append(Transaction).Append("\n");
            sb.Append("  Slot: ").Append(Slot).Append("\n");
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
            return this.Equals(input as SolanaTx);
        }

        /// <summary>
        /// Returns true if SolanaTx instances are equal
        /// </summary>
        /// <param name="input">Instance of SolanaTx to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SolanaTx input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.BlockTime == input.BlockTime ||
                    this.BlockTime.Equals(input.BlockTime)
                ) && 
                (
                    this.Meta == input.Meta ||
                    (this.Meta != null &&
                    this.Meta.Equals(input.Meta))
                ) && 
                (
                    this.Transaction == input.Transaction ||
                    (this.Transaction != null &&
                    this.Transaction.Equals(input.Transaction))
                ) && 
                (
                    this.Slot == input.Slot ||
                    this.Slot.Equals(input.Slot)
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
                hashCode = (hashCode * 59) + this.BlockTime.GetHashCode();
                if (this.Meta != null)
                {
                    hashCode = (hashCode * 59) + this.Meta.GetHashCode();
                }
                if (this.Transaction != null)
                {
                    hashCode = (hashCode * 59) + this.Transaction.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Slot.GetHashCode();
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
