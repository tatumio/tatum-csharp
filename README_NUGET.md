# [Tatum C# SDK](http://tatum.com/)

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

**When contacting Tatum support providing those logs can help us identifying the issue faster.**

To use debug mode simply register Tatum SDK like this:

```cs
// In Program.cs or Startup.cs
builder.Services.AddTatumSdkWithDebug(Network.Testnet);
```

or if using simple init:

```cs
var tatumSdk = TatumSdk.Init(Network.Testnet, apiKey, config => config.EnableDebugMode = true);
```