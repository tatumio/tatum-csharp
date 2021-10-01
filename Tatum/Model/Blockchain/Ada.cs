using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


public class Ada
{

    [JsonProperty("data")]
    public string data { get; set; }


    [JsonProperty("txId")]
    public string txId { get; set; }


    [JsonProperty("testnet")]
    public string testnet { get; set; }


    [JsonProperty("tip")]
    public Tip tip { get; set; }


    [JsonProperty("mnemonic")]
    public string mnemonic { get; set; }


    [JsonProperty("xpub")]
    public string xpub { get; set; }


    [JsonProperty("address")]
    public string address { get; set; }


    [JsonProperty("key")]
    public string key { get; set; }


    [JsonProperty("hash")]
    public string hash { get; set; }


    [JsonProperty("number")]
    public int number { get; set; }


    [JsonProperty("epochNo")]
    public int epochNo { get; set; }

    [JsonProperty("slotNo")]
    public string slotNo { get; set; }


    [JsonProperty("merkleRoot")]
    public string merkleRoot { get; set; }


    [JsonProperty("forgedAt")]
    public object forgedAt { get; set; }


    [JsonProperty("fees")]
    public int fees { get; set; }

    [JsonProperty("slotInEpoch")]
    public long slotInEpoch { get; set; }


    [JsonProperty("transactions")]
    public Transaction[] transactions { get; set; }


    [JsonProperty("fee")]
    public string fee { get; set; }


    [JsonProperty("block")]
    public int block { get; set; }


    [JsonProperty("includedAt")]
    public object includedAt { get; set; }

    [JsonProperty("inputs")]
    public Input[] inputs { get; set; }


    [JsonProperty("outputs")]
    public Output[] outputs { get; set; }

    [JsonProperty("failed")]
    public bool failed { get; set; }



}




public class Tip
{

    [JsonProperty("number")]
    public int number { get; set; }

    [JsonProperty("slotNo")]
    public int slotNo { get; set; }


    [JsonProperty("epoch")]
    public object epoch { get; set; }
}
















