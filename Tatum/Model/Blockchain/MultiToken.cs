using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


public class MultiToken
{

    [JsonProperty("failed")]
    public string failed { get; set; }


    [JsonProperty("txId")]
    public string txId { get; set; }



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


    [JsonProperty("nonce")]
    public int nonce { get; set; }


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


    [JsonProperty("data")]
    public string data { get; set; }

}










