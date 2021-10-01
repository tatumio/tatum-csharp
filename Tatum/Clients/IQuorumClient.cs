using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IQuorumClient
/// </summary>
/// 
namespace Tatum
{
    public interface IQuorumClient
    {

        Task<Quorum> GenerateQuorumAccount(string password);
        Task<Quorum> UnlockQuorumAccount(string address);
        Task<Quorum> Web3HttpDriver(string xapikey);

        Task<Quorum> GetCurrentBlockNumber();
        Task<Quorum> GetQuorumBlockByHash(string hash);
        Task<Quorum> GetQuorumTransaction(string hash);
        Task<Quorum> GetQuorumTransactionReceipt(string hash);
        Task<Quorum> SendQuorumTransaction(string from, string to, string data, string amount);


    }
}