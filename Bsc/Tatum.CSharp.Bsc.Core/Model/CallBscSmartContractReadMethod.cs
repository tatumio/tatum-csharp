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
    /// CallBscSmartContractReadMethod
    /// </summary>
    [DataContract(Name = "CallBscSmartContractReadMethod")]
    public partial class CallBscSmartContractReadMethod : IEquatable<CallBscSmartContractReadMethod>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallBscSmartContractReadMethod" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CallBscSmartContractReadMethod() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CallBscSmartContractReadMethod" /> class.
        /// </summary>
        /// <param name="contractAddress">The address of the smart contract (required).</param>
        /// <param name="methodName">Name of the method to invoke on smart contract. (required).</param>
        /// <param name="methodABI">ABI of the method to invoke. (required).</param>
        /// <param name="_params">_params (required).</param>
        public CallBscSmartContractReadMethod(string contractAddress = default(string), string methodName = default(string), Object methodABI = default(Object), List<string> _params = default(List<string>))
        {
            // to ensure "contractAddress" is required (not null)
            if (contractAddress == null)
            {
                throw new ArgumentNullException("contractAddress is a required property for CallBscSmartContractReadMethod and cannot be null");
            }
            this.ContractAddress = contractAddress;
            // to ensure "methodName" is required (not null)
            if (methodName == null)
            {
                throw new ArgumentNullException("methodName is a required property for CallBscSmartContractReadMethod and cannot be null");
            }
            this.MethodName = methodName;
            // to ensure "methodABI" is required (not null)
            if (methodABI == null)
            {
                throw new ArgumentNullException("methodABI is a required property for CallBscSmartContractReadMethod and cannot be null");
            }
            this.MethodABI = methodABI;
            // to ensure "_params" is required (not null)
            if (_params == null)
            {
                throw new ArgumentNullException("_params is a required property for CallBscSmartContractReadMethod and cannot be null");
            }
            this.Params = _params;
        }


        /// <summary>
        /// The address of the smart contract
        /// </summary>
        /// <value>The address of the smart contract</value>
        [DataMember(Name = "contractAddress", IsRequired = true, EmitDefaultValue = true)]
        public string ContractAddress { get; set; }

        /// <summary>
        /// Name of the method to invoke on smart contract.
        /// </summary>
        /// <value>Name of the method to invoke on smart contract.</value>
        [DataMember(Name = "methodName", IsRequired = true, EmitDefaultValue = true)]
        public string MethodName { get; set; }

        /// <summary>
        /// ABI of the method to invoke.
        /// </summary>
        /// <value>ABI of the method to invoke.</value>
        [DataMember(Name = "methodABI", IsRequired = true, EmitDefaultValue = true)]
        public Object MethodABI { get; set; }

        /// <summary>
        /// Gets or Sets Params
        /// </summary>
        [DataMember(Name = "params", IsRequired = true, EmitDefaultValue = true)]
        public List<string> Params { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CallBscSmartContractReadMethod {\n");
            sb.Append("  ContractAddress: ").Append(ContractAddress).Append("\n");
            sb.Append("  MethodName: ").Append(MethodName).Append("\n");
            sb.Append("  MethodABI: ").Append(MethodABI).Append("\n");
            sb.Append("  Params: ").Append(Params).Append("\n");
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
            return this.Equals(input as CallBscSmartContractReadMethod);
        }

        /// <summary>
        /// Returns true if CallBscSmartContractReadMethod instances are equal
        /// </summary>
        /// <param name="input">Instance of CallBscSmartContractReadMethod to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallBscSmartContractReadMethod input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.ContractAddress == input.ContractAddress ||
                    (this.ContractAddress != null &&
                    this.ContractAddress.Equals(input.ContractAddress))
                ) && 
                (
                    this.MethodName == input.MethodName ||
                    (this.MethodName != null &&
                    this.MethodName.Equals(input.MethodName))
                ) && 
                (
                    this.MethodABI == input.MethodABI ||
                    (this.MethodABI != null &&
                    this.MethodABI.Equals(input.MethodABI))
                ) && 
                (
                    this.Params == input.Params ||
                    this.Params != null &&
                    input.Params != null &&
                    this.Params.SequenceEqual(input.Params)
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
                if (this.ContractAddress != null)
                {
                    hashCode = (hashCode * 59) + this.ContractAddress.GetHashCode();
                }
                if (this.MethodName != null)
                {
                    hashCode = (hashCode * 59) + this.MethodName.GetHashCode();
                }
                if (this.MethodABI != null)
                {
                    hashCode = (hashCode * 59) + this.MethodABI.GetHashCode();
                }
                if (this.Params != null)
                {
                    hashCode = (hashCode * 59) + this.Params.GetHashCode();
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
            // ContractAddress (string) maxLength
            if (this.ContractAddress != null && this.ContractAddress.Length > 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ContractAddress, length must be less than 42.", new [] { "ContractAddress" });
            }

            // ContractAddress (string) minLength
            if (this.ContractAddress != null && this.ContractAddress.Length < 42)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ContractAddress, length must be greater than 42.", new [] { "ContractAddress" });
            }

            // MethodName (string) maxLength
            if (this.MethodName != null && this.MethodName.Length > 500)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for MethodName, length must be less than 500.", new [] { "MethodName" });
            }

            // MethodName (string) minLength
            if (this.MethodName != null && this.MethodName.Length < 1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for MethodName, length must be greater than 1.", new [] { "MethodName" });
            }

            yield break;
        }
    }

}
