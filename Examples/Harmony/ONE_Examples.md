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

### How to generate Harmony wallet

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Harmony/GenerateWalletExampleService.cs)

### How to generate Harmony private key from mnemonic

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Harmony/GeneratePrivateKeyExampleService.cs)

### How to generate Harmony address from private key

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Harmony/GenerateAddressExampleService.cs)

### How to get balance of Harmony address

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Harmony/GetBalanceExampleService.cs)

### How to get Harmony transaction by hash

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Harmony/GetTransactionExampleService.cs)

### How to send Harmony from account to account

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Harmony/BlockchainTransferExampleService.cs)