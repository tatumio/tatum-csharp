using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


public class Dogecoin
{
    [JsonProperty("mnemonic")]
    public string mnemonic { get; set; }


    [JsonProperty("xpub")]
    public string xpub { get; set; }

    [JsonProperty("key")]
    public string key { get; set; }

    [JsonProperty("address")]
    public string address { get; set; }


    [JsonProperty("index")]
    public string index { get; set; }


    [JsonProperty("hash")]
    public string hash { get; set; }


    [JsonProperty("size")]
    public string size { get; set; }


    [JsonProperty("flag")]
    public string flag { get; set; }


    [JsonProperty("ps")]
    public string ps { get; set; }

    [JsonProperty("ts")]
    public string ts { get; set; }


    [JsonProperty("chain")]
    public string chain { get; set; }


    [JsonProperty("blocks")]
    public int blocks { get; set; }


    [JsonProperty("headers")]
    public int headers { get; set; }


    [JsonProperty("bestblockhash")]
    public string bestblockhash { get; set; }



    [JsonProperty("difficulty")]
    public float difficulty { get; set; }


    [JsonProperty("confirmations")]
    public float confirmations { get; set; }



    [JsonProperty("height")]
    public int height { get; set; }



    [JsonProperty("depth")]
    public int depth { get; set; }



    [JsonProperty("version")]
    public int version { get; set; }



    [JsonProperty("prevBlock")]
    public string prevBlock { get; set; }



    [JsonProperty("merkleroot")]
    public string merkleRoot { get; set; }



    [JsonProperty("time")]
    public int time { get; set; }



    [JsonProperty("bits")]
    public int bits { get; set; }



    [JsonProperty("nonce")]
    public int nonce { get; set; }



    [JsonProperty("tx")]
    public Tx[] tx { get; set; }


    [JsonProperty("witnessHash")]
    public string witnessHash { get; set; }



    [JsonProperty("fee")]
    public int fee { get; set; }



    [JsonProperty("rate")]
    public int rate { get; set; }



    [JsonProperty("mtime")]
    public int mtime { get; set; }



    [JsonProperty("block")]
    public string block { get; set; }



    [JsonProperty("inputs")]
    public Input[] inputs { get; set; }



    [JsonProperty("outputs")]
    public Output[] outputs { get; set; }



    [JsonProperty("locktime")]
    public int locktime { get; set; }



    [JsonProperty("incoming")]
    public string incoming { get; set; }



    [JsonProperty("outgoing")]
    public string outgoing { get; set; }



    [JsonProperty("value")]
    public int value { get; set; }



    [JsonProperty("script")]
    public string script { get; set; }


    [JsonProperty("coinbase")]
    public bool coinbase { get; set; }



    [JsonProperty("fromAddress")]
    public Fromaddress[] fromAddress { get; set; }



    [JsonProperty("to")]
    public To[] to { get; set; }



    [JsonProperty("txData")]
    public string txData { get; set; }



    [JsonProperty("signatureId")]
    public string signatureId { get; set; }


    [JsonProperty("previousblockhash")]
    public string previousblockhash { get; set; }

    [JsonProperty("nextblockhash")]
    public string nextblockhash { get; set; }


    [JsonProperty("txid")]
    public string txid { get; set; }

    [JsonProperty("vin")]
    public Vin[] vin { get; set; }

    [JsonProperty("vout")]
    public Vout[] vout { get; set; }


    [JsonProperty("fromUTXO")]
    public Fromutxo[] fromUTXO { get; set; }




}