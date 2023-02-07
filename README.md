# [Tatum C# SDK v3](http://tatum.com/)

![badge](https://img.shields.io/endpoint?url=https://gist.githubusercontent.com/Smrecz/7c96c30e8017c8dfb57b88e323f8114b/raw/csharp-sdk-test-summary.json)
[![Build](https://github.com/tatumio/tatum-csharp/actions/workflows/build.yml/badge.svg?branch=v3)](https://github.com/tatumio/tatum-csharp/actions/workflows/build.yml)

Tatum C# SDK v3 allows C# developers to use Tatum to interact with blockchains in various ways.

> **Are you looking for Tatum.CSharp SDK v2? It has been moved to [`Tatum.CSharp SDK V2`](https://github.com/tatumio/tatum-csharp/tree/v2)**.

> **Are you looking for Tatum.CSharp SDK v1? It has been moved to [`Tatum.CSharp SDK V1`](https://github.com/tatumio/tatum-csharp/tree/v1)**.

## Quick Start

1. Include tatum package in your project:

   `dotnet add ${your_project} package Tatum.CSharp`

2. Register Tatum Client in the DI container by calling `IServiceCollection` method `AddHttpClient`:

```cs
// In Program.cs or Startup.cs

builder.Services
    .AddHttpClient<ITatum, Tatum>(httpClient => new Tatum(httpClient, apiKey));
```
3. Inject Tatum Client to the class of your choice:

```cs
// EthereumController.cs
private readonly ITatum _tatum;

public EthereumController(ITatum tatum)
{
    _tatum = tatum;
}
```

4. You are ready to use Tatum API!

## Debug Mode

If there ever is a need to see what is going on under the hood you can use the Debug Mode to output `request curl` and `response content` to the `Debug` console.

**When contacting Tatum support providing those logs can help us identifying the issue faster.**

To use debug mode simply add this handler when registering Tatum Client:
```cs
// In Program.cs or Startup.cs
builder.Services
    .AddSingleton<DebugModeHandler>();

builder.Services
    .AddHttpClient<ITatum, Tatum>(httpClient => new Tatum(httpClient, apiKey))
    .AddHttpMessageHandler<DebugModeHandler>();
```

or if using HttpClient directly:
```cs
var httpClient = new DebugModeHandler();
httpClient.InnerHandler = new HttpClientHandler();
        
_client = new Tatum(new HttpClient(httpClient), apiKey);
```

## Further Examples

- [Examples - Notifications](Examples/Notifications/TatumNotifications.cs)
- [Examples - FeeEstimations](Examples/Notifications/TatumFeeEstimations.cs)
- [Examples - Nft](Examples/Notifications/TatumNft.cs)
