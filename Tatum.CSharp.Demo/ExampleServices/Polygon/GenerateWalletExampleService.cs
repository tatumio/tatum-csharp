using Tatum.CSharp.Core.Model;
using Tatum.CSharp.Polygon.Clients;

namespace Tatum.CSharp.Demo.ExampleServices.Polygon;

public class GenerateWalletExampleService
{
    private readonly IPolygonClient _polygonClient;

    public GenerateWalletExampleService(IPolygonClient polygonClient)
    {
        _polygonClient = polygonClient;
    }
    
    public Wallet GenerateWallet()
    {
        Wallet wallet = _polygonClient.Local.GenerateWallet();
        
        return wallet;
    }
}