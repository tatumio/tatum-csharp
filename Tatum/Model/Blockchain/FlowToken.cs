using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


public class FlowToken
{

    [JsonProperty("failed")]
    public string failed { get; set; }


    [JsonProperty("txId")]
    public string txId { get; set; }

    [JsonProperty("balance")]
    public string balance { get; set; }

}


