using Tatum.CSharp.Core.Model;
using Tatum.CSharp.Ethereum.Clients;

namespace Tatum.CSharp.Demo.ExampleServices.Ethereum;

public class GenerateWalletExampleService
{
    private readonly IEthereumClient _ethereumClient;

    public GenerateWalletExampleService(IEthereumClient ethereumClient)
    {
        _ethereumClient = ethereumClient;
    }
    
    public Wallet GenerateWallet()
    {
        Wallet wallet = _ethereumClient.Local.GenerateWallet();
        
        return wallet;
    }
}