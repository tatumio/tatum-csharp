using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class AccountBalance
    {
        /// <summary>
        /// Account balance represents all assets on the account, available and blocked.
        /// </summary>
        [JsonPropertyName("accountBalance")]
        public string Balance { get; set; }

        /// <summary>
        /// Available balance on the account represents account balance minus blocked amount on the account.
        /// If the account is frozen or customer is disabled, the available balance will be 0.
        /// Available balance should be user do determine how much can customer send or withdraw from the account.
        /// </summary>
        [JsonPropertyName("availableBalance")]
        public string AvailableBalance { get; set; }
    }
}
