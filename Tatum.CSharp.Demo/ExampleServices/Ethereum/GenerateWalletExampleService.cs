using Tatum.CSharp.Ethereum.Clients;
using Tatum.CSharp.Evm.Local.Models;

namespace Tatum.CSharp.Demo.ExampleServices.Ethereum;

public class GenerateWalletExampleService
{
    private readonly IEthereumClient _ethereumClient;

    public GenerateWalletExampleService(IEthereumClient ethereumClient)
    {
        _ethereumClient = ethereumClient;
    }
    
    public WalletLocal GenerateWallet()
    {
        WalletLocal wallet = _ethereumClient.Local.GenerateWallet();
        
        return wallet;
    }
}