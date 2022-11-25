using Microsoft.AspNetCore.Mvc;
using Tatum.CSharp.Core.Model;
using Tatum.CSharp.Bsc.Clients;

namespace Tatum.CSharp.Demo.ExampleServices.Bsc;

public class GeneratePrivateKeyExampleService
{
    private readonly IBscClient _bscClient;

    public GeneratePrivateKeyExampleService(IBscClient bscClient)
    {
        _bscClient = bscClient;
    }
    
    public PrivKey GeneratePrivateKey([FromBody] PrivKeyRequest request)
    {
        //request.Mnemonic = "mnemonic from your wallet"
        //request.Index = index of the private key you would like to generate
        
        PrivKey privateKey = _bscClient.Local.GenerateAddressPrivateKey(request);
        
        return privateKey;
    }
}