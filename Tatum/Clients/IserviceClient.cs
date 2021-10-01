using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IserviceClient
/// </summary>
/// 
namespace Tatum
{
    public interface IserviceClient
    {
        Task<Service> GetCreditConsumptionForLastMonth();
        Task<Service> GetCurrentExchangeRate(string currency);
        Task<Service> GetApiVersion();
        Task<Service> FreezeApiKey();
        Task<Service> UnFreezeApiKey();
    }

}