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
## Examples:

|    | How to                                                                                                                                                                            |
|---|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|:moneybag:| [Generate Bsc wallet](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Bsc/GenerateWalletExampleService.cs)                        |
|:key:| [Generate Bsc private key from mnemonic](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Bsc/GeneratePrivateKeyExampleService.cs) |
|:mailbox_with_mail:| [Generate Bsc address from private key](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Bsc/GenerateAddressExampleService.cs) |
|:dollar:| [Get balance of Bsc address](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Bsc/GetBalanceExampleService.cs)                |
|:scroll:| [Get Bsc transaction by hash](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Bsc/GetTransactionExampleService.cs)           |
|:outbox_tray:| [Send Bsc from account to account](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Bsc/BlockchainTransferExampleService.cs)  |


## Scenarios:

### `NFT` > [**Mint** with NFT Express](https://github.com/tatumio/tatum-csharp/blob/master/Bsc/Tatum.CSharp.Bsc.Tests.Integration/Scenarios/MintNftBasic.cs)

### `NFT` > [**Mint** natively on a blockchain](https://github.com/tatumio/tatum-csharp/blob/master/Bsc/Tatum.CSharp.Bsc.Tests.Integration/Scenarios/MintNftNative.cs)

### `ERC-20` > [**Mint & Transfer** tokens](https://github.com/tatumio/tatum-csharp/blob/master/Bsc/Tatum.CSharp.Bsc.Tests.Integration/Scenarios/MintErc20AndTransfer.cs)