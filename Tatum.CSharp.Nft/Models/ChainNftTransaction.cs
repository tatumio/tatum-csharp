namespace Tatum.CSharp.Nft.Models
{
    public class ChainNftTransaction
    {
        public int BlockNumber { get; set; }
        public string TxId { get; set; }
        public string ContractAddress { get; set; }
        public string TokenId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}