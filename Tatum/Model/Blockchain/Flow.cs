using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


public class Flow
{
    [JsonProperty("mnemonic")]
    public string mnemonic { get; set; }


    [JsonProperty("xpub")]
    public string xpub { get; set; }

    [JsonProperty("pubkey")]
    public string pubkey { get; set; }

    [JsonProperty("address")]
    public string address { get; set; }


    [JsonProperty("index")]
    public string index { get; set; }


    [JsonProperty("hash")]
    public string hash { get; set; }


    [JsonProperty("size")]
    public string size { get; set; }


    [JsonProperty("id")]
    public string id { get; set; }


    [JsonProperty("parentId")]
    public string parentId { get; set; }


    [JsonProperty("height")]
    public int height { get; set; }


    [JsonProperty("timestamp")]
    public DateTime timestamp { get; set; }


    [JsonProperty("transactions")]
    public string[] transactions { get; set; }


    [JsonProperty("signatures")]
    public string[] signatures { get; set; }



    [JsonProperty("blockSeals")]
    public object[] blockSeals { get; set; }


    [JsonProperty("blockID")]
    public string blockID { get; set; }


    [JsonProperty("blockHeight")]
    public int blockHeight { get; set; }


    [JsonProperty("blockTimestamp")]
    public DateTime blockTimestamp { get; set; }


    [JsonProperty("type")]
    public string type { get; set; }


    [JsonProperty("transactionId")]
    public string transactionId { get; set; }


    [JsonProperty("transactionIndex")]
    public int transactionIndex { get; set; }


    [JsonProperty("eventIndex")]
    public int eventIndex { get; set; }


    [JsonProperty("payload")]
    public string payload { get; set; }


    [JsonProperty("referenceBlockId")]
    public string referenceBlockId { get; set; }


    [JsonProperty("script")]
    public string script { get; set; }


    [JsonProperty("args")]
    public object[] args { get; set; }


    [JsonProperty("gasLimit")]
    public int gasLimit { get; set; }


    [JsonProperty("proposalKey")]
    public Proposalkey proposalKey { get; set; }


    [JsonProperty("payer")]
    public string payer { get; set; }


    [JsonProperty("payloadSignatures")]
    public object[] payloadSignatures { get; set; }


    [JsonProperty("envelopeSignatures")]
    public object[] envelopeSignatures { get; set; }


    [JsonProperty("status")]
    public int status { get; set; }


    [JsonProperty("statusCode")]
    public int statusCode { get; set; }


    [JsonProperty("errorMessage")]
    public string errorMessage { get; set; }


    [JsonProperty("events")]
    public object[] events { get; set; }


    [JsonProperty("balance")]
    public int balance { get; set; }


    [JsonProperty("code")]
    public string code { get; set; }


    [JsonProperty("contracts")]
    public object contracts { get; set; }


    [JsonProperty("keys")]
    public object[] keys { get; set; }



    [JsonProperty("account")]
    public string account { get; set; }


    [JsonProperty("currency")]
    public string currency { get; set; }


    [JsonProperty("to")]
    public string to { get; set; }


    [JsonProperty("amount")]
    public string amount { get; set; }
 

}


public class Proposalkey
{

    [JsonProperty("address")]
    public string address { get; set; }


    [JsonProperty("keyId")]
    public int keyId { get; set; }


    [JsonProperty("sequenceNumber")]
    public int sequenceNumber { get; set; }
}





