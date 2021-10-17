//using Refit;
using System.Threading.Tasks;
using Tatum.Model.Responses;
using Newtonsoft;


namespace Tatum.Blockchain
{
    public interface IEthereumGasApi
    {
        //[Key("/json/ethgasAPI.json")]
        Task<GasPrice> GasPrice();
    }
}
