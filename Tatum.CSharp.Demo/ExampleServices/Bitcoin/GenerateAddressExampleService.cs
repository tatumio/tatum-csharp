using System.Threading.Tasks;
using Tatum.CSharp.Bitcoin.Clients;
using Tatum.CSharp.Core.Model;

namespace Tatum.CSharp.Demo.ExampleServices.Bitcoin;

public class GenerateAddressExampleService
{
    private readonly IBitcoinClient _bitcoinClient;

    public GenerateAddressExampleService(IBitcoinClient bitcoinClient)
    {
        _bitcoinClient = bitcoinClient;
    }
    
    public async Task<GeneratedAddressBtc> GenerateAddress(string xpub, int index)
    {
        //xpub = "xpub from your wallet"
        //index = index of the address you would like to generate
        
        GeneratedAddressBtc address = await _bitcoinClient.BitcoinBlockchain.BtcGenerateAddressAsync(xpub, index);
     
        return address;
    }
}