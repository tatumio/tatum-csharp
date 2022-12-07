using System.Threading.Tasks;
using Tatum.CSharp.Bsc.Clients;
using Tatum.CSharp.Bsc.Core.Model;

namespace Tatum.CSharp.Demo.ExampleServices.Bsc;

public class GetBalanceExampleService
{
    private readonly IBscClient _bscClient;

    public GetBalanceExampleService(IBscClient bscClient)
    {
        _bscClient = bscClient;
    }
    
    public async Task<BscBalance> GetBalance(string address)
    {
        BscBalance balance = await _bscClient.BscBlockchain.BscGetBalanceAsync(address);
        
        return balance;
    }
}