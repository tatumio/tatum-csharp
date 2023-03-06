# [Tatum C# SDK](http://tatum.com/)

[![Build](https://github.com/tatumio/tatum-csharp/actions/workflows/build.yml/badge.svg?branch=v3)](https://github.com/tatumio/tatum-csharp/actions/workflows/build.yml)

## Quick Start

1. Include tatum package in your project:


   `dotnet add ${your_project} package Tatum`


2. Register Tatum Client in the DI container by calling `IServiceCollection` method `AddHttpClient`:

```cs
// In Program.cs or Startup.cs
builder.Services.AddTatumSdk(Network.Testnet, apiKey);
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
```cs
var allNotificationsResult = await _tatumSdk.Notifications.GetAll();
```

## Debug Mode

If there ever is a need to see what is going on under the hood you can use the Debug Mode to output underlying `request curl` and `response content` to the `Debug` console.

**When contacting Tatum support providing those logs can help us identifying the issue faster.**

To use debug mode simply register Tatum SDK like this:
```cs
// In Program.cs or Startup.cs
builder.Services.AddTatumSdkWithDebug(Network.Testnet, apiKey);
```

or if using simple init:
```cs
var tatumSdk = TatumSdk.Init(true, apiKey, config => config.EnableDebugMode = true);
```

## Further Examples

[Demo App (.NET API)](Tatum.Demo)

- [Examples - Notifications](Tatum.Examples/Notifications/TatumNotifications.cs)
