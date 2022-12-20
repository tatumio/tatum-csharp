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
    /// BtcBlock
    /// </summary>
    [DataContract(Name = "BtcBlock")]
    public partial class BtcBlock : IEquatable<BtcBlock>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BtcBlock" /> class.
        /// </summary>
        /// <param name="hash">Hash of block..</param>
        /// <param name="height">The number of blocks preceding a particular block on a block chain..</param>
        /// <param name="depth">The number of blocks following a particular block on a block chain, including current one..</param>
        /// <param name="version">Block version..</param>
        /// <param name="prevBlock">Hash of the previous block..</param>
        /// <param name="merkleRoot">The root node of a merkle tree, a descendant of all the hashed pairs in the tree..</param>
        /// <param name="time">Time of the block..</param>
        /// <param name="bits">bits.</param>
        /// <param name="nonce">Arbitrary number that is used in Bitcoin&#39;s proof of work consensus algorithm..</param>
        /// <param name="txs">txs.</param>
        public BtcBlock(string hash = default(string), decimal height = default(decimal), decimal depth = default(decimal), decimal version = default(decimal), string prevBlock = default(string), string merkleRoot = default(string), decimal time = default(decimal), decimal bits = default(decimal), decimal nonce = default(decimal), List<BtcTx> txs = default(List<BtcTx>))
        {
            this.Hash = hash;
            this.Height = height;
            this.Depth = depth;
            this._Version = version;
            this.PrevBlock = prevBlock;
            this.MerkleRoot = merkleRoot;
            this.Time = time;
            this.Bits = bits;
            this.Nonce = nonce;
            this.Txs = txs;
        }


        /// <summary>
        /// Hash of block.
        /// </summary>
        /// <value>Hash of block.</value>
        [DataMember(Name = "hash", EmitDefaultValue = false)]
        public string Hash { get; set; }

        /// <summary>
        /// The number of blocks preceding a particular block on a block chain.
        /// </summary>
        /// <value>The number of blocks preceding a particular block on a block chain.</value>
        [DataMember(Name = "height", EmitDefaultValue = false)]
        public decimal Height { get; set; }

        /// <summary>
        /// The number of blocks following a particular block on a block chain, including current one.
        /// </summary>
        /// <value>The number of blocks following a particular block on a block chain, including current one.</value>
        [DataMember(Name = "depth", EmitDefaultValue = false)]
        public decimal Depth { get; set; }

        /// <summary>
        /// Block version.
        /// </summary>
        /// <value>Block version.</value>
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public decimal _Version { get; set; }

        /// <summary>
        /// Hash of the previous block.
        /// </summary>
        /// <value>Hash of the previous block.</value>
        [DataMember(Name = "prevBlock", EmitDefaultValue = false)]
        public string PrevBlock { get; set; }

        /// <summary>
        /// The root node of a merkle tree, a descendant of all the hashed pairs in the tree.
        /// </summary>
        /// <value>The root node of a merkle tree, a descendant of all the hashed pairs in the tree.</value>
        [DataMember(Name = "merkleRoot", EmitDefaultValue = false)]
        public string MerkleRoot { get; set; }

        /// <summary>
        /// Time of the block.
        /// </summary>
        /// <value>Time of the block.</value>
        [DataMember(Name = "time", EmitDefaultValue = false)]
        public decimal Time { get; set; }

        /// <summary>
        /// Gets or Sets Bits
        /// </summary>
        [DataMember(Name = "bits", EmitDefaultValue = false)]
        public decimal Bits { get; set; }

        /// <summary>
        /// Arbitrary number that is used in Bitcoin&#39;s proof of work consensus algorithm.
        /// </summary>
        /// <value>Arbitrary number that is used in Bitcoin&#39;s proof of work consensus algorithm.</value>
        [DataMember(Name = "nonce", EmitDefaultValue = false)]
        public decimal Nonce { get; set; }

        /// <summary>
        /// Gets or Sets Txs
        /// </summary>
        [DataMember(Name = "txs", EmitDefaultValue = false)]
        public List<BtcTx> Txs { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BtcBlock {\n");
            sb.Append("  Hash: ").Append(Hash).Append("\n");
            sb.Append("  Height: ").Append(Height).Append("\n");
            sb.Append("  Depth: ").Append(Depth).Append("\n");
            sb.Append("  _Version: ").Append(_Version).Append("\n");
            sb.Append("  PrevBlock: ").Append(PrevBlock).Append("\n");
            sb.Append("  MerkleRoot: ").Append(MerkleRoot).Append("\n");
            sb.Append("  Time: ").Append(Time).Append("\n");
            sb.Append("  Bits: ").Append(Bits).Append("\n");
            sb.Append("  Nonce: ").Append(Nonce).Append("\n");
            sb.Append("  Txs: ").Append(Txs).Append("\n");
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
            return this.Equals(input as BtcBlock);
        }

        /// <summary>
        /// Returns true if BtcBlock instances are equal
        /// </summary>
        /// <param name="input">Instance of BtcBlock to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BtcBlock input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Hash == input.Hash ||
                    (this.Hash != null &&
                    this.Hash.Equals(input.Hash))
                ) && 
                (
                    this.Height == input.Height ||
                    this.Height.Equals(input.Height)
                ) && 
                (
                    this.Depth == input.Depth ||
                    this.Depth.Equals(input.Depth)
                ) && 
                (
                    this._Version == input._Version ||
                    this._Version.Equals(input._Version)
                ) && 
                (
                    this.PrevBlock == input.PrevBlock ||
                    (this.PrevBlock != null &&
                    this.PrevBlock.Equals(input.PrevBlock))
                ) && 
                (
                    this.MerkleRoot == input.MerkleRoot ||
                    (this.MerkleRoot != null &&
                    this.MerkleRoot.Equals(input.MerkleRoot))
                ) && 
                (
                    this.Time == input.Time ||
                    this.Time.Equals(input.Time)
                ) && 
                (
                    this.Bits == input.Bits ||
                    this.Bits.Equals(input.Bits)
                ) && 
                (
                    this.Nonce == input.Nonce ||
                    this.Nonce.Equals(input.Nonce)
                ) && 
                (
                    this.Txs == input.Txs ||
                    this.Txs != null &&
                    input.Txs != null &&
                    this.Txs.SequenceEqual(input.Txs)
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
                if (this.Hash != null)
                {
                    hashCode = (hashCode * 59) + this.Hash.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Height.GetHashCode();
                hashCode = (hashCode * 59) + this.Depth.GetHashCode();
                hashCode = (hashCode * 59) + this._Version.GetHashCode();
                if (this.PrevBlock != null)
                {
                    hashCode = (hashCode * 59) + this.PrevBlock.GetHashCode();
                }
                if (this.MerkleRoot != null)
                {
                    hashCode = (hashCode * 59) + this.MerkleRoot.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Time.GetHashCode();
                hashCode = (hashCode * 59) + this.Bits.GetHashCode();
                hashCode = (hashCode * 59) + this.Nonce.GetHashCode();
                if (this.Txs != null)
                {
                    hashCode = (hashCode * 59) + this.Txs.GetHashCode();
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
