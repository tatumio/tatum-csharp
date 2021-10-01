using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
/// <summary>
/// Summary description for Transaction
/// </summary>
public class Transaction
{

    [JsonProperty("accountId")]
    public string accountId { get; set; }

    [JsonProperty("counterAccountId")]
    public string counterAccountId { get; set; }

    [JsonProperty("currency")]
    public string currency { get; set; }

    [JsonProperty("senderAccountId")]
    public string senderAccountId { get; set; }

    [JsonProperty("recipientAccountId")]
    public string recipientAccountId { get; set; }

    [JsonProperty("amount")]
    public string amount { get; set; }

    [JsonProperty("anonymous")]
    public bool anonymous { get; set; }

    [JsonProperty("compliant")]
    public bool compliant { get; set; }

    [JsonProperty("transactionCode")]
    public string transactionCode { get; set; }

    [JsonProperty("paymentId")]
    public string paymentId { get; set; }

    [JsonProperty("recipientNote")]
    public string recipientNote { get; set; }

    [JsonProperty("baseRate")]
    public int baseRate { get; set; }

    [JsonProperty("senderNote")]
    public string senderNote { get; set; }

    [JsonProperty("created")]
    public long created { get; set; }

    [JsonProperty("marketValue")]
    public Marketvalue marketValue { get; set; }

    [JsonProperty("operationType")]
    public string operationType { get; set; }

    [JsonProperty("transactionType")]
    public string transactionType { get; set; }

    [JsonProperty("reference")]
    public string reference { get; set; }

    [JsonProperty("attr")]
    public string attr { get; set; }

    [JsonProperty("address")]
    public string address { get; set; }

    [JsonProperty("txId")]
    public string txId { get; set; }

}






public class Marketvalue
{

    [JsonProperty("amount")]
    public string amount { get; set; }

    [JsonProperty("currency")]
    public string currency { get; set; }

    [JsonProperty("sourceDate")]
    public long sourceDate { get; set; }

    [JsonProperty("source")]
    public string source { get; set; }
}
