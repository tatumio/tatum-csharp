using System.Threading.Tasks;
using Tatum.CSharp.Harmony.Clients;
using Tatum.CSharp.Harmony.Core.Model;

namespace Tatum.CSharp.Demo.ExampleServices.Harmony;

public class GetTransactionExampleService
{
    private readonly IHarmonyClient _harmonyClient;

    public GetTransactionExampleService(IHarmonyClient harmonyClient)
    {
        _harmonyClient = harmonyClient;
    }
    
    public async Task<OneTx> GetTransaction(string hash)
    {
        OneTx transaction = await _harmonyClient.HarmonyBlockchain.OneGetTransactionAsync(hash);
        
        return transaction;
    }   
}