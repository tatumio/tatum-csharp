using Microsoft.AspNetCore.Mvc;
using Tatum.CSharp.Evm.Local.Models;
using Tatum.CSharp.Polygon.Clients;

namespace Tatum.CSharp.Demo.ExampleServices.Polygon;

public class GeneratePrivateKeyExampleService
{
    private readonly IPolygonClient _polygonClient;

    public GeneratePrivateKeyExampleService(IPolygonClient polygonClient)
    {
        _polygonClient = polygonClient;
    }
    
    public PrivKeyLocal GeneratePrivateKey([FromBody] PrivKeyRequestLocal request)
    {
        //request.Mnemonic = "mnemonic from your wallet"
        //request.Index = index of the private key you would like to generate
        
        PrivKeyLocal privateKey = _polygonClient.Local.GenerateAddressPrivateKey(request);
        
        return privateKey;
    }
}