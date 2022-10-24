# How to use Tatum.CSharp.Bitcoin with .NET 6 API project

## How to start

Add Tatum.CSharp.Bitcoin to your project

```bash
dotnet add package Tatum.CSharp.Bitcoin
```

Register BitcoinClient in the DI Container

```csharp
builder.Services
    .AddHttpClient<IBitcoinClient, BitcoinClient>(httpClient => new BitcoinClient(httpClient, apiKey));
```

Inject IBitcoinClient into your service

```csharp
public class BitcoinController : ControllerBase
{
    private readonly IBitcoinClient _BitcoinClient;

    public BitcoinController(IBitcoinClient BitcoinClient)
    {
        _BitcoinClient = BitcoinClient;
    }
}
```

### How to generate Bitcoin wallet

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/Controllers/BitcoinController.cs#L24)

### How to generate Bitcoin private key from mnemonic

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/Controllers/BitcoinController.cs#L35)


### How to generate Bitcoin address from private key

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/Controllers/BitcoinController.cs#L46)

### How to get balance of Bitcoin address

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/Controllers/BitcoinController.cs#L54)

### How to get Bitcoin transactions by address

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/Controllers/BitcoinController.cs#L62)

### How to send Bitcoin from account to account

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/Controllers/BitcoinController.cs#L110)

