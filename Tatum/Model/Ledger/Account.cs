using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;



public class Account
{

       [JsonProperty("id")]
     public string id { get; set; }

    [JsonProperty("balance")]
    public AccountBalance Balance { get; set; }

    [JsonProperty("currency")]
    public string currency { get; set; }

    [JsonProperty("frozen")]
    public bool frozen { get; set; }

    [JsonProperty("active")]
    public bool active { get; set; }

    [JsonProperty("customerId")]
    public string customerId { get; set; }

    [JsonProperty("customer")]
    public Customer Customer { get; set; }

    [JsonProperty("accountCode")]
    public string accountCode { get; set; }

    [JsonProperty("accountNumber")]
    public string accountNumber { get; set; }

    [JsonProperty("accountingCurrency")]
    public string accountCurrency { get; set; }

    [JsonProperty("compliant")]
    public string compliant { get; set; }

    [JsonProperty("xpub")]
    public string xpub { get; set; }
}


