using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Tatum
{
    public interface IipfsClient
    {
        Task<Ipfs> storeDataToIpfs(object file);
        Task<Ipfs> getFileFromIpfs(string id);
        Task<Ipfs> deleteFileFromIpfs(string id);
    }

}