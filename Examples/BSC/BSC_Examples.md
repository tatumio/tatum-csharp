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
    private readonly IBscClient _BscClient;

    public BscController(IBscClient BscClient)
    {
        _BscClient = BscClient;
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

## Scenarios:

### How to **Mint NFT** with NFT Express

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Bsc/Tatum.CSharp.Bsc.Tests.Integration/Scenarios/MintNftBasic.cs)

### How to **Mint NFT** natively on a blockchain

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Bsc/Tatum.CSharp.Bsc.Tests.Integration/Scenarios/MintNftNative.cs)

### How to **Mint & Transfer ERC20** tokens

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Bsc/Tatum.CSharp.Bsc.Tests.Integration/Scenarios/MintErc20AndTransfer.cs)