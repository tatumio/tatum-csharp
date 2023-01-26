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
using FileParameter = Tatum.CSharp.Ethereum.Core.Client.FileParameter;
using OpenAPIDateConverter = Tatum.CSharp.Ethereum.Core.Client.OpenAPIDateConverter;

namespace Tatum.CSharp.Ethereum.Core.Model
{
    /// <summary>
    /// Defines Erc20Currency
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Erc20Currency
    {
        /// <summary>
        /// Enum BAT for value: BAT
        /// </summary>
        [EnumMember(Value = "BAT")]
        BAT = 1,

        /// <summary>
        /// Enum BUSD for value: BUSD
        /// </summary>
        [EnumMember(Value = "BUSD")]
        BUSD = 2,

        /// <summary>
        /// Enum COIIN for value: COIIN
        /// </summary>
        [EnumMember(Value = "COIIN")]
        COIIN = 3,

        /// <summary>
        /// Enum ETH for value: ETH
        /// </summary>
        [EnumMember(Value = "ETH")]
        ETH = 4,

        /// <summary>
        /// Enum FREE for value: FREE
        /// </summary>
        [EnumMember(Value = "FREE")]
        FREE = 5,

        /// <summary>
        /// Enum GMC for value: GMC
        /// </summary>
        [EnumMember(Value = "GMC")]
        GMC = 6,

        /// <summary>
        /// Enum LATOKEN for value: LATOKEN
        /// </summary>
        [EnumMember(Value = "LATOKEN")]
        LATOKEN = 7,

        /// <summary>
        /// Enum LEO for value: LEO
        /// </summary>
        [EnumMember(Value = "LEO")]
        LEO = 8,

        /// <summary>
        /// Enum LINK for value: LINK
        /// </summary>
        [EnumMember(Value = "LINK")]
        LINK = 9,

        /// <summary>
        /// Enum MATICETH for value: MATIC_ETH
        /// </summary>
        [EnumMember(Value = "MATIC_ETH")]
        MATICETH = 10,

        /// <summary>
        /// Enum MKR for value: MKR
        /// </summary>
        [EnumMember(Value = "MKR")]
        MKR = 11,

        /// <summary>
        /// Enum MMY for value: MMY
        /// </summary>
        [EnumMember(Value = "MMY")]
        MMY = 12,

        /// <summary>
        /// Enum PAX for value: PAX
        /// </summary>
        [EnumMember(Value = "PAX")]
        PAX = 13,

        /// <summary>
        /// Enum PAXG for value: PAXG
        /// </summary>
        [EnumMember(Value = "PAXG")]
        PAXG = 14,

        /// <summary>
        /// Enum PLTC for value: PLTC
        /// </summary>
        [EnumMember(Value = "PLTC")]
        PLTC = 15,

        /// <summary>
        /// Enum REVV for value: REVV
        /// </summary>
        [EnumMember(Value = "REVV")]
        REVV = 16,

        /// <summary>
        /// Enum SAND for value: SAND
        /// </summary>
        [EnumMember(Value = "SAND")]
        SAND = 17,

        /// <summary>
        /// Enum TUSD for value: TUSD
        /// </summary>
        [EnumMember(Value = "TUSD")]
        TUSD = 18,

        /// <summary>
        /// Enum UNI for value: UNI
        /// </summary>
        [EnumMember(Value = "UNI")]
        UNI = 19,

        /// <summary>
        /// Enum USDC for value: USDC
        /// </summary>
        [EnumMember(Value = "USDC")]
        USDC = 20,

        /// <summary>
        /// Enum USDT for value: USDT
        /// </summary>
        [EnumMember(Value = "USDT")]
        USDT = 21,

        /// <summary>
        /// Enum WBTC for value: WBTC
        /// </summary>
        [EnumMember(Value = "WBTC")]
        WBTC = 22,

        /// <summary>
        /// Enum XCON for value: XCON
        /// </summary>
        [EnumMember(Value = "XCON")]
        XCON = 23

    }

}
