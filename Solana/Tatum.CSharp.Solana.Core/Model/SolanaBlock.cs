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
using FileParameter = Tatum.CSharp.Solana.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.Solana.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.Solana.Core.Model
{
    /// <summary>
    /// SolanaBlock
    /// </summary>
    [DataContract(Name = "SolanaBlock")]
    public partial class SolanaBlock : IEquatable<SolanaBlock>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SolanaBlock" /> class.
        /// </summary>
        /// <param name="blockHeight">blockHeight.</param>
        /// <param name="blockTime">blockTime.</param>
        /// <param name="blockhash">blockhash.</param>
        /// <param name="parentSlot">parentSlot.</param>
        /// <param name="previousBlockhash">previousBlockhash.</param>
        /// <param name="rewards">rewards.</param>
        /// <param name="transactions">transactions.</param>
        public SolanaBlock(decimal blockHeight = default(decimal), decimal blockTime = default(decimal), string blockhash = default(string), decimal parentSlot = default(decimal), string previousBlockhash = default(string), List<SolanaBlockReward> rewards = default(List<SolanaBlockReward>), List<SolanaBlockTx> transactions = default(List<SolanaBlockTx>))
        {
            this.BlockHeight = blockHeight;
            this.BlockTime = blockTime;
            this.Blockhash = blockhash;
            this.ParentSlot = parentSlot;
            this.PreviousBlockhash = previousBlockhash;
            this.Rewards = rewards;
            this.Transactions = transactions;
        }


        /// <summary>
        /// Gets or Sets BlockHeight
        /// </summary>
        [DataMember(Name = "blockHeight", EmitDefaultValue = false)]
        public decimal BlockHeight { get; set; }

        /// <summary>
        /// Gets or Sets BlockTime
        /// </summary>
        [DataMember(Name = "blockTime", EmitDefaultValue = false)]
        public decimal BlockTime { get; set; }

        /// <summary>
        /// Gets or Sets Blockhash
        /// </summary>
        [DataMember(Name = "blockhash", EmitDefaultValue = false)]
        public string Blockhash { get; set; }

        /// <summary>
        /// Gets or Sets ParentSlot
        /// </summary>
        [DataMember(Name = "parentSlot", EmitDefaultValue = false)]
        public decimal ParentSlot { get; set; }

        /// <summary>
        /// Gets or Sets PreviousBlockhash
        /// </summary>
        [DataMember(Name = "previousBlockhash", EmitDefaultValue = false)]
        public string PreviousBlockhash { get; set; }

        /// <summary>
        /// Gets or Sets Rewards
        /// </summary>
        [DataMember(Name = "rewards", EmitDefaultValue = false)]
        public List<SolanaBlockReward> Rewards { get; set; }

        /// <summary>
        /// Gets or Sets Transactions
        /// </summary>
        [DataMember(Name = "transactions", EmitDefaultValue = false)]
        public List<SolanaBlockTx> Transactions { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SolanaBlock {\n");
            sb.Append("  BlockHeight: ").Append(BlockHeight).Append("\n");
            sb.Append("  BlockTime: ").Append(BlockTime).Append("\n");
            sb.Append("  Blockhash: ").Append(Blockhash).Append("\n");
            sb.Append("  ParentSlot: ").Append(ParentSlot).Append("\n");
            sb.Append("  PreviousBlockhash: ").Append(PreviousBlockhash).Append("\n");
            sb.Append("  Rewards: ").Append(Rewards).Append("\n");
            sb.Append("  Transactions: ").Append(Transactions).Append("\n");
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
            return this.Equals(input as SolanaBlock);
        }

        /// <summary>
        /// Returns true if SolanaBlock instances are equal
        /// </summary>
        /// <param name="input">Instance of SolanaBlock to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SolanaBlock input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.BlockHeight == input.BlockHeight ||
                    this.BlockHeight.Equals(input.BlockHeight)
                ) && 
                (
                    this.BlockTime == input.BlockTime ||
                    this.BlockTime.Equals(input.BlockTime)
                ) && 
                (
                    this.Blockhash == input.Blockhash ||
                    (this.Blockhash != null &&
                    this.Blockhash.Equals(input.Blockhash))
                ) && 
                (
                    this.ParentSlot == input.ParentSlot ||
                    this.ParentSlot.Equals(input.ParentSlot)
                ) && 
                (
                    this.PreviousBlockhash == input.PreviousBlockhash ||
                    (this.PreviousBlockhash != null &&
                    this.PreviousBlockhash.Equals(input.PreviousBlockhash))
                ) && 
                (
                    this.Rewards == input.Rewards ||
                    this.Rewards != null &&
                    input.Rewards != null &&
                    this.Rewards.SequenceEqual(input.Rewards)
                ) && 
                (
                    this.Transactions == input.Transactions ||
                    this.Transactions != null &&
                    input.Transactions != null &&
                    this.Transactions.SequenceEqual(input.Transactions)
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
                hashCode = (hashCode * 59) + this.BlockHeight.GetHashCode();
                hashCode = (hashCode * 59) + this.BlockTime.GetHashCode();
                if (this.Blockhash != null)
                {
                    hashCode = (hashCode * 59) + this.Blockhash.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ParentSlot.GetHashCode();
                if (this.PreviousBlockhash != null)
                {
                    hashCode = (hashCode * 59) + this.PreviousBlockhash.GetHashCode();
                }
                if (this.Rewards != null)
                {
                    hashCode = (hashCode * 59) + this.Rewards.GetHashCode();
                }
                if (this.Transactions != null)
                {
                    hashCode = (hashCode * 59) + this.Transactions.GetHashCode();
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
