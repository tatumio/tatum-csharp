using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;



namespace Tatum
{
    public interface IEthereumClient
    {
        Wallets CreateWallet(string mnemonic, bool testnet);
        String GeneratePrivateKey(string mnemonic, int index, bool testnet);
        String GenerateAddress(string xPubString, int index, bool testnet);

        Task<Ethereum> Web3Http3Driver(string testnettype, string xApiKey,string jsonrpc,string method,object[] web3params,string id);

        Task<Ethereum> GetCurrentBlockNumber(string xtestnettype);
        Task<Ethereum> GetBlockHash(string xtestnettype,string hash);
        Task<Ethereum> GetEthereumAccountBalance(string xtestnettype, string address);

        Task<Ethereum> GetEthereumTransaction(string xtestnettype, string hash);
        Task<Ethereum> GetCountOfOutgoingTransaction(string xtestnettype, string address);
        Task<Ethereum> GetEthereumTransactionsAddress(string xtestnettype, string address, int from, int to, string sort, int pageSize = 50, int offset = 0);
        Task<Ethereum> TransferEthBlockchain(string xtestnettype, string data, string to, string currency, string gaslimit,string gasprice, string amount,string fromprivatekey);
        Task<Ethereum> TransferEthBlockchainKms(string xtestnettype, string data, string to, string currency, string gaslimit, string gasprice, string amount, string signatureid,string index);

        Task<Ethereum> EstimateEthTransactionFee(string xtestnettype, string from, string to, string amount, string data);

        Task<Ethereum> CallSmartContractMethod(string xtestnettype, string contractAddress, string methodName, object methodAbi, object[] contractparams, string fromPrivateKey, string gasLimit,string gasPrice);

        Task<Ethereum> CallReadSmartContractMethod(string xtestnettype, string contractAddress, string methodName, object methodAbi, object[] contractparams);

        Task<Ethereum> CallSmartContractMethodKMS(string xtestnettype, string contractAddress, string methodName, object methodAbi, object[] contractparams, string signatureId,int index, string gasLimit, string gasPrice);


        Task<Ethereum> GetErc20InternalTransaction(string xtestnettype, string address, int pageSize = 50, int offset = 0);

        Task<Ethereum> BroadcastSignedEthTransaction(string xtestnettype, string txData,string signatureId);


    }

}