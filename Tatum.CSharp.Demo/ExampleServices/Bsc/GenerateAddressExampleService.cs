using Tatum.CSharp.Core.Model;
using Tatum.CSharp.Bsc.Clients;

namespace Tatum.CSharp.Demo.ExampleServices.Bsc;

public class GenerateAddressExampleService
{
    private readonly IBscClient _bscClient;

    public GenerateAddressExampleService(IBscClient bscClient)
    {
        _bscClient = bscClient;
    }
    
    public GeneratedAddressEth GenerateAddress(string xpub, int index)
    {
        //xpub = "xpub from your wallet"
        //index = index of the address you would like to generate
        
        GeneratedAddressEth address = _bscClient.Local.GenerateAddress(xpub, index);
     
        return address;
    }
}