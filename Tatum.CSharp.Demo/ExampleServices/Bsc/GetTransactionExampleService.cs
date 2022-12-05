using System.Threading.Tasks;
using Tatum.CSharp.Bsc.Clients;
using Tatum.CSharp.Bsc.Core.Model;

namespace Tatum.CSharp.Demo.ExampleServices.Bsc;

public class GetTransactionExampleService
{
    private readonly IBscClient _bscClient;

    public GetTransactionExampleService(IBscClient bscClient)
    {
        _bscClient = bscClient;
    }
    
    public async Task<BscTx> GetTransaction(string hash)
    {
        BscTx transaction = await _bscClient.BscBlockchain.BscGetTransactionAsync(hash);
        
        return transaction;
    }   
}