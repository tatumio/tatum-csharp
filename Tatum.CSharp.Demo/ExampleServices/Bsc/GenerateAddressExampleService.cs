using Tatum.CSharp.Bsc.Clients;
using Tatum.CSharp.Evm.Local.Models;

namespace Tatum.CSharp.Demo.ExampleServices.Bsc;

public class GenerateAddressExampleService
{
    private readonly IBscClient _bscClient;

    public GenerateAddressExampleService(IBscClient bscClient)
    {
        _bscClient = bscClient;
    }
    
    public GeneratedAddressEthLocal GenerateAddress(string xpub, int index)
    {
        //xpub = "xpub from your wallet"
        //index = index of the address you would like to generate
        
        GeneratedAddressEthLocal address = _bscClient.Local.GenerateAddress(xpub, index);
     
        return address;
    }
}