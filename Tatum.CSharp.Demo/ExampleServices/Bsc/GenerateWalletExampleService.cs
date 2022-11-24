using Tatum.CSharp.Core.Model;
using Tatum.CSharp.Bsc.Clients;

namespace Tatum.CSharp.Demo.ExampleServices.Bsc;

public class GenerateWalletExampleService
{
    private readonly IBscClient _bscClient;

    public GenerateWalletExampleService(IBscClient bscClient)
    {
        _bscClient = bscClient;
    }
    
    public Wallet GenerateWallet()
    {
        Wallet wallet = _bscClient.Local.GenerateWallet();
        
        return wallet;
    }
}