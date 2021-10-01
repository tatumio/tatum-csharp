using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

/// <summary>
/// Summary description for AccountBalance
/// </summary>
public class AccountBalance
{
   
        /// <summary>
        /// Account balance represents all assets on the account, available and blocked.
        /// </summary>
    [JsonProperty("accountBalance")]
    public string Balance { get; set; }

    /// <summary>
    /// Available balance on the account represents account balance minus blocked amount on the account.
    /// If the account is frozen or customer is disabled, the available balance will be 0.
    /// Available balance should be user do determine how much can customer send or withdraw from the account.
    /// </summary>
    [JsonProperty("availableBalance")]
    public string AvailableBalance { get; set; }
}
