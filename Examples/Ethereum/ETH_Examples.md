# Ethereum - Example API Project

### Add Tatum.CSharp.Ethereum to your project

```bash
dotnet add package Tatum.CSharp.Ethereum
```

### Register EthereumClient in the DI Container

```csharp
builder.Services
    .AddHttpClient<IEthereumClient, EthereumClient>(httpClient => new EthereumClient(httpClient, apiKey));
```

### Inject IEthereumClient into your service

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

### Generate Ethereum wallet

```csharp   
 [HttpGet(Name = "GenerateWallet")]
 public async Task<Wallet> GenerateWallet()
 {
     Wallet wallet = await _ethereumClient.EthereumBlockchain.EthGenerateWalletAsync();
     
     return wallet;
 }
```