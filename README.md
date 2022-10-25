# [Tatum C# SDK v2](http://tatum.io/)
[![RC Version](https://github.com/tatumio/tatum-csharp/actions/workflows/dotnet.yml/badge.svg?branch=develop)](https://github.com/tatumio/tatum-csharp/actions/workflows/dotnet.yml) </br>
[![Tatum.CSharp Post Release Tests](https://github.com/tatumio/tatum-csharp/actions/workflows/postRelease.yml/badge.svg)](https://github.com/tatumio/tatum-csharp/actions/workflows/postRelease.yml)

Tatum C# SDK v2 allows C# developers to interact with Tatum API. It includes the following core components:

- **blockchain** - set of API calls to communicate with different blockchains via <a href="https://tatum.io" target="_blank">Tatum API</a>.
- **local** - set of functions for local generation of wallets, private keys and addressed. It also allows for signing blockchain transactions locally.

You can find API documentation at [API doc](https://tatum.io/apidoc).

> **Are you looking for Tatum.CSharp SDK v1? It has been moved to long living branch [`Tatum.CSharp SDK V1`](https://github.com/tatumio/tatum-csharp/tree/v1)**.

## Included Chains

|  Chain | Nuget_Package | Local Processing with                            |
| ------------- |--------------------------|-----------|
| [`Bitcoin`](Tatum.CSharp.Bitcoin) | <a href="https://www.nuget.org/packages/Tatum.CSharp.Bitcoin"><img alt="Nuget" src="https://buildstats.info/nuget/Tatum.CSharp.Bitcoin"></a> | [NBitcoin](https://github.com/MetacoSA/NBitcoin) |
| [`Ethereum`](Tatum.CSharp.Ethereum) | <a href="https://www.nuget.org/packages/Tatum.CSharp.Ethereum"><img alt="Nuget" src="https://buildstats.info/nuget/Tatum.CSharp.Ethereum"></a> | [NEthereum](https://github.com/Nethereum/Nethereum) |

## Quick Start

1. Include blockchain package in your project:

   `dotnet add ${your_project} package Tatum.CSharp.Ethereum`

2. Go to your [Tatum Dashboard](https://dashboard.tatum.io) and grab one of API KEYs (MainNet or TestNet)

3. Register Tatum Client in the DI container by calling `IServiceCollection` method `AddHttpClient`:

```cs
// In Program.cs or Startup.cs

// Use new EthereumClient(httpClient, apiKey, true) if you are planning to use local functions targetted at testnet.
builder.Services
    .AddHttpClient<IEthereumClient, EthereumClient>(httpClient => new EthereumClient(httpClient, apiKey));
```
4. Inject Tatum Client to the class of your choice:

```cs
// EthereumController.cs
private readonly IEthereumClient _ethereumClient;

public EthereumController(IEthereumClient ethereumClient)
{
    _ethereumClient = ethereumClient;
}
```

5. You are ready to use Tatum API!

## Further Examples

- [Examples - ETH](Examples/Ethereum/ETH_Examples.md)
- [Examples - BTC](Examples/Bitcoin/BTC_Examples.md)

Please check out [Demo App](Tatum.CSharp.Demo) or [Integration Tests](https://github.com/tatumio/tatum-csharp/tree/develop/Tatum.CSharp.Ethereum.Tests.Integration) to see the usage of all methods.
