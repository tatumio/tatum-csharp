using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


public class Xlm
{


    [JsonProperty("address")]
    public string address { get; set; }


    [JsonProperty("secret")]
    public string secret { get; set; }


    [JsonProperty("id")]
    public string id { get; set; }


    [JsonProperty("paging_token")]
    public string paging_token { get; set; }


    [JsonProperty("hash")]
    public string hash { get; set; }


    [JsonProperty("sequence")]
    public int sequence { get; set; }


    [JsonProperty("successful_transaction_count")]
    public int successful_transaction_count { get; set; }


    [JsonProperty("failed_transaction_count")]
    public int failed_transaction_count { get; set; }


    [JsonProperty("operation_count")]
    public int operation_count { get; set; }


    [JsonProperty("closed_at")]
    public DateTime closed_at { get; set; }


    [JsonProperty("total_coins")]
    public string total_coins { get; set; }


    [JsonProperty("fee_pool")]
    public string fee_pool { get; set; }


    [JsonProperty("base_fee_in_stroops")]
    public int base_fee_in_stroops { get; set; }


    [JsonProperty("base_reserve_in_stroops")]
    public int base_reserve_in_stroops { get; set; }


    [JsonProperty("max_tx_set_size")]
    public int max_tx_set_size { get; set; }


    [JsonProperty("protocol_version")]
    public int protocol_version { get; set; }


    [JsonProperty("header_xdr")]
    public string header_xdr { get; set; }


    [JsonProperty("successful")]
    public bool successful { get; set; }


    [JsonProperty("ledger")]
    public int ledger { get; set; }


    [JsonProperty("created_at")]
    public DateTime created_at { get; set; }


    [JsonProperty("source_account")]
    public string source_account { get; set; }


    [JsonProperty("source_account_sequence")]
    public string source_account_sequence { get; set; }


    [JsonProperty("fee_paid")]
    public int fee_paid { get; set; }


    [JsonProperty("fee_charged")]
    public int fee_charged { get; set; }


    [JsonProperty("max_fee")]
    public int max_fee { get; set; }



    [JsonProperty("envelope_xdr")]
    public string envelope_xdr { get; set; }


    [JsonProperty("result_xdr")]
    public string result_xdr { get; set; }


    [JsonProperty("result_meta_xdr")]
    public string result_meta_xdr { get; set; }


    [JsonProperty("fee_meta_xdr")]
    public string fee_meta_xdr { get; set; }


    [JsonProperty("memo")]
    public string memo { get; set; }


    [JsonProperty("memo_type")]
    public string memo_type { get; set; }


    [JsonProperty("signatures")]
    public object[] signatures { get; set; }



    [JsonProperty("account_id")]
    public string account_id { get; set; }


    [JsonProperty("subentry_count")]
    public int subentry_count { get; set; }


    [JsonProperty("last_modified_ledger")]
    public int last_modified_ledger { get; set; }


    [JsonProperty("thresholds")]
    public Thresholds thresholds { get; set; }


    [JsonProperty("flags")]
    public Flags flags { get; set; }


    [JsonProperty("fromAccount")]
    public string fromAccount { get; set; }


    [JsonProperty("to")]
    public string to { get; set; }


    [JsonProperty("amount")]
    public string amount { get; set; }


    [JsonProperty("fromSecret")]
    public string fromSecret { get; set; }


    [JsonProperty("initialize")]
    public bool initialize { get; set; }


    [JsonProperty("message")]
    public string message { get; set; }


    [JsonProperty("txId")]
    public string txId { get; set; }


    [JsonProperty("failed")]
    public bool failed { get; set; }

}




public class Thresholds
{

    [JsonProperty("low_threshold")]
    public int low_threshold { get; set; }


    [JsonProperty("med_threshold")]
    public int med_threshold { get; set; }


    [JsonProperty("high_threshold")]
    public int high_threshold { get; set; }
}

public class Flags
{

    [JsonProperty("auth_required")]
    public bool auth_required { get; set; }


    [JsonProperty("auth_revocable")]
    public bool auth_revocable { get; set; }


    [JsonProperty("auth_immutable")]
    public bool auth_immutable { get; set; }
}




