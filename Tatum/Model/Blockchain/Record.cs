using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


public class Record
{

    [JsonProperty("data")]
    public string data { get; set; }


    [JsonProperty("txId")]
    public string txId { get; set; }

}


