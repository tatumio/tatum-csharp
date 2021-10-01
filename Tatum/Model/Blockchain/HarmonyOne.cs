using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


public class HarmonyOne
{

    [JsonProperty("mnemonic")]
    public string mnemonic { get; set; }

    [JsonProperty("xpub")]
    public string xpub { get; set; }

    [JsonProperty("address")]
    public string address { get; set; }


    [JsonProperty("key")]
    public string key { get; set; }



    [JsonProperty("jsonrpc")]
    public string jsonrpc { get; set; }


    [JsonProperty("id")]
    public int id { get; set; }


    [JsonProperty("result")]
    public string result { get; set; }


    [JsonProperty("shardID")]
    public string shardID { get; set; }


    [JsonProperty("blockNumber")]
    public string blockNumber { get; set; }


    [JsonProperty("difficulty")]
    public string difficulty { get; set; }


    [JsonProperty("extraData")]
    public string extraData { get; set; }


    [JsonProperty("gasLimit")]
    public int gasLimit { get; set; }


    [JsonProperty("gasUsed")]
    public int gasUsed { get; set; }


    [JsonProperty("hash")]
    public string hash { get; set; }


    [JsonProperty("logsBloom")]
    public string logsBloom { get; set; }


    [JsonProperty("miner")]
    public string miner { get; set; }


    [JsonProperty("mixHash")]
    public string mixHash { get; set; }


    [JsonProperty("nonce")]
    public string nonce { get; set; }


    [JsonProperty("number")]
    public int number { get; set; }


    [JsonProperty("parentHash")]
    public string parentHash { get; set; }


    [JsonProperty("receiptsRoot")]
    public string receiptsRoot { get; set; }


    [JsonProperty("sha3Uncles")]
    public string sha3Uncles { get; set; }


    [JsonProperty("size")]
    public int size { get; set; }


    [JsonProperty("stateRoot")]
    public string stateRoot { get; set; }


    [JsonProperty("timestamp")]
    public int timestamp { get; set; }


    [JsonProperty("totalDifficulty")]
    public string totalDifficulty { get; set; }


    [JsonProperty("transactions")]
    public Transaction[] transactions { get; set; }


    [JsonProperty("transactionRoot")]
    public string transactionsRoot { get; set; }

    [JsonProperty("balance")]
    public string balance { get; set; }


    [JsonProperty("blockHash")]
    public string blockHash { get; set; }


    [JsonProperty("status")]
    public bool status { get; set; }





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



    [JsonProperty("cumulativeGasUsed")]
    public int cumulativeGasUsed { get; set; }


    [JsonProperty("contractAddress")]
    public string contractAddress { get; set; }


    [JsonProperty("logs")]
    public Log[] logs { get; set; }

    [JsonProperty("data")]
    public string data { get; set; }


    [JsonProperty("fee")]
    public object fee { get; set; }


    [JsonProperty("amount")]
    public string amount { get; set; }


    [JsonProperty("fromPrivateKey")]
    public string fromPrivateKey { get; set; }


    [JsonProperty("txId")]
    public string txId { get; set; }

    [JsonProperty("failed")]
    public bool failed { get; set; }

}