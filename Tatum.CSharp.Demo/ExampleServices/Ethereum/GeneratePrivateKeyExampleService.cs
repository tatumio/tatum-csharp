using Microsoft.AspNetCore.Mvc;
using Tatum.CSharp.Core.Model;
using Tatum.CSharp.Ethereum.Clients;

namespace Tatum.CSharp.Demo.ExampleServices.Ethereum;

public class GeneratePrivateKeyExampleService
{
    private readonly IEthereumClient _ethereumClient;

    public GeneratePrivateKeyExampleService(IEthereumClient ethereumClient)
    {
        _ethereumClient = ethereumClient;
    }
    
    public PrivKey GeneratePrivateKey([FromBody] PrivKeyRequest request)
    {
        //request.Mnemonic = "mnemonic from your wallet"
        //request.Index = index of the private key you would like to generate
        
        PrivKey privateKey = _ethereumClient.Local.GenerateAddressPrivateKey(request);
        
        return privateKey;
    }
}