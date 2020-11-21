using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tatum.Model.Responses
{
    public class EthereumTx
    {
        [JsonPropertyName("blockHash")]
        public string BlockHash { get; set; }

        [JsonPropertyName("status")]
        public object Status { get; set; }

        [JsonPropertyName("blockNumber")]
        public long BlockNumber { get; set; }

        [JsonPropertyName("from")]
        public string From { get; set; }

        [JsonPropertyName("gas")]
        public int Gas { get; set; }

        [JsonPropertyName("gasPrice")]
        public object GasPrice { get; set; }

        [JsonPropertyName("transactionHash")]
        public string TransactionHash { get; set; }

        [JsonPropertyName("input")]
        public string Input { get; set; }

        [JsonPropertyName("nonce")]
        public long Nonce { get; set; }

        [JsonPropertyName("to")]
        public string To { get; set; }

        [JsonPropertyName("transactionIndex")]
        public int TransactionIndex { get; set; }

        [JsonPropertyName("value")]
        public object Value { get; set; }

        [JsonPropertyName("gasUsed")]
        public int GasUsed { get; set; }

        [JsonPropertyName("cumulativeGasUsed")]
        public int CumulativeGasUsed { get; set; }

        [JsonPropertyName("contractAddress")]
        public string ContractAddress { get; set; }

        [JsonPropertyName("logs")]
        public List<Log> Logs { get; set; }
    }

    public class Log
    {
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("topics")]
        public List<string> Topics { get; set; }

        [JsonPropertyName("data")]
        public string Data { get; set; }

        [JsonPropertyName("logIndex")]
        public int LogIndex { get; set; }

        [JsonPropertyName("transactionIndex")]
        public int TransactionIndex { get; set; }

        [JsonPropertyName("transactionHash")]
        public string TransactionHash { get; set; }
    }
}
