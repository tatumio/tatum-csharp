using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Nethereum.Web3;
using System.Numerics;
using Tatum.Model.Requests;
using Tatum.Model.Responses;



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
       
        Task<Ethereum> GetEthereumTransactionsAddress(string xtestnettype, string address, int from, int to, string sort, int pageSize = 50, int offset = 0);
        Task<Ethereum> TransferEthBlockchainKms(string xtestnettype, string data, string to, string currency, string gaslimit, string gasprice, string amount, string signatureid,string index);

        Task<Ethereum> EstimateEthTransactionFee(string xtestnettype, string from, string to, string amount, string data);

        Task<Ethereum> CallSmartContractMethod(string xtestnettype, string contractAddress, string methodName, object methodAbi, object[] contractparams, string fromPrivateKey, string gasLimit,string gasPrice);

        Task<Ethereum> CallReadSmartContractMethod(string xtestnettype, string contractAddress, string methodName, object methodAbi, object[] contractparams);

        Task<Ethereum> CallSmartContractMethodKMS(string xtestnettype, string contractAddress, string methodName, object methodAbi, object[] contractparams, string signatureId,int index, string gasLimit, string gasPrice);


        Task<Ethereum> GetErc20InternalTransaction(string xtestnettype, string address, int pageSize = 50, int offset = 0);

       
        Task<TransactionHash> BroadcastSignedTransaction(BroadcastRequest request);
        Task<int> GetTransactionsCount(string address);

        /// <summary>
        /// Estimate Gas price for the transaction.
        /// </summary>
        /// <returns>Gas price in Wei.</returns>
        Task<BigInteger> GetGasPriceInWei();

        /// <summary>
        /// Sign Ethereum Store data transaction with private keys locally. Nothing is broadcast to the blockchain.
        /// </summary>
        /// <param name="body">Content of the transaction to broadcast.</param>
        /// <param name="testnet">mainnet or testnet version</param>
        /// <param name="provider">Url of the Ethereum Server to connect to. If not set, default public server will be used.</param>
        /// <returns>Transaction data to be broadcast to blockchain.</returns>
        Task<string> PrepareStoreDataTransaction(CreateRecord body, bool testnet, string provider = null);


        /// <summary>
        ///  Send Ethereum store data transaction to the blockchain. This method broadcasts signed transaction to the blockchain.
        ///  This operation is irreversible.
        /// </summary>
        /// <param name="body">Content of the transaction to broadcast.</param>
        /// <param name="testnet">mainnet or testnet version</param>
        /// <param name="provider">Url of the Ethereum Server to connect to. If not set, default public server will be used.</param>
        /// <returns>Transaction id of the transaction in the blockchain.</returns>
        Task<TransactionHash> SendStoreDataTransaction(CreateRecord body, bool testnet, string provider = null);

    }

}