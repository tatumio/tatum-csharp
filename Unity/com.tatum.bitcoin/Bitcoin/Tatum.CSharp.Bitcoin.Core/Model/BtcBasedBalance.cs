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
    /// BtcBasedBalance
    /// </summary>
    [DataContract(Name = "BtcBasedBalance")]
    public partial class BtcBasedBalance : IEquatable<BtcBasedBalance>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BtcBasedBalance" /> class.
        /// </summary>
        /// <param name="incoming">Total sum of the assets that arrives to the address..</param>
        /// <param name="outgoing">Total sum of the assets that leaves from the address..</param>
        public BtcBasedBalance(string incoming = default(string), string outgoing = default(string))
        {
            this.Incoming = incoming;
            this.Outgoing = outgoing;
        }


        /// <summary>
        /// Total sum of the assets that arrives to the address.
        /// </summary>
        /// <value>Total sum of the assets that arrives to the address.</value>
        [DataMember(Name = "incoming", EmitDefaultValue = false)]
        public string Incoming { get; set; }

        /// <summary>
        /// Total sum of the assets that leaves from the address.
        /// </summary>
        /// <value>Total sum of the assets that leaves from the address.</value>
        [DataMember(Name = "outgoing", EmitDefaultValue = false)]
        public string Outgoing { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BtcBasedBalance {\n");
            sb.Append("  Incoming: ").Append(Incoming).Append("\n");
            sb.Append("  Outgoing: ").Append(Outgoing).Append("\n");
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
            return this.Equals(input as BtcBasedBalance);
        }

        /// <summary>
        /// Returns true if BtcBasedBalance instances are equal
        /// </summary>
        /// <param name="input">Instance of BtcBasedBalance to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BtcBasedBalance input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Incoming == input.Incoming ||
                    (this.Incoming != null &&
                    this.Incoming.Equals(input.Incoming))
                ) && 
                (
                    this.Outgoing == input.Outgoing ||
                    (this.Outgoing != null &&
                    this.Outgoing.Equals(input.Outgoing))
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
                if (this.Incoming != null)
                {
                    hashCode = (hashCode * 59) + this.Incoming.GetHashCode();
                }
                if (this.Outgoing != null)
                {
                    hashCode = (hashCode * 59) + this.Outgoing.GetHashCode();
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
