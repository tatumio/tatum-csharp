using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


public class Binance
{


    [JsonProperty("txId")]
    public string txId { get; set; }


    [JsonProperty("address")]
    public string address { get; set; }


    [JsonProperty("privateKey")]
    public string privateKey { get; set; }



    [JsonProperty("blockHeight")]
    public int blockHeight { get; set; }


    [JsonProperty("tx")]
    public Tx[] tx { get; set; }


    [JsonProperty("account_number")]
    public int account_number { get; set; }



    [JsonProperty("flags")]
    public int flags { get; set; }


    [JsonProperty("sequence")]
    public int sequence { get; set; }



    [JsonProperty("code")]
    public int code { get; set; }


    [JsonProperty("hash")]
    public string hash { get; set; }


    [JsonProperty("height")]
    public string height { get; set; }


    [JsonProperty("log")]
    public string log { get; set; }



    [JsonProperty("ok")]
    public bool ok { get; set; }
   

}







