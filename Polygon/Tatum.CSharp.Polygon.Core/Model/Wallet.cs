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
    /// Wallet
    /// </summary>
    [DataContract(Name = "Wallet")]
    public partial class Wallet : IEquatable<Wallet>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Wallet" /> class.
        /// </summary>
        /// <param name="mnemonic">Generated mnemonic for wallet..</param>
        /// <param name="xpub">Generated Extended public key for wallet with derivation path according to BIP44. This key can be used to generate addresses..</param>
        public Wallet(string mnemonic = default(string), string xpub = default(string))
        {
            this.Mnemonic = mnemonic;
            this.Xpub = xpub;
        }


        /// <summary>
        /// Generated mnemonic for wallet.
        /// </summary>
        /// <value>Generated mnemonic for wallet.</value>
        [DataMember(Name = "mnemonic", EmitDefaultValue = false)]
        public string Mnemonic { get; set; }

        /// <summary>
        /// Generated Extended public key for wallet with derivation path according to BIP44. This key can be used to generate addresses.
        /// </summary>
        /// <value>Generated Extended public key for wallet with derivation path according to BIP44. This key can be used to generate addresses.</value>
        [DataMember(Name = "xpub", EmitDefaultValue = false)]
        public string Xpub { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Wallet {\n");
            sb.Append("  Mnemonic: ").Append(Mnemonic).Append("\n");
            sb.Append("  Xpub: ").Append(Xpub).Append("\n");
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
            return this.Equals(input as Wallet);
        }

        /// <summary>
        /// Returns true if Wallet instances are equal
        /// </summary>
        /// <param name="input">Instance of Wallet to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Wallet input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Mnemonic == input.Mnemonic ||
                    (this.Mnemonic != null &&
                    this.Mnemonic.Equals(input.Mnemonic))
                ) && 
                (
                    this.Xpub == input.Xpub ||
                    (this.Xpub != null &&
                    this.Xpub.Equals(input.Xpub))
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
                if (this.Mnemonic != null)
                {
                    hashCode = (hashCode * 59) + this.Mnemonic.GetHashCode();
                }
                if (this.Xpub != null)
                {
                    hashCode = (hashCode * 59) + this.Xpub.GetHashCode();
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
