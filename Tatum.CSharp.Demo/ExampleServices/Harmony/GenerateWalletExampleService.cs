using Tatum.CSharp.Core.Model;
using Tatum.CSharp.Harmony.Clients;

namespace Tatum.CSharp.Demo.ExampleServices.Harmony;

public class GenerateWalletExampleService
{
    private readonly IHarmonyClient _harmonyClient;

    public GenerateWalletExampleService(IHarmonyClient harmonyClient)
    {
        _harmonyClient = harmonyClient;
    }
    
    public Wallet GenerateWallet()
    {
        Wallet wallet = _harmonyClient.Local.GenerateWallet();
        
        return wallet;
    }
}