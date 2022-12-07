using Microsoft.AspNetCore.Mvc;
using Tatum.CSharp.Ethereum.Clients;
using Tatum.CSharp.Evm.Local.Models;

namespace Tatum.CSharp.Demo.ExampleServices.Ethereum;

public class GeneratePrivateKeyExampleService
{
    private readonly IEthereumClient _ethereumClient;

    public GeneratePrivateKeyExampleService(IEthereumClient ethereumClient)
    {
        _ethereumClient = ethereumClient;
    }
    
    public PrivKeyLocal GeneratePrivateKey([FromBody] PrivKeyRequestLocal request)
    {
        //request.Mnemonic = "mnemonic from your wallet"
        //request.Index = index of the private key you would like to generate
        
        PrivKeyLocal privateKey = _ethereumClient.Local.GenerateAddressPrivateKey(request);
        
        return privateKey;
    }
}