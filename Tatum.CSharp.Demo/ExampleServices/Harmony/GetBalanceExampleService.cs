using System.Threading.Tasks;
using Tatum.CSharp.Harmony.Clients;
using Tatum.CSharp.Harmony.Core.Model;

namespace Tatum.CSharp.Demo.ExampleServices.Harmony;

public class GetBalanceExampleService
{
    private readonly IHarmonyClient _harmonyClient;

    public GetBalanceExampleService(IHarmonyClient harmonyClient)
    {
        _harmonyClient = harmonyClient;
    }
    
    public async Task<OneBalance> GetBalance(string address)
    {
        OneBalance balance = await _harmonyClient.HarmonyBlockchain.OneGetBalanceAsync(address);
        
        return balance;
    }
}