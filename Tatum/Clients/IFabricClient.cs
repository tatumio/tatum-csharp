using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IFabricClient
/// </summary>
/// 
namespace Tatum
{
    public interface IFabricClient
    {
        Task<Fabric> StoreData(string key, string data, string chain);
        Task<Fabric> GetData(string key);
    }
}