# How to use Tatum.CSharp.Ethereum with .NET 6 API project

## How to start

Add Tatum.CSharp.Ethereum to your project

```bash
dotnet add package Tatum.CSharp.Ethereum
```

Register EthereumClient in the DI Container

```csharp
builder.Services
    .AddHttpClient<IEthereumClient, EthereumClient>(httpClient => new EthereumClient(httpClient, apiKey));
```

Inject IEthereumClient into your service

```csharp
public class EthereumController : ControllerBase
{
    private readonly IEthereumClient _ethereumClient;

    public EthereumController(IEthereumClient ethereumClient)
    {
        _ethereumClient = ethereumClient;
    }
}
```
## Examples:

|    | How to                                                                                                                                                                            |
|---|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|:moneybag:| [Generate Ethereum wallet](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Ethereum/GenerateWalletExampleService.cs)                        |
|:key:| [Generate Ethereum private key from mnemonic](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Ethereum/GeneratePrivateKeyExampleService.cs) |
|:incoming_envelope:| [Generate Ethereum address from private key](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Ethereum/GenerateAddressExampleService.cs) |
|:dollar:| [Get balance of Ethereum address](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Ethereum/GetBalanceExampleService.cs)                |
|:scroll:| [Get Ethereum transaction by hash](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Ethereum/GetTransactionExampleService.cs)           |
|:outbox_tray:| [Send Ethereum from account to account](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Ethereum/BlockchainTransferExampleService.cs)  |


## Scenarios:

### `NFT` > [**Mint** with NFT Express](https://github.com/tatumio/tatum-csharp/blob/master/Ethereum/Tatum.CSharp.Ethereum.Tests.Integration/Scenarios/MintNftBasic.cs)

### `NFT` > [**Mint** natively on a blockchain](https://github.com/tatumio/tatum-csharp/blob/master/Ethereum/Tatum.CSharp.Ethereum.Tests.Integration/Scenarios/MintNftNative.cs)

### `ERC-20` > [**Mint & Transfer** tokens](https://github.com/tatumio/tatum-csharp/blob/master/Ethereum/Tatum.CSharp.Ethereum.Tests.Integration/Scenarios/MintErc20AndTransfer.cs)