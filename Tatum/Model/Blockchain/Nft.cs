using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


public class Nft
{

    [JsonProperty("data")]
    public string data { get; set; }


    [JsonProperty("txId")]
    public string txId { get; set; }


    [JsonProperty("addresses")]
    public string[] addresses { get; set; }

    [JsonProperty("values")]
    public string[] values { get; set; }


    [JsonProperty("chain")]
    public string chain { get; set; }


    [JsonProperty("name")]
    public string name { get; set; }


    [JsonProperty("symbol")]
    public string symbol { get; set; }


    [JsonProperty("fromPrivateKey")]
    public string fromPrivateKey { get; set; }


    [JsonProperty("nonce")]
    public int nonce { get; set; }


    [JsonProperty("feeCurrency")]
    public string feeCurrency { get; set; }



    [JsonProperty("failed")]
    public bool failed { get; set; }



    [JsonProperty("contractAddress")]
    public string contractAddress { get; set; }


    [JsonProperty("blockHash")]
    public string blockHash { get; set; }


    [JsonProperty("status")]
    public bool status { get; set; }


    [JsonProperty("blockNumber")]
    public int blockNumber { get; set; }


    [JsonProperty("from")]
    public string from { get; set; }


    [JsonProperty("gas")]
    public int gas { get; set; }


    [JsonProperty("gasPrice")]
    public string gasPrice { get; set; }


    [JsonProperty("transactionHash")]
    public string transactionHash { get; set; }


    [JsonProperty("input")]
    public string input { get; set; }


    [JsonProperty("to")]
    public string to { get; set; }


    [JsonProperty("transactionIndex")]
    public int transactionIndex { get; set; }


    [JsonProperty("value")]
    public string value { get; set; }


    [JsonProperty("gasUsed")]
    public int gasUsed { get; set; }


    [JsonProperty("cumulativeGasUsed")]
    public int cumulativeGasUsed { get; set; }


    [JsonProperty("logs")]
    public object[] logs { get; set; }

}



