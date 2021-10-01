using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// Summary description for VirtualCurrency
/// </summary>
public class VirtualCurrency
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("frozen")]
    public string Frozen { get; set; }

    [JsonProperty("active")]
    public string Active { get; set; }

    [JsonProperty("accountCode")]
    public string AccountCode { get; set; }

    [JsonProperty("xpub")]
    public string xpub { get; set; }

    [JsonProperty("reference")]
    public string reference { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("supply")]
    public string Supply { get; set; }

    [JsonProperty("accountId")]
    public string AccountId { get; set; }

    [JsonProperty("baseRate")]
    public int BaseRate { get; set; }

    [JsonProperty("basePair")]
    public string BasePair { get; set; }

    [JsonProperty("customerId")]
    public string CustomerId { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("erc20Address")]
    public string Erc20Address { get; set; }

    [JsonProperty("issuerAccount")]
    public string IssuerAccount { get; set; }

    [JsonProperty("chain")]
    public string Chain { get; set; }

    [JsonProperty("initialAddress")]
    public string InitialAddress { get; set; }
}