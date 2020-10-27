using System.Threading.Tasks;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public interface IBitcoinClient
    {
        Task<BitcoinInfo> GetBlockchainInfo();
    }
}
