using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


public class QTUM
{
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

    [JsonProperty("confirmations")]
    public int confirmations { get; set; }

    [JsonProperty("size")]
    public int size { get; set; }


    [JsonProperty("height")]
    public int height { get; set; }


    [JsonProperty("version")]
    public int version { get; set; }


    [JsonProperty("merkleroot")]
    public string merkleroot { get; set; }


    [JsonProperty("tx")]
    public string[] tx { get; set; }


    [JsonProperty("time")]
    public int time { get; set; }


    [JsonProperty("nonce")]
    public int nonce { get; set; }


    [JsonProperty("bits")]
    public string bits { get; set; }


    [JsonProperty("difficulty")]
    public string difficulty { get; set; }


    [JsonProperty("chainwork")]
    public string chainwork { get; set; }


    [JsonProperty("previousblockhash")]
    public string previousblockhash { get; set; }


    [JsonProperty("nextblockhash")]
    public string nextblockhash { get; set; }


    [JsonProperty("flags")]
    public string flags { get; set; }


    [JsonProperty("reward")]
    public int reward { get; set; }


    [JsonProperty("isMainChain")]
    public bool isMainChain { get; set; }


    [JsonProperty("minedBy")]
    public string minedBy { get; set; }


    [JsonProperty("ppolInfo")]
    public object poolInfo { get; set; }


    [JsonProperty("txid")]
    public string txid { get; set; }


    [JsonProperty("vout")]
    public int vout { get; set; }


    [JsonProperty("scriptPubKey")]
    public string scriptPubKey { get; set; }


    [JsonProperty("amount")]
    public int amount { get; set; }


    [JsonProperty("satoshis")]
    public int satoshis { get; set; }


    [JsonProperty("isStake")]
    public bool isStake { get; set; }


    [JsonProperty("addrStr")]
    public string addrStr { get; set; }


    [JsonProperty("balance")]
    public int balance { get; set; }


    [JsonProperty("balanceSat")]
    public int balanceSat { get; set; }


    [JsonProperty("totalReceived")]
    public int totalReceived { get; set; }


    [JsonProperty("totalReceivedSat")]
    public int totalReceivedSat { get; set; }


    [JsonProperty("totalSet")]
    public int totalSet { get; set; }


    [JsonProperty("totalSentSat")]
    public int totalSentSat { get; set; }


    [JsonProperty("unconfirmedBalance")]
    public int unconfirmedBalance { get; set; }


    [JsonProperty("unconfirmedBalanceSat")]
    public int unconfirmedBalanceSat { get; set; }


    [JsonProperty("unconfirmedTxApperances")]
    public int unconfirmedTxApperances { get; set; }


    [JsonProperty("txApperances")]
    public int txApperances { get; set; }


    [JsonProperty("transactions")]
    public string[] transactions { get; set; }




    [JsonProperty("locktime")]
    public int locktime { get; set; }


    [JsonProperty("receipt")]
    public int receipt { get; set; }


    [JsonProperty("vin")]
    public Vin[] vin { get; set; }



    [JsonProperty("valueOut")]
    public int valueOut { get; set; }


    [JsonProperty("valueIn")]
    public int valueIn { get; set; }


    [JsonProperty("fees")]
    public int fees { get; set; }


    [JsonProperty("blockhash")]
    public string blockhash { get; set; }



    [JsonProperty("blockheight")]
    public int blockheight { get; set; }


    [JsonProperty("isqrc20Tranfer")]
    public bool isqrc20Transfer { get; set; }


    [JsonProperty("pagesTotal")]
    public int pagesTotal { get; set; }



    [JsonProperty("txId")]
    public string txId { get; set; }


    [JsonProperty("failed")]
    public bool failed { get; set; }

}




