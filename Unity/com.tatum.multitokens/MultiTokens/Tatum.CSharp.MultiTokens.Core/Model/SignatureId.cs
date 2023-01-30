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
using FileParameter = Tatum.CSharp.MultiTokens.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.MultiTokens.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.MultiTokens.Core.Model
{
    /// <summary>
    /// SignatureId
    /// </summary>
    [DataContract(Name = "SignatureId")]
    public partial class SignatureId : IEquatable<SignatureId>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureId" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SignatureId() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureId" /> class.
        /// </summary>
        /// <param name="signatureId">The internal Tatum ID of the prepared transaction for Key Management Sysytem (KMS) to sign&lt;br/&gt;This is different from the &lt;code&gt;signatureId&lt;/code&gt; parameter that you provided in the request body. The &lt;code&gt;signatureId&lt;/code&gt; parameter in the request body specifies the signature ID associated with the private key in KMS. (required).</param>
        public SignatureId(Guid signatureId = default(Guid))
        {
            this._SignatureId = signatureId;
        }


        /// <summary>
        /// The internal Tatum ID of the prepared transaction for Key Management Sysytem (KMS) to sign&lt;br/&gt;This is different from the &lt;code&gt;signatureId&lt;/code&gt; parameter that you provided in the request body. The &lt;code&gt;signatureId&lt;/code&gt; parameter in the request body specifies the signature ID associated with the private key in KMS.
        /// </summary>
        /// <value>The internal Tatum ID of the prepared transaction for Key Management Sysytem (KMS) to sign&lt;br/&gt;This is different from the &lt;code&gt;signatureId&lt;/code&gt; parameter that you provided in the request body. The &lt;code&gt;signatureId&lt;/code&gt; parameter in the request body specifies the signature ID associated with the private key in KMS.</value>
        [DataMember(Name = "signatureId", IsRequired = true, EmitDefaultValue = true)]
        public Guid _SignatureId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SignatureId {\n");
            sb.Append("  _SignatureId: ").Append(_SignatureId).Append("\n");
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
            return this.Equals(input as SignatureId);
        }

        /// <summary>
        /// Returns true if SignatureId instances are equal
        /// </summary>
        /// <param name="input">Instance of SignatureId to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SignatureId input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this._SignatureId == input._SignatureId ||
                    (this._SignatureId != null &&
                    this._SignatureId.Equals(input._SignatureId))
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
                if (this._SignatureId != null)
                {
                    hashCode = (hashCode * 59) + this._SignatureId.GetHashCode();
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
