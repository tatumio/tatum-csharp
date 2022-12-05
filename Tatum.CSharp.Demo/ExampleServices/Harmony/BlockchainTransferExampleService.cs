using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.CSharp.Harmony.Clients;
using Tatum.CSharp.Harmony.Core.Model;

namespace Tatum.CSharp.Demo.ExampleServices.Harmony;

public class BlockchainTransferExampleService
{
    private readonly IHarmonyClient _harmonyClient;

    public BlockchainTransferExampleService(IHarmonyClient harmonyClient)
    {
        _harmonyClient = harmonyClient;
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

        var transfer = new TransferOneBlockchain(
            null,
            TransferOneBlockchain.CurrencyEnum.ONE,
            0,
            toAddress, // address you would like to send to
            null,
            amount, // amount you would like to send eg. "0.00001"
            fromPrivKey);


        TransactionHash transactionHash = await _harmonyClient.HarmonyBlockchain.OneBlockchainTransferAsync(transfer);
        
        return transactionHash;
    }
}