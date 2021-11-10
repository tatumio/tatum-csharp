using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


public class neo
{

    [JsonProperty("privateKey")]
    public string privateKey { get; set; }


    [JsonProperty("address")]
    public string address { get; set; }


    [JsonProperty("hash")]
    public string hash { get; set; }


    [JsonProperty("size")]
    public int size { get; set; }


    [JsonProperty("version")]
    public int version { get; set; }


    [JsonProperty("previousblockhash")]
    public string previousblockhash { get; set; }


    [JsonProperty("merkleroot")]
    public string merkleroot { get; set; }


    [JsonProperty("time")]
    public int time { get; set; }


    [JsonProperty("index")]
    public int index { get; set; }


    [JsonProperty("nonce")]
    public string nonce { get; set; }


    [JsonProperty("nextconsensus")]
    public string nextconsensus { get; set; }


    [JsonProperty("script")]
    public object script { get; set; }



    [JsonProperty("tx")]
    public Tx[] tx { get; set; }


    [JsonProperty("confirmations")]
    public int confirmations { get; set; }


    [JsonProperty("nextblockhash")]
    public string nextblockhash { get; set; }



    [JsonProperty("invocation")]
    public string invocation { get; set; }


    [JsonProperty("verification")]
    public string verification { get; set; }


    [JsonProperty("assets")]
    public Assets assets { get; set; }


    [JsonProperty("tokens")]
    public object tokens { get; set; }


    [JsonProperty("id")]
    public string id { get; set; }


    [JsonProperty("type")]
    public string type { get; set; }


    [JsonProperty("name")]
    public object[] name { get; set; }


    [JsonProperty("amount")]
    public string amount { get; set; }


    [JsonProperty("available")]
    public string available { get; set; }


    [JsonProperty("precision")]
    public int precision { get; set; }


    [JsonProperty("owner")]
    public string owner { get; set; }


    [JsonProperty("admin")]
    public string admin { get; set; }


    [JsonProperty("issuer")]
    public string issuer { get; set; }


    [JsonProperty("expiration")]
    public int expiration { get; set; }


    [JsonProperty("frozen")]
    public bool frozen { get; set; }


    [JsonProperty("asset")]
    public string asset { get; set; }


    [JsonProperty("value")]
    public string value { get; set; }


    [JsonProperty("n")]
    public int n { get; set; }



    [JsonProperty("txid")]
    public string txid { get; set; }


    [JsonProperty("blockHeight")]
    public int blockHeight { get; set; }


    [JsonProperty("change")]
    public object change { get; set; }



    [JsonProperty("parameters")]
    public string[] parameters { get; set; }


    [JsonProperty("returntype")]
    public string returntype { get; set; }



    [JsonProperty("code_version")]
    public string code_version { get; set; }


    [JsonProperty("author")]
    public string author { get; set; }


    [JsonProperty("email")]
    public string email { get; set; }


    [JsonProperty("description")]
    public string description { get; set; }


    [JsonProperty("properties")]
    public Properties properties { get; set; }



    [JsonProperty("attributes")]
    public object[] attributes { get; set; }


    [JsonProperty("vin")]
    public Vin[] vin { get; set; }


    [JsonProperty("address")]
    public Vout[] vout { get; set; }


    [JsonProperty("sys_fee")]
    public string sys_fee { get; set; }


    [JsonProperty("net_fee")]
    public string net_fee { get; set; }


    [JsonProperty("scripts")]
    public object[] scripts { get; set; }


    [JsonProperty("blockhash")]
    public string blockhash { get; set; }



    [JsonProperty("blocktime")]
    public int blocktime { get; set; }

}





public class Assets
{

    [JsonProperty("GAS")]
    public string GAS { get; set; }


    [JsonProperty("NEO")]
    public string NEO { get; set; }
}






public class Properties
{

    [JsonProperty("storage")]
    public bool storage { get; set; }


    [JsonProperty("dynamic_invoke")]
    public bool dynamic_invoke { get; set; }
}


