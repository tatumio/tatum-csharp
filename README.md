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
You can link this library as a standard [Nuget](https://www.nuget.org/packages/TatumCS/) package as described in the [documentation](https://docs.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio).

## Clients Usage
The only classes/interfaces used by the end user are those with suffix `Client` eg. `BitcoinClient`, `EthereumClient`, `LedgerClient`. They are located in [Clients](https://github.com/tatumio/tatum-csharp/Tatum/Clients) folder of the Tatum project. 

Before 
There are 2 basic ways, how to use Clients.
### Direct usage via Create Factory method
First you need to add `Tatum` namespace.  
```C#
using Tatum;
using Tatum.Model;
```  
Then just call `CreateWallet()` method 
```C#
BitcoinClient client = new BitcoinClient("your-x-api-key")

```  

where typically `string baseUrl = "https://api-eu1.tatum.io";`.  
Of course you should store your credentials securely eg. in environment variable or configuration file.  
Then you can call all the methods available for the `Client`. You can find examples of this approach in [Tests project](https://github.com/tatumio/tatum-csharp/tree/master/src/Tatum.Tests).




## Contributing

Contributions to the Tatum API client are welcome. Please ensure
that you have tested the changes with a local client and have added unit test
coverage for your code.
