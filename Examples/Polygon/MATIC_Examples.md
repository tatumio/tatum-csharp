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

### How to generate Polygon wallet

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Polygon/GenerateWalletExampleService.cs)

### How to generate Polygon private key from mnemonic

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Polygon/GeneratePrivateKeyExampleService.cs)

### How to generate Polygon address from private key

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Polygon/GenerateAddressExampleService.cs)

### How to get balance of Polygon address

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Polygon/GetBalanceExampleService.cs)

### How to get Polygon transaction by hash

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Polygon/GetTransactionExampleService.cs)

### How to send Polygon from account to account

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Polygon/BlockchainTransferExampleService.cs)