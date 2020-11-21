using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class VeChainTxReceipt
    {
        [JsonPropertyName("gasUsed")]
        public int GasUsed { get; set; }

        [JsonPropertyName("gasPayer")]
        public string GasPayer { get; set; }

        [JsonPropertyName("paid")]
        public string Paid { get; set; }

        [JsonPropertyName("reward")]
        public string Reward { get; set; }

        [JsonPropertyName("reverted")]
        public bool Reverted { get; set; }

        [JsonPropertyName("meta")]
        public VeChainTxReceiptMeta Meta { get; set; }

        [JsonPropertyName("outputs")]
        public List<VeChainTxReceiptOutput> Outputs { get; set; }

        [JsonPropertyName("blockNumber")]
        public int BlockNumber { get; set; }

        [JsonPropertyName("blockHash")]
        public string BlockHash { get; set; }

        [JsonPropertyName("transactionHash")]
        public string TransactionHash { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    public class VeChainTxReceiptTransfer
    {
        [JsonPropertyName("sender")]
        public string Sender { get; set; }

        [JsonPropertyName("recipient")]
        public string Recipient { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }
    }

    public class VeChainTxReceiptOutput
    {
        [JsonPropertyName("events")]
        public List<object> Events { get; set; }

        [JsonPropertyName("transfers")]
        public List<VeChainTxReceiptTransfer> Transfers { get; set; }
    }

    public class VeChainTxReceiptMeta
    {
        [JsonPropertyName("blockID")]
        public string BlockID { get; set; }

        [JsonPropertyName("blockNumber")]
        public int BlockNumber { get; set; }

        [JsonPropertyName("blockTimestamp")]
        public int BlockTimestamp { get; set; }

        [JsonPropertyName("txID")]
        public string TxID { get; set; }

        [JsonPropertyName("txOrigin")]
        public string TxOrigin { get; set; }
    }
}
