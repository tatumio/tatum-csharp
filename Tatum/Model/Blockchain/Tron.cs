using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;






public class Tron
{


    [JsonProperty("hash")]
    public string hash { get; set; }


    [JsonProperty("blockNumber")]
    public int blockNumber { get; set; }


    [JsonProperty("timestamp")]
    public long timestamp { get; set; }


    [JsonProperty("parentHash")]
    public string parentHash { get; set; }


    [JsonProperty("witnessAddress")]
    public string witnessAddress { get; set; }


    [JsonProperty("witnessSignature")]
    public string witnessSignature { get; set; }


    [JsonProperty("transactions")]
    public Transaction[] transactions { get; set; }


    [JsonProperty("next")]
    public string next { get; set; }


    [JsonProperty("address")]
    public string address { get; set; }


    [JsonProperty("freeNetUsage")]
    public int freeNetUsage { get; set; }


    [JsonProperty("balance")]
    public int balance { get; set; }


    [JsonProperty("trc10")]
    public object[] trc10 { get; set; }


    [JsonProperty("trc20")]
    public object[] trc20 { get; set; }


    [JsonProperty("createTime")]
    public long createTime { get; set; }


    [JsonProperty("assetIssuedId")]
    public string assetIssuedId { get; set; }


    [JsonProperty("assetIssuedName")]
    public int assetIssuedName { get; set; }



    [JsonProperty("ret")]
    public Ret ret { get; set; }


    [JsonProperty("signature")]
    public string[] signature { get; set; }


    [JsonProperty("txID")]
    public string txID { get; set; }


    [JsonProperty("netFee")]
    public int netFee { get; set; }


    [JsonProperty("netUsage")]
    public int netUsage { get; set; }


    [JsonProperty("energyFee")]
    public int energyFee { get; set; }


    [JsonProperty("energyUsage")]
    public int energyUsage { get; set; }


    [JsonProperty("energyUsageTotal")]
    public int energyUsageTotal { get; set; }


    [JsonProperty("internalTransactions")]
    public object[] internalTransactions { get; set; }


    [JsonProperty("rawData")]
    public Rawdata rawData { get; set; }


    [JsonProperty("fromPrivateKey")]
    public string fromPrivateKey { get; set; }


    [JsonProperty("to")]
    public string to { get; set; }


    [JsonProperty("amount")]
    public string amount { get; set; }



    [JsonProperty("receiver")]
    public string receiver { get; set; }


    [JsonProperty("duration")]
    public int duration { get; set; }


    [JsonProperty("resource")]
    public string resource { get; set; }



    [JsonProperty("recipient")]
    public string recipient { get; set; }


    [JsonProperty("name")]
    public string name { get; set; }


    [JsonProperty("abbreviation")]
    public string abbreviation { get; set; }


    [JsonProperty("description")]
    public string description { get; set; }


    [JsonProperty("url")]
    public string url { get; set; }


    [JsonProperty("totalSupply")]
    public int totalSupply { get; set; }


    [JsonProperty("decimals")]
    public int decimals { get; set; }


    [JsonProperty("ownerAddress")]
    public string ownerAddress { get; set; }


    [JsonProperty("tokenAddress")]
    public string tokenAddress { get; set; }


    [JsonProperty("feeLimit")]
    public float feeLimit { get; set; }
   

    [JsonProperty("data")]
    public string data { get; set; }


    [JsonProperty("txId")]
    public string txId { get; set; }


    [JsonProperty("mnemonic")]
    public string mnemonic { get; set; }

    [JsonProperty("xpub")]
    public string xpub { get; set; }


    [JsonProperty("key")]
    public string key { get; set; }


    [JsonProperty("jsonrpc")]
    public string jsonrpc { get; set; }


    [JsonProperty("id")]
    public int id { get; set; }


    [JsonProperty("result")]
    public string result { get; set; }


    [JsonProperty("testnet")]
    public bool testnet { get; set; }

}



public class Ret
{


    [JsonProperty("contractRet")]
    public string contractRet { get; set; }


    [JsonProperty("fee")]
    public object fee { get; set; }
}

public class Rawdata
{


    [JsonProperty("expiration")]
    public long expiration { get; set; }


    [JsonProperty("timestamp")]
    public long timestamp { get; set; }


    [JsonProperty("fee_limit")]
    public int fee_limit { get; set; }


    [JsonProperty("contract")]
    public object[] contract { get; set; }
}


