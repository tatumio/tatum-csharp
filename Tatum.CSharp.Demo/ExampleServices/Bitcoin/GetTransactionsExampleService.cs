using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.CSharp.Bitcoin.Clients;
using Tatum.CSharp.Core.Model;

namespace Tatum.CSharp.Demo.ExampleServices.Bitcoin;

public class GetTransactionsExampleService
{
    private readonly IBitcoinClient _bitcoinClient;

    public GetTransactionsExampleService(IBitcoinClient bitcoinClient)
    {
        _bitcoinClient = bitcoinClient;
    }
    
    public async Task<List<BtcTx>> GetTransactions(string address)
    {
        List<BtcTx> transactions = await _bitcoinClient.BitcoinBlockchain.BtcGetTxByAddressAsync(address, 10);
        
        return transactions;
    }
}