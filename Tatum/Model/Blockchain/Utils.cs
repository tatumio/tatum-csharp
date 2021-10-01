using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// Summary description for Utils
/// </summary>


public class Utils
{

    [JsonProperty("txId")]
    public string txId { get; set; }


    [JsonProperty("failed")]
    public bool failed { get; set; }


    [JsonProperty("signatureId")]
    public string signatureId { get; set; }


    [JsonProperty("contractAddress")]
    public string contractAddress { get; set; }


    [JsonProperty("fast")]
    public string fast { get; set; }


    [JsonProperty("medium")]
    public string medium { get; set; }


    [JsonProperty("slow")]
    public string slow { get; set; }


    [JsonProperty("gasLimit")]
    public int gasLimit { get; set; }


    [JsonProperty("gasPrice")]
    public int gasPrice { get; set; }
}



