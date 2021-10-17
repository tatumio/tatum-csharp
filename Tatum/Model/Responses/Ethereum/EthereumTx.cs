using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tatum.Model.Responses
{
    public class EthereumTx
    {
        [JsonProperty("blockHash")]
        public string BlockHash { get; set; }

        [JsonProperty("status")]
        public object Status { get; set; }

        [JsonProperty("blockNumber")]
        public long BlockNumber { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("gas")]
        public int Gas { get; set; }

        [JsonProperty("gasPrice")]
        public object GasPrice { get; set; }

        [JsonProperty("transactionHash")]
        public string TransactionHash { get; set; }

        [JsonProperty("input")]
        public string Input { get; set; }

        [JsonProperty("nonce")]
        public long Nonce { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("transactionIndex")]
        public int TransactionIndex { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("gasUsed")]
        public int GasUsed { get; set; }

        [JsonProperty("cumulativeGasUsed")]
        public int CumulativeGasUsed { get; set; }

        [JsonProperty("contractAddress")]
        public string ContractAddress { get; set; }

        [JsonProperty("logs")]
        public List<Log> Logs { get; set; }
    }

    public class Log
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("topics")]
        public List<string> Topics { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("logIndex")]
        public int LogIndex { get; set; }

        [JsonProperty("transactionIndex")]
        public int TransactionIndex { get; set; }

        [JsonProperty("transactionHash")]
        public string TransactionHash { get; set; }
    }
}
