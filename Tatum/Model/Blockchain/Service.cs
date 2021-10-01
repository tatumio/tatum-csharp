using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


public class Service
{

    [JsonProperty("day")]
    public long day { get; set; }

    [JsonProperty("usage")]
    public int usage { get; set; }


    [JsonProperty("id")]
    public string id { get; set; }

    [JsonProperty("value")]
    public string value { get; set; }


    [JsonProperty("basePair")]
    public string basePair { get; set; }


    [JsonProperty("timestamp")]
    public long timestamp { get; set; }


    [JsonProperty("source")]
    public string source { get; set; }


    [JsonProperty("version")]
    public string version { get; set; }
}




