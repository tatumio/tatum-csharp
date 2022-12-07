using Tatum.CSharp.Evm.Local.Models;
using Tatum.CSharp.Polygon.Clients;

namespace Tatum.CSharp.Demo.ExampleServices.Polygon;

public class GenerateAddressExampleService
{
    private readonly IPolygonClient _polygonClient;

    public GenerateAddressExampleService(IPolygonClient polygonClient)
    {
        _polygonClient = polygonClient;
    }
    
    public GeneratedAddressEthLocal GenerateAddress(string xpub, int index)
    {
        //xpub = "xpub from your wallet"
        //index = index of the address you would like to generate
        
        GeneratedAddressEthLocal address = _polygonClient.Local.GenerateAddress(xpub, index);
     
        return address;
    }
}