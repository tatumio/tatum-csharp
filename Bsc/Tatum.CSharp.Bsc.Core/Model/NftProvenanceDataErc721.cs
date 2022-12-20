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
using FileParameter = Tatum.CSharp.Bsc.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.Bsc.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.Bsc.Core.Model
{
    /// <summary>
    /// NftProvenanceDataErc721
    /// </summary>
    [DataContract(Name = "NftProvenanceDataErc721")]
    public partial class NftProvenanceDataErc721 : IEquatable<NftProvenanceDataErc721>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NftProvenanceDataErc721" /> class.
        /// </summary>
        /// <param name="provenanceData">provenanceData.</param>
        /// <param name="tokenPrice">tokenPrice.</param>
        public NftProvenanceDataErc721(string provenanceData = default(string), string tokenPrice = default(string))
        {
            this.ProvenanceData = provenanceData;
            this.TokenPrice = tokenPrice;
        }


        /// <summary>
        /// Gets or Sets ProvenanceData
        /// </summary>
        [DataMember(Name = "provenanceData", EmitDefaultValue = false)]
        public string ProvenanceData { get; set; }

        /// <summary>
        /// Gets or Sets TokenPrice
        /// </summary>
        [DataMember(Name = "tokenPrice", EmitDefaultValue = false)]
        public string TokenPrice { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class NftProvenanceDataErc721 {\n");
            sb.Append("  ProvenanceData: ").Append(ProvenanceData).Append("\n");
            sb.Append("  TokenPrice: ").Append(TokenPrice).Append("\n");
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
            return this.Equals(input as NftProvenanceDataErc721);
        }

        /// <summary>
        /// Returns true if NftProvenanceDataErc721 instances are equal
        /// </summary>
        /// <param name="input">Instance of NftProvenanceDataErc721 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NftProvenanceDataErc721 input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ProvenanceData == input.ProvenanceData ||
                    (this.ProvenanceData != null &&
                    this.ProvenanceData.Equals(input.ProvenanceData))
                ) && 
                (
                    this.TokenPrice == input.TokenPrice ||
                    (this.TokenPrice != null &&
                    this.TokenPrice.Equals(input.TokenPrice))
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
                if (this.ProvenanceData != null)
                {
                    hashCode = (hashCode * 59) + this.ProvenanceData.GetHashCode();
                }
                if (this.TokenPrice != null)
                {
                    hashCode = (hashCode * 59) + this.TokenPrice.GetHashCode();
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
