# How to use Tatum.CSharp.Harmony with .NET 6 API project

## How to start

Add Tatum.CSharp.Harmony to your project

```bash
dotnet add package Tatum.CSharp.Harmony
```

Register HarmonyClient in the DI Container

```csharp
builder.Services
    .AddHttpClient<IHarmonyClient, HarmonyClient>(httpClient => new HarmonyClient(httpClient, apiKey));
```

Inject IHarmonyClient into your service

```csharp
public class HarmonyController : ControllerBase
{
    private readonly IHarmonyClient _HarmonyClient;

    public HarmonyController(IHarmonyClient HarmonyClient)
    {
        _HarmonyClient = HarmonyClient;
    }
}
```
## Examples:

|    | How to                                                                                                                                                                            |
|---|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|:moneybag:| [Generate Harmony wallet](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Harmony/GenerateWalletExampleService.cs)                        |
|:key:| [Generate Harmony private key from mnemonic](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Harmony/GeneratePrivateKeyExampleService.cs) |
|:mailbox_with_mail:| [Generate Harmony address from private key](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Harmony/GenerateAddressExampleService.cs) |
|:dollar:| [Get balance of Harmony address](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Harmony/GetBalanceExampleService.cs)                |
|:scroll:| [Get Harmony transaction by hash](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Harmony/GetTransactionExampleService.cs)           |
|:outbox_tray:| [Send Harmony from account to account](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Harmony/BlockchainTransferExampleService.cs)  |


## Scenarios:

### `NFT` > [**Mint** with NFT Express](https://github.com/tatumio/tatum-csharp/blob/master/Harmony/Tatum.CSharp.Harmony.Tests.Integration/Scenarios/MintNftBasic.cs)

### `NFT` > [**Mint** natively on a blockchain](https://github.com/tatumio/tatum-csharp/blob/master/Harmony/Tatum.CSharp.Harmony.Tests.Integration/Scenarios/MintNftNative.cs)

### `ERC-20` > [**Mint & Transfer** tokens](https://github.com/tatumio/tatum-csharp/blob/master/Harmony/Tatum.CSharp.Harmony.Tests.Integration/Scenarios/MintErc20AndTransfer.cs)