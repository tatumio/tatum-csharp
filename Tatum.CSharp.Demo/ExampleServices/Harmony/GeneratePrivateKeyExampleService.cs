using Microsoft.AspNetCore.Mvc;
using Tatum.CSharp.Evm.Local.Models;
using Tatum.CSharp.Harmony.Clients;

namespace Tatum.CSharp.Demo.ExampleServices.Harmony;

public class GeneratePrivateKeyExampleService
{
    private readonly IHarmonyClient _harmonyClient;

    public GeneratePrivateKeyExampleService(IHarmonyClient harmonyClient)
    {
        _harmonyClient = harmonyClient;
    }
    
    public PrivKeyLocal GeneratePrivateKey([FromBody] PrivKeyRequestLocal request)
    {
        //request.Mnemonic = "mnemonic from your wallet"
        //request.Index = index of the private key you would like to generate
        
        PrivKeyLocal privateKey = _harmonyClient.Local.GenerateAddressPrivateKey(request);
        
        return privateKey;
    }
}