using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


public class Vechain
{

    [JsonProperty("address")]
    public string address { get; set; }


    [JsonProperty("key")]
    public string key { get; set; }

    [JsonProperty("balance")]
    public string balance { get; set; }

    [JsonProperty("energy")]
    public string energy { get; set; }

    [JsonProperty("txId")]
    public string txId { get; set; }

    [JsonProperty("failed")]
    public bool failed { get; set; }



    [JsonProperty("mnemonic")]
    public string mnemonic { get; set; }


    [JsonProperty("xpub")]
    public string xpub { get; set; }



    [JsonProperty("number")]
    public int number { get; set; }


    [JsonProperty("id")]
    public string id { get; set; }


    [JsonProperty("size")]
    public int size { get; set; }


    [JsonProperty("parentID")]
    public string parentID { get; set; }


    [JsonProperty("timestamp")]
    public int timestamp { get; set; }


    [JsonProperty("gasLimit")]
    public int gasLimit { get; set; }


    [JsonProperty("beneficiary")]
    public string beneficiary { get; set; }


    [JsonProperty("gasUsed")]
    public int gasUsed { get; set; }


    [JsonProperty("totalScore")]
    public int totalScore { get; set; }


    [JsonProperty("txsRoot")]
    public string txsRoot { get; set; }


    [JsonProperty("txsFeatures")]
    public int txsFeatures { get; set; }


    [JsonProperty("stateRoot")]
    public string stateRoot { get; set; }


    [JsonProperty("receiptsRoot")]
    public string receiptsRoot { get; set; }


    [JsonProperty("signer")]
    public string signer { get; set; }


    [JsonProperty("transactions")]
    public string[] transactions { get; set; }


    [JsonProperty("chainTag")]
    public string chainTag { get; set; }


    [JsonProperty("blockRef")]
    public string blockRef { get; set; }


    [JsonProperty("expiration")]
    public int expiration { get; set; }


    [JsonProperty("clauses")]
    public object[] clauses { get; set; }


    [JsonProperty("gasPriceCoef")]
    public int gasPriceCoef { get; set; }


    [JsonProperty("gas")]
    public int gas { get; set; }


    [JsonProperty("origin")]
    public string origin { get; set; }


    [JsonProperty("nonce")]
    public string nonce { get; set; }


    [JsonProperty(" meta")]
    public VechainMeta meta { get; set; }


    [JsonProperty("blockNumber")]
    public int blockNumber { get; set; }



    [JsonProperty("failed")]
    public string gasPayer { get; set; }


    [JsonProperty("paid")]
    public string paid { get; set; }


    [JsonProperty("reward")]
    public string reward { get; set; }


    [JsonProperty("reverted")]
    public bool reverted { get; set; }



    [JsonProperty("outputs")]
    public Output[] outputs { get; set; }


    [JsonProperty("blockHash")]
    public string blockHash { get; set; }


    [JsonProperty("transactionHash")]
    public string transactionHash { get; set; }


    [JsonProperty("status")]
    public string status { get; set; }

}


public class VechainMeta
{

    [JsonProperty("blockID")]
    public string blockID { get; set; }


    [JsonProperty("blockNumber")]
    public int blockNumber { get; set; }


    [JsonProperty("blockTimestamp")]
    public int blockTimestamp { get; set; }


    [JsonProperty("txID")]
    public string txID { get; set; }


    [JsonProperty("txOrigin")]
    public string txOrigin { get; set; }
}




