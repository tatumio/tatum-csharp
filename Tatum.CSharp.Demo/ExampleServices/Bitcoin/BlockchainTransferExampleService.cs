using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Tatum.CSharp.Bitcoin.Clients;
using Tatum.CSharp.Bitcoin.Core.Model;

namespace Tatum.CSharp.Demo.ExampleServices.Bitcoin;

public class BlockchainTransferExampleService
{
    private readonly IBitcoinClient _bitcoinClient;

    public BlockchainTransferExampleService(IBitcoinClient bitcoinClient)
    {
        _bitcoinClient = bitcoinClient;
    }
    
    private readonly Dictionary<string, string> _someInternalPersistence = new Dictionary<string, string>()
    {
        { "address1", "privateKey1" },
        { "address2", "privateKey2" },
        { "address3", "privateKey3" }
    };
    
    public async Task<TransactionHash> BlockchainTransfer(string fromAddress, string toAddress, string amount)
    {
        var fee = 0.0001m;
        var amountToSend = decimal.Parse(amount, CultureInfo.InvariantCulture);
        
        // We need to calculate the change after sending the amount so first we check the balance of address with below.
        var balance = await _bitcoinClient.BitcoinBlockchain.BtcGetBalanceOfAddressAsync(fromAddress);

        // We calculate how much unspent coins we have.
        var unspentCoins = decimal.Parse(balance.Incoming, CultureInfo.InvariantCulture)
                           - decimal.Parse(balance.Outgoing, CultureInfo.InvariantCulture);

        // Then we calculate change amount by subtracting the amount we want to send and the fee.
        var changeAmount = 
            unspentCoins
            - amountToSend
            - fee;
        
        // Need to know the private key of the address that is sending the amount.
        // In this example, we are using a dictionary to store the private keys.
        // In a real world scenario, you would store the private keys in a secure location.
        var fromPrivKey = _someInternalPersistence[fromAddress];
        
        var transfer = new BtcTransactionFromAddress(
                new List<BtcTransactionFromAddressSource>()
                {
                    new BtcTransactionFromAddressSource(fromAddress, fromPrivKey)
                },
                new List<BtcTransactionFromAddressTarget>()
                {
                    new BtcTransactionFromAddressTarget(toAddress, amountToSend),
                    new BtcTransactionFromAddressTarget(fromAddress, changeAmount)
                });


        TransactionHash transactionHash = await _bitcoinClient.BitcoinBlockchain.BtcTransferBlockchainAsync(transfer);
        
        return transactionHash;
    }
}