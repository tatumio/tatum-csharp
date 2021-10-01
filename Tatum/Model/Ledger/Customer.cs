using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


public class Customer
{
    [JsonProperty("externalId")]
    public string externalId { get; set; }

    [JsonProperty("id")]
    public string id { get; set; }

    [JsonProperty("enabled")]
    public bool enabled { get; set; }

    [JsonProperty("active")]
    public bool active { get; set; }

    [JsonProperty("accountingCurrency")]
    public string accountingCurrency { get; set; }

    [JsonProperty("customerCountry")]
    public string customerCountry { get; set; }

    [JsonProperty("providerCountry")]
    public string providerCountry { get; set; }
}
