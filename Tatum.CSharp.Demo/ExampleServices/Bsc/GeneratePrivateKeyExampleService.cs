using Microsoft.AspNetCore.Mvc;
using Tatum.CSharp.Bsc.Clients;
using Tatum.CSharp.Evm.Local.Models;

namespace Tatum.CSharp.Demo.ExampleServices.Bsc;

public class GeneratePrivateKeyExampleService
{
    private readonly IBscClient _bscClient;

    public GeneratePrivateKeyExampleService(IBscClient bscClient)
    {
        _bscClient = bscClient;
    }
    
    public PrivKeyLocal GeneratePrivateKey([FromBody] PrivKeyRequestLocal request)
    {
        //request.Mnemonic = "mnemonic from your wallet"
        //request.Index = index of the private key you would like to generate
        
        PrivKeyLocal privateKey = _bscClient.Local.GenerateAddressPrivateKey(request);
        
        return privateKey;
    }
}