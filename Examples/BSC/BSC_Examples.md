# How to use Tatum.CSharp.Bsc with .NET 6 API project

## How to start

Add Tatum.CSharp.Bsc to your project

```bash
dotnet add package Tatum.CSharp.Bsc
```

Register BscClient in the DI Container

```csharp
builder.Services
    .AddHttpClient<IBscClient, BscClient>(httpClient => new BscClient(httpClient, apiKey));
```

Inject IBscClient into your service

```csharp
public class BscController : ControllerBase
{
    private readonly IBscClient _ethereumClient;

    public BscController(IBscClient ethereumClient)
    {
        _ethereumClient = ethereumClient;
    }
}
```

### How to generate BSC wallet

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Bsc/GenerateWalletExampleService.cs)

### How to generate BSC private key from mnemonic

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Bsc/GeneratePrivateKeyExampleService.cs)

### How to generate BSC address from private key

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Bsc/GenerateAddressExampleService.cs)

### How to get balance of BSC address

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Bsc/GetBalanceExampleService.cs)

### How to get BSC transaction by hash

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Bsc/GetTransactionExampleService.cs)

### How to send BSC from account to account

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Bsc/BlockchainTransferExampleService.cs)