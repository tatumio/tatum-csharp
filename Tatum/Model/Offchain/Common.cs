using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// Summary description for Common
/// </summary>
public class Common
{
    [JsonProperty("address")]
    public string Address { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("derivationKey")]
    public uint DerivationKey { get; set; }

    [JsonProperty("xpub")]
    public string XPub { get; set; }

    [JsonProperty("destinationTag")]
    public uint? DestinationTag { get; set; }

    [JsonProperty("memo")]
    public string Memo { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("accountid")]
    public string AccountId { get; set; }


    [JsonProperty("id")]
    public string id { get; set; }


    [JsonProperty("currency")]
    public string currency { get; set; }


    [JsonProperty("frozen")]
    public bool frozen { get; set; }


    [JsonProperty("active")]
    public bool active { get; set; }


    [JsonProperty("customerid")]
    public string customerId { get; set; }


    [JsonProperty("acccountcode")]
    public string accountCode { get; set; }


    [JsonProperty("xpub")]
    public string xpub { get; set; }


    [JsonProperty("accountbalance")]
    public string accountBalance { get; set; }


    [JsonProperty("availablebalance")]
    public string availableBalance { get; set; }
}







