using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class CreditUsage
    {
        /// <summary>
        /// UTC millis timestamp of the day.
        /// </summary>
        [JsonPropertyName("day")]
        public long Day { get; set; }

        /// <summary>
        /// Number of credits consumed for the concrete day.
        /// </summary>
        [JsonPropertyName("usage")]
        public int Usage { get; set; }
    }
}
