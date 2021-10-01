using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;


/// <summary>
/// Summary description for IKmsClient
/// </summary>

namespace Tatum
{
    public interface IKmsClient
    {
        Task<List<SecurityTransactions>> GetPendingTransactions(string chain);
        Task<SecurityTransactions> CompletePendingTransactions(string id,string txId);
        Task<List<SecurityTransactions>> GetTransactionDetails(string id);
        Task<SecurityTransactions> DeleteTransaction(string id);
        Task<SecurityTransactions> CheckMaliciousAddress(string address);
    }
}