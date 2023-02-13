# [Tatum C# SDK v3](http://tatum.com/)

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
builder.Services.AddTatumSdk(true, apiKey);
```
3. Inject Tatum Client to the class of your choice:

```cs
// EthereumController.cs
private readonly ITatumSdk _tatumSdk;

public SomeController(ITatumSdk tatumSdk)
{
    _tatumSdk = tatumSdk;
}
```

4. You are ready to use Tatum API!

## Debug Mode

If there ever is a need to see what is going on under the hood you can use the Debug Mode to output `request curl` and `response content` to the `Debug` console.

**When contacting Tatum support providing those logs can help us identifying the issue faster.**

To use debug mode simply add this handler when registering Tatum Client:
```cs
// In Program.cs or Startup.cs
builder.Services.AddTatumSdkWithDebug(true, apiKey);
```

or if using HttpClient directly:
```cs
var debugModeHandler = new DebugModeHandler();
debugModeHandler.InnerHandler = new HttpClientHandler();

_tatumSdk = TatumSdk.Init(true, apiKey, new HttpClient(debugModeHandler));
```

## Further Examples

- [Examples - Notifications](Tatum.CSharp.Examples/Notifications/TatumNotifications.cs)
- [Examples - FeeEstimations](Tatum.CSharp.Examples/Fees/TatumFeeEstimations.cs)
- [Examples - Nft](Tatum.CSharp.Examples/Nft/TatumNft.cs)
