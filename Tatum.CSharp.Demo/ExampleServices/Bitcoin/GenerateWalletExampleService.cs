
using Tatum.CSharp.Bitcoin.Clients;
using Tatum.CSharp.Bitcoin.Local.Models;

namespace Tatum.CSharp.Demo.ExampleServices.Bitcoin;

public class GenerateWalletExampleService
{
    private readonly IBitcoinClient _bitcoinClient;

    public GenerateWalletExampleService(IBitcoinClient bitcoinClient)
    {
        _bitcoinClient = bitcoinClient;
    }
    
    public WalletLocal GenerateWallet()
    {
        WalletLocal wallet = _bitcoinClient.Local.GenerateWallet();
        
        return wallet;
    }
}