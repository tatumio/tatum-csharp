using System.Collections.Generic;

namespace Tatum.Model.Responses
{
    public class TransactionKms
    {
        public string Id { get; set; }
        public Currency Chain { get; set; }
        public string SerializedTransaction { get; set; }
        public List<string> Hashes { get; set; }
        public string TxId { get; set; }
        public string WithdrawalId { get; set; }
        public uint Index { get; set; }
        public List<WithdrawalResponseData> WithdrawalResponses { get; set; }
    }
}
