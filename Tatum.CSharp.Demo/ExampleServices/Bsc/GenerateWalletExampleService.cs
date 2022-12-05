using Tatum.CSharp.Bsc.Clients;
using Tatum.CSharp.Evm.Local.Models;

namespace Tatum.CSharp.Demo.ExampleServices.Bsc;

public class GenerateWalletExampleService
{
    private readonly IBscClient _bscClient;

    public GenerateWalletExampleService(IBscClient bscClient)
    {
        _bscClient = bscClient;
    }
    
    public WalletLocal GenerateWallet()
    {
        WalletLocal wallet = _bscClient.Local.GenerateWallet();
        
        return wallet;
    }
}