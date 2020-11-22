using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class XrpTx
    {
        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("ledger_index")]
        public int LedgerIndex { get; set; }

        [JsonPropertyName("Account")]
        public string Account { get; set; }

        [JsonPropertyName("Amount")]
        public string Amount { get; set; }

        [JsonPropertyName("Destination")]
        public string Destination { get; set; }

        [JsonPropertyName("Fee")]
        public string Fee { get; set; }

        [JsonPropertyName("TransactionType")]
        public string TransactionType { get; set; }

        [JsonPropertyName("Flags")]
        public long Flags { get; set; }

        [JsonPropertyName("LastLedgerSequence")]
        public int LastLedgerSequence { get; set; }

        [JsonPropertyName("Sequence")]
        public int Sequence { get; set; }

        [JsonPropertyName("date")]
        public int Date { get; set; }

        [JsonPropertyName("inLedger")]
        public int InLedger { get; set; }

        [JsonPropertyName("SigningPubKey")]
        public string SigningPubKey { get; set; }

        [JsonPropertyName("TxnSignature")]
        public string TxnSignature { get; set; }

        [JsonPropertyName("meta")]
        public XrpMeta Meta { get; set; }

        [JsonPropertyName("validated")]
        public bool Validated { get; set; }
    }

    public class FinalFields
    {
        [JsonPropertyName("Account")]
        public string Account { get; set; }

        [JsonPropertyName("Balance")]
        public string Balance { get; set; }

        [JsonPropertyName("Flags")]
        public int Flags { get; set; }

        [JsonPropertyName("OwnerCount")]
        public int OwnerCount { get; set; }

        [JsonPropertyName("Sequence")]
        public int Sequence { get; set; }
    }

    public class PreviousFields
    {
        [JsonPropertyName("Balance")]
        public string Balance { get; set; }

        [JsonPropertyName("Sequence")]
        public int Sequence { get; set; }
    }

    public class ModifiedNode
    {
        [JsonPropertyName("FinalFields")]
        public FinalFields FinalFields { get; set; }

        [JsonPropertyName("LedgerEntryType")]
        public string LedgerEntryType { get; set; }

        [JsonPropertyName("LedgerIndex")]
        public string LedgerIndex { get; set; }

        [JsonPropertyName("PreviousFields")]
        public PreviousFields PreviousFields { get; set; }

        [JsonPropertyName("PreviousTxnID")]
        public string PreviousTxnID { get; set; }

        [JsonPropertyName("PreviousTxnLgrSeq")]
        public int PreviousTxnLgrSeq { get; set; }
    }

    public class AffectedNode
    {
        [JsonPropertyName("ModifiedNode")]
        public ModifiedNode ModifiedNode { get; set; }

        [JsonPropertyName("CreatedNode")]
        public CreatedNode CreatedNode { get; set; }
    }

    public class CreatedNode
    {
        [JsonPropertyName("LedgerEntryType")]
        public string LedgerEntryType { get; set; }

        [JsonPropertyName("LedgerIndex")]
        public string LedgerIndex { get; set; }

        [JsonPropertyName("NewFields")]
        public NewFields NewFields { get; set; }
    }

    public class NewFields
    {
        [JsonPropertyName("Account")]
        public string Account { get; set; }

        [JsonPropertyName("Balance")]
        public string Balance { get; set; }

        [JsonPropertyName("Sequence")]
        public int Sequence { get; set; }
    }

    public class XrpMeta
    {
        [JsonPropertyName("AffectedNodes")]
        public List<AffectedNode> AffectedNodes { get; set; }

        [JsonPropertyName("TransactionIndex")]
        public int TransactionIndex { get; set; }

        [JsonPropertyName("TransactionResult")]
        public string TransactionResult { get; set; }

        [JsonPropertyName("delivered_amount")]
        public string DeliveredAmount { get; set; }
    }
}
