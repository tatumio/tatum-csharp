# [Tatum C# SDK v2 - Unity](http://tatum.io/)

Tatum C# SDK v2 allows C# developers to interact with Tatum API. You can find API documentation at [API doc](https://tatum.io/apidoc).

## Package download

| Chain                     | Unity_Package                                                                                                                                  |
|---------------------------|------------------------------------------------------------------------------------------------------------------------------------------------|
|[`Ethereum`](Ethereum)|<a href="https://github.com/tatumio/tatum-csharp/suites/10352541366/artifacts/510148406">Download</a>|
|[`Ethereum`](Ethereum)|<a href="https://github.com/tatumio/tatum-csharp/suites/10352541366/artifacts/510148406">Download</a>|
|[`Polygon`](Polygon)|<a href="https://github.com/tatumio/tatum-csharp/suites/10352541366/artifacts/510148406">Download</a>|
|[`BSC`](Bsc)|<a href="https://github.com/tatumio/tatum-csharp/suites/10352541366/artifacts/510148406">Download</a>|
|[`Harmony`](Harmony)|<a href="https://github.com/tatumio/tatum-csharp/suites/10352541366/artifacts/510148406">Download</a>|
|[`Solana`](Solana)|<a href="https://github.com/tatumio/tatum-csharp/suites/10352541366/artifacts/510148406">Download</a>|

## Unity Quick Start
1. Go to your [Tatum Dashboard](https://dashboard.tatum.io) and grab one of API KEYs (MainNet or TestNet)
2. Download Package of interest from the table above.
3. Unpack the files.
4. Copy files to your Unity Assets folder.
5. Reload the project
6. In the .cs file where you want to call the Tatum API, import System.Net.Http:
```cs
using System.Net.Http;
```
7. Initialise a new HttpClient():
```cs
var httpClient = new HttpClient();
```
8. Initialize a Tatum client for the blockchain that you are using:
```cs
// Use new EthereumClient(httpClient, apiKey, true) if you are planning to use local functions targeted at testnet.
var ethereumClient = new EthereumClient(httpClient, apiKey, true);
```
9. You are ready to use the client. For example, get the balance of an Ethereum address:
```cs
var balance = await ethereumClient
.EthereumBlockchain
.EthGetBalanceAsync("0x8d12A197cB00D4747a1fe03395095ce2A5CC6819");
```

## Debug Mode

If there ever is a need to see what is going on under the hood you can use the Debug Mode to output `request curl` and `response content` to the `Debug` console.

**When contacting Tatum support providing those logs can help us identifying the issue faster.**

To use debug mode simply initialize HttpClient like below:
```cs
var httpClient = new DebugModeHandler();
httpClient.InnerHandler = new HttpClientHandler();
        
_client = new EthereumClient(new HttpClient(httpClient), apiKey, true);
```

## Further Usage Examples

- [Examples - ETH](Examples/Ethereum/ETH_Examples.md)
- [Examples - BTC](Examples/Bitcoin/BTC_Examples.md)
- [Examples - MATIC](Examples/Polygon/MATIC_Examples.md)
- [Examples - BSC](Examples/BSC/BSC_Examples.md)
- [Examples - ONE](Examples/Harmony/ONE_Examples.md)

Please check out [Demo App](Tatum.CSharp.Demo) or [Integration Tests](https://github.com/tatumio/tatum-csharp/tree/develop/Tatum.CSharp.Ethereum.Tests.Integration) to see the usage of all methods.
