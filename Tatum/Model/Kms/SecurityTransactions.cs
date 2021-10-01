using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Transactions
/// </summary>

public class SecurityTransactions
{
    public string id { get; set; }
    public string chain { get; set; }
    public string[] hashes { get; set; }
    public string serializedTransaction { get; set; }
    public string withdrawalId { get; set; }
    public int index { get; set; }
    public string txId { get; set; }
    public string status { get; set; }
    public Withdrawalrespons[] withdrawalResponses { get; set; }
}

public class Withdrawalrespons
{
}
