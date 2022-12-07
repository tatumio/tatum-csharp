using Tatum.CSharp.Ethereum.Clients;
using Tatum.CSharp.Evm.Local.Models;

namespace Tatum.CSharp.Demo.ExampleServices.Ethereum;

public class GenerateAddressExampleService
{
    private readonly IEthereumClient _ethereumClient;

    public GenerateAddressExampleService(IEthereumClient ethereumClient)
    {
        _ethereumClient = ethereumClient;
    }
    
    public GeneratedAddressEthLocal GenerateAddress(string xpub, int index)
    {
        //xpub = "xpub from your wallet"
        //index = index of the address you would like to generate
        
        GeneratedAddressEthLocal address = _ethereumClient.Local.GenerateAddress(xpub, index);
     
        return address;
    }
}