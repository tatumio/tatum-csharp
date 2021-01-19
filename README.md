![Tatum Icon](https://github.com/tatumio/tatum-csharp/blob/master/src/Tatum/tatum_icon.jpg)
# Tatum C#
This library simplifies usage of [Tatum](https://docs.tatum.io/) blockchain developer platform from C# applications. It allows you to call [Tatum API](https://tatum.io/apidoc) endpoints directly as methods from code. Library also validates inputs before calling the API, so you won't waste resources and credits. All operations that require sensitive data are performed locally, so no private keys are sent anywhere.  
C# Library is inspired by [Tatum JS library](https://github.com/tatumio/tatum-js) and it's divided into the same logical parts. It includes the following core components.  
- **wallet** - cryptographic functions like generation of wallets, private keys or addresses.
- **blockchain** - set of API calls to communicate with different blockchains via <a href="https://tatum.io" target="_blank">Tatum API</a>.
- **ledger** - set of API calls to communicate with Tatum Private Ledger via <a href="https://tatum.io" target="_blank">Tatum API</a>.
- **transaction** - set of functions to generate and sign blockchain transactions locally.
- **offchain** - set of functions to generate and sign Tatum off-chain transactions locally.


## Tatum API Credentials
Before you start you need to get Tatum API Key. If you don't have any yet, follow [Tatum docs](https://docs.tatum.io/your-first-app#1-get-your-api-key).

## Installation
![Tatum Nuget version](https://img.shields.io/nuget/v/Tatum.svg)  ![Tatum Nuget downloads](https://img.shields.io/nuget/dt/Tatum.svg)  
You can link this library as a standard [Nuget](https://www.nuget.org/packages/Tatum) package as described in the [documentation](https://docs.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio).

## Clients Usage
The only classes/interfaces used by the end user are those with suffix `Client` eg. `IBitcoinClient`, `IEthereumClient`, `ITatumClient`. They are located in [Clients](https://github.com/tatumio/tatum-csharp/tree/master/src/Tatum/Clients) folder of the Tatum project. The only client not related to specific cryptocurrency/blockchain is the `ITatumClient`. `ITatumClient` enables to call Tatum API endpoints not related to the specific cryptocurency/blockchain.

Before 
There are 2 basic ways, how to use Clients.
### Direct usage via Create Factory method
First you need to add `Tatum.Clients` namespace.  
```C#
using Tatum.Clients;
```  
Then just call `Create()` method 
```C#
var bitcoinClient = BitcoinClient.Create(baseUrl, "your-x-api-key");
```  
or  
```C#
IBitcoinClient bitcoinClient = BitcoinClient.Create(baseUrl, "your-x-api-key");
```
where typically `string baseUrl = "https://api-eu1.tatum.io";`.  
Of course you should store your credentials securely eg. in environment path or configuration file.  
Then you can call all the methods available for the `Client`. You can find examples of this approach in [Tests project](https://github.com/tatumio/tatum-csharp/tree/master/src/Tatum.Tests).

### Usage via Dependency Injection
There is also `IServiceCollection` extension method [`AddTatum(...)`](https://github.com/tatumio/tatum-csharp/blob/master/src/Tatum/ServiceCollectionExtensions.cs) for comfortable usage of .NET Core built in Dependency Injection (DI) container. You can read more about DI in [.NET docs](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection).
If we follow the DI example from .NET docs, you can add all the Clients into DI like that.
```C#
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tatum;

namespace DependencyInjection.Example
{
    class Program
    {
        static Task Main(string[] args) =>
            CreateHostBuilder(args).Build().RunAsync();

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddHostedService<Worker>()
                            .AddTatum("https://api-eu1.tatum.io", "your-x-api-key"));
    }
}
```
Then you can inject arbitrary client into your `Worker` service.
```C#
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Tatum.Clients;

namespace DependencyInjection.Example
{
    public class Worker : BackgroundService
    {
        private readonly IBitcoinClient bitcoinClient;

        public Worker(IBitcoinClient bitcoinClient) =>
            this.bitcoinClient = bitcoinClient;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var info = await bitcoinClient.GetBlockchainInfo();
        }
    }
}
```

## Wallet Static methods
As in case of [Tatum JS library](https://github.com/tatumio/tatum-js) this library also provides static methods generating Wallet, Private Key and Address. You can find them in the [Wallet class](https://github.com/tatumio/tatum-csharp/blob/master/src/Tatum/Wallet/Wallet.cs). They could be used as follows.
```C#
var wallet = Wallet.Create(Currency.BTC, mnemonic, testnet: true);
var address = Wallet.GenerateAddress(Currency.ETH, mnemonic, index: 1, testnet: true);
var privateKey = Wallet.GeneratePrivateKey(Currency.LTC, mnemonic, index: 1, testnet: true);
```

## Contributing

Contributions to the Tatum API client are welcome. Please ensure
that you have tested the changes with a local client and have added unit test
coverage for your code.
