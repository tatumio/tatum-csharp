using System.Threading.Tasks;
using Tatum.CSharp.Core.Model;
using Tatum.CSharp.Ethereum.Clients;

namespace Tatum.CSharp.Demo.ExampleServices.Ethereum;

public class GetBalanceExampleService
{
    private readonly IEthereumClient _ethereumClient;

    public GetBalanceExampleService(IEthereumClient ethereumClient)
    {
        _ethereumClient = ethereumClient;
    }
    
    public async Task<EthBalance> GetBalance(string address)
    {
        EthBalance balance = await _ethereumClient.EthereumBlockchain.EthGetBalanceAsync(address);
        
        return balance;
    }
}