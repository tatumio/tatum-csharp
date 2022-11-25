using Microsoft.AspNetCore.Mvc;
using Tatum.CSharp.Core.Model;
using Tatum.CSharp.Harmony.Clients;

namespace Tatum.CSharp.Demo.ExampleServices.Harmony;

public class GeneratePrivateKeyExampleService
{
    private readonly IHarmonyClient _harmonyClient;

    public GeneratePrivateKeyExampleService(IHarmonyClient harmonyClient)
    {
        _harmonyClient = harmonyClient;
    }
    
    public PrivKey GeneratePrivateKey([FromBody] PrivKeyRequest request)
    {
        //request.Mnemonic = "mnemonic from your wallet"
        //request.Index = index of the private key you would like to generate
        
        PrivKey privateKey = _harmonyClient.Local.GenerateAddressPrivateKey(request);
        
        return privateKey;
    }
}