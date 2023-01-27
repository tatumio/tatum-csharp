using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.CSharp.Ethereum.Clients;
using Tatum.CSharp.Ethereum.Core.Model;

namespace Tatum.CSharp.Demo.ExampleServices.Ethereum;

public class BlockchainTransferExampleService
{
    private readonly IEthereumClient _ethereumClient;

    public BlockchainTransferExampleService(IEthereumClient ethereumClient)
    {
        _ethereumClient = ethereumClient;
    }

    private readonly Dictionary<string, string> _someInternalPersistence = new Dictionary<string, string>()
    {
        { "address1", "privateKey1" },
        { "address2", "privateKey2" },
        { "address3", "privateKey3" }
    };
    
    public async Task<TransactionHash> BlockchainTransfer(string fromAddress, string toAddress, string amount)
    {
        // Need to know the private key of the address that is sending the amount.
        // In this example, we are using a dictionary to store the private keys.
        // In a real world scenario, you would store the private keys in a secure location.
        var fromPrivKey = _someInternalPersistence[fromAddress];

        var transfer = new TransferEthBlockchain(
            toAddress, // address you would like to send to
            amount, // amount you would like to send eg. "0.00001"
            Erc20Currency.ETH,
            fromPrivKey);
        
        TransactionHash transactionHash = await _ethereumClient.EthereumBlockchain.EthBlockchainTransferAsync(transfer);
        
        return transactionHash;
    }
}