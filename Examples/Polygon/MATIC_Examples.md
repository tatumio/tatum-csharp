# How to use Tatum.CSharp.Polygon with .NET 6 API project

## How to start

Add Tatum.CSharp.Polygon to your project

```bash
dotnet add package Tatum.CSharp.Polygon
```

Register PolygonClient in the DI Container

```csharp
builder.Services
    .AddHttpClient<IPolygonClient, PolygonClient>(httpClient => new PolygonClient(httpClient, apiKey));
```

Inject IPolygonClient into your service

```csharp
public class PolygonController : ControllerBase
{
    private readonly IPolygonClient _polygonClient;

    public PolygonController(IPolygonClient polygonClient)
    {
        _polygonClient = polygonClient;
    }
}
```
## Examples:

|    | How to                                                                                                                                                                            |
|---|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|:moneybag:| [Generate Polygon wallet](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Polygon/GenerateWalletExampleService.cs)                        |
|:key:| [Generate Polygon private key from mnemonic](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Polygon/GeneratePrivateKeyExampleService.cs) |
|:mailbox_with_mail:| [Generate Polygon address from private key](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Polygon/GenerateAddressExampleService.cs) |
|:dollar:| [Get balance of Polygon address](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Polygon/GetBalanceExampleService.cs)                |
|:scroll:| [Get Polygon transaction by hash](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Polygon/GetTransactionExampleService.cs)           |
|:outbox_tray:| [Send Polygon from account to account](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Polygon/BlockchainTransferExampleService.cs)  |


## Scenarios:

### `NFT` > [**Mint** with NFT Express](https://github.com/tatumio/tatum-csharp/blob/master/Polygon/Tatum.CSharp.Polygon.Tests.Integration/Scenarios/MintNftBasic.cs)

### `NFT` > [**Mint** natively on a blockchain](https://github.com/tatumio/tatum-csharp/blob/master/Polygon/Tatum.CSharp.Polygon.Tests.Integration/Scenarios/MintNftNative.cs)

### `ERC-20` > [**Mint & Transfer** tokens](https://github.com/tatumio/tatum-csharp/blob/master/Polygon/Tatum.CSharp.Polygon.Tests.Integration/Scenarios/MintErc20AndTransfer.cs)