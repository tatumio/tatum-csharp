using System.Threading.Tasks;
using Tatum.CSharp.Core.Model;
using Tatum.CSharp.Ethereum.Clients;

namespace Tatum.CSharp.Demo.ExampleServices.Ethereum;

public class GenerateAddressExampleService
{
    private readonly IEthereumClient _ethereumClient;

    public GenerateAddressExampleService(IEthereumClient ethereumClient)
    {
        _ethereumClient = ethereumClient;
    }
    
    public GeneratedAddressEth GenerateAddress(string xpub, int index)
    {
        //xpub = "xpub from your wallet"
        //index = index of the address you would like to generate
        
        GeneratedAddressEth address = _ethereumClient.Local.GenerateAddress(xpub, index);
     
        return address;
    }
}