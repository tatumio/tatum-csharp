using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// Summary description for OffBlockchain
/// </summary>

public class OffBlockchain
{
    [JsonProperty("senderAccountId")]
    public string senderAccountId { get; set; }


    [JsonProperty("address")]
    public string address { get; set; }


    [JsonProperty("amount")]
    public string amount { get; set; }


    [JsonProperty("account")]
    public string account { get; set; }


    [JsonProperty("secret")]
    public string secret { get; set; }


    [JsonProperty("sourceTag")]
    public string sourceTag { get; set; }


    [JsonProperty("compliant")]
    public bool compliant { get; set; }


    [JsonProperty("multipleAmounts")]
    public string[] multipleAmounts { get; set; }


    [JsonProperty("fee")]
    public string fee { get; set; }


    [JsonProperty("attr")]
    public string attr { get; set; }


    [JsonProperty("mnemonic")]
    public string mnemonic { get; set; }


    [JsonProperty("xpub")]
    public string xpub { get; set; }


    [JsonProperty("paymentId")]
    public string paymentId { get; set; }


    [JsonProperty("senderNote")]
    public string senderNote { get; set; }

    [JsonProperty("index")]
    public int Index { get; set; }

    [JsonProperty("nonce")]
    public int nonce { get; set; }

    [JsonProperty("privateKey")]
    public string PrivateKey { get; set; }

    [JsonProperty("gasLimit")]
    public string GasLimit { get; set; }

    [JsonProperty("gasPrice")]
    public int GasPrice { get; set; }



    [JsonProperty("symbol")]
    public string symbol { get; set; }

    [JsonProperty("supply")]
    public string supply { get; set; }

    [JsonProperty("decimals")]
    public int decimals { get; set; }

    [JsonProperty("type")]
    public string type { get; set; }

    [JsonProperty("description")]
    public string description { get; set; }

    [JsonProperty("url")]
    public string url { get; set; }

    [JsonProperty("basepair")]
    public string basePair { get; set; }

    [JsonProperty("baserate")]
    public int baseRate { get; set; }

    [JsonProperty("customer")]
    public Customer customer { get; set; }


    [JsonProperty("derivationIndex")]
    public int derivationIndex { get; set; }


    [JsonProperty("feeCurrency")]
    public string feeCurrency { get; set; }


    [JsonProperty("fast")]
    public Customer fast { get; set; }


    [JsonProperty("medium")]
    public int medium { get; set; }


    [JsonProperty("slow")]
    public string slow { get; set; }



}









