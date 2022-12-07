using Tatum.CSharp.Evm.Local.Models;
using Tatum.CSharp.Harmony.Clients;

namespace Tatum.CSharp.Demo.ExampleServices.Harmony;

public class GenerateWalletExampleService
{
    private readonly IHarmonyClient _harmonyClient;

    public GenerateWalletExampleService(IHarmonyClient harmonyClient)
    {
        _harmonyClient = harmonyClient;
    }
    
    public WalletLocal GenerateWallet()
    {
        WalletLocal wallet = _harmonyClient.Local.GenerateWallet();
        
        return wallet;
    }
}