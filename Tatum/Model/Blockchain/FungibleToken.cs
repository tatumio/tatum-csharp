using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// Summary description for FungibleToken
/// </summary>
/// 

public class FungibleToken
{

    [JsonProperty("chain")]
    public string chain { get; set; }


    [JsonProperty("symbol")]
    public string symbol { get; set; }


    [JsonProperty("name")]
    public string name { get; set; }


    [JsonProperty("totalCap")]
    public string totalCap { get; set; }


    [JsonProperty("supply")]
    public string supply { get; set; }


    [JsonProperty("digits")]
    public int digits { get; set; }


    [JsonProperty("address")]
    public string address { get; set; }


    [JsonProperty("fromPrivateKey")]
    public string fromPrivateKey { get; set; }


    [JsonProperty("nonce")]
    public int nonce { get; set; }


    [JsonProperty("fee")]
    public Fee fee { get; set; }


    [JsonProperty("amount")]
    public string amount { get; set; }


    [JsonProperty("to")]
    public string to { get; set; }


    [JsonProperty("contractAddress")]
    public string contractAddress { get; set; }


    [JsonProperty("spender")]
    public string spender { get; set; }


    [JsonProperty("currency")]
    public string currency { get; set; }
}





