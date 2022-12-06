
using Tatum.CSharp.Bitcoin.Clients;
using Tatum.CSharp.Bitcoin.Local.Models;
using Tatum.CSharp.Evm.Local.Models;

namespace Tatum.CSharp.Demo.ExampleServices.Bitcoin;

public class GeneratePrivateKeyExampleService
{
    private readonly IBitcoinClient _bitcoinClient;

    public GeneratePrivateKeyExampleService(IBitcoinClient bitcoinClient)
    {
        _bitcoinClient = bitcoinClient;
    }
    
    public PrivKeyLocal GeneratePrivateKey(PrivKeyRequestLocal request)
    {
        //request.Mnemonic = "mnemonic from your wallet"
        //request.Index = index of the private key you would like to generate
        
        PrivKeyLocal privateKey = _bitcoinClient.Local.GenerateAddressPrivateKey(request);
        
        return privateKey;
    }
}