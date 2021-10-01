using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

public class Scrypta
{
    [JsonProperty("mnemonic")]
    public string mnemonic { get; set; }

    [JsonProperty("xpub")]
    public string xpub { get; set; }

    [JsonProperty("key")]
    public string key { get; set; }

    [JsonProperty("hash")]
    public string hash { get; set; }

    [JsonProperty("address")]
    public string address { get; set; }


    [JsonProperty("txid")]
    public string txid { get; set; }


    [JsonProperty("failed")]
    public string failed { get; set; }


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
    public float difficulty { get; set; }


    [JsonProperty("chainwork")]
    public string chainwork { get; set; }


    [JsonProperty("previousblockhash")]
    public string previousblockhash { get; set; }


    [JsonProperty("nextblockhash")]
    public string nextblockhash { get; set; }


    [JsonProperty("txs")]
    public Tx[] txs { get; set; }



    [JsonProperty("fromAddress")]
    public Fromaddress[] fromAddress { get; set; }


    [JsonProperty("fromUTXO")]
    public Fromutxo[] fromUTXO { get; set; }


    [JsonProperty("to")]
    public To[] to { get; set; }



    [JsonProperty("inputs")]

    public Input[] inputs { get; set; }


    [JsonProperty("outputs")]
    public Output[] outputs { get; set; }



    [JsonProperty("blockhash")]
    public string blockhash { get; set; }


    [JsonProperty("vout")]
    public int vout { get; set; }


    [JsonProperty("amount")]
    public float amount { get; set; }


    [JsonProperty("scriptPubKey")]
    public string scriptPubKey { get; set; }


    [JsonProperty("block")]
    public int block { get; set; }



    [JsonProperty("protocolversion")]
    public int protocolversion { get; set; }


    [JsonProperty("walletversion")]
    public int walletversion { get; set; }


    [JsonProperty("balance")]
    public float balance { get; set; }


    [JsonProperty("obfuscation_balance")]
    public int obfuscation_balance { get; set; }


    [JsonProperty("blocks")]
    public int blocks { get; set; }


    [JsonProperty("timeoffset")]
    public int timeoffset { get; set; }


    [JsonProperty("connections")]
    public int connections { get; set; }


    [JsonProperty("proxy")]
    public string proxy { get; set; }



    [JsonProperty("testnet")]
    public bool testnet { get; set; }


    [JsonProperty("keypoololdest")]
    public int keypoololdest { get; set; }


    [JsonProperty("keypoolsize")]
    public int keypoolsize { get; set; }


    [JsonProperty("paytxfee")]
    public int paytxfee { get; set; }


    [JsonProperty("relayfee")]
    public float relayfee { get; set; }


    [JsonProperty("statingstatus")]
    public string stakingstatus { get; set; }


    [JsonProperty("errors")]
    public string errors { get; set; }


    [JsonProperty("indexed")]
    public int indexed { get; set; }


    [JsonProperty("toindex")]
    public int toindex { get; set; }


    [JsonProperty("checksum")]
    public string checksum { get; set; }


    [JsonProperty("node")]
    public string node { get; set; }
}




