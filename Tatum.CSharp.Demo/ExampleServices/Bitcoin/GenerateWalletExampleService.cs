using Tatum.CSharp.Bitcoin.Clients;
using Tatum.CSharp.Core.Model;

namespace Tatum.CSharp.Demo.ExampleServices.Bitcoin;

public class GenerateWalletExampleService
{
    private readonly IBitcoinClient _bitcoinClient;

    public GenerateWalletExampleService(IBitcoinClient bitcoinClient)
    {
        _bitcoinClient = bitcoinClient;
    }
    
    public Wallet GenerateWallet()
    {
        Wallet wallet = _bitcoinClient.Local.GenerateWallet();
        
        return wallet;
    }
}