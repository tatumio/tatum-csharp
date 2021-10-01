using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
public class Subscription
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("attr")]
    public Attr Attr { get; set; }

    [JsonProperty("hmacSecret")]
    public string HmacSecret { get; set; }
}

public class Attr
{
}