using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// Summary description for Marketplace
/// </summary>

public class Marketplace
{

    [JsonProperty("chain")]
    public string chain { get; set; }


    [JsonProperty("feeRecipient")]
    public string feeRecipient { get; set; }


    [JsonProperty("marketplaceFee")]
    public int marketplaceFee { get; set; }


    [JsonProperty("fromPrivateKey")]
    public string fromPrivateKey { get; set; }


    [JsonProperty("nonce")]
    public int nonce { get; set; }


    [JsonProperty("fee")]
    public Fee fee { get; set; }


    [JsonProperty("contractAddress")]
    public string contractAddress { get; set; }


    [JsonProperty("nftAddress")]
    public string nftAddress { get; set; }


    [JsonProperty("seller")]
    public string seller { get; set; }


    [JsonProperty("erc20Address")]
    public string erc20Address { get; set; }


    [JsonProperty("listingId")]
    public string listingId { get; set; }


    [JsonProperty("amount")]
    public string amount { get; set; }


    [JsonProperty("tokenId")]
    public string tokenId { get; set; }


    [JsonProperty("price")]
    public string price { get; set; }


    [JsonProperty("isErc721")]
    public bool isErc721 { get; set; }


    [JsonProperty("address")]
    public string address { get; set; }


    [JsonProperty("state")]
    public string state { get; set; }
}






