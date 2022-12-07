using System.Threading.Tasks;
using Tatum.CSharp.Polygon.Clients;
using Tatum.CSharp.Polygon.Core.Model;

namespace Tatum.CSharp.Demo.ExampleServices.Polygon;

public class GetTransactionExampleService
{
    private readonly IPolygonClient _polygonClient;

    public GetTransactionExampleService(IPolygonClient polygonClient)
    {
        _polygonClient = polygonClient;
    }
    
    public async Task<PolygonTx> GetTransaction(string hash)
    {
        PolygonTx transaction = await _polygonClient.PolygonBlockchain.PolygonGetTransactionAsync(hash);
        
        return transaction;
    }   
}