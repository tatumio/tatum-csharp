using Refit;
using System.Threading.Tasks;
using Tatum.Model.Responses;

namespace Tatum.Blockchain
{
    public interface IEthereumGasApi
    {
        [Get("/json/ethgasAPI.json")]
        Task<GasPrice> GasPrice();
    }
}
