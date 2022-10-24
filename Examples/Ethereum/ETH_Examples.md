# How to use Tatum.CSharp.Ethereum with .NET 6 API project

## How to start

Add Tatum.CSharp.Ethereum to your project

```bash
dotnet add package Tatum.CSharp.Ethereum
```

Register EthereumClient in the DI Container

```csharp
builder.Services
    .AddHttpClient<IEthereumClient, EthereumClient>(httpClient => new EthereumClient(httpClient, apiKey));
```

Inject IEthereumClient into your service

```csharp
public class EthereumController : ControllerBase
{
    private readonly IEthereumClient _ethereumClient;

    public EthereumController(IEthereumClient ethereumClient)
    {
        _ethereumClient = ethereumClient;
    }
}
```

### How to generate Ethereum wallet

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/Controllers/EthereumController.cs#L21)

### How to generate Ethereum private key from mnemonic

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/Controllers/EthereumController.cs#L32)


### How to generate Ethereum address from private key

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/Controllers/EthereumController.cs#L43)

### How to get balance of Ethereum address

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/Controllers/EthereumController.cs#L51)

### How to get Ethereum transaction by hash

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/Controllers/EthereumController.cs#L59)

### How to send Ethereum from account to account

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/Controllers/EthereumController.cs#L88)

