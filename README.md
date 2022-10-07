# [Tatum C# SDK v2](http://tatum.io/) &middot; [![CI](https://github.com/tatumio/tatum-csharp/actions/workflows/dotnet.yml/badge.svg?branch=develop)](https://github.com/tatumio/tatum-csharp/actions/workflows/dotnet.yml)

Tatum C# SDK v2 allows C# developers to interact with Tatum API. It includes the following core components.

- **blockchain** - cryptographic functions like generation of wallets, private keys or addresses.
- **local** - set of functions for local generation of wallets, priveate keys and addressed. It also allows for signing blockchain transactions locally.

You can find API documentation at [API doc](https://tatum.io/apidoc).

## Included Chains

[`Ethereum`](Tatum.CSharp.Ethereum/)

## Quick Start

1. Include blockchain package in your project:

   `dotnet add ${your_project} package Tatum.CSharp.Ethereum`

2. Go to your [Tatum Dashboard](https://dashboard.tatum.io) and grab one of API KEYs (mainnet or testnet)

3. Register Tatum Client in the DI container by calling `IServiceCollection` method `AddHttpClient`:

```cs
// In Program.cs or Startup.cs

// Use new EthereumClient(httpClient, apiKey, true) if you are planning to use local functions targetted at testnet.
builder.Services
    .AddHttpClient<IEthereumClient, EthereumClient>(httpClient => new EthereumClient(httpClient, apiKey));
```
4. Inject Tatum Client to the class of you choice:

```cs
// EthereumController.cs
private readonly IEthereumClient _ethereumClient;

public EthereumController(IEthereumClient ethereumClient)
{
    _ethereumClient = ethereumClient;
}
```

5. You are ready to use Tatum API :smiley:

