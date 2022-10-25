using Tatum.CSharp.Bitcoin.Clients;
using Tatum.CSharp.Core.Model;

namespace Tatum.CSharp.Demo.ExampleServices.Bitcoin;

public class GeneratePrivateKeyExampleService
{
    private readonly IBitcoinClient _bitcoinClient;

    public GeneratePrivateKeyExampleService(IBitcoinClient bitcoinClient)
    {
        _bitcoinClient = bitcoinClient;
    }
    
    public PrivKey GeneratePrivateKey(PrivKeyRequest request)
    {
        //request.Mnemonic = "mnemonic from your wallet"
        //request.Index = index of the private key you would like to generate
        
        PrivKey privateKey = _bitcoinClient.Local.GenerateAddressPrivateKey(request);
        
        return privateKey;
    }
}