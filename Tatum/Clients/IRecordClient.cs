using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IRecordClient
/// </summary>
/// 

namespace Tatum
{
    public interface IRecordClient
    {

        Task<Record> CreateRecord(string data, string chain, string fromprivateKey, string nonce, string to);
        Task<Record> CreateRecordCelo(string data, string chain,string feecurrency, string fromprivateKey, string nonce, string to);

        Task<Record> CreateRecordQuorum(string data, string chain, string from,  string to);
        Task<Record> CreateRecordFabric(string data, string chain, string key);

        Task<Record> GetLogRecord( string chain, string id);
    }

}