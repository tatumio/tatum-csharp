# [Tatum C# SDK](http://tatum.com/)

[![Build](https://github.com/tatumio/tatum-csharp/actions/workflows/build.yml/badge.svg?branch=main)](https://github.com/tatumio/tatum-csharp/actions/workflows/build.yml)
<a href="https://www.nuget.org/packages/Tatum"><img alt="Nuget" src="https://buildstats.info/nuget/Tatum"></a>

## Quick Start

1. Include tatum package in your project:

   `dotnet add ${your_project} package Tatum`

2. Register Tatum Client in the DI container by calling `IServiceCollection` method `AddTatumSdk`:

```cs
// In Program.cs or Startup.cs
builder.Services.AddTatumSdk(Network.Testnet);
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

## Documentation

Please find SDK related documentation [here](https://docs.tatum.com/).

## Debug Mode

If there ever is a need to see what is going on under the hood you can use the Debug Mode to output underlying `request curl` and `response content` to the `Debug` console.

To use debug mode simply register Tatum SDK like this:

```cs
// In Program.cs or Startup.cs
builder.Services.AddTatumSdkWithDebug(Network.Testnet);
```

or if using simple init:

```cs
var tatumSdk = TatumSdk.Init(Network.Testnet, apiKey, config => config.EnableDebugMode = true);
```

## Further Examples

[Demo App (.NET API)](Tatum.Demo)

- [Examples - Notifications](Tatum.Examples/Notifications/Examples/Subscribe.cs)

## Troubleshooting

Should you face any issues, feel free to contribute to our troubleshooting process by forking the SDK and submitting pull requests for any changes. For reporting issues and tracking progress, create new issues within this GitHub repository.
