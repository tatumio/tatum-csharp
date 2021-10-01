using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


public class Xrp
{


    [JsonProperty("address")]
    public string address { get; set; }


    [JsonProperty("secret")]
    public string secret { get; set; }


    [JsonProperty("ledger_hash")]
    public string ledger_hash { get; set; }


    [JsonProperty("ledger_index")]
    public int ledger_index { get; set; }


    [JsonProperty("current_ledger_size")]
    public string current_ledger_size { get; set; }


    [JsonProperty("current_queue_size")]
    public string current_queue_size { get; set; }


    [JsonProperty("drops")]
    public Drops drops { get; set; }


    [JsonProperty("expected_ledger_size")]
    public string expected_ledger_size { get; set; }


    [JsonProperty("ledger_current_index")]
    public int ledger_current_index { get; set; }


    [JsonProperty("levels")]
    public Levels levels { get; set; }


    [JsonProperty("max_queue_size")]
    public string max_queue_size { get; set; }


    [JsonProperty("account")]
    public string account { get; set; }


    [JsonProperty("ledger_index_max")]
    public int ledger_index_max { get; set; }


    [JsonProperty("ledger_index_min")]
    public int ledger_index_min { get; set; }


    [JsonProperty("marker")]
    public Marker marker { get; set; }


    [JsonProperty("transactions")]
    public Transaction[] transactions { get; set; }


    [JsonProperty("ledger")]
    public Ledger ledger { get; set; }


    [JsonProperty("validated")]
    public bool validated { get; set; }


    [JsonProperty("hash")]
    public string hash { get; set; }


    [JsonProperty("Account")]
    public string Account { get; set; }


    [JsonProperty("Amount")]
    public string Amount { get; set; }


    [JsonProperty("Destination")]
    public string Destination { get; set; }


    [JsonProperty("Fee")]
    public string Fee { get; set; }


    [JsonProperty("TransactionType")]
    public string TransactionType { get; set; }


    [JsonProperty("Flags")]
    public long Flags { get; set; }


    [JsonProperty("LastLedgerSequence")]
    public int LastLedgerSequence { get; set; }


    [JsonProperty("Sequence")]
    public int Sequence { get; set; }


    [JsonProperty("date")]
    public int date { get; set; }


    [JsonProperty("inLedger")]
    public int inLedger { get; set; }


    [JsonProperty("SigningPubKey")]
    public string SigningPubKey { get; set; }


    [JsonProperty("TxnSignature")]
    public string TxnSignature { get; set; }


    [JsonProperty("meta")]
    public Meta meta { get; set; }



    [JsonProperty("account_data")]
    public Account_Data account_data { get; set; }



    [JsonProperty("assets")]
    public object[] assets { get; set; }


    [JsonProperty("balance")]
    public string balance { get; set; }


    [JsonProperty("txId")]
    public string txId { get; set; }


    [JsonProperty("failed")]
    public bool failed { get; set; }


    [JsonProperty("fromAccount")]
    public string fromAccount { get; set; }


    [JsonProperty("issuerAccount")]
    public string issuerAccount { get; set; }


    [JsonProperty("limit")]
    public string limit { get; set; }


    [JsonProperty("token")]
    public string token { get; set; }


    [JsonProperty("fromSecret")]
    public string fromSecret { get; set; }


    [JsonProperty("fee")]
    public string fee { get; set; }
}




public class Drops
{

    [JsonProperty("base_fee")]
    public string base_fee { get; set; }


    [JsonProperty("median_fee")]
    public string median_fee { get; set; }


    [JsonProperty("minimum_fee")]
    public string minimum_fee { get; set; }


    [JsonProperty("open_ledger_fee")]
    public string open_ledger_fee { get; set; }
}

public class Levels
{

    [JsonProperty("median_level")]
    public string median_level { get; set; }


    [JsonProperty("minimum_level")]
    public string minimum_level { get; set; }


    [JsonProperty("open_ledger_level")]
    public string open_ledger_level { get; set; }


    [JsonProperty("reference_level")]
    public string reference_level { get; set; }
}



public class Marker
{

    [JsonProperty("ledger")]
    public int ledger { get; set; }


    [JsonProperty("seq")]
    public int seq { get; set; }
}



public class Ledger
{

    [JsonProperty("accepted")]
    public bool accepted { get; set; }


    [JsonProperty("account_hash")]
    public string account_hash { get; set; }


    [JsonProperty("close_flags")]
    public int close_flags { get; set; }


    [JsonProperty("close_time")]
    public int close_time { get; set; }


    [JsonProperty("close_time_human")]
    public string close_time_human { get; set; }


    [JsonProperty("close_time_resolution")]
    public int close_time_resolution { get; set; }


    [JsonProperty("closed")]
    public bool closed { get; set; }


    [JsonProperty("hash")]
    public string hash { get; set; }


    [JsonProperty("ledger_hash")]
    public string ledger_hash { get; set; }


    [JsonProperty("ledger_index")]
    public string ledger_index { get; set; }


    [JsonProperty("parent_close_time")]
    public int parent_close_time { get; set; }


    [JsonProperty("parent_hash")]
    public string parent_hash { get; set; }


    [JsonProperty("seqNum")]
    public string seqNum { get; set; }


    [JsonProperty("secret")]
    public string totalCoins { get; set; }


    [JsonProperty("total_coins")]
    public string total_coins { get; set; }


    [JsonProperty("transaction_hash")]
    public string transaction_hash { get; set; }


    [JsonProperty("transactions")]
    public object[] transactions { get; set; }
}



public class Meta
{

    [JsonProperty("AffectedNodes")]
    public object[] AffectedNodes { get; set; }


    [JsonProperty("TransactionIndex")]
    public int TransactionIndex { get; set; }


    [JsonProperty("TransactionResult")]
    public string TransactionResult { get; set; }


    [JsonProperty("delivered_amount")]
    public string delivered_amount { get; set; }
}



public class Account_Data
{
    [JsonProperty("Account")]
    public string Account { get; set; }


    [JsonProperty("Balance")]
    public string Balance { get; set; }


    [JsonProperty("Flags")]
    public int Flags { get; set; }


    [JsonProperty("LedgerEntryType")]
    public string LedgerEntryType { get; set; }


    [JsonProperty("OwnerCount")]
    public int OwnerCount { get; set; }


    [JsonProperty("PreviousTxnID")]
    public string PreviousTxnID { get; set; }


    [JsonProperty("PreviousTxnLgrSeq")]
    public int PreviousTxnLgrSeq { get; set; }


    [JsonProperty("Sequence")]
    public int Sequence { get; set; }


    [JsonProperty("index ")]
    public string index { get; set; }
}






