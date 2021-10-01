using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// Summary description for OrderBook
/// </summary>
public class OrderBook
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("price")]
    public string Price { get; set; }

    [JsonProperty("amount")]
    public string Amount { get; set; }

    [JsonProperty("pair")]
    public string Pair { get; set; }

    [JsonProperty("fill")]
    public string Fill { get; set; }

    [JsonProperty("currency1AccountId")]
    public string Currency1AccountId { get; set; }

    [JsonProperty("currency2AccountId")]
    public string Currency2AccountId { get; set; }

    [JsonProperty("created")]
    public long Created { get; set; }
}