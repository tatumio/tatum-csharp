using System.Threading.Tasks;
using Tatum.CSharp.Ethereum.Clients;
using Tatum.CSharp.Ethereum.Core.Model;

namespace Tatum.CSharp.Demo.ExampleServices.Ethereum;

public class GetTransactionExampleService
{
    private readonly IEthereumClient _ethereumClient;

    public GetTransactionExampleService(IEthereumClient ethereumClient)
    {
        _ethereumClient = ethereumClient;
    }
    
    public async Task<EthTx> GetTransaction(string hash)
    {
        EthTx transaction = await _ethereumClient.EthereumBlockchain.EthGetTransactionAsync(hash);
        
        return transaction;
    }   
}