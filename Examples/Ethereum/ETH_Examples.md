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

### How to generate Ethereum wallet

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Ethereum/GenerateWalletExampleService.cs)

### How to generate Ethereum private key from mnemonic

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Ethereum/GeneratePrivateKeyExampleService.cs)

### How to generate Ethereum address from private key

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Ethereum/GenerateAddressExampleService.cs)

### How to get balance of Ethereum address

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Ethereum/GetBalanceExampleService.cs)

### How to get Ethereum transaction by hash

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Ethereum/GetTransactionExampleService.cs)

### How to send Ethereum from account to account

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Tatum.CSharp.Demo/ExampleServices/Ethereum/BlockchainTransferExampleService.cs)

## Scenarios:

### How to **Mint NFT** with NFT Express

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Ethereum/Tatum.CSharp.Ethereum.Tests.Integration/Scenarios/MintNftBasic.cs)

### How to **Mint NFT** natively on a blockchain

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Ethereum/Tatum.CSharp.Ethereum.Tests.Integration/Scenarios/MintNftNative.cs)

### How to **Mint & Transfer ERC20** tokens

Check example [here](https://github.com/tatumio/tatum-csharp/blob/master/Ethereum/Tatum.CSharp.Ethereum.Tests.Integration/Scenarios/MintErc20AndTransfer.cs)