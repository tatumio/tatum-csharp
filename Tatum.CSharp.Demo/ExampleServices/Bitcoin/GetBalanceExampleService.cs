using System.Threading.Tasks;
using Tatum.CSharp.Bitcoin.Clients;
using Tatum.CSharp.Bitcoin.Core.Model;

namespace Tatum.CSharp.Demo.ExampleServices.Bitcoin;

public class GetBalanceExampleService
{
    private readonly IBitcoinClient _bitcoinClient;

    public GetBalanceExampleService(IBitcoinClient bitcoinClient)
    {
        _bitcoinClient = bitcoinClient;
    }
    
    public async Task<BtcBasedBalance> GetBalance(string address)
    {
        BtcBasedBalance balance = await _bitcoinClient.BitcoinBlockchain.BtcGetBalanceOfAddressAsync(address);
        
        return balance;
    }
}